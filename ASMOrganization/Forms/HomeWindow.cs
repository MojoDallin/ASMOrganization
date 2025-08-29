using System.Diagnostics; // debugging purposes

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

        private void generateLogistics(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "This will automatically generate formulas for moving around" +
                " missionaries in the most efficient way.\nContinue?",
                "Generate Logistics",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                Debug.WriteLine("implement");
            }

        }
    }
}
