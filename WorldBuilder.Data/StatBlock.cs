using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class Stats
    {
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
    }

    public class Skills
    {
        public string Athletics { get; set; }
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
        public string stringimidation { get; set; }
        public string Performance { get; set; }
        public string Persuasion { get; set; }
    }
}
