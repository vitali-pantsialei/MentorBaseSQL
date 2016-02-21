select distinct e.FirstName from Employees e
	inner join EmployeeTerritories et
	on e.EmployeeID = et.EmployeeID
	inner join Territories t
	on et.TerritoryID = t.TerritoryID
	inner join Region r
	on r.RegionID = t.RegionID
	where r.RegionDescription = N'Western';

select c.ContactName, count(o.CustomerID) from Customers c
	left join Orders o
	on c.CustomerID = o.CustomerID
	group by c.ContactName
	order by count(o.CustomerID)