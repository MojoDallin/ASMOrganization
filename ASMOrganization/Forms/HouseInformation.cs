using System.Text.Json;
using ASMOrganization.NonForms;
using System.IO;
using System.ComponentModel;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
namespace ASMOrganization.Forms
{
    public partial class HouseInformation : Form
    {
        private readonly BindingList<House> houses = [];
        private readonly House house;
        private readonly string curTeachingArea;
        private readonly List<string> curMissionaries;
        public HouseInformation(BindingList<House> h, House h2)
        {
            InitializeComponent();
            missionaryHolder.RowStyles.Clear();
            houses = h;
            house = h2;
            curTeachingArea = house.TeachingArea;
            curMissionaries = [.. house.Missionaries]; // works apparently
            LoadData();
            missionaryHolder.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            missionaryHolder.Paint += (s, e) =>
            {
                using Pen pen = new(System.Drawing.Color.SlateGray, 4);
                Rectangle rect = new(0, 0, missionaryHolder.Size.Width, missionaryHolder.Size.Height);
                e.Graphics.DrawRectangle(pen, rect);
            };
        }

        private void CreateMissionaryButton(string missionary)
        {
            Button button = new()
            {
                Font = houseNameLabel.Font,
                Text = missionary,
                Anchor = houseNameLabel.Anchor,
                Height = (int)(houseNameLabel.Height * 1.5) // good height so text doesnt get cut off
            };
            button.Click += (s, e) =>
            {
                missionaryHolder.Controls.Remove(button);
                house.Missionaries.Remove(missionary);
            };
            missionaryHolder.Controls.Add(button);
        }
        private void LoadData()
        {
            houseNameLabel.Text = house.Name;
            houseIdLabel.Text = house.Id.ToString();
            houseXLabel.Text = house.Coordinates[0].ToString();
            houseYLabel.Text = house.Coordinates[1].ToString();
            houseTeachingAreaBox.Text = house.TeachingArea;
            foreach (string missionary in house.Missionaries)
                CreateMissionaryButton(missionary);
        }

        private void DeleteHouse(object sender, EventArgs e)
        {
            // double check just cause
            DialogResult result = MessageBox.Show("Are you sure you want to delete this house?",
                "Delete?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                houses.Remove(house);
                Close(); // house no longer exists so
            }
        }

        private void AddMissionary(object sender, EventArgs e)
        {
            BindingList<string> boundList = new(house.Missionaries); // binding so we can update it here
            EnterMissionaryName enterMissionaryName = new(boundList);
            enterMissionaryName.Show();
            boundList.ListChanged += (s, e) =>
                CreateMissionaryButton(house.Missionaries[e.NewIndex]);
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            if(curTeachingArea != houseTeachingAreaBox.Text || !curMissionaries.SequenceEqual(house.Missionaries)) // only save if either changed
            {
                string json = JsonSerializer.Serialize(houses, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("HousingData.json", json); // file WILL exist regardless so dont need to check
            }
        }

    }

    public partial class EnterMissionaryName : Form // this does not need to be its own file(s)
    {
        public EnterMissionaryName(BindingList<string> missionaryList)
        {
            Size = new(250, 140);
            BackColor = System.Drawing.Color.LightGray;
            Text = "Add Missionary";

            TextBox enterName = new()
            {
                PlaceholderText = "Enter Missionary Name...",
                Font = new("Sitka Banner", 9.749999f),
                Size = new(225, 60),
                Location = new(5, 9),
                TextAlign = HorizontalAlignment.Center,
            };

            Button add = new()
            {
                Text = "Add Missionary",
                Font = new("Sitka Banner", 18.75f, FontStyle.Italic),
                Size = new(225, 50),
                Location = new(5, 50),
                BackColor = System.Drawing.Color.SlateGray,
                ForeColor = System.Drawing.Color.White,
            };
            add.Click += (s, e) => {
                if(!string.IsNullOrEmpty(enterName.Text))
                {
                    missionaryList.Add(enterName.Text);
                }
            };
            Controls.Add(enterName);
            Controls.Add(add);
        }
    }
}
