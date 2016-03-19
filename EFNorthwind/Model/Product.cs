using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("Supplier")]
        public int? SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey("Category")]
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public Int16 UnitsOnOrder { get; set; }
        public Int16 ReorderLevel { get; set; }
        public Boolean Discontinued { get; set; }
    }
}
