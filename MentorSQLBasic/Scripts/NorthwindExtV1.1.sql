if not exists (select * from sys.objects
	where OBJECT_ID = OBJECT_ID(N'[dbo].[Credit Cards]'))
begin
create table [dbo].[Credit Cards](
	[CreditCardID] [int] identity(1,1) not null,
	[CreditCardNumber] [varchar](20) not null,
	[ExpirationDate] [datetime] not null,
	[CardHolder] [nvarchar](200) not null,
	[EmployeeID] [int],
	constraint [PK_CreditCards] primary key ([CreditCardID] asc),
	constraint [FK_EmpID] foreign key ([EmployeeID]) references [dbo].[Employees] ([EmployeeID])
)
end