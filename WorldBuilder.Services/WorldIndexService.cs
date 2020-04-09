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
        {
            var items = db.Items.ToList();

            foreach (Item item in items)
            {
                if (!(from entries in db.WorldIndex
                    where entries.DataType == "Item" && entries.DataTypeID == item.ItemID
                    select item.ItemID).Any())
                {
                    AddItem(item);
                }
            }
        }

        public void UpdateSpells()
        {
            var spells = db.Spells.ToList();

            foreach (Spell spell in spells)
            {
                if (!(from entries in db.WorldIndex
                      where entries.DataType == "Spell" && entries.DataTypeID == spell.SpellID
                      select spell.SpellID).Any())
                {
                    AddSpell(spell);
                }
            }
        }

        public void UpdateFeatures()
        {
            var features = db.Features.ToList();

            foreach (Feature feature in features)
            {
                if (!(from entries in db.WorldIndex
                      where entries.DataType == "Feature" && entries.DataTypeID == feature.FeatureID
                      select feature.FeatureID).Any())
                {
                    AddFeature(feature);
                }
            }
        }

        public void UpdatePlayerCharacters()
        {
            var playercharacters = db.PlayerCharacters.ToList();

            foreach (PlayerCharacter playercharacter in playercharacters)
            {
                if (!(from entries in db.WorldIndex
                      where entries.DataType == "PlayerCharacter" && entries.DataTypeID == playercharacter.PCID
                      select playercharacter.PCID).Any())
                {
                    AddPlayerCharacter(playercharacter);
                }
            }
        }

        public WorldIndexEntry AddPlayerCharacter(PlayerCharacter entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry
            {
                Name = entity.Name,
                HashCode = entity.Name.GetHashCode(),
                DataType = "PlayerCharacter",
                DataTypeID = entity.PCID,
                AssocID = ("PC" + entity.PCID.ToString()).GetHashCode()
            };

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public WorldIndexEntry AddItem(Item entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry
            {
                Name = entity.Name,
                HashCode = entity.Name.GetHashCode(),
                DataType = "Item",
                DataTypeID = entity.ItemID,
                AssocID = ("IT" + entity.ItemID.ToString()).GetHashCode()
            };

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public WorldIndexEntry AddSpell(Spell entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry
            {
                Name = entity.Name,
                HashCode = entity.Name.GetHashCode(),
                DataType = "Spell",
                DataTypeID = entity.SpellID,
                AssocID = ("SP" + entity.SpellID.ToString()).GetHashCode()
            };

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

        public WorldIndexEntry AddFeature(Feature entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry
            {
                Name = entity.Name,
                HashCode = entity.Name.GetHashCode(),
                DataType = "Feature",
                DataTypeID = entity.FeatureID,
                AssocID = ("FE" + entity.FeatureID.ToString()).GetHashCode()
            };

            db.WorldIndex.Add(entry);
            db.SaveChanges();
            return entry;
        }

    }
}
