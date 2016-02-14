select ContactName, Country from Customers
	where Country in ('USA', 'Canada')
	order by ContactName, Country;

select ContactName, Country from Customers
	where Country not in ('USA', 'Canada')
	order by ContactName;

select distinct Country from Customers
	order by Country desc;