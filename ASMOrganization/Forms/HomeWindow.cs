using System.Diagnostics; // debugging purposes
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

        private void GenerateLogistics(object sender, EventArgs e)
        {
            // double check
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
            // if no, don't do anything (because why would it);

        }

        private void ViewCurrentTransferBoard(object sender, EventArgs e)
        {
            CurrentTransferBoard curBoard = new();
            curBoard.BringToFront();
            curBoard.Visible = true;
        }
    }
}
