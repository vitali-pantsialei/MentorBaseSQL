using Linq2DbTask.Entities;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DbTask.Queries
{
    public static class SelectQueries
    {
        public class EmployeeRegion
        {
            public string LastName {get;set;}
            public string FirstName {get;set;}
            public string RegionDescription {get;set;}
        }

        public class EmployeeRegionStat
        {
            public string RegionDescription { get; set; }
            public int EmployeeCount { get; set; }
        }

        public class EmployeeShipper
        {
            public Employee Employee {get;set;}
            public Shipper Shipper {get;set;}
        }

        public static IEnumerable<Product> Products()
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                var q = from p in db.Product
                        select p;
                return q.ToList();
            }
        }

        public static IEnumerable<EmployeeRegion> GetEmployeeRegionInformation()
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                var q = from e in db.Employee
                        join et in db.EmployeeTerritory on e.EmployeeID equals et.Employee.EmployeeID
                        join t in db.Territory on et.Territory.TerritoryID equals t.TerritoryID
                        join r in db.Region on t.Region.RegionID equals r.RegionID
                        select new EmployeeRegion()
                        {
                            LastName = e.LastName,
                            FirstName = e.FirstName,
                            RegionDescription = r.RegionDescription
                        };
                return q.ToList();
            }
        }

        public static IEnumerable<EmployeeRegionStat> GetEmployeeRegionStatistic()
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                var q = from e in db.Employee
                        join et in db.EmployeeTerritory on e.EmployeeID equals et.Employee.EmployeeID
                        join t in db.Territory on et.Territory.TerritoryID equals t.TerritoryID
                        join r in db.Region on t.Region.RegionID equals r.RegionID
                        group e by r.RegionDescription into grp
                        select new EmployeeRegionStat()
                        {
                            RegionDescription = grp.Key,
                            EmployeeCount = grp.Count()
                        };
                return q.ToList();
            }
        }

        public static IEnumerable<EmployeeShipper> GetEmployeeShipperCoworking()
        {
            using (DbNorthwind db = new DbNorthwind())
            {
                var q = from o in db.Order
                        select new EmployeeShipper()
                        {
                            Employee = o.Employee,
                            Shipper = o.Shipper
                        };
                return q.ToList();
            }
        }
    }
}
