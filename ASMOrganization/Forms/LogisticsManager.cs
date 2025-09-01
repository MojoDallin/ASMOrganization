using System.Diagnostics; // debug
using ClosedXML.Excel;
using ASMOrganization.NonForms; // logic

namespace ASMOrganization.Forms
{
    public partial class LogisticsManager : Form
    {
        public LogisticsManager()
        {
            InitializeComponent();
        }
        List<List<string>> curTransferData = [];
        List<List<string>> newTransferData = [];

        private OpenFileDialog ImportExcelFile() // function so i dont type this code twice
        {
            return new OpenFileDialog()
            {
                Title = "Select an Excel Spreadsheet file...",
                Filter = "Excel Spreadsheet Files (*.xlsx)|*.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
        }

        private List<List<string>> ReadTransferData(string path)
        {
            List<List<string>> data = [];
            List<string> missionaryNames = [];
            List<string> missionaryZones = [];
            List<string> missionaryAreas = [];
            using (XLWorkbook workbook = new(path))
            {
                var wks = workbook.Worksheet(1);
                foreach (var row in wks.RowsUsed())
                {
                    string zone = row.Cell(6).Value.ToString();
                    string missionary = row.Cell(1).Value.ToString();
                    string area = row.Cell(8).Value.ToString();
                    if (row.Cell(5).Value.ToString() == "In-Field" && zone != "Office") // only in field and non-office missionaries
                    {
                        missionaryNames.Add(missionary);
                        missionaryZones.Add(zone);
                        missionaryZones.Add(area);
                    }
                }

            }
            data.Add(missionaryNames);
            data.Add(missionaryZones);
            data.Add(missionaryAreas);
            return data;
        }

        private void ImportTransferBoard(object sender, EventArgs e)
        {
            string[] results = ["Successfully loaded!", "Could not load file!"];
            Button? button = sender as Button;
            if (button is not null)
            {
                using OpenFileDialog ofd = ImportExcelFile();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (button.Name == "importCurrentTransferBoardButton")
                    {
                        curTransferData = ReadTransferData(ofd.FileName);
                        resultImportCurrentLabel.Text = results[0];
                    }
                    else
                    {
                        newTransferData = ReadTransferData(ofd.FileName);
                        resultImportNextLabel.Text = results[0];
                    }
                }
                else
                {
                    if (button.Name == "importCurrentTransferBoardButton")
                        resultImportCurrentLabel.Text = results[1];
                    else
                        resultImportNextLabel.Text = results[1];
                }

            }
        }

        private void GenerateLogistics(object sender, EventArgs e) => resultGenerateLogisticsLabel.Text = NonForms.Algorithms.FigureOutLogistics(curTransferData, newTransferData);
    }
}
