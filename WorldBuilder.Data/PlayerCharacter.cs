using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorldBuilder.Models;

namespace WorldBuilder.Data
{
    public class PlayerCharacter
    {
        [Key]
        public int PCID { get; set; }
        //public string BindID { get { return "PC" + PCID; } }
        [Required]        
        public string Name { get; set; }
        //public string Summary {get;set;} //belongs in a museum IE abstract parent class
        public string NameFull { get; set; }
        public string Level { get; set; } //string not int because no math also "2nd" level... etc
        public string Class { get; set; }
        public string Species { get; set; }
        //public string Alignment { get; set; } //not in MY GAME
        public string Background { get; set; } //eventually link it 
        public string PersonalHistory { get; set; } //EVERYTHING
        public string Personality { get; set; } //traits, ideals, flaws and bonds
        public int Age { get; set; }
        public int CurHP { get; set; }  //setting up for "live" charsheet future
        public int CurHD { get; set; }  //setting up for "live" charsheet future
        public int MaxHP { get; set; }
        public string HitDice { get; set; } //perhaps should be another parsed "math" item?
        public int ProficiencyBonus { get; set; }
        public int STR { get; set; }
        public int DEX { get; set; }
        public int CON { get; set; }
        public int INT { get; set; }
        public int WIS { get; set; }
        public int CHA { get; set; }
        /*public int STRsave { get; set; }  //probably gonna need to add these eventually (ugh)
        public int DEXsave { get; set; }
        public int CONsave { get; set; }
        public int INTsave { get; set; }
        public int WISsave { get; set; }
        public int CHAsave { get; set; }*/
        //public string Skills { get; set; }
            public int Athletics { get; set; } //need to track skill bonuses too if i'm gonna go full programatic
            public int Acrobatics { get; set; }
            public int SleightofHand { get; set; }
            public int Stealth { get; set; }
            public int Arcana { get; set; }
            public int History { get; set; }
            public int Investigation { get; set; }
            public int Nature { get; set; }
            public int Religion { get; set; }
            public int AnimalHandling { get; set; }
            public int Insight { get; set; }
            public int Medicine { get; set; }
            public int Perception { get; set; }
            public int Survival { get; set; }
            public int Deception { get; set; }
            public int Intimidation { get; set; }
            public int Performance { get; set; }
            public int Persuasion { get; set; }
        public string Player { get; set; }
        public string Notes { get; set; }
        public string OwnerID { get; set; } 
        public virtual List<Feature> Features { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<Spell> Spells { get; set; }
        //public List<StatusEffect> Conditions { get; set; }  //left out for future live play feature & my sanity

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
