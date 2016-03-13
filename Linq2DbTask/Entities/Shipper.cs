using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Shippers")]
    public class Shipper
    {
        [PrimaryKey, Identity]
        public int ShipperID { get; set; }
        [Column, NotNull]
        public string CompanyName { get; set; }
        [Column, Nullable]
        public string Phone { get; set; }
    }
}
