using System.ComponentModel.DataAnnotations;

namespace WorldBuilder.Data
{
    public class Feature
    {
        //this should cover Feats, Features & Attacks
        [Key]
        public int FeatureID { get; set; }
        //public string BindID { get { return "FE" + FeatureID; } }
        [Required]
        public string Name { get; set; } //name of feature
        public string Summary { get; set; } //just the facts
        public string FullText { get; set; } //all the juicy details
        public string Mechanics { get; set; }  //that sweet sweet XML cheese
        public string Source { get; set; } //PHB p 135, warrior feature
        public string Notes { get; set; }
        //public string Math { get; set; } //gonna come up with a slick parsing system for the numbers here. //replaced by "mechanics" above
    }
}
