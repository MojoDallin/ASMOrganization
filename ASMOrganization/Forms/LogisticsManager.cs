using ClosedXML.Excel; // reading an excel file
using ASMOrganization.Properties; // saving data

namespace ASMOrganization.Forms
{
    public partial class LogisticsManager : Form
    {
        private string filePath = "none";
        private string transferFile = "";
        public LogisticsManager()
        {
            InitializeComponent();
            if (Settings.Default.LogisticsFilePath is not null) // only load data if theres data
            {
                filePath = Settings.Default.LogisticsFilePath;
                currentFilePathLabel.Text = $"Current File Path: {filePath}";
            }
        }
        private readonly List<List<string>> curTransferData = [];
        private readonly List<List<string>> newTransferData = [];

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
            using (XLWorkbook workbook = new(path))
            {
                var wks = workbook.Worksheet(1);
                var range = wks.RangeUsed();
                if(range is not null)
                    foreach (var col in range.Columns())
                    {
                        List<string> colData = [];
                        foreach (var cell in col.Cells($"3:{col.CellCount()}")) // skip first two rows
                            colData.Add(cell.Value.ToString());
                        data.Add(colData);
                    }
            }
            return data;
        }

        private void ImportTransferBoard(object sender, EventArgs e)
        {
            string[] results = ["Successfully loaded ", "Could not load file!"]; // convenience
            Button? button = sender as Button;
            if (button is not null) // just incase
            {
                using OpenFileDialog ofd = ImportExcelFile();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    transferFile = ofd.FileName;
                    resultImportLabel.Text = results[0] + ofd.SafeFileName + "!";
                }
                else
                    resultImportLabel.Text = results[1];
            }
        }

        private void GenerateLogistics(object sender, EventArgs e)
        {
            if (transferFile == "")
                resultGenerateLogisticsLabel.Text = "No transfer data!";
            else // update data before generating (to prevent errors)
            {
                try
                {
                    resultGenerateLogisticsLabel.Text = NonForms.Algorithms.FigureOutLogistics(ReadTransferData(transferFile), filePath);
                }
                catch (Exception ex)
                {
                    resultGenerateLogisticsLabel.Text = $"Error while generating! Did you select the correct file?\nFull Error: {ex.Message}";
                }
            }
        }

        private void ChangeFilePath(object sender, EventArgs e)
        {
            using FolderBrowserDialog fbd = new();
            if (filePath == "none")
                fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                fbd.InitialDirectory = filePath;
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
