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
