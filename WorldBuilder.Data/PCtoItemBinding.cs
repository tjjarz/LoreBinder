using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class PCtoItemBinding
    {
        [Key]
        public int PCtoFEBindID { get; set; }

        [ForeignKey(nameof(PC))]
        public int PCID { get; set; }
        public virtual PlayerCharacter PC { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
    }
}
