using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using WorldBuilder.Models;

namespace WorldBuilder.Services
{
    public class WorldService
    {
        private readonly Guid _userID;

        public WorldService(Guid userID)
        {
            _userID = userID;
        }


        public XDocument XLTreeBuilder(List<Element> chaff)
        {
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            // Create a writer to write XML to the console.
            //settings.IndentChars
            //XmlWriter writer = XmlWriter.Create(XDocument xdoc, settings);
            // Write the root element

            XDocument newTree = new XDocument();
            using (XmlWriter writer = newTree.CreateWriter())
            {
                //bool nesting = false;
                foreach (Element elem in chaff)
                {
                    if (elem.XLValue == "!.nestend")
                    {
                        //nesting = false;
                        writer.WriteFullEndElement();
                    }
                    else if (elem.XLValue == "!.neststart" || elem.XLValue == null || elem.XLValue == "")
                    {
                        //nesting = true;
                        writer.WriteStartElement(elem.XLName);
                    }
                    else
                    {
                        writer.WriteElementString(elem.XLName, elem.XLValue);
                        //writer.WriteStartElement("item");
                        //writer.WriteAttributeString("date", "2/19/01");
                        //writer.WriteAttributeString("orderID", "136A5");

                        // Write a full end element. Because this element has no
                        // content, calling WriteEndElement would have written a
                        // short end tag '/>'.
                    }
                }
                //believe we need this one...
                writer.WriteFullEndElement();
                //writer.WriteEndElement();
                // Write the XML to file and close the writer
                writer.Close();
            }



            return newTree;
        }


        public XElement XLTreeBuilduur(List<Element> chaff)  //should this be a bool or an xelement?
        {
            XElement workingTree = new XElement("!.WorkingTreeStart", "!.New");

            foreach (Element elem in chaff)
            {
                workingTree.Add(new XElement(elem.XLName, elem.XLValue));
            }



            foreach (Element elem in chaff)
            {
                switch (elem.XLValue)
                {
                    case "":
                    default:
                        workingTree.Add(new XElement(elem.XLName, elem.XLValue));
                        break;
                }
            }


            return workingTree;
        }

        public XElement XLNestedNodeBuilder(List<Element> chaff)  //should this be a bool or an xelement?
        {
            XElement workingTree = new XElement("!.WorkingTreeStart", "!.New");
            /*
            bool listmode = false;
            foreach (Element elem in chaff)
            {
                if (elem.XLValue.GetType() == NestedElement)

                    if (elem.XLValue == "!.ListStart")
                    { listmode = true; }

                if (listmode == true)
                {
                    workingTree.Add(new XElement(elem.XLName, elem.XLValue));
                }
                else
                {
                    workingTree.Add(new XElement(elem.XLName, elem.XLValue));
                }
            }
            */
            return workingTree;
        }
    }
}
