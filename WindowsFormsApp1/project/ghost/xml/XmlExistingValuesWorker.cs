using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LayoutProject.program;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApp1.project.ghost.xml
{
    class XmlExistingValuesWorker
    {
        //make a list of hexes
        //change counter to last element of list 1
        //make a list of non hexes
        //migrate this boths lists and put the non hexed at the end. set them to be papakeynode

        internal XmlNodeList GetModifiedList(XMLModifier xMLModifier, XmlNode papaKeyNode)
        {
            List<XmlNode> hexedList = new List<XmlNode>();
            List<XmlNode> emptyHexedList = new List<XmlNode>();
            int papaChildsCount = papaKeyNode.ChildNodes.Count;

            foreach (XmlNode keyNode in papaKeyNode.ChildNodes)
            {
                if (!keyNode.InnerText.Equals(""))
                    hexedList.Add(keyNode.CloneNode(true));
                else
                    emptyHexedList.Add(keyNode.CloneNode(true));

            }

            if (emptyHexedList.Count == 0)
                Application.Exit();


            xMLModifier.SetNodeIdx(hexedList.Count);
            papaKeyNode.RemoveAll();

            foreach (XmlNode keyXmlNode in hexedList)
            {
                papaKeyNode.AppendChild(keyXmlNode.CloneNode(true));
            }

            foreach (XmlNode keyXmlNode in emptyHexedList)
            {
                papaKeyNode.AppendChild(keyXmlNode.CloneNode(true));
            }

            return papaKeyNode.ChildNodes;
        }
    }
}