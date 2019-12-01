USE [master]
GO
/****** Object:  Database [Emissions]    Script Date: 01.12.2019 19:41:17 ******/
CREATE DATABASE [Emissions]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Emissions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Emissions.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Emissions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Emissions_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Emissions] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Emissions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Emissions] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Emissions] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Emissions] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Emissions] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Emissions] SET ARITHABORT OFF 
GO
ALTER DATABASE [Emissions] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Emissions] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Emissions] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Emissions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Emissions] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Emissions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Emissions] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Emissions] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Emissions] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Emissions] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Emissions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Emissions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Emissions] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Emissions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Emissions] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Emissions] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Emissions] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Emissions] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Emissions] SET  MULTI_USER 
GO
ALTER DATABASE [Emissions] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Emissions] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Emissions] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Emissions] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Emissions] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Emissions] SET QUERY_STORE = OFF
GO
USE [Emissions]
GO
/****** Object:  Table [dbo].[Parameters]    Script Date: 01.12.2019 19:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameters](
	[parameterUuid] [varchar](50) NOT NULL,
	[code] [varchar](50) NOT NULL,
	[unit] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[sensorUuid] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 01.12.2019 19:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[valueUuid] [varchar](50) NOT NULL,
	[timestampStart] [int] NOT NULL,
	[timestampEnd] [int] NOT NULL,
	[value] [varchar](50) NOT NULL,
	[parameterUuid] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sensors]    Script Date: 01.12.2019 19:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensors](
	[sensorUuid] [varchar](50) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[sourceUuid] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sources]    Script Date: 01.12.2019 19:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sources](
	[sourceUuid] [varchar](50) NOT NULL,
	[pniv] [int] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Emissions] SET  READ_WRITE 
GO
