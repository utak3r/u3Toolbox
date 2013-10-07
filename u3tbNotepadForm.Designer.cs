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
            this.notepadText = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFormatBold = new System.Windows.Forms.ToolStripButton();
            this.btnFormatItalic = new System.Windows.Forms.ToolStripButton();
            this.btnFormatStrikeout = new System.Windows.Forms.ToolStripButton();
            this.btnFormatUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbFontFamily = new u3Toolbox.u3FontComboBox();
            this.cbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cbFontColor = new System.Windows.Forms.ToolStripComboBox();
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
            this.notepadText.Size = new System.Drawing.Size(595, 221);
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
            this.btnFormatUnderline,
            this.toolStripSeparator1,
            this.cbFontFamily,
            this.cbFontSize,
            this.toolStripSeparator2,
            this.cbFontColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(595, 25);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cbFontFamily
            // 
            this.cbFontFamily.DropDownWidth = 180;
            this.cbFontFamily.MaxDropDownItems = 16;
            this.cbFontFamily.Name = "cbFontFamily";
            this.cbFontFamily.Size = new System.Drawing.Size(121, 25);
            this.cbFontFamily.SelectedIndexChanged += new System.EventHandler(this.cbFontFamily_SelectedIndexChanged);
            // 
            // cbFontSize
            // 
            this.cbFontSize.AutoSize = false;
            this.cbFontSize.DropDownWidth = 40;
            this.cbFontSize.Items.AddRange(new object[] {
            "6",
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(35, 23);
            this.cbFontSize.TextChanged += new System.EventHandler(this.cbFontSize_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cbFontColor
            // 
            this.cbFontColor.AutoSize = false;
            this.cbFontColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontColor.DropDownWidth = 250;
            this.cbFontColor.Name = "cbFontColor";
            this.cbFontColor.Size = new System.Drawing.Size(50, 23);
            this.cbFontColor.SelectedIndexChanged += new System.EventHandler(this.cbFontColor_SelectedIndexChanged);
            // 
            // u3tbNotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 249);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.notepadText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 170);
            this.Name = "u3tbNotepadForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "u3tbNotepadForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.u3tbNotepadForm_FormClosing);
            this.Load += new System.EventHandler(this.u3tbNotepadForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.u3tbNotepadForm_KeyDown);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cbFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cbFontColor;
        private u3FontComboBox cbFontFamily;

    }
}