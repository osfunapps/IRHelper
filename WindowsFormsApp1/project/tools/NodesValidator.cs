using System;
using System.Linq;
using System.Xml;
using LayoutProject.program;

namespace WindowsFormsApp1
{
    internal class NodesValidator
    {

        private double AVERAGE_FACTOR = 0.8;
        private int MINIMUM_NODE_LENGTH = 50;


        private string ATT_KEYS = "keys";


        public bool AreAllNodesValidated(XmlDocument xmlDocument)
        {

            XmlNode papaKeyNode = xmlDocument.GetElementsByTagName(ATT_KEYS)[0];
            XmlNodeList nodesList = papaKeyNode.ChildNodes;


            //create a list of all of the keys lengths
            var lengthsList = GetLengthsList(nodesList);

            //take avarage
            var avarage = Average(lengthsList);

            //remove smaller values
            var containsCorruptNodes = false;
            foreach (XmlNode node in nodesList)
            {
                var nodeLength = node.InnerText.Length;
                if (LengthIsBelowAverage(nodeLength, Average()) || 
                    LengthIsSmallerThenMinimum(nodeLength))  { 
                    node.InnerText = "";
                    containsCorruptNodes = true;
                }
            }


            xmlDocument.Save(XMLModifier.xmlPath);
            return !containsCorruptNodes;
        }

        private bool LengthIsSmallerThenMinimum(int nodeLength)
        {
            return nodeLength < MINIMUM_NODE_LENGTH;

        }

        private bool LengthIsBelowAverage(int nodeLength, double average)
        {
            return nodeLength < average * AVERAGE_FACTOR;
        }


        private int[] GetLengthsList(XmlNodeList nodesList)
        {
            var intArr = new int[nodesList.Count];
            for (var i = 0; i < nodesList.Count; i++)
                intArr[i] = nodesList[i].InnerText.Length;
            return intArr;
        }

        private int Sum(params int[] customerssalary)
        {
            return customerssalary.Sum();
        }

        private double Average(params int[] customerssalary)
        {
            var sum = Sum(customerssalary);
            var result = (double)sum / customerssalary.Length;
            return result;
        }

    }
}