using System.Text.Json;
using ASMOrganization.NonForms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
namespace ASMOrganization.Forms
{
    public partial class HousingData : Form
    {
        private readonly BindingList<House> houses = []; // we use a bindinglist to call an event when the list is updated
        private readonly JsonSerializerOptions options = new() { WriteIndented = true };
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
            button.Click += (s, e) =>
            {
                HouseInformation hi = new(houses, houseData);
                hi.Show();
            };
            return button;
        }
        private void LoadHousingData(TableLayoutPanel holder)
        {
            if (File.Exists("HousingData.json"))
            {
                string fileJson = File.ReadAllText("HousingData.json");
                BindingList<House> housingData = JsonSerializer.Deserialize<BindingList<House>>(fileJson, options)!; // will never be null
                for (int index = 0; index < housingData.Count; index++) // populate
                {
                    houses.Add(housingData[index]);
                    holder.Controls.Add(CreateHouseButton(housingData[index]), 0, index);
                }
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
                string json = JsonSerializer.Serialize(houses, options);
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
