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
    public class PCtoItemBindingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PCtoItemBindings
        public ActionResult Index()
        {
            var pCItems = db.PCItems.Include(p => p.Item).Include(p => p.PC);
            return View(pCItems.ToList());
        }

        // GET: PCtoItemBindings/Details/5
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

        // GET: PCtoItemBindings/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name");
            return View();
        }

        // POST: PCtoItemBindings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PCtoFEBindID,PCID,ItemID")] PCtoItemBinding pCtoItemBinding)
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

        // GET: PCtoItemBindings/Edit/5
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

        // POST: PCtoItemBindings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCtoFEBindID,PCID,ItemID")] PCtoItemBinding pCtoItemBinding)
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

        // GET: PCtoItemBindings/Delete/5
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

        // POST: PCtoItemBindings/Delete/5
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
