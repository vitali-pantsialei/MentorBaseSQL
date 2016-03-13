using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [PrimaryKey]
        public string TerritoryID { get; set; }
        [Column, NotNull]
        public string TerritoryDescription { get; set; }
        [Association(Storage="_region", ThisKey="RegionID", OtherKey="RegionID")]
        public Region Region
        {
            get { return _region.Entity; }
            set { _region.Entity = value; }
        }

        private EntityRef<Region> _region = new EntityRef<Region>();
        [Column, NotNull]
        public int? RegionID;
    }
}
