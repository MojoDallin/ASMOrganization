namespace ASMOrganization.Forms
{
    partial class HousingData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HousingData));
            addHouseButton = new Button();
            searchBox = new TextBox();
            addMissionaryButton = new Button();
            SuspendLayout();
            // 
            // addHouseButton
            // 
            addHouseButton.AutoSize = true;
            addHouseButton.BackColor = Color.SlateGray;
            addHouseButton.Font = new Font("Sitka Small", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            addHouseButton.ForeColor = SystemColors.Control;
            addHouseButton.Location = new Point(9, 9);
            addHouseButton.Margin = new Padding(0);
            addHouseButton.Name = "addHouseButton";
            addHouseButton.Size = new Size(389, 50);
            addHouseButton.TabIndex = 3;
            addHouseButton.Text = "Add House";
            addHouseButton.UseVisualStyleBackColor = false;
            addHouseButton.Click += AddHouse;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.BackColor = SystemColors.Control;
            searchBox.Font = new Font("Sitka Banner", 9.749999F);
            searchBox.ForeColor = SystemColors.ControlText;
            searchBox.Location = new Point(12, 62);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Search (Name, ID (only numbers), Missionaries, Zone, Teaching Areas)";
            searchBox.Size = new Size(776, 24);
            searchBox.TabIndex = 5;
            searchBox.TextAlign = HorizontalAlignment.Center;
            searchBox.TextChanged += Search;
            // 
            // addMissionaryButton
            // 
            addMissionaryButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addMissionaryButton.AutoSize = true;
            addMissionaryButton.BackColor = Color.SlateGray;
            addMissionaryButton.Font = new Font("Sitka Small", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            addMissionaryButton.ForeColor = SystemColors.Control;
            addMissionaryButton.Location = new Point(402, 9);
            addMissionaryButton.Margin = new Padding(0);
            addMissionaryButton.Name = "addMissionaryButton";
            addMissionaryButton.Size = new Size(389, 50);
            addMissionaryButton.TabIndex = 6;
            addMissionaryButton.Text = "Add Missionary";
            addMissionaryButton.UseVisualStyleBackColor = false;
            addMissionaryButton.Click += AddMissionary;
            // 
            // HousingData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(800, 459);
            Controls.Add(addMissionaryButton);
            Controls.Add(searchBox);
            Controls.Add(addHouseButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HousingData";
            Text = "ASM Housing Data";
            WindowState = FormWindowState.Maximized;
            Load += SetUpPanels;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addHouseButton;
        private TextBox searchBox;
        private Button addMissionaryButton;
    }
}