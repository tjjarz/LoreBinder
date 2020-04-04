using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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
            List<XElement> Model = new List<XElement>();
            if (Model == null) { return HttpNotFound("it's fucked foureyes."); }
            return View(Model);
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(List<XElement> xtree)
        {
            if (xtree == null) { return HttpNotFound("Model was Null!"); }
            XDocument xdoc = DocGrabber();
            xdoc.Add(xtree);

            xdoc.Save(@"C:\Users\Tom\OneDrive\Codespace\Red\WorldBuilder\WorldBuilder.Data\WorkingData.xml");
            
            return View(xtree);
        }
    }
}