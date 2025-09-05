using System.Text.Json;
using ASMOrganization.NonForms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
namespace ASMOrganization.Forms
{
    public partial class HousingData : Form
    {
        BindingList<House> houses = []; // we use a bindinglist to call an event when the list is updated
        public HousingData()
        {
            InitializeComponent();
        }

        private Button CreateHouseButton(House houseData)
        {
            Button button = new()
            {
                Font = new Font("Sitka Text", 14),
                ForeColor = addHouseButton.ForeColor,
                BackColor = addHouseButton.BackColor,
                Dock = DockStyle.Fill,
                Size = addHouseButton.Size,
                Text = $"{houseData.Name} House"
            };
            return button;
        }
        private void LoadHousingData(TableLayoutPanel holder)
        {
            if (File.Exists("HousingData.json"))
            {
                string fileJson = File.ReadAllText("HousingData.json");
                List<House> housingData = JsonSerializer.Deserialize<List<House>>(fileJson)!; // will never be null
                for (int index = 0; index < housingData.Count; index++) // populate
                    holder.Controls.Add(CreateHouseButton(housingData[index]), 0, index);
            }
        }

        private void SetUpPanels(object sender, EventArgs e)
        {
            Panel panel = new()
            {
                Dock = DockStyle.Bottom,
                AutoScroll = true,
                BorderStyle = BorderStyle.Fixed3D,
                Height = ClientSize.Height - addHouseButton.Height - 15
            };
            Controls.Add(panel);

            TableLayoutPanel houseButtonHolder = new()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                GrowStyle = TableLayoutPanelGrowStyle.AddRows
            };
            houseButtonHolder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            LoadHousingData(houseButtonHolder);

            panel.Controls.Add(houseButtonHolder);

            Resize += (s, e) =>
            {
                panel.Height = ClientSize.Height - addHouseButton.Height - 15;
            };

            houses.ListChanged += (s, e) => // add/remove button when houses list is changed
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                    houseButtonHolder.Controls.Add(CreateHouseButton(houses[e.NewIndex]), 0, e.NewIndex);
                // save to file
                string json = JsonSerializer.Serialize(houses, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("HousingData.json", json);
            };
        }

        private void AddHouse(object sender, EventArgs e)
        {
            NewHouse nh = new(houses);
            nh.Show();
        }
    }
}
