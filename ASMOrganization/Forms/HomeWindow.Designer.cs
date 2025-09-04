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
            logisticsManagerButton = new Button();
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
            // logisticsManagerButton
            // 
            logisticsManagerButton.Anchor = AnchorStyles.Top;
            logisticsManagerButton.AutoSize = true;
            logisticsManagerButton.BackColor = Color.SlateGray;
            logisticsManagerButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logisticsManagerButton.ForeColor = SystemColors.Control;
            logisticsManagerButton.Location = new Point(281, 71);
            logisticsManagerButton.Margin = new Padding(0);
            logisticsManagerButton.Name = "logisticsManagerButton";
            logisticsManagerButton.Size = new Size(235, 50);
            logisticsManagerButton.TabIndex = 1;
            logisticsManagerButton.Text = "Logistics Manager";
            logisticsManagerButton.UseVisualStyleBackColor = false;
            logisticsManagerButton.Click += ManageLogistics;
            // 
            // HomeWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 450);
            Controls.Add(logisticsManagerButton);
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
        private Button logisticsManagerButton;
    }
}
