namespace u3Toolbox
{
    partial class u3tbParamForm
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
            this.paramLabel = new System.Windows.Forms.Label();
            this.paramText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // paramLabel
            // 
            this.paramLabel.AutoSize = true;
            this.paramLabel.Location = new System.Drawing.Point(12, 9);
            this.paramLabel.Name = "paramLabel";
            this.paramLabel.Size = new System.Drawing.Size(35, 13);
            this.paramLabel.TabIndex = 0;
            this.paramLabel.Text = "label1";
            // 
            // paramText
            // 
            this.paramText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paramText.Location = new System.Drawing.Point(15, 25);
            this.paramText.Name = "paramText";
            this.paramText.Size = new System.Drawing.Size(257, 20);
            this.paramText.TabIndex = 1;
            this.paramText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paramText_KeyDown);
            // 
            // u3tbParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 59);
            this.Controls.Add(this.paramText);
            this.Controls.Add(this.paramLabel);
            this.Name = "u3tbParamForm";
            this.Text = "u3tbParamForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label paramLabel;
        public System.Windows.Forms.TextBox paramText;

    }
}