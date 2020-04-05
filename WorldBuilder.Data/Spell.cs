using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class Spell
    {
        public int SpellID { get; set; }
        //public string BindID { get { return "SP" + SpellID; } }
        public string Name { get; set; }
        public string SpellLevel { get; set; }
        public string SpellSchool { get; set; }
        public string CastTime { get; set; }
        public string RangeArea { get; set; }
        public string Duration { get; set; }
        public bool Concentration { get; set; }
        public string Components { get; set; }
        public bool Verbal { get; set; }
        public bool Somatic { get; set; }
        public bool Material { get; set; }
        public string SpellEffectType { get; set; }
        public string SpellDescription { get; set; } //gonna be "rich text"
        public string Math { get; set; }
    }
}
