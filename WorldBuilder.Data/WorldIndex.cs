using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Data
{
    public class WorldIndex
    {
        [Key]
        public int IndexID { get; set; }
        
        //[ForeignKey(nameof(NameofEntity))]
        public string Name { get; set; }
        //public virtual string NameofEntity { get; set; }
        
        //public int HashCode { 
        //    get { return Name.GetHashCode(); } } //seems like it shouldn't be this easy...
        public int HashCode { get; set; }
        public string DataType { get; set; }
        public int DataTypeID { get; set; }
        //public string Maker { get; set; } //should be guid SOMEDAY

        





    }



    public class WorldIndexEntry
    {
        [Key]
        public int IndexID { get; set; }
        public string Name { get; set; }
        public int HashCode { get; set; }
        public string DataType { get; set; }
        public int DataTypeID { get; set; }
        //public string Maker { get; set; }

    }
}
