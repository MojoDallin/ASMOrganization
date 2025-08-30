using System.Diagnostics;

namespace ASMOrganization.Forms
{
    public partial class CurrentTransferBoard : Form
    {
        public CurrentTransferBoard()
        {
            InitializeComponent();
        }

        private void ImportTransferBoard(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a text file...";
                ofd.Filter = "Text Files (*.txt)|*.txt";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Debug.WriteLine("implement database import");
                }
            }
        }
    }
}
