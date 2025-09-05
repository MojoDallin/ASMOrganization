using System.Text.Json;
using ASMOrganization.NonForms;
using System.IO;
namespace ASMOrganization.Forms
{
    public partial class HousingData : Form
    {
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
                Text = "Button"
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
        }

        private void AddHouse(object sender, EventArgs e)
        {

        }
    }
}
