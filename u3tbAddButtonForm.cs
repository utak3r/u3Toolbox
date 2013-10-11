using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace u3Toolbox
{
    public partial class u3tbAddButtonForm : Form
    {
        public u3tbAddButtonForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialogNew()
        {
            cbType.Items.Clear();
            cbType.Items.Add("Command");
            cbType.Items.Add("Notepad");
            cbType.SelectedIndex = 0;
            textTitle.Text = "New command";

            return ShowDialog();
        }

        public DialogResult ShowDialogEdit(u3tbButton button)
        {
            cbType.Items.Clear();
            cbType.Items.Add("Command");
            cbType.Items.Add("Notepad");

            textTitle.Text = button.title;
            switch (button.type)
            {
                case u3tbButtonType.ButtonCommand:
                    cbType.SelectedIndex = cbType.FindStringExact("Command");
                    textCommand.Text = button.command;
                    textParam1.Text = button.param1;
                    break;
                case u3tbButtonType.ButtonNotepad:
                    cbType.SelectedIndex = cbType.FindStringExact("Notepad");
                    break;
            }
            
            return ShowDialog();
        }

        private void u3tbAddButtonForm_Load(object sender, EventArgs e)
        {
            textTitle.Focus();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.Text == "Command")
            {
                lblCommand.Show();
                textCommand.Show();
                lblParam1.Show();
                textParam1.Show();
            }
            if (cbType.Text == "Notepad")
            {
                lblCommand.Hide();
                textCommand.Hide();
                lblParam1.Hide();
                textParam1.Hide();
            }
        }

        private void u3tbAddButtonForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
