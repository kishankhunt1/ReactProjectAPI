USE [master]
GO
/****** Object:  Database [ReactAPIProject]    Script Date: 2024-05-07 12:55:11 AM ******/
CREATE DATABASE [ReactAPIProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReactAPIProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ReactAPIProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReactAPIProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ReactAPIProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ReactAPIProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReactAPIProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReactAPIProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReactAPIProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReactAPIProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReactAPIProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReactAPIProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReactAPIProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReactAPIProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReactAPIProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReactAPIProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReactAPIProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReactAPIProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReactAPIProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReactAPIProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReactAPIProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReactAPIProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReactAPIProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReactAPIProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReactAPIProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReactAPIProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReactAPIProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReactAPIProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReactAPIProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReactAPIProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReactAPIProject] SET  MULTI_USER 
GO
ALTER DATABASE [ReactAPIProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReactAPIProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReactAPIProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReactAPIProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReactAPIProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReactAPIProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ReactAPIProject] SET QUERY_STORE = OFF
GO
USE [ReactAPIProject]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 2024-05-07 12:55:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[CountryCode] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [Created], [Modified]) VALUES (1, N'India', N'IND', CAST(N'2024-04-29T23:51:42.930' AS DateTime), CAST(N'2024-04-29T23:51:42.930' AS DateTime))
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [Created], [Modified]) VALUES (2, N'string', N'string', CAST(N'2024-05-07T00:16:26.150' AS DateTime), CAST(N'2024-05-07T00:16:26.150' AS DateTime))
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
/****** Object:  StoredProcedure [dbo].[PR_Country_DeleteByPK]    Script Date: 2024-05-07 12:55:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Country_DeleteByPK]
@CountryID		INT
AS
DELETE 
From	dbo.Country
WHERE	dbo.Country.CountryID=@CountryID
GO
/****** Object:  StoredProcedure [dbo].[PR_Country_Insert]    Script Date: 2024-05-07 12:55:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Country_Insert]
--@CountryID		INT,
@CountryName		NVARCHAR(50),
@CountryCode		NVARCHAR(50),
@Created			DATETIME,
@Modified			DATETIME
AS

INSERT INTO dbo.Country
(
		dbo.Country.CountryName,
		dbo.Country.CountryCode,
		dbo.Country.Created,
		dbo.Country.Modified
)
VALUES
(
		@CountryName,
		@CountryCode,
		ISNULL(@Created,GETDATE()),
		ISNULL(@Modified,GETDATE())
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Country_SelectAll]    Script Date: 2024-05-07 12:55:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Country_SelectAll]
AS
SELECT
		dbo.Country.CountryID,
		dbo.Country.CountryName,
		dbo.Country.CountryCode,
		dbo.Country.Created,
		dbo.Country.Modified
FROM	dbo.Country
Order
By		dbo.Country.CountryName
GO
/****** Object:  StoredProcedure [dbo].[PR_Country_SelectByPK]    Script Date: 2024-05-07 12:55:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Country_SelectByPK]
@CountryID		INT
AS
SELECT
		dbo.Country.CountryID,
		dbo.Country.CountryName,
		dbo.Country.CountryCode,
		dbo.Country.Created,
		dbo.Country.Modified
FROM	dbo.Country
WHERE	dbo.Country.CountryID=@CountryID
Order
By		dbo.Country.CountryName
GO
/****** Object:  StoredProcedure [dbo].[PR_Country_UpdateByPK]    Script Date: 2024-05-07 12:55:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Country_UpdateByPK]
@CountryID		INT,
@CountryName		NVARCHAR(50),
@CountryCode		NVARCHAR(50),
@Modified			DATETIME
AS
UPDATE  dbo.Country
SET
		dbo.Country.CountryName=@CountryName,
		dbo.Country.CountryCode=@CountryCode,
		dbo.Country.Modified=GETDATE()
WHERE	dbo.Country.CountryID=@CountryID
GO
USE [master]
GO
ALTER DATABASE [ReactAPIProject] SET  READ_WRITE 
GO
