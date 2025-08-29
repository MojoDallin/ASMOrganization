namespace ASMOrganization.Forms
{
    partial class NextTransferBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NextTransferBoard));
            updateCurrentTransferBoardButton = new Button();
            SuspendLayout();
            // 
            // updateCurrentTransferBoardButton
            // 
            updateCurrentTransferBoardButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            updateCurrentTransferBoardButton.AutoSize = true;
            updateCurrentTransferBoardButton.BackColor = Color.CornflowerBlue;
            updateCurrentTransferBoardButton.Font = new Font("Sitka Small", 14.2499981F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            updateCurrentTransferBoardButton.Location = new Point(454, 391);
            updateCurrentTransferBoardButton.Margin = new Padding(0);
            updateCurrentTransferBoardButton.Name = "updateCurrentTransferBoardButton";
            updateCurrentTransferBoardButton.Size = new Size(337, 50);
            updateCurrentTransferBoardButton.TabIndex = 2;
            updateCurrentTransferBoardButton.Text = "Update Current Transfer Board";
            updateCurrentTransferBoardButton.UseVisualStyleBackColor = false;
            updateCurrentTransferBoardButton.Click += UpdateCurrentTransferBoard;
            // 
            // NextTransferBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCoral;
            ClientSize = new Size(800, 450);
            Controls.Add(updateCurrentTransferBoardButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NextTransferBoard";
            Text = "Next Transfer Board";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button updateCurrentTransferBoardButton;
    }
}