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
                try
                {
                    string fileJson = File.ReadAllText("HousingData.json");
                    BindingList<House> housingData = JsonSerializer.Deserialize<BindingList<House>>(fileJson, options)!; // will never be null
                    for (int index = 0; index < housingData.Count; index++) // populate
                    {
                        houses.Add(housingData[index]);
                        holder.Controls.Add(CreateHouseButton(housingData[index]), 0, index);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error was encountered while loading the housing data!" +
                        $"\nError: {ex.Message}",
                        "Loading Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    DialogResult result = MessageBox.Show("Would you like to erase the data (do this as a last resort)?",
                        "Erase?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete("HousingData.json");
                        MessageBox.Show("Data successfully erased.",
                            "Erase Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
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
                else
                    houseButtonHolder.Controls.RemoveAt(e.NewIndex);
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
