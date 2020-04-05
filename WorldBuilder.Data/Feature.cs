using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    class Feature
    {
        //this should cover Feats, Features & Attacks
        public int FeatureID { get; set; }
        //public string BindID { get { return "FE" + FeatureID; } }
        public string Title { get; set; } //name of feature
        public string ShortDesc { get; set; } //just the facts
        public string FullDesc { get; set; } //all the juicy details
        public string Source { get; set; } //PHB p 135, warrior feature
        public string Math { get; set; } //gonna come up with a slick parsing system for the numbers here.
    }
}
