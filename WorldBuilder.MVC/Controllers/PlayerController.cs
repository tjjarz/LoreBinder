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
    public class PlayerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Player
        public ActionResult Index()
        {
            return View(db.PlayerCharacters.ToList());
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerCharacter playerCharacter = db.PlayerCharacters.Find(id);
            if (playerCharacter == null)
            {
                return HttpNotFound();
            }
            return View(playerCharacter);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PCID,NameShort,NameFull,Level,Class,Species,Age,Background,PersonalHistory,Personality,CurHP,CurHD,MaxHP,HitDice,ProficiencyBonus,STR,DEX,CON,INT,WIS,CHA,Athletics,Acrobatics,SleightofHand,Stealth,Arcana,History,Investigation,Nature,Religion,AnimalHandling,Insight,Medicine,Perception,Survival,Deception,Intimidation,Performance,Persuasion,Player,OwnerID")] PlayerCharacter playerCharacter)
        public ActionResult Create(CharacterBuild playerCharacter)
        {
            if (ModelState.IsValid)
            {
                db.PlayerCharacters.Add(playerCharacter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerCharacter);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerCharacter playerCharacter = db.PlayerCharacters.Find(id);
            if (playerCharacter == null)
            {
                return HttpNotFound();
            }
            return View(playerCharacter);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCID,NameShort,NameFull,Level,Class,Species,Age,Background,PersonalHistory,Personality,CurHP,CurHD,MaxHP,HitDice,ProficiencyBonus,STR,DEX,CON,INT,WIS,CHA,Athletics,Acrobatics,SleightofHand,Stealth,Arcana,History,Investigation,Nature,Religion,AnimalHandling,Insight,Medicine,Perception,Survival,Deception,Intimidation,Performance,Persuasion,Player")] PlayerCharacter playerCharacter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerCharacter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerCharacter);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerCharacter playerCharacter = db.PlayerCharacters.Find(id);
            if (playerCharacter == null)
            {
                return HttpNotFound();
            }
            return View(playerCharacter);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerCharacter playerCharacter = db.PlayerCharacters.Find(id);
            db.PlayerCharacters.Remove(playerCharacter);
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
