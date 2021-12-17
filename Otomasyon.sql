USE [master]
GO
/****** Object:  Database [Otomasyon]    Script Date: 6.09.2021 14:43:42 ******/
CREATE DATABASE [Otomasyon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Otomasyon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Otomasyon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Otomasyon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Otomasyon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Otomasyon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Otomasyon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Otomasyon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Otomasyon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Otomasyon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Otomasyon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Otomasyon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Otomasyon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Otomasyon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Otomasyon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Otomasyon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Otomasyon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Otomasyon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Otomasyon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Otomasyon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Otomasyon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Otomasyon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Otomasyon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Otomasyon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Otomasyon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Otomasyon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Otomasyon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Otomasyon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Otomasyon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Otomasyon] SET RECOVERY FULL 
GO
ALTER DATABASE [Otomasyon] SET  MULTI_USER 
GO
ALTER DATABASE [Otomasyon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Otomasyon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Otomasyon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Otomasyon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Otomasyon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Otomasyon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Otomasyon', N'ON'
GO
ALTER DATABASE [Otomasyon] SET QUERY_STORE = OFF
GO
USE [Otomasyon]
GO
/****** Object:  Table [dbo].[kullanicilar]    Script Date: 6.09.2021 14:43:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanicilar](
	[tcno] [float] NULL,
	[ad] [nvarchar](255) NULL,
	[soyad] [nvarchar](255) NULL,
	[yetki] [nvarchar](255) NULL,
	[kullaniciadi] [nvarchar](255) NULL,
	[parola] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musteriarac]    Script Date: 6.09.2021 14:43:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteriarac](
	[aracmarkamodel] [varchar](50) NULL,
	[aracyil] [smallint] NULL,
	[aracplaka] [varchar](50) NOT NULL,
	[musterisikayet] [varchar](50) NULL,
	[yapilacakislemler] [varchar](50) NOT NULL,
	[bittimi] [bit] NULL,
	[yapilanislemler] [varchar](50) NULL,
	[musteritelefon] [numeric](18, 0) NULL,
	[aracsahibiadsoyad] [varchar](50) NULL,
	[email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[kullanicilar] ([tcno], [ad], [soyad], [yetki], [kullaniciadi], [parola]) VALUES (11111111111, N'CIHAN', N'YANTIR', N'Yönetici', N'cihanom', 1689712)
INSERT [dbo].[kullanicilar] ([tcno], [ad], [soyad], [yetki], [kullaniciadi], [parola]) VALUES (22222222222, N'Mehmet', N'Karayel', N'Kullanıcı', N'mehmet', 168971)
GO
INSERT [dbo].[musteriarac] ([aracmarkamodel], [aracyil], [aracplaka], [musterisikayet], [yapilacakislemler], [bittimi], [yapilanislemler], [musteritelefon], [aracsahibiadsoyad], [email]) VALUES (N'sss', 1995, N'60', N'ssssss', N'sdddddd', 1, NULL, CAST(222222222 AS Numeric(18, 0)), N'ssssss', N'a@gmail.com')
INSERT [dbo].[musteriarac] ([aracmarkamodel], [aracyil], [aracplaka], [musterisikayet], [yapilacakislemler], [bittimi], [yapilanislemler], [musteritelefon], [aracsahibiadsoyad], [email]) VALUES (N'citroen c4 1.4 sx', 2004, N'34xd3434', N'fren eskisi gibi değil', N'yapacak birşey yok', 0, NULL, CAST(5555555555 AS Numeric(18, 0)), N'serkan şahin', NULL)
INSERT [dbo].[musteriarac] ([aracmarkamodel], [aracyil], [aracplaka], [musterisikayet], [yapilacakislemler], [bittimi], [yapilanislemler], [musteritelefon], [aracsahibiadsoyad], [email]) VALUES (N'Plaio', 1999, N'60abg332', N'sss', N'ssss', NULL, NULL, CAST(5362083112 AS Numeric(18, 0)), N'Mehmet', N'mehmet@hotmail.com')
GO
USE [master]
GO
ALTER DATABASE [Otomasyon] SET  READ_WRITE 
GO
