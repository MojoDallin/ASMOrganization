using System.Diagnostics;

namespace ASMOrganization.Forms
{
    public partial class LogisticsManager : Form
    {
        public LogisticsManager()
        {
            InitializeComponent();
        }

        private OpenFileDialog ImportExcelFile() // function so i dont type this code twice
        {
            return new OpenFileDialog()
            {
                Title = "Select an Excel Spreadsheet file...",
                Filter = "Excel Spreadsheet Files (*.xlsx)|*.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            
        }

        private void ImportTransferBoard(object sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button is not null)
            {
                using (OpenFileDialog ofd = ImportExcelFile())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (button.Name == "importCurrentTransferBoardButton")
                        {

                        }
                        else // default is other button, no need to check directly
                        {

                        }
                    }
                }
            }
        }
    }
}
