using ClosedXML.Excel; // reading an excel file
using ASMOrganization.Properties; // saving data

namespace ASMOrganization.Forms
{
    public partial class LogisticsManager : Form
    {
        private string filePath = "none";
        private string curTransferFile = "";
        private string newTransferFile = "";
        public LogisticsManager()
        {
            InitializeComponent();
            if (Settings.Default.LogisticsFilePath is not null) // only load data if theres data
            {
                filePath = Settings.Default.LogisticsFilePath;
                currentFilePathLabel.Text = $"Current File Path: {filePath}";
            }
        }
        private List<List<string>> curTransferData = [];
        private List<List<string>> newTransferData = [];

        private static OpenFileDialog ImportExcelFile() // function so i dont type this code twice
        {
            return new OpenFileDialog()
            {
                Title = "Select an Excel Spreadsheet file...",
                Filter = "Excel Spreadsheet Files (*.xlsx)|*.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
        }

        private static List<List<string>> ReadTransferData(string path)
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
                    string area = row.Cell(8).Value.ToString(); // set variables for formatting purposes
                    if (row.Cell(5).Value.ToString() == "In-Field" && zone != "Office") // only in field and non-office missionaries
                    {
                        missionaryNames.Add(missionary);
                        missionaryZones.Add(zone);
                        missionaryAreas.Add(area);
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
            string[] results = ["Successfully loaded!", "Could not load file!"]; // convenience
            Button? button = sender as Button;
            if (button is not null) // just incase
            {
                using OpenFileDialog ofd = ImportExcelFile();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (button.Name == "importCurrentTransferBoardButton")
                    {
                        curTransferFile = ofd.FileName;
                        resultImportCurrentLabel.Text = results[0];
                    }
                    else
                    {
                        newTransferFile = ofd.FileName;
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

        private void GenerateLogistics(object sender, EventArgs e)
        {
            curTransferData = ReadTransferData(curTransferFile);
            newTransferData = ReadTransferData(newTransferFile);
            // update data before generating (to prevent errors)
            resultGenerateLogisticsLabel.Text = NonForms.Algorithms.FigureOutLogistics(curTransferData, newTransferData, filePath);
        }

        private void ChangeFilePath(object sender, EventArgs e)
        {
            using FolderBrowserDialog fbd = new();
            fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                filePath = fbd.SelectedPath;
                currentFilePathLabel.Text = $"Current File Path: {filePath}";
                Settings.Default.LogisticsFilePath = filePath;
                Settings.Default.Save();
            }
        }
    }
}
