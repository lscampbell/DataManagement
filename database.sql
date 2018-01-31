--CREATE DATABASE DataManagement;

USE DataManagement
-- CREATE TABLE[dbo].[Users](  
--     [UserId][int] IDENTITY(1, 1) NOT NULL, [UserName][varchar](50) NULL, [UserMobile][varchar](50) NULL, [UserEmail][varchar](50) NULL, [FaceBookUrl][varchar](50) NULL, [LinkedInUrl][varchar](50) NULL, [TwitterUrl][varchar](50) NULL, [PersonalWebUrl][varchar](50) NULL, [IsDeleted][bit] NULL) ON[PRIMARY]  
-- GO  
-- ALTER TABLE[dbo].[Users] ADD CONSTRAINT[DF_User_IsDeleted] DEFAULT((0)) FOR[IsDeleted]  
-- GO

CREATE PROCEDURE[dbo].[AddUser]
    @UserName varchar(50),  
    @UserMobile varchar(50),  
    @UserEmail varchar(50),  
    @FaceBookUrl varchar(50),  
    @LinkedInUrl varchar(50),  
    @TwitterUrl varchar(50),  
    @PersonalWebUrl varchar(50)  
AS  
BEGIN  
SET NOCOUNT ON
INSERT INTO Users(UserName, UserMobile, UserEmail, FaceBookUrl, LinkedInUrl, TwitterUrl, PersonalWebUrl)  
VALUES(@UserName, @UserMobile, @UserEmail, @FaceBookUrl, @LinkedInUrl, @TwitterUrl, @PersonalWebUrl)  
END  
GO; 

CREATE PROCEDURE[dbo].[DeleteUser]  
@UserId int  
AS  
BEGIN  
SET NOCOUNT ON 
UPDATE Users set IsDeleted = 1 where UserId = @UserId  
END  

CREATE PROCEDURE[dbo].[GetAllUsers]  
AS  
BEGIN  
SET NOCOUNT ON  
select * from Users  
END

CREATE PROCEDURE[dbo].[GetUserById]  
@UserId int  
AS  
BEGIN  
SET NOCOUNT ON  
select * from Users where UserId = @UserId;  
END  
GO 

CREATE PROCEDURE[dbo].[UpdateUser]  
    @UserId int,  
    @UserName varchar(50),  
    @UserMobile varchar(50),  
    @UserEmail varchar(50),  
    @FaceBookUrl varchar(50),  
    @LinkedInUrl varchar(50),  
    @TwitterUrl varchar(50),  
    @PersonalWebUrl varchar(50)  
AS  
BEGIN  
SET NOCOUNT ON  
UPDATE Users SET
    UserName = @UserName,  
    UserMobile = @UserMobile,  
    UserEmail = @UserEmail,  
    FaceBookUrl = @FaceBookUrl,  
    LinkedInUrl = @LinkedInUrl,  
    TwitterUrl = @TwitterUrl,  
    PersonalWebUrl = @PersonalWebUrl  
WHERE UserId = @UserId  
END  
GO 

SELECT * FROM dbo.sysobjects
 WHERE (type = 'P')

 select *  from DataManagement.information_schema.routines 
 where (routine_type = 'PROCEDURE')