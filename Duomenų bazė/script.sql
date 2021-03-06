USE [master]
GO
/****** Object:  Database [akademine_sistema]    Script Date: 2020-12-06 09:15:14 ******/
CREATE DATABASE [akademine_sistema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AS', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'AS_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [akademine_sistema] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [akademine_sistema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [akademine_sistema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [akademine_sistema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [akademine_sistema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [akademine_sistema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [akademine_sistema] SET ARITHABORT OFF 
GO
ALTER DATABASE [akademine_sistema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [akademine_sistema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [akademine_sistema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [akademine_sistema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [akademine_sistema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [akademine_sistema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [akademine_sistema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [akademine_sistema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [akademine_sistema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [akademine_sistema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [akademine_sistema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [akademine_sistema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [akademine_sistema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [akademine_sistema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [akademine_sistema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [akademine_sistema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [akademine_sistema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [akademine_sistema] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [akademine_sistema] SET  MULTI_USER 
GO
ALTER DATABASE [akademine_sistema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [akademine_sistema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [akademine_sistema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [akademine_sistema] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [akademine_sistema] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [akademine_sistema] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [akademine_sistema] SET QUERY_STORE = OFF
GO
USE [akademine_sistema]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 2020-12-06 09:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[surname] [nvarchar](20) NOT NULL,
	[username] [nvarchar](40) NOT NULL,
	[password] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grades]    Script Date: 2020-12-06 09:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grades](
	[subjectId] [int] NOT NULL,
	[studentId] [int] NOT NULL,
	[grade] [decimal](2, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 2020-12-06 09:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students]    Script Date: 2020-12-06 09:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[surname] [nvarchar](20) NOT NULL,
	[username] [nvarchar](40) NOT NULL,
	[password] [nvarchar](40) NOT NULL,
	[groupId] [int] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subjects]    Script Date: 2020-12-06 09:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](40) NOT NULL,
	[groupId] [int] NULL,
 CONSTRAINT [PK_subjects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teachers]    Script Date: 2020-12-06 09:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teachers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[surname] [nvarchar](20) NOT NULL,
	[username] [nvarchar](40) NOT NULL,
	[password] [nvarchar](40) NOT NULL,
	[subjectId] [int] NULL,
 CONSTRAINT [PK_teacherssss] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[admins] ON 

INSERT [dbo].[admins] ([id], [name], [surname], [username], [password]) VALUES (1, N'Vaidas', N'Liubinas', N'vaidas', N'vaidas')
SET IDENTITY_INSERT [dbo].[admins] OFF
GO
INSERT [dbo].[grades] ([subjectId], [studentId], [grade]) VALUES (1, 4, CAST(10 AS Decimal(2, 0)))
INSERT [dbo].[grades] ([subjectId], [studentId], [grade]) VALUES (1, 5, CAST(10 AS Decimal(2, 0)))
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([id], [name]) VALUES (4, N'PI18D')
INSERT [dbo].[groups] ([id], [name]) VALUES (5, N'PI19B')
INSERT [dbo].[groups] ([id], [name]) VALUES (6, N'PI20C')
INSERT [dbo].[groups] ([id], [name]) VALUES (7, N'KS18A')
INSERT [dbo].[groups] ([id], [name]) VALUES (8, N'IS18A')
INSERT [dbo].[groups] ([id], [name]) VALUES (9, N'EI18B')
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [name], [surname], [username], [password], [groupId]) VALUES (4, N'Gabrielius', N'Radžiūnas', N'gabrielius', N'gabrielius', 5)
INSERT [dbo].[students] ([id], [name], [surname], [username], [password], [groupId]) VALUES (5, N'Goda', N'Marcinkevičiūtė', N'goda', N'goda', 5)
INSERT [dbo].[students] ([id], [name], [surname], [username], [password], [groupId]) VALUES (6, N'Lukas', N'Vanglikas', N'lukas', N'lukas', 4)
INSERT [dbo].[students] ([id], [name], [surname], [username], [password], [groupId]) VALUES (7, N'Lukas', N'Anužis', N'lukas', N'lukas', 5)
INSERT [dbo].[students] ([id], [name], [surname], [username], [password], [groupId]) VALUES (36, N'g', N'g', N'g', N'g', NULL)
SET IDENTITY_INSERT [dbo].[students] OFF
GO
SET IDENTITY_INSERT [dbo].[subjects] ON 

INSERT [dbo].[subjects] ([id], [title], [groupId]) VALUES (1, N'Objektinis programavimas', 5)
INSERT [dbo].[subjects] ([id], [title], [groupId]) VALUES (2, N'Informacijos sistemos', 5)
INSERT [dbo].[subjects] ([id], [title], [groupId]) VALUES (3, N'Duomenų bazių projektavimas', 5)
INSERT [dbo].[subjects] ([id], [title], [groupId]) VALUES (4, N'Antroji programavimo praktika', 5)
INSERT [dbo].[subjects] ([id], [title], [groupId]) VALUES (5, N'Vadyba', 5)
INSERT [dbo].[subjects] ([id], [title], [groupId]) VALUES (6, N'Teisė', 5)
SET IDENTITY_INSERT [dbo].[subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[teachers] ON 

INSERT [dbo].[teachers] ([id], [name], [surname], [username], [password], [subjectId]) VALUES (1, N'Mindaugas', N'Liogys', N'mindaugas', N'mindaugas', 1)
SET IDENTITY_INSERT [dbo].[teachers] OFF
GO
ALTER TABLE [dbo].[grades]  WITH CHECK ADD  CONSTRAINT [FK_grades_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([id])
GO
ALTER TABLE [dbo].[grades] CHECK CONSTRAINT [FK_grades_students]
GO
ALTER TABLE [dbo].[grades]  WITH CHECK ADD  CONSTRAINT [FK_grades_subjects] FOREIGN KEY([subjectId])
REFERENCES [dbo].[subjects] ([id])
GO
ALTER TABLE [dbo].[grades] CHECK CONSTRAINT [FK_grades_subjects]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_groups]
GO
ALTER TABLE [dbo].[subjects]  WITH CHECK ADD  CONSTRAINT [FK_subjects_groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[subjects] CHECK CONSTRAINT [FK_subjects_groups]
GO
ALTER TABLE [dbo].[teachers]  WITH CHECK ADD  CONSTRAINT [FK_teachers_subjects] FOREIGN KEY([subjectId])
REFERENCES [dbo].[subjects] ([id])
GO
ALTER TABLE [dbo].[teachers] CHECK CONSTRAINT [FK_teachers_subjects]
GO
USE [master]
GO
ALTER DATABASE [akademine_sistema] SET  READ_WRITE 
GO
