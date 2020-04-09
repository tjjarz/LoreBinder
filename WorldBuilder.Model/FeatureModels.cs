using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Models
{
    class FeatureModels
    {
        public class FeatureListVariant
        {
            public int FeatureID { get; set; }
            public string Name { get; set; }
            public string Summary { get; set; }
            public string Mechanics { get; set; }
        }
    }
}
