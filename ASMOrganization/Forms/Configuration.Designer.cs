namespace ASMOrganization
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            distanceThresholdTitle = new Label();
            distanceThresholdDescription = new Label();
            distanceThresholdBox = new TextBox();
            maxDistanceBox = new TextBox();
            maxDistanceDescription = new Label();
            maxDistanceTitle = new Label();
            overriddenZonesBox = new TextBox();
            overriddenZonesDescription = new Label();
            overridenZonesTitle = new Label();
            meetingLocationTitle = new Label();
            meetingLocationDescription = new Label();
            missionOffice = new RadioButton();
            baulkhamHillsChapel = new RadioButton();
            SuspendLayout();
            // 
            // distanceThresholdTitle
            // 
            distanceThresholdTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            distanceThresholdTitle.Font = new Font("Sitka Banner", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            distanceThresholdTitle.Location = new Point(12, 9);
            distanceThresholdTitle.Name = "distanceThresholdTitle";
            distanceThresholdTitle.Size = new Size(1166, 50);
            distanceThresholdTitle.TabIndex = 1;
            distanceThresholdTitle.Text = "Distance Threshold";
            distanceThresholdTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // distanceThresholdDescription
            // 
            distanceThresholdDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            distanceThresholdDescription.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            distanceThresholdDescription.Location = new Point(12, 59);
            distanceThresholdDescription.Name = "distanceThresholdDescription";
            distanceThresholdDescription.Size = new Size(1166, 75);
            distanceThresholdDescription.TabIndex = 2;
            distanceThresholdDescription.Text = resources.GetString("distanceThresholdDescription.Text");
            distanceThresholdDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // distanceThresholdBox
            // 
            distanceThresholdBox.Anchor = AnchorStyles.Top;
            distanceThresholdBox.BackColor = SystemColors.Control;
            distanceThresholdBox.Font = new Font("Sitka Banner", 9.749999F);
            distanceThresholdBox.ForeColor = SystemColors.ControlText;
            distanceThresholdBox.Location = new Point(498, 137);
            distanceThresholdBox.MaxLength = 5;
            distanceThresholdBox.Name = "distanceThresholdBox";
            distanceThresholdBox.PlaceholderText = "Distance Threshold";
            distanceThresholdBox.Size = new Size(189, 24);
            distanceThresholdBox.TabIndex = 5;
            distanceThresholdBox.TextAlign = HorizontalAlignment.Center;
            // 
            // maxDistanceBox
            // 
            maxDistanceBox.Anchor = AnchorStyles.Top;
            maxDistanceBox.BackColor = SystemColors.Control;
            maxDistanceBox.Font = new Font("Sitka Banner", 9.749999F);
            maxDistanceBox.ForeColor = SystemColors.ControlText;
            maxDistanceBox.Location = new Point(498, 263);
            maxDistanceBox.MaxLength = 5;
            maxDistanceBox.Name = "maxDistanceBox";
            maxDistanceBox.PlaceholderText = "Max Distance";
            maxDistanceBox.Size = new Size(189, 24);
            maxDistanceBox.TabIndex = 8;
            maxDistanceBox.TextAlign = HorizontalAlignment.Center;
            // 
            // maxDistanceDescription
            // 
            maxDistanceDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            maxDistanceDescription.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maxDistanceDescription.Location = new Point(12, 214);
            maxDistanceDescription.Name = "maxDistanceDescription";
            maxDistanceDescription.Size = new Size(1166, 46);
            maxDistanceDescription.TabIndex = 7;
            maxDistanceDescription.Text = resources.GetString("maxDistanceDescription.Text");
            maxDistanceDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // maxDistanceTitle
            // 
            maxDistanceTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            maxDistanceTitle.Font = new Font("Sitka Banner", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maxDistanceTitle.Location = new Point(12, 164);
            maxDistanceTitle.Name = "maxDistanceTitle";
            maxDistanceTitle.Size = new Size(1166, 50);
            maxDistanceTitle.TabIndex = 6;
            maxDistanceTitle.Text = "Maximum Public Transport Distance";
            maxDistanceTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // overriddenZonesBox
            // 
            overriddenZonesBox.Anchor = AnchorStyles.Top;
            overriddenZonesBox.BackColor = SystemColors.Control;
            overriddenZonesBox.Font = new Font("Sitka Banner", 9.749999F);
            overriddenZonesBox.ForeColor = SystemColors.ControlText;
            overriddenZonesBox.Location = new Point(498, 367);
            overriddenZonesBox.MaxLength = 100;
            overriddenZonesBox.Name = "overriddenZonesBox";
            overriddenZonesBox.PlaceholderText = "Overridden Zones";
            overriddenZonesBox.Size = new Size(189, 24);
            overriddenZonesBox.TabIndex = 11;
            overriddenZonesBox.TextAlign = HorizontalAlignment.Center;
            // 
            // overriddenZonesDescription
            // 
            overriddenZonesDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            overriddenZonesDescription.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            overriddenZonesDescription.Location = new Point(12, 340);
            overriddenZonesDescription.Name = "overriddenZonesDescription";
            overriddenZonesDescription.Size = new Size(1166, 24);
            overriddenZonesDescription.TabIndex = 10;
            overriddenZonesDescription.Text = "Zones in this list will *always* use cars, due to their vast size. Seperate by comma (ex. Nephi, Teancum, Enos).\r\n";
            overriddenZonesDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // overridenZonesTitle
            // 
            overridenZonesTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            overridenZonesTitle.Font = new Font("Sitka Banner", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            overridenZonesTitle.Location = new Point(12, 290);
            overridenZonesTitle.Name = "overridenZonesTitle";
            overridenZonesTitle.Size = new Size(1166, 50);
            overridenZonesTitle.TabIndex = 9;
            overridenZonesTitle.Text = "Overridden Zones";
            overridenZonesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // meetingLocationTitle
            // 
            meetingLocationTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            meetingLocationTitle.Font = new Font("Sitka Banner", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meetingLocationTitle.Location = new Point(12, 394);
            meetingLocationTitle.Name = "meetingLocationTitle";
            meetingLocationTitle.Size = new Size(1166, 50);
            meetingLocationTitle.TabIndex = 12;
            meetingLocationTitle.Text = "Meeting Location";
            meetingLocationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // meetingLocationDescription
            // 
            meetingLocationDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            meetingLocationDescription.Font = new Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            meetingLocationDescription.Location = new Point(12, 444);
            meetingLocationDescription.Name = "meetingLocationDescription";
            meetingLocationDescription.Size = new Size(1166, 24);
            meetingLocationDescription.TabIndex = 13;
            meetingLocationDescription.Text = "Where the missionaries will meet for transfers. The selected option is the filled-in circle.";
            meetingLocationDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // missionOffice
            // 
            missionOffice.Anchor = AnchorStyles.Top;
            missionOffice.AutoSize = true;
            missionOffice.Checked = true;
            missionOffice.Font = new Font("Sitka Banner", 9.75F);
            missionOffice.Location = new Point(352, 471);
            missionOffice.Name = "missionOffice";
            missionOffice.Size = new Size(225, 23);
            missionOffice.TabIndex = 14;
            missionOffice.TabStop = true;
            missionOffice.Text = "Mission Office (756 Pennant Hills Road)";
            missionOffice.TextAlign = ContentAlignment.MiddleCenter;
            missionOffice.UseVisualStyleBackColor = true;
            // 
            // baulkhamHillsChapel
            // 
            baulkhamHillsChapel.Anchor = AnchorStyles.Top;
            baulkhamHillsChapel.AutoSize = true;
            baulkhamHillsChapel.Font = new Font("Sitka Banner", 9.75F);
            baulkhamHillsChapel.Location = new Point(609, 471);
            baulkhamHillsChapel.Name = "baulkhamHillsChapel";
            baulkhamHillsChapel.Size = new Size(236, 23);
            baulkhamHillsChapel.TabIndex = 15;
            baulkhamHillsChapel.Text = "Baulkham Hills Chapel (77 Watkins Road)";
            baulkhamHillsChapel.TextAlign = ContentAlignment.MiddleCenter;
            baulkhamHillsChapel.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1190, 650);
            Controls.Add(baulkhamHillsChapel);
            Controls.Add(missionOffice);
            Controls.Add(meetingLocationDescription);
            Controls.Add(meetingLocationTitle);
            Controls.Add(overriddenZonesBox);
            Controls.Add(overriddenZonesDescription);
            Controls.Add(overridenZonesTitle);
            Controls.Add(maxDistanceBox);
            Controls.Add(maxDistanceDescription);
            Controls.Add(maxDistanceTitle);
            Controls.Add(distanceThresholdBox);
            Controls.Add(distanceThresholdDescription);
            Controls.Add(distanceThresholdTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Configuration";
            Text = "Configuration";
            WindowState = FormWindowState.Maximized;
            FormClosing += SaveData;
            Load += LoadData;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label distanceThresholdTitle;
        private Label distanceThresholdDescription;
        private TextBox distanceThresholdBox;
        private TextBox maxDistanceBox;
        private Label maxDistanceDescription;
        private Label maxDistanceTitle;
        private TextBox overriddenZonesBox;
        private Label overriddenZonesDescription;
        private Label overridenZonesTitle;
        private Label meetingLocationTitle;
        private Label meetingLocationDescription;
        private RadioButton missionOffice;
        private RadioButton baulkhamHillsChapel;
    }
}
