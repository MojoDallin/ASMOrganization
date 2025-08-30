using System.Diagnostics;

namespace ASMOrganization.Forms
{
    public partial class NextTransferBoard : Form
    {
        public NextTransferBoard()
        {
            InitializeComponent();
        }

        private void UpdateCurrentTransferBoard(object sender, EventArgs e)
        {
            // double check
            DialogResult result = MessageBox.Show(
                "This will overwrite the CURRENT transfer board with the data on" +
                " the NEW one.\nGENERATE LOGISTICS *BEFORE* DOING THIS." +
                "\nAre you SURE everything is correct?",
                "Overwrite",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                Debug.WriteLine("implement too");
            }
        }
    }
}
