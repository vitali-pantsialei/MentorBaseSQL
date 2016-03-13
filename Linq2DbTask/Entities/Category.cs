using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, Identity]
        public int CategoryID { get; set; }
        [Column, NotNull]
        public string CategoryName { get; set; }
        [Column, Nullable]
        public string Description { get; set; }
        [Column, Nullable]
        public byte[] Picture { get; set; }
    }
}
