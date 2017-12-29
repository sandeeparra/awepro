USE [master]
GO
/****** Object:  Database [ISW]    Script Date: 12/29/2017 4:17:35 PM ******/
CREATE DATABASE [ISW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ISW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ISW.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ISW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ISW_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ISW] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ISW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ISW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ISW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ISW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ISW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ISW] SET ARITHABORT OFF 
GO
ALTER DATABASE [ISW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ISW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ISW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ISW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ISW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ISW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ISW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ISW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ISW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ISW] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ISW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ISW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ISW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ISW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ISW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ISW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ISW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ISW] SET RECOVERY FULL 
GO
ALTER DATABASE [ISW] SET  MULTI_USER 
GO
ALTER DATABASE [ISW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ISW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ISW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ISW] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ISW] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ISW', N'ON'
GO
ALTER DATABASE [ISW] SET  READ_WRITE 
GO
