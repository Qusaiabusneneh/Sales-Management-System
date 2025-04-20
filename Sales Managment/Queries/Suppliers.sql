create table Suppliers
(
	SupplierID int primary key,
	SupplierName nvarchar(50),
	SupplierPhone nvarchar(50),
	SupplierEmail nvarchar(50),
	SupplierImage image
);
create procedure SP_GetAllSuppliers
as
	begin
		select * from Suppliers;
	end
---------------------------------------------------
create procedure SP_AddNewSupplier
@NewSupplierID int output,
@SupplierName nvarchar(50),
@SupplierEmail nvarchar(50),
@SuppplierPhone nvarchar(50),
@SupplierImage image
as
	begin
		insert into Suppliers(SupplierName,SupplierPhone,SupplierEmail,SupplierImage)
		VALUES(@SupplierName,@SuppplierPhone,@SupplierEmail,@SupplierImage)
		SET @NewSupplierID=SCOPE_IDENTITY();
	end
---------------------------------------------------
create procedure SP_UpdateSupplierInfo
@SupplierID int,
@SupplierName nvarchar(50),
@SupplierPhone nvarchar(50),
@SupplierEmail nvarchar(50),
@SupplierImage image
as
	begin
		update Suppliers set SupplierName=@SupplierName,
							 SupplierPhone=@SupplierPhone,
							 SupplierEmail=@SupplierEmail,
							 SupplierImage=@SupplierImage
		where SupplierID=@SupplierID;
	end
---------------------------------------------------
create procedure SP_DeleteSupplier
@SupplierID int
as 
	begin
		delete from Suppliers where SupplierID=@SupplierID;
	end
---------------------------------------------------
create procedure SP_GetSupplierInfoByID
@SupplierID int
as
	begin
		select * from Suppliers where SupplierID=@SupplierID;
	end
---------------------------------------------------
create procedure SP_GetSupplierInfoBySupplierName
@SupplierName nvarchar(50)
as
	begin
		select * from Suppliers where SupplierName=@SupplierName;
	end
---------------------------------------------
create procedure SP_GetCountOfSuppliers
as
	begin
		select count(*) from Suppliers;
	end
