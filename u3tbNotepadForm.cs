﻿using System;
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
            fillFontsList();
        }

        private void fillFontsList()
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                cbFontFamily.Items.Add(font.Name);
            }
            cbFontFamily.SelectedIndex = cbFontFamily.FindStringExact(notepadText.Font.Name);
            cbFontSize.SelectedIndex = cbFontSize.FindStringExact(Convert.ToString(notepadText.Font.Size));
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
            string name = notepadText.SelectionFont.Name;
            float size = notepadText.SelectionFont.Size;
            cbFontFamily.SelectedIndex = cbFontFamily.FindStringExact(name);
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
            if (cbFontFamily.Text != "")
            {
                FontStyle style = notepadText.SelectionFont.Style;
                float size = notepadText.SelectionFont.Size;
                notepadText.SelectionFont = new Font(
                    cbFontFamily.Text, 
                    size, style);
                notepadText.Focus();
            }
        }

        private void cbFontSize_TextChanged(object sender, EventArgs e)
        {
            string name = notepadText.SelectionFont.Name;
            FontStyle style = notepadText.SelectionFont.Style;
            float size = float.Parse(cbFontSize.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
            notepadText.SelectionFont = new Font(name, size, style);
            notepadText.Focus();
        }

    }
}
