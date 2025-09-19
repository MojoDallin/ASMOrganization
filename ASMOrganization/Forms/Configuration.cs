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
        }

        private void SaveData(object sender, FormClosingEventArgs e)
        {
            TransportNumbers.Save(
                Double.Parse(distanceThresholdBox.Text),
                Int32.Parse(maxDistanceBox.Text),
                overriddenZonesBox.Text);
        }
    }
}
