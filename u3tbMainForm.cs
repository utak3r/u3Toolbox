using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace u3Toolbox
{

    public partial class u3tbMainForm : Form
    {
        public List<u3tbButton> buttonsList;
        public u3tbStyle appStyle;

        public u3tbMainForm()
        {
            InitializeComponent();
        }

        private void u3tbMainForm_Load(object sender, EventArgs e)
        {
            appStyle = new u3tbStyle(u3tbStyle.style.Steel);
            u3tbLoadConfig();
            createButtons();
            buttonsPanel.Paint += new PaintEventHandler(buttonsPanel_Paint);
            toolBar.Paint += new PaintEventHandler(toolBar_Paint);
        }

        private void u3tbMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i > 0; i--)
            {
                if (Application.OpenForms[i] != null)
                    Application.OpenForms[i].Close();
            }
            saveConfig();
            e.Cancel = false;
        }

        private void u3tbLoadConfig()
        {
            XmlDocument cfg = new XmlDocument();
            try
            {
                cfg.Load(u3tbUtilities.getHomePath() + "\\u3ToolboxCfg.xml");
            }
            catch
            {
                return;
            }

            // main app preferencies
            XmlNode prefposnode = cfg.SelectSingleNode("u3Toolbox/Preferences/Position");
            if (prefposnode != null)
            {
                try
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.DesktopBounds = new Rectangle(
                        Convert.ToInt32(prefposnode.Attributes["left"].InnerText),
                        Convert.ToInt32(prefposnode.Attributes["top"].InnerText),
                        Convert.ToInt32(prefposnode.Attributes["width"].InnerText),
                        Convert.ToInt32(prefposnode.Attributes["height"].InnerText));
                }
                catch
                {
                    this.StartPosition = FormStartPosition.WindowsDefaultBounds;
                }
            }
            XmlNode prefstylenode = cfg.SelectSingleNode("u3Toolbox/Preferences/Style");
            if (prefstylenode != null)
            {
                try
                {
                    string style = prefstylenode.Attributes["name"].InnerText;
                    appStyle.setCurrentStyle(appStyle.findStyleFromName(style));
                }
                catch
                {
                }
            }

            // buttons list
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
                        try
                        {
                            int left = Convert.ToInt32(node.Attributes["left"].InnerText);
                            int top = Convert.ToInt32(node.Attributes["top"].InnerText);
                            int width = Convert.ToInt32(node.Attributes["width"].InnerText);
                            int height = Convert.ToInt32(node.Attributes["height"].InnerText);
                            button.wndProperties = new u3tbWndProperties(left, top, width, height);
                        }
                        catch
                        {
                        }
                        break;
                }
                
                if (button.title != "")
                    buttonsList.Add(button);
            }
        }

        private void createButtons()
        {
            if (buttonsList == null)
                return;

            for (int i = 0; i < buttonsPanel.Controls.Count; i++)
            {
                if (buttonsPanel.Controls[i] is Button)
                {
                    Button button = (Button)buttonsPanel.Controls[i];
                    button.Click -= button_Click;
                    buttonsPanel.Controls.Remove(buttonsPanel.Controls[i]);
                    button.Dispose();
                    // we're modifying the list, which we're iterating! 
                    // step backwards, so we won't miss anything...
                    i--;
                }
                this.Refresh();
            }

            for (int i = 0; i < buttonsList.Count; i++)
            {
                Button newButton = new Button();
                newButton.Tag = i;
                newButton.Size = new Size(buttonsPanel.Width - 8, 26);
                newButton.Location = new Point(4, 4 + 32*i);
                newButton.Text = buttonsList[i].title;
                newButton.Click += button_Click;
                newButton.Paint += new PaintEventHandler(button_Paint);
                //newButton.FlatStyle = FlatStyle.Popup;
                buttonsPanel.Controls.Add(newButton);
            }
            this.Height = 32 * (buttonsList.Count + 1) + 8 + 25;
            this.Refresh();
        }

        private void saveConfig()
        {
            string cfgString = "<u3Toolbox>\r\n";

            string prefString = savePreferences();
            string buttonsString = "\t<Buttons>\r\n";
            if ((buttonsList == null) || (buttonsList.Count == 0))
                return;
            foreach (u3tbButton button in buttonsList)
            {
                buttonsString += "\t\t" + saveButton(button) + "\r\n";
            }
            buttonsString += "\t</Buttons>\r\n";

            cfgString += prefString + buttonsString + "</u3Toolbox>\r\n";

            System.IO.File.WriteAllText(
                u3tbUtilities.getHomePath() + "\\u3ToolboxCfg.xml",
                cfgString);
        }

        private string savePreferences()
        {
            string position = 
                "\t\t<Position left=\"" + this.DesktopBounds.Location.X + "\" " +
                "top=\"" + this.DesktopBounds.Location.Y + "\" " +
                "width=\"" + this.DesktopBounds.Size.Width + "\" " +
                "height=\"" + this.DesktopBounds.Size.Height + "\" />\r\n";

            string style =
                "\t\t<!-- Possible styles currently are: " + appStyle.stylesListCommaSeparated() + " -->\r\n" +
                "\t\t<Style name=\"" + appStyle.currentStyleName() + "\" />\r\n";

            return "\t<Preferences>\r\n" + 
                position + 
                style +
                "\t</Preferences>\r\n";
        }

        private string saveButton(u3tbButton button)
        {
            string buttonString = "<Button title=\"" + button.title + "\" ";
            switch (button.type)
            {
                case u3tbButtonType.ButtonCommand:
                    buttonString += "type=\"command\" ";
                    buttonString += "cmd=\"" + button.command + "\" ";
                    if (button.param1 != "")
                        buttonString += "param1=\"" + button.param1 + "\" ";
                    break;
                case u3tbButtonType.ButtonNotepad:
                    buttonString += "type=\"notepad\" ";
                    if (button.wndProperties != null)
                        buttonString += button.wndProperties.XmlString();
                    break;
            }
            buttonString += "/>";
            return buttonString;
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
                    break;
                case u3tbButtonType.ButtonNotepad:
                    string title = buttonsList[i].title;
                    string filename = u3tbUtilities.getHomePath() + "\\" + buttonsList[i].title_no_spaces() + ".rtf";

                    foreach (Form wnd in Application.OpenForms)
                    {
                        if (wnd.Text == title)
                        {
                            wnd.Focus();
                            return;
                        }
                    }

                    u3tbNotepadForm notepad = new u3tbNotepadForm();
                    notepad.mainForm = this;
                    notepad.toolboxPosition = i;
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
                    if (buttonsList[i].wndProperties != null)
                    {
                        try
                        {
                            notepad.StartPosition = FormStartPosition.Manual;
                            notepad.DesktopBounds = new Rectangle(
                                buttonsList[i].wndProperties.location,
                                buttonsList[i].wndProperties.size);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        buttonsList[i].wndProperties = new u3tbWndProperties(notepad.DesktopBounds.Location, notepad.DesktopBounds.Size);
                    }
                    notepad.Show();
                    notepad.notepadText.DeselectAll();
                    break;
            }

        }

        public void saveNotepadGeometry(int which, System.Drawing.Point location, System.Drawing.Size size)
        {
            buttonsList[which].wndProperties.location = location;
            buttonsList[which].wndProperties.size = size;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            u3tbAddButtonForm addDlg = new u3tbAddButtonForm();
            if (addDlg.ShowDialogNew() == System.Windows.Forms.DialogResult.OK)
            {
                u3tbButton button = new u3tbButton();
                button.title = addDlg.textTitle.Text;
                if (addDlg.cbType.Text == "Command")
                {
                    button.type = u3tbButtonType.ButtonCommand;
                    button.command = addDlg.textCommand.Text;
                    button.param1 = addDlg.textParam1.Text;
                }
                if (addDlg.cbType.Text == "Notepad")
                {
                    button.type = u3tbButtonType.ButtonNotepad;
                }
                if (buttonsList == null)
                    buttonsList = new List<u3tbButton>();
                buttonsList.Add(button);
                createButtons();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            u3tbChooseButton chooseDlg = new u3tbChooseButton();
            chooseDlg.lbButtonsList.Items.Clear();
            foreach (u3tbButton button in buttonsList)
            {
                chooseDlg.lbButtonsList.Items.Add(button);
            }
            if (chooseDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (chooseDlg.lbButtonsList.CheckedItems.Count > 0)
                {
                    foreach (u3tbButton button in chooseDlg.lbButtonsList.CheckedItems)
                    {
                        if (button.type == u3tbButtonType.ButtonNotepad)
                        {
                            if (File.Exists(u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf"))
                            {
                                switch (MessageBox.Show(
                                    "The file containing your note exists on the disk.\nDo you want to remove it?",
                                    "u3Toolbox",
                                    MessageBoxButtons.YesNoCancel))
                                {
                                    case System.Windows.Forms.DialogResult.Yes:
                                        switch (MessageBox.Show(
                                            "Are you sure you want to remove the file\n" + u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf ?",
                                            "u3Toolbox",
                                            MessageBoxButtons.YesNoCancel))
                                        {
                                            case System.Windows.Forms.DialogResult.Yes:
                                                try
                                                {
                                                    File.Delete(u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf");
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Couldn't delete the file\n" +
                                                        u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf\n" +
                                                        "Leaving it in its current location."
                                                        );
                                                }
                                                buttonsList.Remove(button);
                                                break;
                                            case System.Windows.Forms.DialogResult.No:
                                                continue;
                                            case System.Windows.Forms.DialogResult.Cancel:
                                                continue;
                                        }
                                        break;
                                    case System.Windows.Forms.DialogResult.No:
                                        switch (MessageBox.Show(
                                            "Preserving the file\n" + u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf\n" +
                                            "Do you want to move it to your documents folder?",
                                            "u3Toolbox",
                                            MessageBoxButtons.YesNoCancel))
                                        {
                                            case System.Windows.Forms.DialogResult.Yes:
                                                try
                                                {
                                                    File.Move(
                                                        u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf",
                                                        u3tbUtilities.getMyDocumentsPath() + "\\" + button.title_no_spaces() + ".rtf"
                                                        );
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Couldn't move the file\n" +
                                                        u3tbUtilities.getHomePath() + "\\" + button.title_no_spaces() + ".rtf\n" +
                                                        "to " + u3tbUtilities.getMyDocumentsPath() + "\\" + button.title_no_spaces() + ".rtf !\n" +
                                                        "Leaving it in its current location."
                                                        );
                                                }
                                                buttonsList.Remove(button);
                                                break;
                                            case System.Windows.Forms.DialogResult.No:
                                                buttonsList.Remove(button);
                                                break;
                                            case System.Windows.Forms.DialogResult.Cancel:
                                                continue;
                                        }
                                        break;
                                    case System.Windows.Forms.DialogResult.Cancel:
                                        continue;
                                }
                            }
                            else
                                buttonsList.Remove(button);
                        }
                        else
                            buttonsList.Remove(button);
                    }
                    createButtons();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            u3tbChooseButton chooseDlg = new u3tbChooseButton();
            chooseDlg.lbButtonsList.Items.Clear();
            foreach (u3tbButton button in buttonsList)
            {
                chooseDlg.lbButtonsList.Items.Add(button);
            }
            if (chooseDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (chooseDlg.lbButtonsList.CheckedItems.Count > 0)
                {
                    u3tbButton button = chooseDlg.lbButtonsList.CheckedItems[0] as u3tbButton;
                    int index = chooseDlg.lbButtonsList.CheckedIndices[0];
                    u3tbAddButtonForm addDlg = new u3tbAddButtonForm();
                    if (addDlg.ShowDialogEdit(button) == System.Windows.Forms.DialogResult.OK)
                    {
                        u3tbButton newButton = new u3tbButton();
                        newButton.title = addDlg.textTitle.Text;
                        if (addDlg.cbType.Text == "Command")
                        {
                            newButton.type = u3tbButtonType.ButtonCommand;
                            newButton.command = addDlg.textCommand.Text;
                            newButton.param1 = addDlg.textParam1.Text;
                        }
                        if (addDlg.cbType.Text == "Notepad")
                        {
                            newButton.type = u3tbButtonType.ButtonNotepad;
                        }
                        buttonsList.RemoveAt(index);
                        buttonsList.Insert(index, newButton);
                        createButtons();
                    }
                }
            }
        }

        void buttonsPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, appStyle.getGradientColor1(), appStyle.getGradientColor2(), LinearGradientMode.Vertical);
            g.FillRectangle(brush, rect);
        }

        void toolBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, toolBar.Size.Width, toolBar.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, appStyle.getGradientColor2(), appStyle.getGradientColor1(), LinearGradientMode.Vertical);
            g.FillRectangle(brush, rect);
        }

        void button_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Button))
                return;
            Graphics g = e.Graphics;
            Button button = sender as Button;
            Rectangle rect = new Rectangle(0, 0, button.Size.Width, button.Size.Height);
            
            // background
            g.FillRectangle(
                new LinearGradientBrush(rect, appStyle.getGradientColor1(), appStyle.getGradientColor2(), LinearGradientMode.Vertical),
                rect
                );

            // frame
            g.DrawRectangle(
                new Pen(appStyle.getFrameColor()), 
                new Rectangle(0, 0, button.Size.Width - 1, button.Size.Height - 1)
                );

            // text
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(
                button.Text, 
                new Font(button.Font, appStyle.getTextFontStyle()),
                new SolidBrush(appStyle.getTextColor()), 
                rect, 
                format
                );
        }


    }

}
