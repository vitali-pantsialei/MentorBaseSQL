using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Linq2DbTask.Queries;
using Linq2DbTask.Entities;

namespace Linq2DbTests
{
    [TestClass]
    public class Linq2Tests
    {
        [TestMethod]
        public void ProductListTest()
        {
            SelectQueries.Products();
        }

        [TestMethod]
        public void EmployeeRegionTest()
        {
            SelectQueries.GetEmployeeRegionInformation();
        }

        [TestMethod]
        public void EmployeeRegionStatisticTest()
        {
            SelectQueries.GetEmployeeRegionStatistic();
        }

        [TestMethod]
        public void EmployeeShipperTest()
        {
            SelectQueries.GetEmployeeShipperCoworking();
        }

        [TestMethod]
        public void NewEmployeeTest()
        {
            ManipQueries.AddEmployee("Petrov", new string[] {"01581", "01730"});
        }

        [TestMethod]
        public void AddProductsTest()
        {
            ManipQueries.AddProducts(new Product[] {
                new Product()
                {
                    ProductName = "Ice cream",
                    Category = new Category()
                    {
                        CategoryName = "Cool cat"
                    },
                    Supplier = new Supplier()
                    {
                        CompanyName = "SupCO"
                    }
                }
            });
        }

        [TestMethod]
        public void ReplaceByProductTest()
        {
            ManipQueries.ReplaceByProduct(new Linq2DbTask.Entities.Product()
            {
                ProductID = 1
            });
        }
    }
}
