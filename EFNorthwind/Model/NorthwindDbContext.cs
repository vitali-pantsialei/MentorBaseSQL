using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNorthwind.Model
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext() : base("NorthwindConnection") { }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Shipper> Shippers { get; set; }
        public IDbSet<Supplier> Suppliers { get; set; }
        public IDbSet<Territory> Territories { get; set; }
        public IDbSet<EmployeeCard> Cards { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
