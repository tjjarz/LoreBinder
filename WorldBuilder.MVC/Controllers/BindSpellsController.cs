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
    public class BindSpellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BindSpells
        public ActionResult Index()
        {
            var pCSpells = db.PCSpells.Include(p => p.PC).Include(p => p.Spell);
            return View(pCSpells.ToList());
        }

        // GET: BindSpells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoSpellBinding pCtoSpellBinding = db.PCSpells.Find(id);
            if (pCtoSpellBinding == null)
            {
                return HttpNotFound();
            }
            return View(pCtoSpellBinding);
        }

        // GET: BindSpells/Create
        public ActionResult Create()
        {
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name");
            ViewBag.SpellID = new SelectList(db.Spells, "SpellID", "Name");
            return View();
        }

        // POST: BindSpells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PCtoSPBindID,PCID,SpellID")] PCtoSpellBinding pCtoSpellBinding)
        {
            if (ModelState.IsValid)
            {
                db.PCSpells.Add(pCtoSpellBinding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoSpellBinding.PCID);
            ViewBag.SpellID = new SelectList(db.Spells, "SpellID", "Name", pCtoSpellBinding.SpellID);
            return View(pCtoSpellBinding);
        }

        // GET: BindSpells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoSpellBinding pCtoSpellBinding = db.PCSpells.Find(id);
            if (pCtoSpellBinding == null)
            {
                return HttpNotFound();
            }
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoSpellBinding.PCID);
            ViewBag.SpellID = new SelectList(db.Spells, "SpellID", "Name", pCtoSpellBinding.SpellID);
            return View(pCtoSpellBinding);
        }

        // POST: BindSpells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCtoSPBindID,PCID,SpellID")] PCtoSpellBinding pCtoSpellBinding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pCtoSpellBinding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name", pCtoSpellBinding.PCID);
            ViewBag.SpellID = new SelectList(db.Spells, "SpellID", "Name", pCtoSpellBinding.SpellID);
            return View(pCtoSpellBinding);
        }

        // GET: BindSpells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCtoSpellBinding pCtoSpellBinding = db.PCSpells.Find(id);
            if (pCtoSpellBinding == null)
            {
                return HttpNotFound();
            }
            return View(pCtoSpellBinding);
        }

        // POST: BindSpells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PCtoSpellBinding pCtoSpellBinding = db.PCSpells.Find(id);
            db.PCSpells.Remove(pCtoSpellBinding);
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
