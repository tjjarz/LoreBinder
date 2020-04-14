using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldBuilder.Data;
using WorldBuilder.Services;

namespace WorldBuilder.MVC.Controllers
{
    [Authorize]
    public class SpellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private WorldIndexService CreateWorldIndexService()
        {
            //shouldn't this be a Guid?
            string userID = User.Identity.GetUserId();
            var worldIndexService = new WorldIndexService(userID);

            return worldIndexService;
        }

        // GET: Spells
        public ActionResult Index()
        {
            List<Spell> allspells = new List<Spell>();
            allspells = db.Spells.ToList();
            return View(allspells);
        }

        // GET: Spells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spells.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // GET: Spells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpellID,Name,SpellLevel,SpellSchool,CastTime,RangeArea,Duration,Concentration,Components,Verbal,Somatic,Material,SpellEffectType,Summary,FullText,Mechanics")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                db.Spells.Add(spell);
                db.SaveChanges();
                
                WorldIndexService worldIndexService = CreateWorldIndexService();
                worldIndexService.UpdateSpells();
                
                return RedirectToAction("Index");
            }

            return View(spell);
        }

        // GET: Spells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spells.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpellID,Name,SpellLevel,SpellSchool,CastTime,RangeArea,Duration,Concentration,Components,Verbal,Somatic,Material,SpellEffectType,Summary,FullText,Mechanics")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spell);
        }

        // GET: Spells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spells.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spell spell = db.Spells.Find(id);
            db.Spells.Remove(spell);
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
