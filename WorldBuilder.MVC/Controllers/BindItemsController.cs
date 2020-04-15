using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldBuilder.Data;

namespace WorldBuilder.MVC.Controllers
{
    public class BindItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BindItems
        public ActionResult Index()
        {
            var pCItems = db.PCItems.Include(p => p.Item).Include(p => p.PC);
            return View(pCItems.ToList());
        }

        // GET: Bound Items
        public List<Item> GetPCItems(int pcid)
        {
            List<Item> pcItems = new List<Item>();
            var pcBoundItems = db.PCItems.Include(p => p.Item).Include(p => p.PC);
            foreach (PCtoItemBinding binding in pcBoundItems)
            {
                pcItems.Add(db.Items.Find(binding.ItemID));
            }
            return pcItems;
        }

        // GET: BindItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoItemBinding pCtoItemBinding = db.PCItems.Find(id);
            if (pCtoItemBinding == null)
            {
                return HttpNotFound();
            }
            return View(pCtoItemBinding);
        }

        // GET: BindItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name");
            return View();
        }

        // POST: BindItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PCtoITBindID,PCID,ItemID")] PCtoItemBinding pCtoItemBinding)
        {
            if (ModelState.IsValid)
            {
                db.PCItems.Add(pCtoItemBinding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", pCtoItemBinding.ItemID);
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoItemBinding.PCID);
            return View(pCtoItemBinding);
        }

        // GET: BindItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoItemBinding pCtoItemBinding = db.PCItems.Find(id);
            if (pCtoItemBinding == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", pCtoItemBinding.ItemID);
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoItemBinding.PCID);
            return View(pCtoItemBinding);
        }

        // POST: BindItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCtoITBindID,PCID,ItemID")] PCtoItemBinding pCtoItemBinding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pCtoItemBinding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", pCtoItemBinding.ItemID);
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoItemBinding.PCID);
            return View(pCtoItemBinding);
        }

        // GET: BindItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoItemBinding pCtoItemBinding = db.PCItems.Find(id);
            if (pCtoItemBinding == null)
            {
                return HttpNotFound();
            }
            return View(pCtoItemBinding);
        }

        // POST: BindItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PCtoItemBinding pCtoItemBinding = db.PCItems.Find(id);
            db.PCItems.Remove(pCtoItemBinding);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
