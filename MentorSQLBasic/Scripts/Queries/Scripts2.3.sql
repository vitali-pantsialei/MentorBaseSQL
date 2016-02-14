select distinct OrderID from [Order Details]
	where Quantity between 3 and 10;

select CustomerID, Country from Customers
	where Lower(Country) between 'b%' and 'h%'
	order by Country;

select CustomerID, Country from Customers
	where Lower(Country) >= 'b%' and Lower(Country) <= 'h%';