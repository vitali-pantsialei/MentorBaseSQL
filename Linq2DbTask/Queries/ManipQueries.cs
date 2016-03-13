using Linq2DbTask.Entities;
using LinqToDB.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Queries
{
    public static class ManipQueries
    {
        public static void AddEmployee(string lastName, string[] territories, string firstName = "", string title = "")
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                Employee emp = new Employee()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    Title = title,
                    BirthDate = DateTime.Now,
                    HireDate = DateTime.Now
                };
                emp.EmployeeID = Convert.ToInt32(db.InsertWithIdentity(emp));
                foreach (string terr in territories)
                {
                    Territory territory = (from t in db.Territory
                                          where t.TerritoryID == terr
                                          select t).First();
                    EmployeeTerritory et = new EmployeeTerritory()
                    {
                         Employee = emp,
                         Territory = territory
                    };
                }
            }
        }

        public static void UpdateCategory(Product[] products, Category newCategory)
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                foreach (Product prod in products)
                {
                    prod.Category = newCategory;
                    db.Update(prod);
                }
            }
        }

        public static void AddProducts(Product[] products)
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                foreach (Product prod in products)
                {
                    var cat = from c in db.Category
                                    where c.CategoryID == prod.Category.CategoryID
                                    select c;
                    if (cat.Count() == 0)
                        prod.Category.CategoryID = Convert.ToInt32(db.InsertWithIdentity(prod.Category));
                    else
                        prod.Category = cat.First();

                    var sup = from s in db.Supplier
                                    where s.SupplierID == prod.Supplier.SupplierID
                                    select s;
                    if (sup.Count() == 0)
                        prod.Supplier.SupplierID = Convert.ToInt32(db.InsertWithIdentity(prod.Supplier));
                    else
                        prod.Supplier = sup.First();

                    db.Insert(prod);
                }
            }
        }

        public static void ReplaceByProduct(Product newProduct)
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                var prod = from p in db.Product
                                where p.ProductID == newProduct.ProductID
                                select p;
                if (prod.Count() == 0)
                    newProduct.ProductID = Convert.ToInt32(db.InsertWithIdentity(newProduct));

                var q = (from o in db.Order
                        where o.ShippedDate == null
                        select o).ToList();
                foreach (Order order in q)
                {
                    OrderDetail orderDetail = (from od in db.OrderDetail 
                                               where od.Order.OrderID == order.OrderID
                                               select od).First();
                    orderDetail.Product = newProduct;
                    db.Update(orderDetail);
                }
            }
        }
    }
}
