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
        private readonly List<string> curTeachingAreas;
        private readonly BindingList<Missionary> flatMissionaries = [];
        public HouseInformation(BindingList<House> h, House h2)
        {
            InitializeComponent();
            missionaryHolder.RowStyles.Clear();
            houses = h;
            house = h2;
            curTeachingAreas = house.TeachingAreas;
            LoadData();
            missionaryHolder.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            missionaryHolder.Paint += (s, e) =>
            {
                using Pen pen = new(System.Drawing.Color.SlateGray, 4);
                Rectangle rect = new(0, 0, missionaryHolder.Size.Width, missionaryHolder.Size.Height);
                e.Graphics.DrawRectangle(pen, rect);
            };
        }

        private void CreateMissionaryButton(Missionary missionary)
        {
            Button button = new()
            {
                Font = houseNameLabel.Font,
                Text = missionary.Name,
                Anchor = houseNameLabel.Anchor,
                Height = (int)(houseNameLabel.Height * 1.5) // good height so text doesnt get cut off
            };
            button.Click += (s, e) =>
            {
                // redo this
            };
            flatMissionaries.Add(missionary);
            missionaryHolder.Controls.Add(button);
        }
        private void LoadData()
        {
            houseNameLabel.Text = house.Name;
            houseIdLabel.Text = "ID: " + house.Id.ToString();
            houseAddressLabel.Text = "Address: " + house.Address;
            houseXLabel.Text = "Latitude: " + house.Coordinates[0].ToString();
            houseYLabel.Text = "Longitude: " + house.Coordinates[1].ToString();
            houseZoneLabel.Text = "Zone: " + house.Zone;
            houseTeachingAreaBox.Text = house.ReverseParseTeachingAreas();
            foreach (Missionary missionary in TransportNumbers.allMissionaries)
                if(missionary.FlatID.Equals(house.Id))
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
            EnterMissionaryName enterMissionaryName = new();
            enterMissionaryName.Show();
            flatMissionaries.ListChanged += (s, e) =>
                CreateMissionaryButton(flatMissionaries[e.NewIndex]);
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            house.TeachingAreas = House.ParseTeachingAreas(houseTeachingAreaBox.Text);
            if (!curTeachingAreas.SequenceEqual(house.TeachingAreas)) // only save if changed
            {
                string json = JsonSerializer.Serialize(houses, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("HousingData.json", json); // file WILL exist regardless so dont need to check
            }
            //TODO: improve this later
            
        }
    }

    public partial class EnterMissionaryName : Form // this does not need to be its own file(s)
    {
        public EnterMissionaryName()
        {
            Size = new(250, 225);
            BackColor = System.Drawing.Color.LightGray;
            Text = "Add Missionary";

            TextBox enterName = new()
            {
                PlaceholderText = "Enter Missionary Name...",
                Font = new("Sitka Banner", 9.749999f),
                Size = new(225, 60),
                Location = new(5, 9),
                TextAlign = HorizontalAlignment.Center
            };
            TextBox enterId = new()
            {
                PlaceholderText = "Enter Missionary ID...",
                Font = new("Sitka Banner", 9.749999f),
                Size = new(225, 60),
                Location = new(5, 39),
                TextAlign = HorizontalAlignment.Center
            };
            TextBox enterFlatID = new()
            {
                PlaceholderText = "Enter Flat ID...",
                Font = new("Sitka Banner", 9.749999f),
                Size = new(225, 60),
                Location = new(5, 69),
                TextAlign = HorizontalAlignment.Center
            };
            TextBox enterAreaName = new()
            {
                PlaceholderText = "Enter Area Name...",
                Font = new("Sitka Banner", 9.749999f),
                Size = new(225, 60),
                Location = new(5, 99),
                TextAlign = HorizontalAlignment.Center
            };

            Button add = new()
            {
                Text = "Add Missionary",
                Font = new("Sitka Banner", 18.75f, FontStyle.Italic),
                Size = new(225, 50),
                Location = new(5, 129),
                BackColor = System.Drawing.Color.SlateGray,
                ForeColor = System.Drawing.Color.White,
            };
            add.Click += (s, e) => {
                if(!string.IsNullOrEmpty(enterName.Text))
                {
                    Missionary newMissionary = new()
                    {
                        Name = enterName.Text,
                        ID = int.Parse(enterId.Text),
                        FlatID = int.Parse(enterFlatID.Text),
                        Area = enterAreaName.Text,
                    };
                    TransportNumbers.allMissionaries.Add(newMissionary);
                    //missionaryList.Add(newMissionary);
                }
            };
            Controls.Add(enterName);
            Controls.Add(enterId);
            Controls.Add(enterFlatID);
            Controls.Add(enterAreaName);
            Controls.Add(add);
        }
    }
}
