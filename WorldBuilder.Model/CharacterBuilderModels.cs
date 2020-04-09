using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilder.Data;

namespace WorldBuilder.Models
{
    public class CharacterBuild
    {
        [Key]
        public int PCID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string NameFull { get; set; }
        public string Level { get; set; } //string not int because no math also "2nd" level... etc
        public string Class { get; set; }
        public string Species { get; set; }
        //public string Alignment { get; set; } //not in MY GAME
        public string Age { get; set; }
        public string Background { get; set; } //eventually link it 
        public string PersonalHistory { get; set; } //EVERYTHING
        public string Personality { get; set; } //traits, ideals, flaws and bonds
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
    }

    public class PCListVariant
    {
        public int PCID { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Species { get; set; }
        public string Class { get; set; }
        public string Summary { get; set; }
        public string OwnerID { get; set; }
    }
}
