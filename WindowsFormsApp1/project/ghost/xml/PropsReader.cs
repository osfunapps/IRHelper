using System;
using System.Windows.Forms;
using System.Xml;

namespace LayoutProject.program
{
    internal class PropsReader
    {
        private string ATT_PROPERTIES = "props";
        private string ERROR_MSG = "CANT DETERMINE REMOTE TYPE! CONFIG FILE CORRUPTED. \nEXITING...";

        public string GetRemoteType(XmlDocument document)
        {

            var propsPapa = document.GetElementsByTagName(ATT_PROPERTIES)[0];
            if(propsPapa != null)
            foreach (XmlElement prop in propsPapa.ChildNodes)
            {
                if (prop.Attributes["remote_type"] != null)
                {
                    return prop.Attributes["remote_type"].Value;
                }
            }

            MessageBox.Show(ERROR_MSG);
            Application.Exit();
            Environment.Exit(0);
            return null;
        }
    }
}