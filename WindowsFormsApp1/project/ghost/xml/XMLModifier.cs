using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WindowsFormsApp1;
using WindowsFormsApp1.project.ghost.xml;

namespace LayoutProject.program
{
    class XMLModifier
    {

        //instances
        private IXMLModifierCallback xmlReaderCallback;
        private XmlDocument xmlDocument;

        //finals
        private string ATT_KEYS = "keys";
        private static string ATT_NAME = "name";

        //nodes list 
        private XmlNodeList keysNodesList;
        private int nodeIdx;
        public static string xmlPath;
        private XmlNode papaKeyNode;

        public XMLModifier(IXMLModifierCallback callback)
        {
            xmlReaderCallback = callback;
            nodeIdx = 0;
        }

        internal void ReadXMLPath(string xmlPath)
        {
            XMLModifier.xmlPath = xmlPath;
            xmlDocument = new XmlDocument();
            xmlDocument.Load(@xmlPath);
            papaKeyNode = xmlDocument.GetElementsByTagName(ATT_KEYS)[0];
            if (AppForm.startOver)
                keysNodesList = papaKeyNode.ChildNodes;
            else {
                XmlExistingValuesWorker xmlWorker = new XmlExistingValuesWorker();
                keysNodesList = xmlWorker.GetModifiedList(this, papaKeyNode);
            }

        }


        internal void SetNextNodeVal(string nextNodeVal)
        {
            keysNodesList[nodeIdx].InnerText = nextNodeVal;
            xmlDocument.Save(xmlPath);
            nodeIdx++;

            if (nodeIdx == keysNodesList.Count)
            {
                xmlReaderCallback.OnAllNodesSet(xmlDocument);
                return;
            }

            xmlReaderCallback.OnNodeValSet();
        }

        /** this method will return true if reached to the end of the list and skipped a val, false otherwise **/
        internal bool SkipNextValAndFinish()
        {
            papaKeyNode.RemoveChild(keysNodesList[nodeIdx]);
            xmlDocument.Save(xmlPath);

            if (nodeIdx == keysNodesList.Count)
            {
                xmlReaderCallback.OnAllNodesSet(xmlDocument);
                return true;
            }

            return false;
            //xmlReaderCallback.OnNodeValSet();
        }

        internal void ClearAllValues()
        {
            for (int i = 0; i < keysNodesList.Count; i++)
            {
                keysNodesList[i].InnerText = "";
            }
            xmlDocument.Save(xmlPath);
        }

        internal string GetNextValName()
        {
            return keysNodesList[nodeIdx].Attributes[ATT_NAME].Value;
        }


        internal void SetNodeIdx(int nodeIdx)
        {
            this.nodeIdx = nodeIdx;
        }


        public interface IXMLModifierCallback
        {
            void OnAllNodesSet(XmlDocument document);
            void OnNodeValSet();
        }

        public void ClearPreviousVal()
        {
            if(nodeIdx==0)return;
            nodeIdx--;
        }
    }
}
