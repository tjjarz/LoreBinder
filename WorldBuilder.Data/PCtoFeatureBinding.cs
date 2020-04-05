using System.ComponentModel.DataAnnotations.Schema;

namespace WorldBuilder.Data
{
    public class PCtoFeatureBinding
    {
        public int PCtoFEBindID { get; set; }

        [ForeignKey(nameof(PC))]
        public int PCID { get; set; }
        public virtual PlayerCharacter PC { get; set; }

        [ForeignKey(nameof(Feature))]
        public int FeatureID { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
