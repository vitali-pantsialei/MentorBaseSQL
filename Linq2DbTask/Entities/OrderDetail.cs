using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Entities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Association(Storage="_order", ThisKey="OrderID", OtherKey="OrderID")]
        public Order Order
        {
            get { return _order.Entity; }
            set { _order.Entity = value; }
        }
        [Association(Storage="_product", ThisKey="ProductID", OtherKey="ProductID")]
        public Product Product
        {
            get { return _product.Entity; }
            set { _product.Entity = value; }
        }
        [Column, NotNull]
        public decimal UnitPrice { get; set; }
        [Column, NotNull]
        public Int16 Quantity { get; set; }
        [Column, NotNull]
        public Single Discount { get; set; }

        private EntityRef<Order> _order = new EntityRef<Order>();
        private EntityRef<Product> _product = new EntityRef<Product>();
        [Column, NotNull, PrimaryKey]
        public int? OrderID;
        [Column, NotNull, PrimaryKey]
        public int? ProductID;
    }
}
