create table Purchases
(
	PurchasesID int primary key,
	CategoryID int references  Categories(CategoryID),
	SupplierID int references Suppliers(SupplierID),
	PurchaseName nvarchar(50),
	PurchaseType nvarchar(50),
	PurchaseDetails nvarchar(50),
	PurchaseBuy float,
	PurchaseSell float,
	PurchaseQuantity float,
	purchaseTotalSell float,
	PurchaseTotalBuy float,
	PurchaseTotalEarnings float
);

select * from Purchases;

create procedure SP_AddNewPurchases
@NewPurchaseID int output,
@CategoryID int,
@SupplierID int,
@PurchaseName nvarchar(50),
@PurchaseType nvarchar(50),
@PurchaseDetails nvarchar(50),
@PurchaseBuy float,
@PurchaseSell float,
@PurchaseQuantity float,
@purchaseTotalSell float,
@PurchaseTotalBuy float,
@PurchaseTotalEarnings float
as
	begin
		insert into Purchases(CategoryID,SupplierID,PurchaseName,PurchaseType,PurchaseDetails,
							 PurchaseBuy,PurchaseSell,PurchaseQuantity,purchaseTotalSell,
							 PurchaseTotalBuy,PurchaseTotalEarnings) 
					VALUES(@CategoryID,@SupplierID,@PurchaseName,@PurchaseType,@PurchaseDetails,
						  @PurchaseBuy,@PurchaseSell,@PurchaseQuantity,@purchaseTotalSell,
						  @PurchaseTotalBuy,@PurchaseTotalEarnings)
				set @NewPurchaseID=SCOPE_IDENTITY();
	end
-----------------------------------------------------------------------------------
create procedure SP_UpdatePurchase
@PurchaseID int,
@CategoryID int,
@SupplierID int,
@PurchaseName nvarchar(50),
@PurchaseType nvarchar(50),
@PurchaseDetails nvarchar(50),
@PurchaseBuy float,
@PurchaseSell float,
@PurchaseQuantity float,
@purchaseTotalSell float,
@PurchaseTotalBuy float,
@PurchaseTotalEarnings float
as
	begin
		update Purchases set CategoryID=@CategoryID,
							 SupplierID=@SupplierID,
							 PurchaseName=@PurchaseName,
							 PurchaseType=@PurchaseType,
							 PurchaseDetails=@PurchaseDetails,
							 PurchaseBuy=@PurchaseBuy,
							 PurchaseSell=@PurchaseSell,
							 PurchaseQuantity=@PurchaseQuantity,
							 purchaseTotalSell =@purchaseTotalSell,
							 PurchaseTotalBuy =@PurchaseTotalBuy,
							 PurchaseTotalEarnings=@PurchaseTotalEarnings
				where Purchases.PurchasesID=@PurchaseID;
	end
-----------------------------------------------------------------------------------
create procedure SP_GetAllPurchases
as
	begin
		select Purchases.PurchasesID,Categories.categoryName,Suppliers.SupplierName,Purchases.PurchaseName,
		Purchases.PurchaseType,Purchases.PurchaseDetails, Purchases.PurchaseBuy,
		Purchases.PurchaseSell,Purchases.PurchaseQuantity,Purchases.purchaseTotalSell,
		Purchases.PurchaseTotalBuy,Purchases.PurchaseTotalEarnings from Purchases
		inner join Categories on Categories.CategoryID=Purchases.CategoryID
		inner join Suppliers on Suppliers.SupplierID = Purchases.SupplierID;
	end
-----------------------------------------------------------------------------------
create procedure SP_GetPurchaseInfoByID
@PurchaseID int
as	
	begin
		select * from Purchases where Purchases.PurchasesID=@PurchaseID;
	end
-----------------------------------------------------------------------------------
create procedure SP_DeletePurchase
@PurchaseID int
as
	begin
		delete from Purchases where Purchases.PurchasesID=@PurchaseID;
	end
----------------------------------------------------------------------------------
create procedure SP_GetPurchaseInfoByPurchaseName
@PurchaseName nvarchar(50)
as	
	begin
		select * from Purchases where Purchases.PurchaseName=@PurchaseName;
	end
-----------------------------------------------------------------------------------
create procedure SP_GetCountOfPurchases
as
	begin
		select  COUNT(*) from Purchases
	end