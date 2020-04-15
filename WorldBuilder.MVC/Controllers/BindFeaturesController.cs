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
    public class BindFeaturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BindFeatures
        public ActionResult Index()
        {
            var pCFeatures = db.PCFeatures.Include(p => p.Feature).Include(p => p.PC);
            return View(pCFeatures.ToList());
        }

        // GET: BindFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoFeatureBinding pCtoFeatureBinding = db.PCFeatures.Find(id);
            if (pCtoFeatureBinding == null)
            {
                return HttpNotFound();
            }
            return View(pCtoFeatureBinding);
        }

        // GET: BindFeatures/Create
        public ActionResult Create()
        {
            ViewBag.FeatureID = new SelectList(db.Features, "FeatureID", "Name");
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name");
            return View();
        }

        // POST: BindFeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PCtoFEBindID,PCID,FeatureID")] PCtoFeatureBinding pCtoFeatureBinding)
        {
            if (ModelState.IsValid)
            {
                db.PCFeatures.Add(pCtoFeatureBinding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FeatureID = new SelectList(db.Features, "FeatureID", "Name", pCtoFeatureBinding.FeatureID);
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoFeatureBinding.PCID);
            return View(pCtoFeatureBinding);
        }

        // GET: BindFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoFeatureBinding pCtoFeatureBinding = db.PCFeatures.Find(id);
            if (pCtoFeatureBinding == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeatureID = new SelectList(db.Features, "FeatureID", "Name", pCtoFeatureBinding.FeatureID);
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoFeatureBinding.PCID);
            return View(pCtoFeatureBinding);
        }

        // POST: BindFeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCtoFEBindID,PCID,FeatureID")] PCtoFeatureBinding pCtoFeatureBinding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pCtoFeatureBinding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FeatureID = new SelectList(db.Features, "FeatureID", "Name", pCtoFeatureBinding.FeatureID);
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoFeatureBinding.PCID);
            return View(pCtoFeatureBinding);
        }

        // GET: BindFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoFeatureBinding pCtoFeatureBinding = db.PCFeatures.Find(id);
            if (pCtoFeatureBinding == null)
            {
                return HttpNotFound();
            }
            return View(pCtoFeatureBinding);
        }

        // POST: BindFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PCtoFeatureBinding pCtoFeatureBinding = db.PCFeatures.Find(id);
            db.PCFeatures.Remove(pCtoFeatureBinding);
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
