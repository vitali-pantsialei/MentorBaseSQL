using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class OrderDetail
    {
        [Key]
        [ForeignKey("Order"), Column(Order = 0)]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [Key]
        [ForeignKey("Product"), Column(Order = 1)]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Single Discount { get; set; }
    }
}
