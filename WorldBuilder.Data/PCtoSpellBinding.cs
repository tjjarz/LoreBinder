using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class PCtoSpellBinding
    {
        public int PCtoSPBindID { get; set; }

        [ForeignKey(nameof(PC))]
        public int PCID { get; set; }
        public virtual PlayerCharacter PC { get; set; }

        [ForeignKey(nameof(Spell))]
        public int SpellID { get; set; }
        public virtual Spell Spell { get; set; }
    }
}
