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
            changeFilePathButton = new Button();
            currentFilePathLabel = new Label();
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
            resultImportLabel.Location = new Point(9, 59);
            resultImportLabel.Name = "resultImportLabel";
            resultImportLabel.Size = new Size(776, 37);
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
            resultGenerateLogisticsLabel.Location = new Point(9, 146);
            resultGenerateLogisticsLabel.Name = "resultGenerateLogisticsLabel";
            resultGenerateLogisticsLabel.Size = new Size(776, 74);
            resultGenerateLogisticsLabel.TabIndex = 7;
            resultGenerateLogisticsLabel.Text = "Output...";
            resultGenerateLogisticsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // changeFilePathButton
            // 
            changeFilePathButton.Anchor = AnchorStyles.Top;
            changeFilePathButton.AutoSize = true;
            changeFilePathButton.BackColor = Color.SlateGray;
            changeFilePathButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            changeFilePathButton.ForeColor = SystemColors.Control;
            changeFilePathButton.Location = new Point(3, 220);
            changeFilePathButton.Margin = new Padding(0);
            changeFilePathButton.Name = "changeFilePathButton";
            changeFilePathButton.Size = new Size(782, 50);
            changeFilePathButton.TabIndex = 8;
            changeFilePathButton.Text = "Change File Path";
            changeFilePathButton.UseVisualStyleBackColor = false;
            changeFilePathButton.Click += ChangeFilePath;
            // 
            // currentFilePathLabel
            // 
            currentFilePathLabel.Anchor = AnchorStyles.Top;
            currentFilePathLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentFilePathLabel.Location = new Point(3, 270);
            currentFilePathLabel.Name = "currentFilePathLabel";
            currentFilePathLabel.Size = new Size(776, 74);
            currentFilePathLabel.TabIndex = 9;
            currentFilePathLabel.Text = "Current File Path: none";
            currentFilePathLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LogisticsManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 459);
            Controls.Add(currentFilePathLabel);
            Controls.Add(changeFilePathButton);
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
        private Button changeFilePathButton;
        private Label currentFilePathLabel;
    }
}