create table Customers
(
	CustomerID int primary key,
	CustomerName nvarchar(50),
	CustomerEmail nvarchar(50),
	CustomerPhone nvarchar(50),
	CustomerImage image
);
create procedure SP_GetAllCustomers
as
	begin
		select * from Customers
	end
---------------------------------------------
create procedure SP_AddNewCustomer
@NewCustomerID int output,
@CustomerName nvarchar(50),
@CustomerPhone nvarchar(50),
@CustomerEmail nvarchar(50),
@CustomerImage image
as
	begin
		insert into Customers(CustomerName,CustomerPhone,CustomerEmail,CustomerImage)
		values(@CustomerName,@CustomerPhone,@CustomerEmail,@CustomerImage)
		set @NewCustomerID=SCOPE_IDENTITY();
	end
---------------------------------------------
create procedure SP_UpdateCustomer
@CustomerID int output,
@CustomerName nvarchar(50),
@CustomerPhone nvarchar(50),
@CustomerEmail nvarchar(50),
@CustomerImage image
as
	begin
		update Customers set CustomerName=@CustomerName,
							 CustomerPhone=@CustomerPhone,
							 CustomerEmail=@CustomerEmail,
							 CustomerImage=@CustomerImage
			 where CustomerID=@CustomerID;
	end
---------------------------------------------
create procedure SP_DeleteCustomer
@CustomerID int
as
	begin
		delete from Customers where CustomerID=@CustomerID;
	end
---------------------------------------------
create procedure SP_GetCustomerInfoByID
@CustomerID int
as
	begin
		select * from Customers where CustomerID=@CustomerID;
	end
---------------------------------------------
create procedure SP_GetCustomerInfoByCustomerName
@CustomerName nvarchar(50)
as
	begin
		select * from Customers where CustomerName=@CustomerName;
	end
---------------------------------------------
create procedure SP_GetCountOfCustomer
as
	begin
		select COUNT(*) from Customers
	end
---------------------------------------------
select * from Students