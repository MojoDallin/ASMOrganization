namespace ASMOrganization.Forms
{
    partial class HouseInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HouseInformation));
            deleteHouseButton = new Button();
            houseNameLabel = new Label();
            houseIdLabel = new Label();
            houseXLabel = new Label();
            houseYLabel = new Label();
            addMissionaryButton = new Button();
            missionaryHolder = new TableLayoutPanel();
            houseTeachingAreaBox = new TextBox();
            houseZoneLabel = new Label();
            houseAddressLabel = new Label();
            SuspendLayout();
            // 
            // deleteHouseButton
            // 
            deleteHouseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deleteHouseButton.BackColor = Color.SlateGray;
            deleteHouseButton.Font = new Font("Sitka Small", 15.7499981F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            deleteHouseButton.ForeColor = SystemColors.Control;
            deleteHouseButton.Location = new Point(12, 406);
            deleteHouseButton.Name = "deleteHouseButton";
            deleteHouseButton.Size = new Size(234, 41);
            deleteHouseButton.TabIndex = 3;
            deleteHouseButton.Text = "Delete House";
            deleteHouseButton.UseVisualStyleBackColor = false;
            deleteHouseButton.Click += DeleteHouse;
            // 
            // houseNameLabel
            // 
            houseNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseNameLabel.BorderStyle = BorderStyle.FixedSingle;
            houseNameLabel.Font = new Font("Sitka Banner", 12.2499981F);
            houseNameLabel.Location = new Point(12, 9);
            houseNameLabel.Name = "houseNameLabel";
            houseNameLabel.Size = new Size(234, 24);
            houseNameLabel.TabIndex = 9;
            houseNameLabel.Text = "name";
            houseNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // houseIdLabel
            // 
            houseIdLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseIdLabel.BorderStyle = BorderStyle.FixedSingle;
            houseIdLabel.Font = new Font("Sitka Banner", 12.2499981F);
            houseIdLabel.Location = new Point(12, 33);
            houseIdLabel.Name = "houseIdLabel";
            houseIdLabel.Size = new Size(234, 24);
            houseIdLabel.TabIndex = 10;
            houseIdLabel.Text = "id";
            houseIdLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // houseXLabel
            // 
            houseXLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseXLabel.BorderStyle = BorderStyle.FixedSingle;
            houseXLabel.Font = new Font("Sitka Banner", 12.2499981F);
            houseXLabel.Location = new Point(12, 81);
            houseXLabel.Name = "houseXLabel";
            houseXLabel.Size = new Size(234, 24);
            houseXLabel.TabIndex = 11;
            houseXLabel.Text = "x";
            houseXLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // houseYLabel
            // 
            houseYLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseYLabel.BorderStyle = BorderStyle.FixedSingle;
            houseYLabel.Font = new Font("Sitka Banner", 12.2499981F);
            houseYLabel.Location = new Point(12, 105);
            houseYLabel.Name = "houseYLabel";
            houseYLabel.Size = new Size(234, 24);
            houseYLabel.TabIndex = 12;
            houseYLabel.Text = "y";
            houseYLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addMissionaryButton
            // 
            addMissionaryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addMissionaryButton.BackColor = Color.SlateGray;
            addMissionaryButton.Font = new Font("Sitka Small", 15.7499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            addMissionaryButton.ForeColor = SystemColors.Control;
            addMissionaryButton.Location = new Point(12, 359);
            addMissionaryButton.Name = "addMissionaryButton";
            addMissionaryButton.Size = new Size(234, 41);
            addMissionaryButton.TabIndex = 2;
            addMissionaryButton.Text = "Add Missionary";
            addMissionaryButton.UseVisualStyleBackColor = false;
            addMissionaryButton.Click += AddMissionary;
            // 
            // missionaryHolder
            // 
            missionaryHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            missionaryHolder.AutoScroll = true;
            missionaryHolder.ColumnCount = 1;
            missionaryHolder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.854702F));
            missionaryHolder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.145298F));
            missionaryHolder.Location = new Point(12, 186);
            missionaryHolder.Name = "missionaryHolder";
            missionaryHolder.RowCount = 3;
            missionaryHolder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            missionaryHolder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            missionaryHolder.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            missionaryHolder.Size = new Size(234, 167);
            missionaryHolder.TabIndex = 4;
            // 
            // houseTeachingAreaBox
            // 
            houseTeachingAreaBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseTeachingAreaBox.BackColor = SystemColors.Control;
            houseTeachingAreaBox.Font = new Font("Sitka Banner", 9.749999F);
            houseTeachingAreaBox.ForeColor = SystemColors.ControlText;
            houseTeachingAreaBox.Location = new Point(12, 156);
            houseTeachingAreaBox.Name = "houseTeachingAreaBox";
            houseTeachingAreaBox.PlaceholderText = "Teaching Areas";
            houseTeachingAreaBox.Size = new Size(234, 24);
            houseTeachingAreaBox.TabIndex = 1;
            houseTeachingAreaBox.TextAlign = HorizontalAlignment.Center;
            // 
            // houseZoneLabel
            // 
            houseZoneLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseZoneLabel.BorderStyle = BorderStyle.FixedSingle;
            houseZoneLabel.Font = new Font("Sitka Banner", 12.2499981F);
            houseZoneLabel.Location = new Point(12, 129);
            houseZoneLabel.Name = "houseZoneLabel";
            houseZoneLabel.Size = new Size(234, 24);
            houseZoneLabel.TabIndex = 13;
            houseZoneLabel.Text = "zone";
            houseZoneLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // houseAddressLabel
            // 
            houseAddressLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseAddressLabel.BorderStyle = BorderStyle.FixedSingle;
            houseAddressLabel.Font = new Font("Sitka Banner", 12.2499981F);
            houseAddressLabel.Location = new Point(12, 57);
            houseAddressLabel.Name = "houseAddressLabel";
            houseAddressLabel.Size = new Size(234, 24);
            houseAddressLabel.TabIndex = 14;
            houseAddressLabel.Text = "address";
            houseAddressLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HouseInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(258, 459);
            Controls.Add(houseAddressLabel);
            Controls.Add(houseZoneLabel);
            Controls.Add(houseTeachingAreaBox);
            Controls.Add(houseYLabel);
            Controls.Add(houseXLabel);
            Controls.Add(houseIdLabel);
            Controls.Add(houseNameLabel);
            Controls.Add(addMissionaryButton);
            Controls.Add(deleteHouseButton);
            Controls.Add(missionaryHolder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HouseInformation";
            Text = "House Information";
            FormClosing += Close;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button deleteHouseButton;
        private Label houseNameLabel;
        private Label houseIdLabel;
        private Label houseXLabel;
        private Label houseYLabel;
        private Button addMissionaryButton;
        private TableLayoutPanel missionaryHolder;
        private TextBox houseTeachingAreaBox;
        private Label houseZoneLabel;
        private Label houseAddressLabel;
    }
}