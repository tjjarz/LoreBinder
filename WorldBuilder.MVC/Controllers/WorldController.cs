using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using WorldBuilder.Models;

namespace WorldBuilder.MVC.Controllers
{
    public class WorldController : Controller
    {
        string _filepath = "C:/Users/Tom/OneDrive/Codespace/Red/WorldBuilder/WorldBuilder.Data/WorldData.xml";
        public XDocument DocGrabber()
        {
            //var filepath = HttpContext.Current.Server.MapPath("~/WorldBuilder.Data/WorldData.xml");
            XDocument loaded_xdoc = XDocument.Load(_filepath);
            return loaded_xdoc;
        }

        // GET: World
        public ActionResult Index()
        {
            XDocument xdoc = DocGrabber();
            return View(xdoc);
        }

        // GET: Create
        public ActionResult Create()
        {
            List<Element> Model = new List<Element>();
            Model.Add(new Element("!.tree-start", "!.voidvalue"));
            if (Model == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "We don't need to see his identification."); }
            if (Model[0].XLName != "!.tree-start") { return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "these aren't the droids we're looking for..."); }
            return View(Model);
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(List<Element> workingtree)
        {
            if (workingtree == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Negative, didn't go in, just impacted on the surface."); }

            XDocument xdoc = DocGrabber();
            //xdoc.Add(xtree);

            //WorldService _service = new WorldService;

            XDocument workingxdoc = XLTreeBuilder(workingtree);


            workingxdoc.Save(@"C:\Users\Tom\OneDrive\Codespace\Red\WorldBuilder\WorldBuilder.Data\WorkingDataz.xml");

            /*
            StringBuilder bs = new StringBuilder();
            int counter = 1;
            foreach (Element elem in workingtree)
            {
                bs.Append("/<" + elem.XLName + "/>");
                bs.Append("/<" + elem.XLValue + "/>");
                bs.Append("/<//"+ elem.XLName + "/>"+counter);
                counter++;
            }

            string builtstring = bs.ToString();*/
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, builtstring);

            return View(workingtree);
        }



        //should be moved to services

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
    }
}