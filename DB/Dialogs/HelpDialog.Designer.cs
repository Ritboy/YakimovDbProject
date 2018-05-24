namespace DB.Dialogs
{
    partial class HelpDialog
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
            this.helpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // helpRichTextBox
            // 
            this.helpRichTextBox.BackColor = System.Drawing.Color.Honeydew;
            this.helpRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.helpRichTextBox.Name = "helpRichTextBox";
            this.helpRichTextBox.Size = new System.Drawing.Size(800, 450);
            this.helpRichTextBox.TabIndex = 0;
            this.helpRichTextBox.Text = "";
            // 
            // HelpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.helpRichTextBox);
            this.Name = "HelpDialog";
            this.Text = "Помощь";
            this.Load += new System.EventHandler(this.HelpDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox helpRichTextBox;
    }
}