using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System.Collections.Generic;

namespace DALTest
{
    [TestClass]
    public class DALTests
    {
        IOrdersManipulation nwOrders;

        [TestInitialize]
        public void Initialize()
        {
            this.nwOrders = new NorthwindOrders();
        }

        [TestMethod]
        public void Test_GetOrders()
        {
            IList<Order> orders = nwOrders.GetOrders();
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public void Test_GetOrderDetails()
        {
            Order order = new Order()
            {
                OrderID = 11063
            };
            OrderDetails orderDetails = nwOrders.GetOrderDetails(order);
            Assert.IsTrue(!String.IsNullOrEmpty(orderDetails.ProductName));
        }

        [TestMethod]
        public void Test_UpdateOrder_FromInProgress()
        {
            Order order = new Order()
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                Freight = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShipAddress = "address",
                ShipCity = "city",
                ShipCountry = "country",
                ShipName = "name",
                ShippedDate = null,
                ShipPostalCode = "223710",
                ShipRegion = "Region",
                ShipVia = 1
            };
            Assert.IsFalse(nwOrders.UpdateOrder(order));
        }

        [TestMethod]
        public void Test_DeleteOrder_FromComplete()
        {
            Order order = new Order()
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                Freight = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShipAddress = "address",
                ShipCity = "city",
                ShipCountry = "country",
                ShipName = "name",
                ShippedDate = DateTime.Now,
                ShipPostalCode = "223710",
                ShipRegion = "Region",
                ShipVia = 1
            };
            Assert.IsFalse(nwOrders.DeleteOrder(order));
        }

        [TestMethod]
        public void Test_SetInProgress_FromInProgress()
        {
            Order order = new Order()
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                Freight = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShipAddress = "address",
                ShipCity = "city",
                ShipCountry = "country",
                ShipName = "name",
                ShippedDate = null,
                ShipPostalCode = "223710",
                ShipRegion = "Region",
                ShipVia = 1
            };
            Assert.IsFalse(nwOrders.SetInProgress(order, null));
        }

        [TestMethod]
        public void Test_GetCustomerOrderHistory()
        {
            string customerId = "ALFKI";
            IList<CustomerOrderHist> custHist = nwOrders.GetCustomerOrdersHistory(customerId);
            Assert.IsTrue(custHist.Count > 0);
        }
    }
}
