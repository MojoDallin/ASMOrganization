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
            importCurrentTransferBoardButton = new Button();
            resultImportCurrentLabel = new Label();
            importNextTransferBoardButton = new Button();
            resultImportNextLabel = new Label();
            generateLogisticsButton = new Button();
            resultGenerateLogisticsLabel = new Label();
            changeFilePathButton = new Button();
            currentFilePathLabel = new Label();
            SuspendLayout();
            // 
            // importCurrentTransferBoardButton
            // 
            importCurrentTransferBoardButton.Anchor = AnchorStyles.Top;
            importCurrentTransferBoardButton.AutoSize = true;
            importCurrentTransferBoardButton.BackColor = Color.SlateGray;
            importCurrentTransferBoardButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            importCurrentTransferBoardButton.ForeColor = SystemColors.Control;
            importCurrentTransferBoardButton.Location = new Point(3, 9);
            importCurrentTransferBoardButton.Margin = new Padding(0);
            importCurrentTransferBoardButton.Name = "importCurrentTransferBoardButton";
            importCurrentTransferBoardButton.Size = new Size(782, 50);
            importCurrentTransferBoardButton.TabIndex = 2;
            importCurrentTransferBoardButton.Text = "Import Current Transfer Board";
            importCurrentTransferBoardButton.UseVisualStyleBackColor = false;
            importCurrentTransferBoardButton.Click += ImportTransferBoard;
            // 
            // resultImportCurrentLabel
            // 
            resultImportCurrentLabel.Anchor = AnchorStyles.Top;
            resultImportCurrentLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultImportCurrentLabel.Location = new Point(9, 59);
            resultImportCurrentLabel.Name = "resultImportCurrentLabel";
            resultImportCurrentLabel.Size = new Size(776, 37);
            resultImportCurrentLabel.TabIndex = 3;
            resultImportCurrentLabel.Text = "Output...";
            resultImportCurrentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // importNextTransferBoardButton
            // 
            importNextTransferBoardButton.Anchor = AnchorStyles.Top;
            importNextTransferBoardButton.AutoSize = true;
            importNextTransferBoardButton.BackColor = Color.SlateGray;
            importNextTransferBoardButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            importNextTransferBoardButton.ForeColor = SystemColors.Control;
            importNextTransferBoardButton.Location = new Point(3, 96);
            importNextTransferBoardButton.Margin = new Padding(0);
            importNextTransferBoardButton.Name = "importNextTransferBoardButton";
            importNextTransferBoardButton.Size = new Size(782, 50);
            importNextTransferBoardButton.TabIndex = 4;
            importNextTransferBoardButton.Text = "Import Next Transfer Board";
            importNextTransferBoardButton.UseVisualStyleBackColor = false;
            importNextTransferBoardButton.Click += ImportTransferBoard;
            // 
            // resultImportNextLabel
            // 
            resultImportNextLabel.Anchor = AnchorStyles.Top;
            resultImportNextLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultImportNextLabel.Location = new Point(9, 146);
            resultImportNextLabel.Name = "resultImportNextLabel";
            resultImportNextLabel.Size = new Size(776, 37);
            resultImportNextLabel.TabIndex = 5;
            resultImportNextLabel.Text = "Output...";
            resultImportNextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // generateLogisticsButton
            // 
            generateLogisticsButton.Anchor = AnchorStyles.Top;
            generateLogisticsButton.AutoSize = true;
            generateLogisticsButton.BackColor = Color.SlateGray;
            generateLogisticsButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            generateLogisticsButton.ForeColor = SystemColors.Control;
            generateLogisticsButton.Location = new Point(3, 183);
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
            resultGenerateLogisticsLabel.Location = new Point(9, 233);
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
            changeFilePathButton.Location = new Point(3, 307);
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
            currentFilePathLabel.Location = new Point(3, 367);
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
            Controls.Add(resultImportNextLabel);
            Controls.Add(importNextTransferBoardButton);
            Controls.Add(resultImportCurrentLabel);
            Controls.Add(importCurrentTransferBoardButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogisticsManager";
            Text = "ASM Logistics Manager";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button importCurrentTransferBoardButton;
        private Label resultImportCurrentLabel;
        private Button importNextTransferBoardButton;
        private Label resultImportNextLabel;
        private Button generateLogisticsButton;
        private Label resultGenerateLogisticsLabel;
        private Button changeFilePathButton;
        private Label currentFilePathLabel;
    }
}