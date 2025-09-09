namespace ASMOrganization.Forms
{
    partial class NewHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewHouse));
            houseNameBox = new TextBox();
            houseIDBox = new TextBox();
            houseXCoordinateBox = new TextBox();
            houseYCoordinateBox = new TextBox();
            missionaryHolder = new TableLayoutPanel();
            createHouseButton = new Button();
            addMissionaryButton = new Button();
            resultCreateHouseLabel = new Label();
            houseTeachingAreaBox = new TextBox();
            SuspendLayout();
            // 
            // houseNameBox
            // 
            houseNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseNameBox.BackColor = SystemColors.Control;
            houseNameBox.Font = new Font("Sitka Banner", 9.749999F);
            houseNameBox.ForeColor = SystemColors.ControlText;
            houseNameBox.Location = new Point(12, 12);
            houseNameBox.Name = "houseNameBox";
            houseNameBox.PlaceholderText = "Enter Housing Name...";
            houseNameBox.Size = new Size(234, 24);
            houseNameBox.TabIndex = 0;
            houseNameBox.TextAlign = HorizontalAlignment.Center;
            // 
            // houseIDBox
            // 
            houseIDBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseIDBox.BackColor = SystemColors.Control;
            houseIDBox.Font = new Font("Sitka Banner", 9.749999F);
            houseIDBox.ForeColor = SystemColors.ControlText;
            houseIDBox.Location = new Point(12, 41);
            houseIDBox.Name = "houseIDBox";
            houseIDBox.PlaceholderText = "Enter Housing ID...";
            houseIDBox.Size = new Size(234, 24);
            houseIDBox.TabIndex = 1;
            houseIDBox.TextAlign = HorizontalAlignment.Center;
            // 
            // houseXCoordinateBox
            // 
            houseXCoordinateBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseXCoordinateBox.BackColor = SystemColors.Control;
            houseXCoordinateBox.Font = new Font("Sitka Banner", 9.749999F);
            houseXCoordinateBox.ForeColor = SystemColors.ControlText;
            houseXCoordinateBox.Location = new Point(12, 70);
            houseXCoordinateBox.Name = "houseXCoordinateBox";
            houseXCoordinateBox.PlaceholderText = "Enter House X Coordinate...";
            houseXCoordinateBox.Size = new Size(234, 24);
            houseXCoordinateBox.TabIndex = 2;
            houseXCoordinateBox.TextAlign = HorizontalAlignment.Center;
            // 
            // houseYCoordinateBox
            // 
            houseYCoordinateBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseYCoordinateBox.BackColor = SystemColors.Control;
            houseYCoordinateBox.Font = new Font("Sitka Banner", 9.749999F);
            houseYCoordinateBox.ForeColor = SystemColors.ControlText;
            houseYCoordinateBox.Location = new Point(12, 99);
            houseYCoordinateBox.Name = "houseYCoordinateBox";
            houseYCoordinateBox.PlaceholderText = "Enter House Y Coordinate...";
            houseYCoordinateBox.Size = new Size(234, 24);
            houseYCoordinateBox.TabIndex = 3;
            houseYCoordinateBox.TextAlign = HorizontalAlignment.Center;
            // 
            // missionaryHolder
            // 
            missionaryHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            missionaryHolder.AutoScroll = true;
            missionaryHolder.ColumnCount = 1;
            missionaryHolder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.854702F));
            missionaryHolder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.145298F));
            missionaryHolder.Location = new Point(12, 159);
            missionaryHolder.Name = "missionaryHolder";
            missionaryHolder.RowCount = 3;
            missionaryHolder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            missionaryHolder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            missionaryHolder.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            missionaryHolder.Size = new Size(234, 153);
            missionaryHolder.TabIndex = 4;
            // 
            // createHouseButton
            // 
            createHouseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            createHouseButton.BackColor = Color.SlateGray;
            createHouseButton.Font = new Font("Sitka Small", 15.7499981F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            createHouseButton.ForeColor = SystemColors.Control;
            createHouseButton.Location = new Point(12, 365);
            createHouseButton.Name = "createHouseButton";
            createHouseButton.Size = new Size(234, 41);
            createHouseButton.TabIndex = 6;
            createHouseButton.Text = "Create House";
            createHouseButton.UseVisualStyleBackColor = false;
            createHouseButton.Click += CreateHouse;
            // 
            // addMissionaryButton
            // 
            addMissionaryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addMissionaryButton.BackColor = Color.SlateGray;
            addMissionaryButton.Font = new Font("Sitka Small", 15.7499981F, FontStyle.Italic, GraphicsUnit.Point, 0);
            addMissionaryButton.ForeColor = SystemColors.Control;
            addMissionaryButton.Location = new Point(12, 318);
            addMissionaryButton.Name = "addMissionaryButton";
            addMissionaryButton.Size = new Size(234, 41);
            addMissionaryButton.TabIndex = 5;
            addMissionaryButton.Text = "Add Missionary";
            addMissionaryButton.UseVisualStyleBackColor = false;
            addMissionaryButton.Click += AddMissionary;
            // 
            // resultCreateHouseLabel
            // 
            resultCreateHouseLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultCreateHouseLabel.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultCreateHouseLabel.Location = new Point(12, 409);
            resultCreateHouseLabel.Name = "resultCreateHouseLabel";
            resultCreateHouseLabel.Size = new Size(234, 41);
            resultCreateHouseLabel.TabIndex = 8;
            resultCreateHouseLabel.Text = "Output...";
            resultCreateHouseLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // houseTeachingAreaBox
            // 
            houseTeachingAreaBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            houseTeachingAreaBox.BackColor = SystemColors.Control;
            houseTeachingAreaBox.Font = new Font("Sitka Banner", 9.749999F);
            houseTeachingAreaBox.ForeColor = SystemColors.ControlText;
            houseTeachingAreaBox.Location = new Point(12, 129);
            houseTeachingAreaBox.Name = "houseTeachingAreaBox";
            houseTeachingAreaBox.PlaceholderText = "Enter House Teaching Area...";
            houseTeachingAreaBox.Size = new Size(234, 24);
            houseTeachingAreaBox.TabIndex = 4;
            houseTeachingAreaBox.TextAlign = HorizontalAlignment.Center;
            // 
            // NewHouse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(258, 459);
            Controls.Add(houseTeachingAreaBox);
            Controls.Add(resultCreateHouseLabel);
            Controls.Add(addMissionaryButton);
            Controls.Add(createHouseButton);
            Controls.Add(missionaryHolder);
            Controls.Add(houseYCoordinateBox);
            Controls.Add(houseXCoordinateBox);
            Controls.Add(houseIDBox);
            Controls.Add(houseNameBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NewHouse";
            Text = "Add Housing";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox houseNameBox;
        private TextBox houseIDBox;
        private TextBox houseXCoordinateBox;
        private TextBox houseYCoordinateBox;
        private TableLayoutPanel missionaryHolder;
        private Button createHouseButton;
        private Button addMissionaryButton;
        private Label resultCreateHouseLabel;
        private TextBox houseTeachingAreaBox;
    }
}