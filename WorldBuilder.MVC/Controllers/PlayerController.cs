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
using WorldBuilder.Models;
using WorldBuilder.Services;

namespace WorldBuilder .MVC.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private WorldIndexService CreateWorldIndexService()
        {
            //shouldn't this be a Guid?
            string userID = User.Identity.GetUserId();
            var worldIndexService = new WorldIndexService(userID);

            return worldIndexService;
        }

        // GET: Player
        public ActionResult Index()
        {
            return View(db.PlayerCharacters.ToList());
        }

        [Authorize]
        private PlayerCharacterService CreatePlayerChararacterService()
        {
            //shouldn't this be a Guid?
            string userId = User.Identity.GetUserId();
            var characterService = new PlayerCharacterService(userId);

            return characterService;
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

            playerCharacter.Items = GetPCItems(id);
            playerCharacter.Features = GetPCFeatures(id);
            playerCharacter.Spells = GetPCSpells(id);
            return View(playerCharacter);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            ViewBag.Items = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.Features = new SelectList(db.Features, "FeatureID", "Name");
            ViewBag.Spells = new SelectList(db.Spells, "SpellID", "Name");

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
                PlayerCharacterService characterService = CreatePlayerChararacterService();
                db.PlayerCharacters.Add(characterService.BuildPlayerCharacter(playerCharacter));
                db.SaveChanges();
                
                WorldIndexService worldIndexService = CreateWorldIndexService();
                worldIndexService.UpdatePlayerCharacters();
                
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
            
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name");
            //ViewBag.PCID = playerCharacter.PCID;
            return View(playerCharacter);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerCharacter playerCharacter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerCharacter).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.PCID = new SelectList(db.PlayerCharacters, "PCID", "Name");
            //ViewBag.PCID = playerCharacter.PCID;
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

        public List<Item> GetPCItems(int? pcid)
        {
            List<Item> pcItems = new List<Item>();
            var pcbounditems = db.PCItems.Where(s => s.PCID == pcid).ToList();
            //var pcBoundItems = db.PCItems.Include(p => p.Item).Include(p => p.PC);
            foreach (PCtoItemBinding binding in pcbounditems)
            {
                pcItems.Add(db.Items.Find(binding.ItemID));
            }
            return pcItems;
        }
        
        public List<Feature> GetPCFeatures(int? pcid)
        {
            List<Feature> pcFeatures = new List<Feature>();
            var pcbounditems = db.PCFeatures.Where(s => s.PCID == pcid).ToList();
            foreach (PCtoFeatureBinding binding in pcbounditems)
            {
                pcFeatures.Add(db.Features.Find(binding.FeatureID));
            }
            return pcFeatures;
        }
        
        public List<Spell> GetPCSpells(int? pcid)
        {
            List<Spell> pcSpells = new List<Spell>();
            var pcbounditems = db.PCSpells.Where(s => s.PCID == pcid).ToList();
            foreach (PCtoSpellBinding binding in pcbounditems)
            {
                pcSpells.Add(db.Spells.Find(binding.SpellID));
            }
            return pcSpells;
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
