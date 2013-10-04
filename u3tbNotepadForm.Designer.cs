namespace u3Toolbox
{
    partial class u3tbNotepadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(u3tbNotepadForm));
            this.notepadText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // notepadText
            // 
            this.notepadText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notepadText.Location = new System.Drawing.Point(0, 0);
            this.notepadText.Multiline = true;
            this.notepadText.Name = "notepadText";
            this.notepadText.Size = new System.Drawing.Size(378, 343);
            this.notepadText.TabIndex = 0;
            this.notepadText.ModifiedChanged += new System.EventHandler(this.notepadText_ModifiedChanged);
            // 
            // u3tbNotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 343);
            this.Controls.Add(this.notepadText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "u3tbNotepadForm";
            this.ShowIcon = false;
            this.Text = "u3tbNotepadForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox notepadText;

    }
}