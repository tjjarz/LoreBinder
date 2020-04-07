using System;
using WorldBuilder.Data;
using WorldBuilder.Models;

namespace WorldBuilder.Services
{
    public class PlayerCharacterService
    {
        //private readonly ApplicationDbContext _db;
        private readonly string _userID;  //changing to string from Guid to please BasicdB code
        public PlayerCharacterService(string userID)
        {
            //_db = new ApplicationDbContext();
            _userID = userID;
        }

        public PlayerCharacter BuildPlayerCharacter(CharacterBuild characterbuild)
        {
            var entity =
            new PlayerCharacter()
            {
                Name = characterbuild.Name,
                NameFull = characterbuild.NameFull,
                Level = characterbuild.Level,
                Class = characterbuild.Class,
                Species = characterbuild.Species,
                Age = characterbuild.Age,
                Background = characterbuild.Background,
                PersonalHistory = characterbuild.PersonalHistory,
                Personality = characterbuild.Personality,
                CurHP = characterbuild.CurHP,
                CurHD = characterbuild.CurHD,
                MaxHP = characterbuild.MaxHP,
                HitDice = characterbuild.HitDice,
                ProficiencyBonus = characterbuild.ProficiencyBonus,
                STR = characterbuild.STR,
                DEX = characterbuild.DEX,
                CON = characterbuild.CON,
                INT = characterbuild.INT,
                WIS = characterbuild.WIS,
                CHA = characterbuild.CHA,
                Athletics = characterbuild.Athletics,
                Acrobatics = characterbuild.Acrobatics,
                SleightofHand = characterbuild.SleightofHand,
                Stealth = characterbuild.Stealth,
                Arcana = characterbuild.Arcana,
                History = characterbuild.History,
                Investigation = characterbuild.Investigation,
                Nature = characterbuild.Nature,
                Religion = characterbuild.Religion,
                AnimalHandling = characterbuild.AnimalHandling,
                Insight = characterbuild.Insight,
                Medicine = characterbuild.Medicine,
                Perception = characterbuild.Perception,
                Survival = characterbuild.Survival,
                Deception = characterbuild.Deception,
                Intimidation = characterbuild.Intimidation,
                Performance = characterbuild.Performance,
                Persuasion = characterbuild.Persuasion,
                Player = characterbuild.Player,
                OwnerID = _userID
            };

            //_db.PlayerCharacters.Add(entity);
            //return _db.SaveChanges() == 1;
            return entity;
        }
    }
}
