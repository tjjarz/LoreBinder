using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using WorldBuilder.Models;

namespace WorldBuilder.Data
{
    public class PlayerCharacter
    {
        [Key]
        public int PCID { get; set; }
        [Required]        
        public string Name { get; set; }
        public string Summary {get;set;} //belongs in a museum IE abstract parent class
        public string NameFull { get; set; }
        public string Level { get; set; } //string not int because no math also "2nd" level... etc
        public string Class { get; set; }
        public string Species { get; set; }
        //public string Alignment { get; set; } //not in MY GAME
        public string Background { get; set; } //eventually link it 
        public string PersonalHistory { get; set; } //EVERYTHING
        public string Personality { get; set; } //traits, ideals, flaws and bonds
        public string Age { get; set; }
        public string CurHP { get; set; }  //setting up for "live" charsheet future
        public string CurHD { get; set; }  //setting up for "live" charsheet future
        public string MaxHP { get; set; }
        public string HitDice { get; set; } //perhaps should be another parsed "math" item?
        public string ProficiencyBonus { get; set; }
        public string STR { get; set; }
        public string DEX { get; set; }
        public string CON { get; set; }
        public string INT { get; set; }
        public string WIS { get; set; }
        public string CHA { get; set; }
        /*public int STRsave { get; set; }  //probably gonna need to add these eventually (ugh)
        public int DEXsave { get; set; }
        public int CONsave { get; set; }
        public int INTsave { get; set; }
        public int WISsave { get; set; }
        public int CHAsave { get; set; }*/
        //public string Skills { get; set; }
            public string Athletics { get; set; } //need to track skill bonuses too if i'm gonna go full programatic
            public string Acrobatics { get; set; }
            public string SleightofHand { get; set; }
            public string Stealth { get; set; }
            public string Arcana { get; set; }
            public string History { get; set; }
            public string Investigation { get; set; }
            public string Nature { get; set; }
            public string Religion { get; set; }
            public string AnimalHandling { get; set; }
            public string Insight { get; set; }
            public string Medicine { get; set; }
            public string Perception { get; set; }
            public string Survival { get; set; }
            public string Deception { get; set; }
            public string Intimidation { get; set; }
            public string Performance { get; set; }
            public string Persuasion { get; set; }
        public string Player { get; set; }
        public string Notes { get; set; }
        public string OwnerID { get; set; } 
        public virtual List<Feature> Features { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<Spell> Spells { get; set; }
        //public int AssocID => ("PC" + PCID.ToString()).GetHashCode();

        //public List<StatusEffect> Conditions { get; set; }  //left out for future live play feature & my sanity

        public PlayerCharacter()
        {

        }

        /*
        public PlayerCharacter(CharacterBuild characterbuild)
        {
            NameShort = characterbuild.NameShort;
            NameFull = characterbuild.NameFull;
            Level = characterbuild.Level;
            Class = characterbuild.Class;
            Species = characterbuild.Species;
            Age = characterbuild.Age;
            Background = characterbuild.Background;
            PersonalHistory = characterbuild.PersonalHistory;
            Personality = characterbuild.Personality;
            CurHP = characterbuild.CurHP;
            CurHD = characterbuild.CurHD;
            MaxHP = characterbuild.MaxHP;
            HitDice = characterbuild.HitDice;
            ProficiencyBonus = characterbuild.ProficiencyBonus;
            STR = characterbuild.STR;
            DEX = characterbuild.DEX;
            CON = characterbuild.CON;
            INT = characterbuild.INT;
            WIS = characterbuild.WIS;
            CHA = characterbuild.CHA;
            Athletics = characterbuild.Athletics;
            Acrobatics = characterbuild.Acrobatics;
            SleightofHand = characterbuild.SleightofHand;
            Stealth = characterbuild.Stealth;
            Arcana = characterbuild.Arcana;
            History = characterbuild.History;
            Investigation = characterbuild.Investigation;
            Nature = characterbuild.Nature;
            Religion = characterbuild.Religion;
            AnimalHandling = characterbuild.AnimalHandling;
            Insight = characterbuild.Insight;
            Medicine = characterbuild.Medicine;
            Perception = characterbuild.Perception;
            Survival = characterbuild.Survival;
            Deception = characterbuild.Deception;
            Intimidation = characterbuild.Intimidation;
            Performance = characterbuild.Performance;
            Persuasion = characterbuild.Persuasion;
            Player = characterbuild.Player;
            OwnerID = _userID;
        }*/
    }
}
