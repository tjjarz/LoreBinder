using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class PlayerCharacter
    {
        public int PCID { get; set; }
        //public string BindID { get { return "PC" + PCID; } }
        public string NameShort { get; set; }
        public string NameFull { get; set; }
        public string Level { get; set; } //string not int because no math also "2nd" level... etc
        public string Class { get; set; }
        public string Species { get; set; }
        public string PersonalHistory { get; set; } //EVERYTHING
        public string Personality { get; set; } //traits, ideals, flaws and bonds
        public int CurHP { get; set; }  //setting up for "live" charsheet future
        public int CurHD { get; set; }  //setting up for "live" charsheet future
        public int MaxHP { get; set; }
        public string HitDice { get; set; } //perhaps should be another parsed "math" item?
        public int STR { get; set; }
        public int DEX { get; set; }
        public int CON { get; set; }
        public int INT { get; set; }
        public int WIS { get; set; }
        public int CHA { get; set; }
        public int Athletics { get; set; }
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
        //public List<StatusEffect> Conditions { get; set; }  //left out for future live play feature & my sanity
    }
}
