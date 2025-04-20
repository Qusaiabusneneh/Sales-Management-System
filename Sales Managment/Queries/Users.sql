create table Users(
UserID int primary key,
UserName nvarchar(50),
Password nvarchar(50),
UserRoll nvarchar(50),
UserState nvarchar(50)
);
create procedure SP_GetAllUsers
as	
	begin
		select * from Users;
	end
---------------------------------------------
create procedure SP_AddNewUser
@NewUserID int output,
@Username nvarchar(50),
@Password nvarchar(256),
@UserRoll nvarchar(50),
@UserState nvarchar(50)
as
	begin
		insert into Users(UserName,Password,UserRoll,UserState)
		values(@Username,@Password,@UserRoll,@UserState)
		set @NewUserID=SCOPE_IDENTITY();
	end
---------------------------------------------
create procedure SP_GetUserInfoByID
@UserID int
as
	begin
		select * from Users where UserID=@UserID;
	end
---------------------------------------------
create procedure SP_UpdateUser
@UserID int,
@Username nvarchar(50),
@Password nvarchar(256),
@UserRoll nvarchar(50),
@UserState nvarchar(50)
as
	begin
		update Users set UserName=@Username,
						 Password=@Password,
						 UserRoll=@UserRoll,
						 UserState=@UserState
		where UserID=@UserID;
	end
---------------------------------------------
create procedure SP_DeleteUser
@UserID int
as
	begin
		delete from Users where UserID=@UserID;
	end
---------------------------------------------
create procedure SP_GetUserInfoByUsernameAndPassword
@Username nvarchar(50),
@Password nvarchar(255)
as
	begin
		select * from Users where Username = @Username and Password = @Password
	end

	EXEC [SP_GetUserInfoByUsernameAndPassword] @Username = 'قصي ابو سنينه', 
	@Password = '1211';
---------------------------------------------
create procedure SP_GetUserInfoUserStateInTrue
@UserState nvarchar(50)
as
	begin
		select * from Users where Users.UserState=@UserState;
	end
---------------------------------------------
create procedure SP_GetCountOfUsers
as
	begin
		select count(*) from Users;
	end
