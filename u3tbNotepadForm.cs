using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace u3Toolbox
{
    public partial class u3tbNotepadForm : Form
    {
        public int NOTEPAD_AUTOSAVE_INTERVAL = 3000;
        public string filename;
        public int toolboxPosition = -1;
        public u3tbMainForm mainForm = null;
        private System.Windows.Forms.Timer modifyTimer;
        public Boolean isSaving = false;

        public u3tbNotepadForm()
        {
            InitializeComponent();
            modifyTimer = new System.Windows.Forms.Timer();
            modifyTimer.Interval = NOTEPAD_AUTOSAVE_INTERVAL;
            modifyTimer.Tick += new EventHandler(modifyTimer_Tick);
        }

        private void u3tbNotepadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveGeometry();
            while (isSaving) Thread.Sleep(100);
            if (notepadText.Modified)
                saveFile();
            modifyTimer.Stop();
        }

        private void u3tbNotepadForm_Load(object sender, EventArgs e)
        {
            fillColorsList();
            cbFontFamily.LoadFontFamilies();
            updateStyleButtons();
            updateFontComboBoxes();            
            this.KeyPreview = true;
        }

        private void fillColorsList()
        {
            cbFontColor.Items.Add("Black");
            cbFontColor.Items.Add("DarkGray");
            cbFontColor.Items.Add("LightGray");
            cbFontColor.Items.Add("White");
            cbFontColor.Items.Add("Red");
            cbFontColor.Items.Add("Blue");
            cbFontColor.Items.Add("DarkGreen");
            cbFontColor.ComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            cbFontColor.ComboBox.DrawItem += new DrawItemEventHandler(cbFontColor_DrawItem);
        }

        private void u3tbNotepadForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && Control.ModifierKeys == Keys.Control)
                btnFormatBold.PerformClick();
            if (e.KeyCode == Keys.I && Control.ModifierKeys == Keys.Control)
            {
                btnFormatItalic.PerformClick();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.U && Control.ModifierKeys == Keys.Control)
                btnFormatUnderline.PerformClick();
        }

        void cbFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 70, rect.Y + 2, rect.Width - 10, rect.Height - 2);
            }
        }

        private void saveGeometry()
        {
            if (System.Windows.Forms.Application.OpenForms["u3tbMainForm"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["u3tbMainForm"] as u3tbMainForm).saveNotepadGeometry(
                    toolboxPosition,
                    this.DesktopBounds.Location,
                    this.DesktopBounds.Size);
            }
        }

        private void saveFile()
        {
            try
            {
                isSaving = true;
                notepadText.SaveFile(filename);
                notepadText.Modified = false;
                isSaving = false;
            }
            catch
            {
                MessageBox.Show("u3Toolbox couldn't write to the file.", "u3Toolbox notepad");
            }
        }

        private void modifyTimer_Tick(object sender, EventArgs e)
        {
            modifyTimer.Stop();
            saveFile();
        }

        private void notepadText_ModifiedChanged(object sender, EventArgs e)
        {
            modifyTimer.Start();
        }

        private void btnFormatBold_Click(object sender, EventArgs e)
        {
            changeStyle();
        }

        private void btnFormatItalic_Click(object sender, EventArgs e)
        {
            changeStyle();
        }

        private void btnFormatStrikeout_Click(object sender, EventArgs e)
        {
            changeStyle();
        }

        private void btnFormatUnderline_Click(object sender, EventArgs e)
        {
            changeStyle();
        }

        private void changeStyle()
        {
            FontStyle style = FontStyle.Regular;
            if (btnFormatBold.Checked)
                style |= FontStyle.Bold;
            if (btnFormatItalic.Checked)
                style |= FontStyle.Italic;
            if (btnFormatStrikeout.Checked)
                style |= FontStyle.Strikeout;
            if (btnFormatUnderline.Checked)
                style |= FontStyle.Underline;

            notepadText.SelectionFont = new Font(notepadText.SelectionFont, style);
        }

        private void updateStyleButtons()
        {
            FontStyle style = notepadText.SelectionFont.Style;
            bool bold = false;
            bool italic = false;
            bool strikeout = false;
            bool underline = false;
            if (style.HasFlag(FontStyle.Bold))
                bold = true;
            if (style.HasFlag(FontStyle.Italic))
                italic = true;
            if (style.HasFlag(FontStyle.Strikeout))
                strikeout = true;
            if (style.HasFlag(FontStyle.Underline))
                underline = true;

            btnFormatBold.Checked = bold;
            btnFormatItalic.Checked = italic;
            btnFormatStrikeout.Checked = strikeout;
            btnFormatUnderline.Checked = underline;
        }

        private void updateFontComboBoxes()
        {
            string name = notepadText.SelectionFont.FontFamily.Name;
            float size = notepadText.SelectionFont.Size;
            //cbFontFamily.SelectedIndex = cbFontFamily.FindStringExact(name);
            cbFontFamily.Text = name;
            cbFontSize.SelectedIndex = cbFontSize.FindStringExact(Convert.ToString(size));
            cbFontSize.Text = Convert.ToString(size);
        }

        private void notepadText_SelectionChanged(object sender, EventArgs e)
        {
            updateStyleButtons();
            updateFontComboBoxes();            
        }

        private void cbFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            notepadText.SelectionFont = new Font(
                cbFontFamily.Text,
                notepadText.SelectionFont.Size,
                notepadText.SelectionFont.Style);
            notepadText.Focus();
        }

        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            string name = notepadText.SelectionFont.Name;
            FontStyle style = notepadText.SelectionFont.Style;
            float size = 10;
            try
            {
                size = float.Parse(cbFontSize.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
            }
            catch
            {                
            }
            notepadText.SelectionFont = new Font(name, size, style);
            notepadText.Focus();
        }

        private void cbFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(cbFontColor.Text);
            notepadText.SelectionColor = color;
            notepadText.Focus();
        }

    }
}
