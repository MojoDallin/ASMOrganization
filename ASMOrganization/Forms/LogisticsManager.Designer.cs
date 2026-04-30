namespace ASMOrganization.Forms
{
    partial class LogisticsManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogisticsManager));
            importTransferBoardButton = new Button();
            resultImportLabel = new Label();
            generateLogisticsButton = new Button();
            resultGenerateLogisticsLabel = new Label();
            changeImportFilePathButton = new Button();
            currentExportFilePathLabel = new Label();
            currentImportFilePathLabel = new Label();
            changeExportFilePathButton = new Button();
            generateHousingDataInformationButton = new Button();
            housingDataInformationOutputLabel = new Label();
            SuspendLayout();
            // 
            // importTransferBoardButton
            // 
            importTransferBoardButton.Anchor = AnchorStyles.Top;
            importTransferBoardButton.AutoSize = true;
            importTransferBoardButton.BackColor = Color.SlateGray;
            importTransferBoardButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            importTransferBoardButton.ForeColor = SystemColors.Control;
            importTransferBoardButton.Location = new Point(3, 9);
            importTransferBoardButton.Margin = new Padding(0);
            importTransferBoardButton.Name = "importTransferBoardButton";
            importTransferBoardButton.Size = new Size(782, 50);
            importTransferBoardButton.TabIndex = 2;
            importTransferBoardButton.Text = "Import Transfer Board";
            importTransferBoardButton.UseVisualStyleBackColor = false;
            importTransferBoardButton.Click += ImportTransferBoard;
            // 
            // resultImportLabel
            // 
            resultImportLabel.Anchor = AnchorStyles.Top;
            resultImportLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultImportLabel.Location = new Point(6, 59);
            resultImportLabel.Name = "resultImportLabel";
            resultImportLabel.Size = new Size(779, 37);
            resultImportLabel.TabIndex = 3;
            resultImportLabel.Text = "Output...";
            resultImportLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // generateLogisticsButton
            // 
            generateLogisticsButton.Anchor = AnchorStyles.Top;
            generateLogisticsButton.AutoSize = true;
            generateLogisticsButton.BackColor = Color.SlateGray;
            generateLogisticsButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            generateLogisticsButton.ForeColor = SystemColors.Control;
            generateLogisticsButton.Location = new Point(3, 96);
            generateLogisticsButton.Margin = new Padding(0);
            generateLogisticsButton.Name = "generateLogisticsButton";
            generateLogisticsButton.Size = new Size(782, 50);
            generateLogisticsButton.TabIndex = 6;
            generateLogisticsButton.Text = "Generate Logistics";
            generateLogisticsButton.UseVisualStyleBackColor = false;
            generateLogisticsButton.Click += GenerateLogistics;
            // 
            // resultGenerateLogisticsLabel
            // 
            resultGenerateLogisticsLabel.Anchor = AnchorStyles.Top;
            resultGenerateLogisticsLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultGenerateLogisticsLabel.Location = new Point(6, 146);
            resultGenerateLogisticsLabel.Name = "resultGenerateLogisticsLabel";
            resultGenerateLogisticsLabel.Size = new Size(779, 74);
            resultGenerateLogisticsLabel.TabIndex = 7;
            resultGenerateLogisticsLabel.Text = "Output...";
            resultGenerateLogisticsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // changeImportFilePathButton
            // 
            changeImportFilePathButton.Anchor = AnchorStyles.Top;
            changeImportFilePathButton.AutoSize = true;
            changeImportFilePathButton.BackColor = Color.SlateGray;
            changeImportFilePathButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            changeImportFilePathButton.ForeColor = SystemColors.Control;
            changeImportFilePathButton.Location = new Point(3, 220);
            changeImportFilePathButton.Margin = new Padding(0);
            changeImportFilePathButton.Name = "changeImportFilePathButton";
            changeImportFilePathButton.Size = new Size(386, 50);
            changeImportFilePathButton.TabIndex = 8;
            changeImportFilePathButton.Text = "Change Import File Path";
            changeImportFilePathButton.UseVisualStyleBackColor = false;
            changeImportFilePathButton.Click += ImportButtonClick;
            // 
            // currentExportFilePathLabel
            // 
            currentExportFilePathLabel.Anchor = AnchorStyles.Top;
            currentExportFilePathLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentExportFilePathLabel.Location = new Point(6, 320);
            currentExportFilePathLabel.Name = "currentExportFilePathLabel";
            currentExportFilePathLabel.Size = new Size(779, 50);
            currentExportFilePathLabel.TabIndex = 9;
            currentExportFilePathLabel.Text = "Current Export File Path: none";
            currentExportFilePathLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currentImportFilePathLabel
            // 
            currentImportFilePathLabel.Anchor = AnchorStyles.Top;
            currentImportFilePathLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentImportFilePathLabel.Location = new Point(6, 270);
            currentImportFilePathLabel.Name = "currentImportFilePathLabel";
            currentImportFilePathLabel.Size = new Size(779, 50);
            currentImportFilePathLabel.TabIndex = 10;
            currentImportFilePathLabel.Text = "Current Import File Path: none";
            currentImportFilePathLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // changeExportFilePathButton
            // 
            changeExportFilePathButton.Anchor = AnchorStyles.Top;
            changeExportFilePathButton.AutoSize = true;
            changeExportFilePathButton.BackColor = Color.SlateGray;
            changeExportFilePathButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            changeExportFilePathButton.ForeColor = SystemColors.Control;
            changeExportFilePathButton.Location = new Point(399, 220);
            changeExportFilePathButton.Margin = new Padding(0);
            changeExportFilePathButton.Name = "changeExportFilePathButton";
            changeExportFilePathButton.Size = new Size(386, 50);
            changeExportFilePathButton.TabIndex = 11;
            changeExportFilePathButton.Text = "Change Export File Path";
            changeExportFilePathButton.UseVisualStyleBackColor = false;
            changeExportFilePathButton.Click += ExportButtonClick;
            // 
            // generateHousingDataInformationButton
            // 
            generateHousingDataInformationButton.Anchor = AnchorStyles.Top;
            generateHousingDataInformationButton.AutoSize = true;
            generateHousingDataInformationButton.BackColor = Color.SlateGray;
            generateHousingDataInformationButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            generateHousingDataInformationButton.ForeColor = SystemColors.Control;
            generateHousingDataInformationButton.Location = new Point(3, 370);
            generateHousingDataInformationButton.Margin = new Padding(0);
            generateHousingDataInformationButton.Name = "generateHousingDataInformationButton";
            generateHousingDataInformationButton.Size = new Size(782, 50);
            generateHousingDataInformationButton.TabIndex = 12;
            generateHousingDataInformationButton.Text = "Generate Housing Data Information";
            generateHousingDataInformationButton.UseVisualStyleBackColor = false;
            generateHousingDataInformationButton.Click += GenerateHousingDataFile;
            // 
            // housingDataInformationOutputLabel
            // 
            housingDataInformationOutputLabel.Anchor = AnchorStyles.Top;
            housingDataInformationOutputLabel.AutoSize = true;
            housingDataInformationOutputLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            housingDataInformationOutputLabel.Location = new Point(6, 420);
            housingDataInformationOutputLabel.MaximumSize = new Size(779, 999);
            housingDataInformationOutputLabel.MinimumSize = new Size(779, 71);
            housingDataInformationOutputLabel.Name = "housingDataInformationOutputLabel";
            housingDataInformationOutputLabel.Size = new Size(779, 71);
            housingDataInformationOutputLabel.TabIndex = 13;
            housingDataInformationOutputLabel.Text = "Output...";
            housingDataInformationOutputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LogisticsManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 500);
            Controls.Add(housingDataInformationOutputLabel);
            Controls.Add(generateHousingDataInformationButton);
            Controls.Add(changeExportFilePathButton);
            Controls.Add(currentImportFilePathLabel);
            Controls.Add(currentExportFilePathLabel);
            Controls.Add(changeImportFilePathButton);
            Controls.Add(resultGenerateLogisticsLabel);
            Controls.Add(generateLogisticsButton);
            Controls.Add(resultImportLabel);
            Controls.Add(importTransferBoardButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogisticsManager";
            Text = "ASM Logistics Manager";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button importTransferBoardButton;
        private Label resultImportLabel;
        private Button generateLogisticsButton;
        private Label resultGenerateLogisticsLabel;
        private Button changeImportFilePathButton;
        private Label currentExportFilePathLabel;
        private Label currentImportFilePathLabel;
        private Button changeExportFilePathButton;
        private Button generateHousingDataInformationButton;
        private Label housingDataInformationOutputLabel;
    }
}