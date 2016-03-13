using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, Identity]
        public int ProductID { get; set; }
        [Column, NotNull]
        public string ProductName { get; set; }
        [Association(Storage="_supplier", ThisKey="SupplierID", OtherKey="SupplierID")]
        public Supplier Supplier
        {
            get { return _supplier.Entity; }
            set { _supplier.Entity = value; }
        }
        [Association(Storage="_category", ThisKey="CategoryID", OtherKey="CategoryID")]
        public Category Category
        {
            get { return _category.Entity; }
            set { _category.Entity = value; }
        }
        [Column, Nullable]
        public string QuantityPerUnit { get; set; }
        [Column, Nullable]
        public decimal UnitPrice { get; set; }
        [Column, Nullable]
        public Int16 UnitsInStock { get; set; }
        [Column, Nullable]
        public Int16 UnitsOnOrder { get; set; }
        [Column, Nullable]
        public Int16 ReorderLevel { get; set; }
        [Column, NotNull]
        public Boolean Discontinued { get; set; }

        private EntityRef<Supplier> _supplier = new EntityRef<Supplier>();
        private EntityRef<Category> _category = new EntityRef<Category>();
        [Column, Nullable]
        public int? SupplierID;
        [Column, Nullable]
        public int? CategoryID;
    }
}
