using ASMOrganization.Forms;
using ASMOrganization.NonForms;
using System.ComponentModel;
using System.Text.Json;
using static System.Windows.Forms.Design.AxImporter;

namespace ASMOrganization
{
    public partial class HomeWindow : Form
    {
        public HomeWindow()
        {
            InitializeComponent();
            ScrollLabel();
        }

        private void ScrollLabel()
        {
            // fancy ui stuff
            System.Windows.Forms.Timer timer = new()
            {
                Interval = 10
            };
            timer.Tick += (a, b) =>
            {
                titleLabel.Left += 2;
                if (titleLabel.Left > ClientSize.Width)
                    titleLabel.Left = -titleLabel.Width;
            };
            timer.Start();
        }
        private void ManageLogistics(object sender, EventArgs e)
        {
            LogisticsManager logisticsManager = new();
            logisticsManager.Show();
        }

        private void ViewHousingData(object sender, EventArgs e)
        {
            HousingData housingData = new();
            housingData.Show();
        }
        private void Configure(object sender, EventArgs e)
        {
            Configuration config = new();
            config.Show();
        }

        private void SaveMissionaryData(object sender, FormClosingEventArgs e)
        {
            string json2 = JsonSerializer.Serialize(TransportNumbers.allMissionaries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("MissionaryData.json", json2);
        }

        private void LoadMissionaryData(object sender, EventArgs e)
        {
            if (File.Exists("MissionaryData.json"))
            {
                string fileJson = File.ReadAllText("MissionaryData.json");
                TransportNumbers.allMissionaries = JsonSerializer.Deserialize<BindingList<Missionary>>(fileJson, new JsonSerializerOptions { WriteIndented = true })!;
            }
        }
    }
}
