using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldBuilder.Data
{
    public class PCtoSpellBinding
    {
        [Key]
        public int PCtoSPBindID { get; set; }

        [ForeignKey(nameof(PC))]
        public int PCID { get; set; }
        public virtual PlayerCharacter PC { get; set; }

        [ForeignKey(nameof(Spell))]
        public int SpellID { get; set; }
        public virtual Spell Spell { get; set; }
    }
}
