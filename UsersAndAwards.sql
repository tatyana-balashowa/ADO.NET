USE [master]
GO
/****** Object:  Database [Users]    Script Date: 28.04.2020 16:21:37 ******/
CREATE DATABASE [Users]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Users', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Users.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Users_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Users_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Users] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Users].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Users] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Users] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Users] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Users] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Users] SET ARITHABORT OFF 
GO
ALTER DATABASE [Users] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Users] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Users] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Users] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Users] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Users] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Users] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Users] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Users] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Users] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Users] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Users] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Users] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Users] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Users] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Users] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Users] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Users] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Users] SET  MULTI_USER 
GO
ALTER DATABASE [Users] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Users] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Users] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Users] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Users] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Users] SET QUERY_STORE = OFF
GO
USE [Users]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 28.04.2020 16:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[IDAward] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[IDAward] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28.04.2020 16:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IDUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IDUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAward]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAward](
	[IDUser] [int] NOT NULL,
	[IDAward] [int] NOT NULL,
 CONSTRAINT [PK_UserAward] PRIMARY KEY CLUSTERED 
(
	[IDUser] ASC,
	[IDAward] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAward]  WITH CHECK ADD  CONSTRAINT [FK_UserAward_Award] FOREIGN KEY([IDAward])
REFERENCES [dbo].[Award] ([IDAward])
GO
ALTER TABLE [dbo].[UserAward] CHECK CONSTRAINT [FK_UserAward_Award]
GO
ALTER TABLE [dbo].[UserAward]  WITH CHECK ADD  CONSTRAINT [FK_UserAward_User] FOREIGN KEY([IDUser])
REFERENCES [dbo].[User] ([IDUser])
GO
ALTER TABLE [dbo].[UserAward] CHECK CONSTRAINT [FK_UserAward_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [HighAge] CHECK  (([Age]<(100)))
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [HighAge]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [LowAge] CHECK  (([Age]>(0)))
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [LowAge]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward]
@idUser int,
@title nvarchar(50)
AS
BEGIN
IF (NOT Exists(Select *From Award  where Title = @title))
begin 
 INSERT INTO Award (Title)
 Values (@title)
end 
 INSERT INTO UserAward (IDUser, IDAward)
 Values (@idUser, (Select IDAward from Award Where Title = @title))
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
   @Name NVARCHAR(10),
   @DateofBirth DATETIME, 
   @Age INT
AS
BEGIN
 INSERT INTO dbo.[User] ([Name],DateOfBirth, Age) 
 VALUES(@Name,@DateofBirth, @Age)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	SELECT * FROM dbo.[User]
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByUser]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardByUser]
@id int
AS
BEGIN
Select Award.IDAward, Award.Title From UserAward Inner Join Award on UserAward.IDAward=Award.IDAward
  Where UserAward.IDUser = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetDeletedUsers]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetDeletedUsers]
@id Int
AS
BEGIN
	SELECT * FROM dbo.[User] Where IDUser=@id
END

GO
/****** Object:  StoredProcedure [dbo].[GetNeedAwards]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNeedAwards]
@idUser int, 
@title nvarchar(50)
AS
BEGIN
Select Award.IDAward , Award.Title From Award inner Join UserAward on Award.IDAward = UserAward.IDAward Where UserAward.IDAward = (Select IDAward From Award Where Title = @title) And UserAward.IDUser = @idUser
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAward]
@title nvarchar(50),
@idUser int
AS
BEGIN
	Delete from UserAward Where IdAward = (Select IDAward From Award Where Title = @title) And IDUser = @idUser
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 28.04.2020 16:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUser]
@id Int
AS
BEGIN
    Delete from UserAward Where IDUser = @id
	DELETE FROM [User]
	WHERE IDUser=@id
END
GO
USE [master]
GO
ALTER DATABASE [Users] SET  READ_WRITE 
GO
