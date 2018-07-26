using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace LayoutProject.program
{
    internal class ACKeysFetcher
    {
        public List<XmlNode> FetchKeyNodes(XmlNode papaKeyNode, bool runOverValues)
        {

            List<XmlNode> nodesToAdd = new List<XmlNode>();
            List<XmlNode> restOfNodes = new List<XmlNode>();

            for (var i = 0; i < papaKeyNode.ChildNodes.Count; i++)
            {
                if (papaKeyNode.ChildNodes[i].Attributes["type"] == null)
                    continue;

                if (papaKeyNode.ChildNodes[i].Attributes["type"].Value == "hex")
                    nodesToAdd.Add(papaKeyNode.ChildNodes[i]);
                else
                    restOfNodes.Add(papaKeyNode.ChildNodes[i]);
            }

            //nodes to add, add all
            if (!runOverValues)
                nodesToAdd = FilterValueNodes(nodesToAdd, restOfNodes);

    //        papaKeyNode.RemoveAll();
//            AddNodesToParent(papaKeyNode, nodesToAdd);
//            XmlNodeList nodesList = papaKeyNode.ChildNodes;
  //          AddNodesToParent(papaKeyNode, restOfNodes);
            return nodesToAdd;

        }

        private void AddNodesToParent(XmlNode papaNode, List<XmlNode> nodesToAdd)
        {
            foreach (var node in nodesToAdd)
                papaNode.AppendChild(node);
        }

        private List<XmlNode> FilterValueNodes(List<XmlNode> nodesToAdd, List<XmlNode> restOfNodes)
        {
            for (int i = 0; i < nodesToAdd.Count; i++)
            {
                if (nodesToAdd[i].InnerText != "")
                {
                    restOfNodes.Add(nodesToAdd[i]);
                    nodesToAdd.RemoveAt(i);
                    i--;
                }
            }
            return nodesToAdd;
        }
    }
}