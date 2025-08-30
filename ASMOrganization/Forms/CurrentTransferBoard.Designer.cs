namespace ASMOrganization.Forms
{
    partial class CurrentTransferBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentTransferBoard));
            importTransferBoardButton = new Button();
            SuspendLayout();
            // 
            // importTransferBoardButton
            // 
            importTransferBoardButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            importTransferBoardButton.AutoSize = true;
            importTransferBoardButton.BackColor = Color.CornflowerBlue;
            importTransferBoardButton.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            importTransferBoardButton.Location = new Point(535, 391);
            importTransferBoardButton.Margin = new Padding(0);
            importTransferBoardButton.Name = "importTransferBoardButton";
            importTransferBoardButton.Size = new Size(256, 50);
            importTransferBoardButton.TabIndex = 2;
            importTransferBoardButton.Text = "Import Transfer Board From File";
            importTransferBoardButton.UseVisualStyleBackColor = false;
            importTransferBoardButton.Click += ImportTransferBoard;
            // 
            // CurrentTransferBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCoral;
            ClientSize = new Size(800, 450);
            Controls.Add(importTransferBoardButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CurrentTransferBoard";
            Text = "Current Transfer Board";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button importTransferBoardButton;
    }
}