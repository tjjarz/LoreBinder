using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilder.Data;
using System.Data;
using WorldBuilder.Models;

namespace WorldBuilder.Services
{
    public class WorldIndexService
    {
        private readonly ApplicationDbContext db;
        private readonly string _userID;  //changing to string from Guid to please BasicdB code
        public WorldIndexService(string userID)
        {
            db = new ApplicationDbContext();
            _userID = userID;
        }

        public void CreateWorldIndex()
        {

            foreach (var playerCharacter in db.PlayerCharacters)
            {
                AddPlayerCharacter(playerCharacter);
            }

            foreach (var feature in db.Features)
            {
                AddFeature(feature);
            }

            foreach (var spell in db.Spells)
            {
                AddSpell(spell);
            }

            foreach (var item in db.Items)
            {
                AddItem(item);
            }

            db.SaveChanges();
            //should probably error check this eventually.
        }

        public void UpdateItems()
        //public void UpdateItems(Item item)
        {
            var items = from i in db.Items select i;
            var indicies = from entry in db.WorldIndex select entry;
            var itemEntries = indicies.Where(x => x.DataType == "Item").Select(x=>x.DataTypeID);
            
            foreach (Item item in items)
            {
                //if (!itemEntries.Any().Equals(item.ItemID))
                if (!itemEntries.Contains(item.ItemID));
                {
                    AddItem(item);
                }
            }
        }

        public WorldIndexEntry AddPlayerCharacter(PlayerCharacter entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "PlayerCharacter";
            entry.DataTypeID = entity.PCID;

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public WorldIndexEntry AddItem(Item entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "Item";
            entry.DataTypeID = entity.ItemID;

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public WorldIndexEntry AddSpell(Spell entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "Spell";
            entry.DataTypeID = entity.SpellID;

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public WorldIndexEntry AddFeature(Feature entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "Feature";
            entry.DataTypeID = entity.FeatureID;

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

    }
}
