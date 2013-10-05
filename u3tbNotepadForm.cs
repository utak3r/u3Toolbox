using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace u3Toolbox
{
    public partial class u3tbNotepadForm : Form
    {
        public int NOTEPAD_AUTOSAVE_INTERVAL = 3000;
        public string filename;
        private Timer modifyTimer;

        public u3tbNotepadForm()
        {
            InitializeComponent();
            modifyTimer = new Timer();
            modifyTimer.Interval = NOTEPAD_AUTOSAVE_INTERVAL;
            modifyTimer.Tick += new EventHandler(modifyTimer_Tick);
        }

        private void modifyTimer_Tick(object sender, EventArgs e)
        {
            modifyTimer.Stop();
            try
            {
                notepadText.SaveFile(filename);
                notepadText.Modified = false;
            }
            catch
            {
                MessageBox.Show("u3Toolbox couldn't write to the file.", "u3Toolbox notepad");
            }
        }

        private void notepadText_ModifiedChanged(object sender, EventArgs e)
        {
            modifyTimer.Start();
        }

    }
}
