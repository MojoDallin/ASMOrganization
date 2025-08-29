namespace ASMOrganization
{
    partial class HomeWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeWindow));
            titleLabel = new Label();
            viewCurrentTransferBoardButton = new Button();
            viewNextTransferBoardButton = new Button();
            generateLogisticsButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Top;
            titleLabel.Font = new Font("Sitka Banner", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(162, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(476, 50);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Australia Sydney Mission Organization";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // viewCurrentTransferBoardButton
            // 
            viewCurrentTransferBoardButton.Anchor = AnchorStyles.Top;
            viewCurrentTransferBoardButton.AutoSize = true;
            viewCurrentTransferBoardButton.BackColor = Color.CornflowerBlue;
            viewCurrentTransferBoardButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewCurrentTransferBoardButton.Location = new Point(281, 71);
            viewCurrentTransferBoardButton.Margin = new Padding(0);
            viewCurrentTransferBoardButton.Name = "viewCurrentTransferBoardButton";
            viewCurrentTransferBoardButton.Size = new Size(235, 50);
            viewCurrentTransferBoardButton.TabIndex = 1;
            viewCurrentTransferBoardButton.Text = "View Current Transfer Board";
            viewCurrentTransferBoardButton.UseVisualStyleBackColor = false;
            viewCurrentTransferBoardButton.Click += ViewCurrentTransferBoard;
            // 
            // viewNextTransferBoardButton
            // 
            viewNextTransferBoardButton.Anchor = AnchorStyles.Top;
            viewNextTransferBoardButton.AutoSize = true;
            viewNextTransferBoardButton.BackColor = Color.CornflowerBlue;
            viewNextTransferBoardButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewNextTransferBoardButton.Location = new Point(281, 131);
            viewNextTransferBoardButton.Margin = new Padding(0);
            viewNextTransferBoardButton.Name = "viewNextTransferBoardButton";
            viewNextTransferBoardButton.Size = new Size(235, 50);
            viewNextTransferBoardButton.TabIndex = 2;
            viewNextTransferBoardButton.Text = "View Next Transfer Board";
            viewNextTransferBoardButton.UseVisualStyleBackColor = false;
            // 
            // generateLogisticsButton
            // 
            generateLogisticsButton.Anchor = AnchorStyles.Top;
            generateLogisticsButton.AutoSize = true;
            generateLogisticsButton.BackColor = Color.CornflowerBlue;
            generateLogisticsButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            generateLogisticsButton.Location = new Point(281, 191);
            generateLogisticsButton.Margin = new Padding(0);
            generateLogisticsButton.Name = "generateLogisticsButton";
            generateLogisticsButton.Size = new Size(235, 50);
            generateLogisticsButton.TabIndex = 3;
            generateLogisticsButton.Text = "Generate Logistics";
            generateLogisticsButton.UseVisualStyleBackColor = false;
            generateLogisticsButton.Click += GenerateLogistics;
            // 
            // HomeWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCoral;
            ClientSize = new Size(800, 450);
            Controls.Add(generateLogisticsButton);
            Controls.Add(viewNextTransferBoardButton);
            Controls.Add(viewCurrentTransferBoardButton);
            Controls.Add(titleLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HomeWindow";
            Text = "Australia Sydney Mission Organization";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button viewCurrentTransferBoardButton;
        private Button viewNextTransferBoardButton;
        private Button generateLogisticsButton;
    }
}
