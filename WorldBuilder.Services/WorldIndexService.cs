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
        private readonly ApplicationDbContext _db;
        private readonly string _userID;  //changing to string from Guid to please BasicdB code
        public WorldIndexService(string userID)
        {
            _db = new ApplicationDbContext();
            _userID = userID;
        }

        public void CreateWorldIndex()
        {

            foreach (var playerCharacter in _db.PlayerCharacters)
            {
                AddPlayerCharacter(playerCharacter);
            }

            foreach (var feature in _db.Features)
            {
                AddFeature(feature);
            }

            foreach (var spell in _db.Spells)
            {
                AddSpell(spell);
            }

            foreach (var item in _db.Items)
            {
                AddItem(item);
            }

            _db.SaveChanges();
            //should probably error check this eventually.
        }

        public WorldIndexEntry AddPlayerCharacter(PlayerCharacter entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "PlayerCharacter";
            entry.DataTypeID = entity.PCID;

            return entry;
        }

        public WorldIndexEntry AddItem(Item entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "Item";
            entry.DataTypeID = entity.ItemID;

            return entry;
        }

        public WorldIndexEntry AddSpell(Spell entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "Spell";
            entry.DataTypeID = entity.SpellID;

            return entry;
        }

        public WorldIndexEntry AddFeature(Feature entity)
        {
            WorldIndexEntry entry = new WorldIndexEntry();

            entry.Name = entity.Name;
            entry.HashCode = entity.Name.GetHashCode();
            entry.DataType = "Feature";
            entry.DataTypeID = entity.FeatureID;

            return entry;
        }

    }
}
