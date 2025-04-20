select * from Categories;
create procedure SP_GetAllCategories
as
	begin
		select * from Categories;
	end
-----------------------------------------------------------
create procedure SP_AddNewCategory
@CategoryName nvarchar(50),
@CategoryImage image,
@NewCategoryID int output
as
	begin
		insert into Categories(categoryName,categoryImage)
		values (@CategoryName,@CategoryImage)
		set @NewCategoryID=SCOPE_IDENTITY();
	end
-----------------------------------------------------------
create procedure SP_DeleteCategory
@CategoryID int
as
	begin
		delete from Categories where Categories.ID=@CategoryID;
	end
-----------------------------------------------------------
create procedure SP_UpdateCategory
@CategoryID int,
@CategoryName nvarchar(50),
@CategoryImage image
as
	begin
		update Categories 
		set categoryName=@CategoryName,
			categoryImage=@CategoryImage
			where ID=@CategoryID;
	end
-----------------------------------------------------------
create procedure SP_GetCategoryInfoByID
@CategoryID int
as
	begin
		select * from Categories where Categories.ID=@CategoryID;
	end
-----------------------------------------------------------
create procedure SP_GetCategoryInfoByCategoryName
@CategoryName nvarchar(50)
as
	begin
		select * from Categories where Categories.categoryName=@CategoryName;
	end
-----------------------------------------------------------
create procedure SP_GetCountOfCategories
as
	begin
		select COUNT(*) from Categories
	end