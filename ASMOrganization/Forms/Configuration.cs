using ASMOrganization.Forms;
using ASMOrganization.NonForms;

namespace ASMOrganization
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, EventArgs e)
        {
            TransportNumbers.Load();
            distanceThresholdBox.Text = TransportNumbers.GetDistanceThreshold().ToString();
            maxDistanceBox.Text = TransportNumbers.GetMaxDistance().ToString();
            overriddenZonesBox.Text = TransportNumbers.GetOverriddenZones();
            if (!TransportNumbers.GoToOffice())
            {
                missionOffice.Checked = false;
                baulkhamHillsChapel.Checked = true;
            }
        }

        private void SaveData(object sender, FormClosingEventArgs e)
        {
            bool chapel = false;
            if (baulkhamHillsChapel.Checked)
                chapel = true;
            TransportNumbers.Save(
                Double.Parse(distanceThresholdBox.Text),
                Int32.Parse(maxDistanceBox.Text),
                overriddenZonesBox.Text,
                chapel);
        }
    }
}
