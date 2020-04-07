using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Summary { get; set; } //Keep it short!
        public string FullText { get; set; } //incl. physical description, actions, restraints, history, etc
        public string Mechanics { get; set; } //place to store all the parseable number data
        public string Notes { get; set; }
        public string Source { get; set; } //refers to the official reference, DMG-275 for instance
        

    }
}
