create table Sells(
	SellID int primary key,
	CustomerID int references Customers(CustomerID),
	PurchaseID int references Purchases(PurchasesID),
	Price float,
	Quantity int,
	SellDate datetime,
	TotalPrice float
)
create procedure SP_GetAllSells
as
	begin
		select Sells.SellID,Customers.CustomerName,Purchases.PurchaseName,Sells.Price,Sells.Quantity,Sells.SellDate,Sells.TotalPrice from Sells
		inner join Customers on Customers.CustomerID=Sells.CustomerID
		inner join Purchases on Purchases.PurchasesID=Sells.PurchaseID;
	end
-------------------------------------------------------------------------
create procedure SP_AddNewSell
@NewSellID int output,
@CustomerID int,
@PurchaseID int,
@Price float,
@Quantity int,
@SellDate datetime,
@TotalPrice float
as
	begin
		insert into Sells(CustomerID,PurchaseID,Price,Quantity,SellDate,TotalPrice)
		values (@CustomerID,@PurchaseID,@Price,@Quantity,@SellDate,@TotalPrice)
		set @NewSellID=SCOPE_IDENTITY();
	end
-------------------------------------------------------------------------
create procedure SP_UpdateSell
@SellID int,
@CustomerID int,
@PurchaseID int,
@Price float,
@Quantity int,
@SellDate datetime,
@TotalPrice float
as
	begin
		update Sells set CustomerID=@CustomerID,
						 PurchaseID=@PurchaseID,
						 Price=@Price,
						 Quantity=@Quantity,
						 SellDate=@SellDate,
						 TotalPrice=@TotalPrice
			 where Sells.SellID=@SellID;
	end
-------------------------------------------------------------------------
create procedure SP_DeleteSell
@SellID int 
as
	begin
		delete from Sells where Sells.SellID=@SellID;
	end
-------------------------------------------------------------------------
create procedure SP_GetSellInfoByID
@SellID int 
as
	begin
		select Sells.SellID,Customers.CustomerName,Purchases.PurchaseName,Sells.Price,Sells.Quantity,Sells.SellDate,Sells.TotalPrice from Sells
		inner join Customers on Customers.CustomerID=Sells.CustomerID
		inner join Purchases on Purchases.PurchasesID=Sells.PurchaseID
		where Sells.SellID=@SellID;
	end
-------------------------------------------------------------------------
create procedure SP_GetCountOfSells
as
	begin
		select COUNT(*)from Sells;
	end