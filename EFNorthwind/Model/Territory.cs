using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class Territory
    {
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        [ForeignKey("Region")]
        [Column("RegionsID")]
        public int? RegionID { get; set; }
        public Region Region { get; set; }
    }
}
