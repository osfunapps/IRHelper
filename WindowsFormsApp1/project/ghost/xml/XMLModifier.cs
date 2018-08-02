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
        private List<XmlNode> keysNodesList;
        private int nodeIdx;
        public static string xmlPath;
        private XmlNode papaKeyNode;
        private PropsReader propsReader;
        private string REMOTE_TYPE_NORMAL = "normal";
        private string REMOTE_TYPE_AC = "ac";

        public XMLModifier(IXMLModifierCallback callback)
        {
            xmlReaderCallback = callback;
            nodeIdx = 0;
            this.propsReader = new PropsReader();
        }

        internal void ReadXMLPath(string xmlPath, bool runOverValues)
        {
            XMLModifier.xmlPath = xmlPath;
            xmlDocument = new XmlDocument();
            xmlDocument.Load(@xmlPath);
            nodeIdx = 0;
            //here we will fetch the remote keys by the remote type.
            FetchRemoteKeysToRecord(runOverValues);
        }

        //todo: from here, we will need to think how to handle the ac remote and the other normal ones. We need to tell the system that
        //if it's an ac remote, then insert to the list only the btns which aren't behave as screen elements.
        private void FetchRemoteKeysToRecord(bool runOverValues)
        {
            
            var remoteType = propsReader.GetRemoteType(xmlDocument);

            papaKeyNode = xmlDocument.GetElementsByTagName(ATT_KEYS)[0];

            if (remoteType == REMOTE_TYPE_AC)
            {
                ACKeysFetcher acKeysFetcher = new ACKeysFetcher();
                keysNodesList = acKeysFetcher.FetchKeyNodes(papaKeyNode, runOverValues);
            }

            else if (remoteType == REMOTE_TYPE_NORMAL)
            {
                //check the type of the remote. Remember to remove the remote type 
                if (runOverValues)
                    keysNodesList = ChildNodesToListNodes(papaKeyNode);
                else
                {
                    XmlExistingValuesWorker xmlWorker = new XmlExistingValuesWorker();
                    var papsXml = xmlWorker.GetModifiedList(this, papaKeyNode);
                    keysNodesList = ChildNodesToListNodes(papsXml);
                }
            }

        }

        public static List<XmlNode> ChildNodesToListNodes(XmlNode xmlNode)
        {
            List<XmlNode> xmlNodeList = new List<XmlNode>();
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
             xmlNodeList.Add(node);   
            }
            return xmlNodeList;
        }

        internal void SetNextNodeVal(string nextNodeVal)
        {
            keysNodesList[nodeIdx].InnerText = nextNodeVal;
            xmlDocument.Save(xmlPath);
            nodeIdx++;

            if (nodeIdx == keysNodesList.Count)
            {
                nodeIdx = 0;
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
            if (nodeIdx == 0) return;
            nodeIdx--;
        }

        public void ClearCorruptNodesFromValues(List<string> corruptNodes)
        {
            foreach (string corruptNode in corruptNodes)
            {
                foreach (XmlNode xmlNode in keysNodesList)
                {
                    if (xmlNode.Attributes[ATT_NAME].Value == corruptNode) { 
                        xmlNode.InnerText = "";
                        break;
                    }
                }
            }

            nodeIdx = 0;
            xmlDocument.Save(xmlPath);
        }
    }
}