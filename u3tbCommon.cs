using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace u3Toolbox
{
    public enum u3tbButtonType
    {
        ButtonCommand = 1,
        ButtonNotepad
    }

    public class u3tbButton
    {
        public u3tbButtonType type;
        public u3tbWndProperties wndProperties;
        public string title { get; set; }
        public string command { get; set; }
        public string param1 { get; set; }

        //! for displaying in lists
        public override string ToString()
        {
            return title;
        }

        //! for creating a filename from a title
        public string title_no_spaces()
        {
            return title.Replace(" ", "_");
        }
    }

    public class u3tbWndProperties
    {
        public u3tbWndProperties(int x, int y, int width, int height)
        {
            location = new Point(x, y);
            size = new Size(width, height);
        }

        public u3tbWndProperties(System.Drawing.Point aLocation, System.Drawing.Size aSize)
        {
            location = aLocation;
            size = aSize;
        }

        public System.Drawing.Point location { get; set; }
        public System.Drawing.Size size { get; set; }

        //! construct XML attributes string
        public string XmlString()
        {
            return
                "left=\"" + location.X + "\" " +
                "top=\"" + location.Y + "\" " +
                "width=\"" + size.Width + "\" " +
                "height=\"" + size.Height + "\" ";
        }
    }

    public class u3tbStyle
    {
        private System.Drawing.Color gradientColor1;
        private System.Drawing.Color gradientColor2;
        private System.Drawing.Color frameColor;
        private System.Drawing.Color textColor;
        private System.Drawing.FontStyle textFontStyle;

        public enum style
        {
            DarkGreys = 1,
            LightGreys,
            LightBlues
        }

        private style currentStyle;

        public u3tbStyle()
        {
            setCurrentStyle(style.DarkGreys);
        }

        public u3tbStyle(style aStyle)
        {
            setCurrentStyle(aStyle);
        }

        public string currentStyleName()
        {
            string name = "";
            switch (currentStyle)
            {
                case style.DarkGreys:
                    name = "DarkGreys";
                    break;
                case style.LightGreys:
                    name = "LightGreys";
                    break;
                case style.LightBlues:
                    name = "LightBlues";
                    break;
            }
            return name;
        }

        public style findStyleFromName(string name)
        {
            style foundStyle = style.LightGreys;
            if (name == "DarkGreys")
                foundStyle = style.DarkGreys;
            if (name == "LightGreys")
                foundStyle = style.LightGreys;
            if (name == "LightBlues")
                foundStyle = style.LightBlues;
            return foundStyle;
        }

        public void setCurrentStyle(style aStyle)
        {
            currentStyle = aStyle;
            switch (currentStyle)
            {
                case style.DarkGreys:
                    gradientColor1 = Color.FromArgb(150, 150, 150);
                    gradientColor2 = Color.FromArgb(90, 90, 90);
                    frameColor = Color.WhiteSmoke;
                    textColor = Color.WhiteSmoke;
                    textFontStyle = FontStyle.Bold;
                    break;
                case style.LightGreys:
                    gradientColor1 = Color.FromArgb(220, 220, 220);
                    gradientColor2 = Color.FromArgb(140, 140, 140);
                    frameColor = Color.WhiteSmoke;
                    textColor = Color.Black;
                    textFontStyle = FontStyle.Regular;
                    break;
                case style.LightBlues:
                    gradientColor1 = Color.FromArgb(249, 252, 254);
                    gradientColor2 = Color.FromArgb(220, 231, 245);
                    frameColor = Color.Black;
                    textColor = Color.Black;
                    textFontStyle = FontStyle.Regular;
                    break;
            }
        }

        public System.Drawing.Color getGradientColor1() { return gradientColor1; }
        public System.Drawing.Color getGradientColor2() { return gradientColor2; }
        public System.Drawing.Color getFrameColor() { return frameColor; }
        public System.Drawing.Color getTextColor() { return textColor; }
        public System.Drawing.FontStyle getTextFontStyle() { return textFontStyle; }
    }

    public static class u3tbUtilities
    {
        public static string getHomePath()
        {
            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            try
            {
                if (!Directory.Exists(homePath + "\\.u3ToolBox"))
                {
                    Directory.CreateDirectory(homePath + "\\.u3ToolBox");
                }
                homePath += "\\.u3ToolBox";
            }
            catch
            {
                homePath = AppDomain.CurrentDomain.BaseDirectory;
            }
            return homePath;
        }

        public static string getMyDocumentsPath()
        {
            return (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }

}
