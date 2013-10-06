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

    }
}
