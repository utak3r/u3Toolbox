﻿namespace u3Toolbox
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
            this.notepadText = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFormatBold = new System.Windows.Forms.ToolStripButton();
            this.btnFormatItalic = new System.Windows.Forms.ToolStripButton();
            this.btnFormatStrikeout = new System.Windows.Forms.ToolStripButton();
            this.btnFormatUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notepadText
            // 
            this.notepadText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notepadText.Location = new System.Drawing.Point(0, 28);
            this.notepadText.Name = "notepadText";
            this.notepadText.Size = new System.Drawing.Size(260, 221);
            this.notepadText.TabIndex = 1;
            this.notepadText.Text = "";
            this.notepadText.SelectionChanged += new System.EventHandler(this.notepadText_SelectionChanged);
            this.notepadText.ModifiedChanged += new System.EventHandler(this.notepadText_ModifiedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFormatBold,
            this.btnFormatItalic,
            this.btnFormatStrikeout,
            this.btnFormatUnderline});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(260, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFormatBold
            // 
            this.btnFormatBold.CheckOnClick = true;
            this.btnFormatBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFormatBold.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatBold.Image")));
            this.btnFormatBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFormatBold.Name = "btnFormatBold";
            this.btnFormatBold.Size = new System.Drawing.Size(23, 22);
            this.btnFormatBold.Text = "Bold";
            this.btnFormatBold.Click += new System.EventHandler(this.btnFormatBold_Click);
            // 
            // btnFormatItalic
            // 
            this.btnFormatItalic.CheckOnClick = true;
            this.btnFormatItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFormatItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatItalic.Image")));
            this.btnFormatItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFormatItalic.Name = "btnFormatItalic";
            this.btnFormatItalic.Size = new System.Drawing.Size(23, 22);
            this.btnFormatItalic.Text = "Italic";
            this.btnFormatItalic.Click += new System.EventHandler(this.btnFormatItalic_Click);
            // 
            // btnFormatStrikeout
            // 
            this.btnFormatStrikeout.CheckOnClick = true;
            this.btnFormatStrikeout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFormatStrikeout.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatStrikeout.Image")));
            this.btnFormatStrikeout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFormatStrikeout.Name = "btnFormatStrikeout";
            this.btnFormatStrikeout.Size = new System.Drawing.Size(23, 22);
            this.btnFormatStrikeout.Text = "Striked out";
            this.btnFormatStrikeout.Click += new System.EventHandler(this.btnFormatStrikeout_Click);
            // 
            // btnFormatUnderline
            // 
            this.btnFormatUnderline.CheckOnClick = true;
            this.btnFormatUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFormatUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnFormatUnderline.Image")));
            this.btnFormatUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFormatUnderline.Name = "btnFormatUnderline";
            this.btnFormatUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnFormatUnderline.Text = "Underlined";
            this.btnFormatUnderline.Click += new System.EventHandler(this.btnFormatUnderline_Click);
            // 
            // u3tbNotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 249);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.notepadText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 170);
            this.Name = "u3tbNotepadForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "u3tbNotepadForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.u3tbNotepadForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox notepadText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFormatBold;
        private System.Windows.Forms.ToolStripButton btnFormatItalic;
        private System.Windows.Forms.ToolStripButton btnFormatStrikeout;
        private System.Windows.Forms.ToolStripButton btnFormatUnderline;

    }
}