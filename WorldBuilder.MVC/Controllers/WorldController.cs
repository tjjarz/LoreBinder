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
        public XDocument DocGrabber()
        {
            //var filepath = HttpContext.Current.Server.MapPath("~/WorldBuilder.Data/WorldData.xml");
            var filepath = "C:/Users/Tom/OneDrive/Codespace/Red/WorldBuilder/WorldBuilder.Data/WorldData.xml";
            XDocument loaded_xdoc = XDocument.Load(filepath);
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
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(XElement xtree)
        {
            XDocument xdoc = DocGrabber();

            xdoc.AddAfterSelf(xtree);
            
            return View(xtree);
        }
    }
}