using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace u3Toolbox
{

    public enum u3tbButtonType
    {
        ButtonCommand = 1,
        ButtonNotepad
    }

    public struct u3tbButton
    {
        public u3tbButtonType type;
        public string title;
        public string command;
        public string param1;
    }

    public partial class u3tbMainForm : Form
    {
        public List<u3tbButton> buttonsList;


        public u3tbMainForm()
        {
            InitializeComponent();
        }

        private void u3tbMainForm_Load(object sender, EventArgs e)
        {
            u3tbLoadConfig();
            createButtons();
        }

        private void u3tbMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form wnd in Application.OpenForms)
            {
                //wnd.Close();
            }
        }

        private void u3tbLoadConfig()
        {
            XmlDocument cfg = new XmlDocument();
            cfg.Load(AppDomain.CurrentDomain.BaseDirectory + "\\u3ToolboxCfg.xml");
            buttonsList = new List<u3tbButton>();

            foreach (XmlNode node in cfg.SelectNodes("u3Toolbox/Buttons/Button"))
            {
                u3tbButton button = new u3tbButton();
                try
                {
                    button.title = node.Attributes["title"].InnerText;
                }
                catch
                {
                    continue;
                }
                string type = "";
                try
                {
                    type = node.Attributes["type"].InnerText;
                }
                catch
                {
                    type = "";
                }
                switch (type)
                {
                    case "command":
                        button.type = u3tbButtonType.ButtonCommand;
                        break;
                    case "notepad":
                        button.type = u3tbButtonType.ButtonNotepad;
                        break;
                    default:
                        button.type = u3tbButtonType.ButtonCommand;
                        break;
                }

                switch (button.type)
                {
                    case u3tbButtonType.ButtonCommand:
                        try
                        {
                            button.command = node.Attributes["cmd"].InnerText;
                        }
                        catch
                        {
                            button.command = "";
                        }
                        try
                        {
                            button.param1 = node.Attributes["param1"].InnerText;
                        }
                        catch
                        {
                            button.param1 = "";
                        }
                        break;
                    case u3tbButtonType.ButtonNotepad:
                        break;
                }
                
                if (button.title != "")
                    buttonsList.Add(button);
            }
        }

        private void createButtons()
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                Button newButton = new Button();
                newButton.Tag = i;
                newButton.Size = new Size(buttonsPanel.Width - 8, 26);
                newButton.Location = new Point(4, 4 + 32*i);
                newButton.Text = buttonsList[i].title;
                newButton.Click += button_Click;
                newButton.FlatStyle = FlatStyle.Popup;
                buttonsPanel.Controls.Add(newButton);
            }
            this.Height = 32 * (buttonsList.Count + 1) + 8;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int i = (int)button.Tag;
            u3tbButtonType type = buttonsList[i].type;

            switch (type)
            {
                case u3tbButtonType.ButtonCommand:
                    string cmd = buttonsList[i].command;
                    string paramtitle = buttonsList[i].param1;
                    string param = "";

                    if (paramtitle != "")
                    {
                        u3tbParamForm dlg = new u3tbParamForm();
                        dlg.paramLabel.Text = paramtitle;
                        dlg.paramText.Text = "";
                        dlg.ShowDialog();
                        if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                            param = dlg.paramText.Text;
                        else
                            return;
                        dlg.Dispose();
                    }

                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/c " + cmd;
                    if (param != "")
                    {
                        process.StartInfo.Arguments += " " + param;
                    }
                    process.Start();
                    //process.WaitForExit();
                    break;
                case u3tbButtonType.ButtonNotepad:
                    string title = buttonsList[i].title;
                    string filename = AppDomain.CurrentDomain.BaseDirectory + "\\" + no_spaces(title) + ".rtf";

                    u3tbNotepadForm notepad = new u3tbNotepadForm();
                    notepad.Text = title;
                    notepad.notepadText.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);

                    if (File.Exists(filename))
                    {
                        try
                        {
                            notepad.notepadText.LoadFile(filename);
                        }
                        catch
                        {
                            MessageBox.Show("Couldn't recognize file format, while trying to load a note!", "u3Toolbox notepad");
                        }
                    }
                    notepad.filename = filename;
                    notepad.Show();
                    notepad.notepadText.DeselectAll();
                    break;
            }

        }

        public string no_spaces(string badstring)
        {
            return badstring.Replace(" ", "_");
        }

    }
}
