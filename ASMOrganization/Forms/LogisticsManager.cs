using ClosedXML.Excel; // reading an excel file
using ASMOrganization.Properties; // saving data

namespace ASMOrganization.Forms
{
    public partial class LogisticsManager : Form
    {
        private string exportFilePath = "none";
        private string importFilePath = "none";
        private string transferFile = "";
        public LogisticsManager()
        {
            InitializeComponent();
            if (Settings.Default.LogisticsExportFilePath is not null) // only load data if theres data
            {
                exportFilePath = Settings.Default.LogisticsExportFilePath;
                currentExportFilePathLabel.Text = $"Current Export File Path: {exportFilePath}";
            }
            if (Settings.Default.LogisticsImportFilePath is not null)
            {
                importFilePath = Settings.Default.LogisticsImportFilePath;
                currentImportFilePathLabel.Text = $"Current Import File Path: {importFilePath}";
            }
        }
        private readonly List<List<string>> curTransferData = [];
        private readonly List<List<string>> newTransferData = [];

        private OpenFileDialog ImportExcelFile() // function so i dont type this code twice
        {
            string inDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // if a file path is set, open to it; otherwise just go to MyDocuments by default
            if (importFilePath != "none")
                inDir = importFilePath;
            return new OpenFileDialog()
            {
                Title = "Select an Excel Spreadsheet file...",
                Filter = "Excel Spreadsheet Files (*.xlsx)|*.xlsx",
                InitialDirectory = inDir
            };
        }

        private static List<List<string>> ReadTransferData(string path)
        {
            List<List<string>> data = [];
            using (XLWorkbook workbook = new(path))
            {
                var wks = workbook.Worksheet(1);
                var range = wks.RangeUsed();
                if (range is not null)
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
                    resultGenerateLogisticsLabel.Text = NonForms.Algorithms.FigureOutLogistics(ReadTransferData(transferFile), exportFilePath);
                }
                catch (Exception ex)
                {
                    resultGenerateLogisticsLabel.Text = $"Error while generating! Did you select the correct file?\nFull Error: {ex.Message}";
                }
            }
        }

        private void ChangeFilePath(ref Label label, ref string path, string setting) // same function for two buttons. optimization!
        {
            using FolderBrowserDialog fbd = new();
            if (path == "none")
                fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                fbd.InitialDirectory = path;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                label.Text = $"Current File Path: {path}";
                if (setting == "E") // cant pass settings as refs so this is the best way around that afaik
                    Settings.Default.LogisticsExportFilePath = path;
                else
                    Settings.Default.LogisticsImportFilePath = path;
                Settings.Default.Save();
            }
        }

        private void ImportButtonClick(object sender, EventArgs e) => ChangeFilePath(ref currentImportFilePathLabel, ref importFilePath, "I");

        private void ExportButtonClick(object sender, EventArgs e) => ChangeFilePath(ref currentExportFilePathLabel, ref exportFilePath, "E");
    }
}
