using ASMOrganization.Forms;

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
            System.Windows.Forms.Timer timer = new();
            timer.Interval = 10;
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
    }
}
