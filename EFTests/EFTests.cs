using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFNorthwind.Model;
using System.Collections.Generic;

namespace EFTests
{
    [TestClass]
    public class EFTests
    {
        public class OrderInformation
        {
            public decimal UnitPrice { get; set; }
            public Int16 Quantity { get; set; }
            public Single Discount { get; set; }
            public string ProductName { get; set; }
            public string ContactName { get; set; }
        }

        [TestMethod]
        public void CategoryTest()
        {
            using (NorthwindDbContext db = new NorthwindDbContext())
            {
                IQueryable<Category> categories = from cat in db.Categories
                                                  select cat;
                Assert.IsTrue(categories.Count() > 0);
                IQueryable<OrderInformation> of = from o in db.Orders
                                                  join od in db.OrderDetails on o.OrderID equals od.OrderID
                                                  join c in db.Customers on o.CustomerID equals c.CustomerID
                                                  join p in db.Products on od.ProductID equals p.ProductID
                                                  where p.Category.CategoryName == "Condiments"
                                                  select new OrderInformation()
                                                  {
                                                      ContactName = c.ContactName,
                                                      Discount = od.Discount,
                                                      ProductName = p.ProductName,
                                                      Quantity = od.Quantity,
                                                      UnitPrice = od.UnitPrice
                                                  };
                Assert.IsTrue(of.Count() > 0);
            }
        }
    }
}
