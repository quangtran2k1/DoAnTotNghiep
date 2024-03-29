USE [master]
GO
/****** Object:  Database [HanoiConnection]    Script Date: 1/20/2024 10:59:17 AM ******/
CREATE DATABASE [HanoiConnection]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HanoiConnection', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HanoiConnection.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HanoiConnection_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HanoiConnection_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HanoiConnection] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HanoiConnection].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HanoiConnection] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HanoiConnection] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HanoiConnection] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HanoiConnection] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HanoiConnection] SET ARITHABORT OFF 
GO
ALTER DATABASE [HanoiConnection] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HanoiConnection] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HanoiConnection] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HanoiConnection] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HanoiConnection] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HanoiConnection] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HanoiConnection] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HanoiConnection] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HanoiConnection] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HanoiConnection] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HanoiConnection] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HanoiConnection] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HanoiConnection] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HanoiConnection] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HanoiConnection] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HanoiConnection] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HanoiConnection] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HanoiConnection] SET RECOVERY FULL 
GO
ALTER DATABASE [HanoiConnection] SET  MULTI_USER 
GO
ALTER DATABASE [HanoiConnection] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HanoiConnection] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HanoiConnection] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HanoiConnection] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HanoiConnection] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HanoiConnection', N'ON'
GO
USE [HanoiConnection]
GO
/****** Object:  Table [dbo].[base_salary]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[base_salary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[currentSalary] [int] NOT NULL,
 CONSTRAINT [PK_current_salary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bonus]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bonus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[reason] [nvarchar](max) NOT NULL,
	[bonus] [int] NOT NULL,
	[teacherId] [int] NOT NULL,
 CONSTRAINT [PK_bonus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[classes]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[class] [nvarchar](max) NOT NULL,
	[startTime] [time](7) NOT NULL,
	[endTime] [time](7) NOT NULL,
	[status] [tinyint] NOT NULL,
	[semesterId] [int] NOT NULL,
 CONSTRAINT [PK_classes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[discipline]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discipline](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[reason] [nvarchar](max) NOT NULL,
	[fine] [int] NOT NULL,
	[teacherId] [int] NOT NULL,
 CONSTRAINT [PK_discipline] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lesson_count]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lesson_count](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[lessonsCount] [int] NOT NULL,
	[teacherId] [int] NOT NULL,
 CONSTRAINT [PK_lesson_count] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[parents]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[dadName] [nvarchar](max) NULL,
	[dadPhone] [nvarchar](50) NULL,
	[momName] [nvarchar](max) NULL,
	[momPhone] [nvarchar](50) NULL,
	[studentId] [int] NOT NULL,
	[usersId] [int] NOT NULL,
 CONSTRAINT [PK_parents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[role]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[salary]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[baseSalaryId] [int] NOT NULL,
	[teacherId] [int] NOT NULL,
	[total] [int] NOT NULL,
 CONSTRAINT [PK_salary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[semester]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[semester](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[block] [nvarchar](50) NOT NULL,
	[startSemester] [date] NOT NULL,
	[endSemester] [date] NOT NULL,
	[status] [tinyint] NOT NULL,
 CONSTRAINT [PK_semester] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[name] [nvarchar](max) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[sex] [tinyint] NOT NULL,
	[avatar] [varchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[status] [tinyint] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[students_classes]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students_classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updateAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[note] [nvarchar](max) NULL,
	[status] [tinyint] NOT NULL,
	[studentId] [int] NOT NULL,
	[classId] [int] NOT NULL,
 CONSTRAINT [PK_students_classes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[teacher_class]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher_class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updateAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[note] [nvarchar](max) NULL,
	[status] [tinyint] NOT NULL,
	[teacherId] [int] NOT NULL,
	[classesId] [int] NOT NULL,
 CONSTRAINT [PK_teacher_class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[teachers]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[teachers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[name] [nvarchar](max) NOT NULL,
	[citizenIdentification] [varchar](20) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[nation] [nvarchar](50) NOT NULL,
	[sex] [tinyint] NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[avatar] [varchar](max) NOT NULL,
	[status] [tinyint] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_teachers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 1/20/2024 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](max) NOT NULL,
	[status] [tinyint] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[roleId] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[base_salary] ON 

INSERT [dbo].[base_salary] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [currentSalary]) VALUES (1, CAST(N'2023-12-24 16:57:55.743' AS DateTime), CAST(N'2023-12-24 16:57:55.743' AS DateTime), 1, 1, 30000)
SET IDENTITY_INSERT [dbo].[base_salary] OFF
SET IDENTITY_INSERT [dbo].[classes] ON 

INSERT [dbo].[classes] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [class], [startTime], [endTime], [status], [semesterId]) VALUES (2, CAST(N'2023-12-19 09:05:00.000' AS DateTime), CAST(N'2024-01-11 13:32:58.257' AS DateTime), 1, 1, N'Lớp test 1', CAST(N'07:00:00' AS Time), CAST(N'08:30:00' AS Time), 1, 1)
INSERT [dbo].[classes] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [class], [startTime], [endTime], [status], [semesterId]) VALUES (3, CAST(N'2023-12-20 17:08:50.023' AS DateTime), CAST(N'2023-12-21 15:11:15.730' AS DateTime), 1, 1, N'Lớp test', CAST(N'15:00:00' AS Time), CAST(N'16:30:00' AS Time), 1, 1)
INSERT [dbo].[classes] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [class], [startTime], [endTime], [status], [semesterId]) VALUES (4, CAST(N'2023-12-20 17:10:11.627' AS DateTime), CAST(N'2023-12-20 17:10:11.627' AS DateTime), 1, 1, N'Lớp test 3', CAST(N'14:00:00' AS Time), CAST(N'15:30:00' AS Time), 1, 1)
INSERT [dbo].[classes] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [class], [startTime], [endTime], [status], [semesterId]) VALUES (5, CAST(N'2023-12-20 20:35:12.370' AS DateTime), CAST(N'2023-12-20 20:35:12.370' AS DateTime), 1, 1, N'Lớp test 4', CAST(N'09:00:00' AS Time), CAST(N'10:30:00' AS Time), 1, 1)
INSERT [dbo].[classes] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [class], [startTime], [endTime], [status], [semesterId]) VALUES (6, CAST(N'2024-01-11 15:16:48.000' AS DateTime), CAST(N'2024-01-11 15:16:48.000' AS DateTime), 1, 1, N'Lớp 1', CAST(N'00:00:00' AS Time), CAST(N'16:00:00' AS Time), 1, 1)
SET IDENTITY_INSERT [dbo].[classes] OFF
SET IDENTITY_INSERT [dbo].[discipline] ON 

INSERT [dbo].[discipline] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [reason], [fine], [teacherId]) VALUES (1, CAST(N'2024-01-19 22:12:15.603' AS DateTime), CAST(N'2024-01-19 22:12:15.603' AS DateTime), 1, 1, N'Đi muộn', 200000, 1)
SET IDENTITY_INSERT [dbo].[discipline] OFF
SET IDENTITY_INSERT [dbo].[lesson_count] ON 

INSERT [dbo].[lesson_count] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [lessonsCount], [teacherId]) VALUES (1, CAST(N'2023-12-24 16:57:55.743' AS DateTime), CAST(N'2023-12-24 16:57:55.743' AS DateTime), 1, 1, 180, 1)
INSERT [dbo].[lesson_count] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [lessonsCount], [teacherId]) VALUES (3, CAST(N'2024-01-19 19:01:08.187' AS DateTime), CAST(N'2024-01-19 19:01:08.187' AS DateTime), 1, 1, 120, 2)
INSERT [dbo].[lesson_count] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [lessonsCount], [teacherId]) VALUES (4, CAST(N'2024-01-19 22:12:34.777' AS DateTime), CAST(N'2024-01-19 22:12:34.777' AS DateTime), 1, 1, 180, 1)
SET IDENTITY_INSERT [dbo].[lesson_count] OFF
SET IDENTITY_INSERT [dbo].[parents] ON 

INSERT [dbo].[parents] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [dadName], [dadPhone], [momName], [momPhone], [studentId], [usersId]) VALUES (12, CAST(N'2024-01-09 10:25:14.300' AS DateTime), CAST(N'2024-01-09 11:09:53.403' AS DateTime), 1, 1, N'Quang', N'<Trống>', N'<Trống>', N'<Trống>', 4, 7)
SET IDENTITY_INSERT [dbo].[parents] OFF
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id], [role]) VALUES (1, N'Admin')
INSERT [dbo].[role] ([id], [role]) VALUES (2, N'Học sinh')
INSERT [dbo].[role] ([id], [role]) VALUES (3, N'Phụ Huynh')
INSERT [dbo].[role] ([id], [role]) VALUES (4, N'Giáo viên')
SET IDENTITY_INSERT [dbo].[role] OFF
SET IDENTITY_INSERT [dbo].[salary] ON 

INSERT [dbo].[salary] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [month], [year], [baseSalaryId], [teacherId], [total]) VALUES (1, CAST(N'2023-12-24 16:57:55.743' AS DateTime), CAST(N'2023-12-24 16:57:55.743' AS DateTime), 1, 1, 12, 2023, 1, 1, 5400000)
INSERT [dbo].[salary] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [month], [year], [baseSalaryId], [teacherId], [total]) VALUES (4, CAST(N'2024-01-19 19:01:12.403' AS DateTime), CAST(N'2024-01-19 19:01:12.403' AS DateTime), 1, 1, 1, 2024, 1, 2, 3600000)
INSERT [dbo].[salary] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [month], [year], [baseSalaryId], [teacherId], [total]) VALUES (5, CAST(N'2024-01-19 22:12:49.470' AS DateTime), CAST(N'2024-01-19 22:12:49.470' AS DateTime), 1, 1, 1, 2024, 1, 1, 5200000)
SET IDENTITY_INSERT [dbo].[salary] OFF
SET IDENTITY_INSERT [dbo].[semester] ON 

INSERT [dbo].[semester] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [block], [startSemester], [endSemester], [status]) VALUES (1, CAST(N'2023-12-19 09:05:00.000' AS DateTime), CAST(N'2023-12-19 09:05:00.000' AS DateTime), 1, 1, N'5-7 tuổi', CAST(N'2023-12-01' AS Date), CAST(N'2023-12-31' AS Date), 1)
INSERT [dbo].[semester] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [block], [startSemester], [endSemester], [status]) VALUES (2, CAST(N'2023-12-24 15:33:00.433' AS DateTime), CAST(N'2023-12-24 15:33:00.433' AS DateTime), 1, 1, N'7-9 tuổi', CAST(N'2024-01-01' AS Date), CAST(N'2024-01-31' AS Date), 1)
INSERT [dbo].[semester] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [block], [startSemester], [endSemester], [status]) VALUES (3, CAST(N'2024-01-11 15:18:28.393' AS DateTime), CAST(N'2024-01-11 15:18:28.393' AS DateTime), 1, 1, N'Khối 3-5 tuổi (Sáng)', CAST(N'2024-01-01' AS Date), CAST(N'2024-02-29' AS Date), 1)
SET IDENTITY_INSERT [dbo].[semester] OFF
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [name], [dateOfBirth], [sex], [avatar], [address], [status], [userId]) VALUES (2, CAST(N'2023-12-16 20:24:00.000' AS DateTime), CAST(N'2023-12-26 18:01:34.097' AS DateTime), 1, 2, N'Trần Nhật Quang', CAST(N'2023-12-26' AS Date), 1, N'/bin/Debug/Images/User\test.jpg', N'Hà Nội', 1, 2)
INSERT [dbo].[students] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [name], [dateOfBirth], [sex], [avatar], [address], [status], [userId]) VALUES (4, CAST(N'2023-12-16 20:24:00.000' AS DateTime), CAST(N'2024-01-12 11:47:45.627' AS DateTime), 1, 6, N'Quang', CAST(N'2024-01-12' AS Date), 1, N'\Images\User\test1.png', N'Hà Nội', 1, 6)
INSERT [dbo].[students] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [name], [dateOfBirth], [sex], [avatar], [address], [status], [userId]) VALUES (5, CAST(N'2023-12-24 23:56:54.097' AS DateTime), CAST(N'2023-12-27 21:30:13.170' AS DateTime), 1, 11, N'quang', CAST(N'2023-12-27' AS Date), 0, N'/Images/User/default-avatar-image.png', N'<Trống>', 1, 11)
INSERT [dbo].[students] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [name], [dateOfBirth], [sex], [avatar], [address], [status], [userId]) VALUES (6, CAST(N'2024-01-11 15:17:19.890' AS DateTime), CAST(N'2024-01-11 15:17:19.890' AS DateTime), 1, 1, N'Quang 19CN3', CAST(N'2024-01-11' AS Date), 0, N'/Images/User/default-avatar-image.png', N'<Trống>', 1, 13)
SET IDENTITY_INSERT [dbo].[students] OFF
SET IDENTITY_INSERT [dbo].[students_classes] ON 

INSERT [dbo].[students_classes] ([id], [createdAt], [updateAt], [createdBy], [updatedBy], [note], [status], [studentId], [classId]) VALUES (2, CAST(N'2023-12-24 16:57:55.743' AS DateTime), CAST(N'2023-12-24 16:57:55.743' AS DateTime), 1, 1, N'test', 1, 4, 3)
SET IDENTITY_INSERT [dbo].[students_classes] OFF
SET IDENTITY_INSERT [dbo].[teacher_class] ON 

INSERT [dbo].[teacher_class] ([id], [createdAt], [updateAt], [createdBy], [updatedBy], [note], [status], [teacherId], [classesId]) VALUES (5, CAST(N'2023-12-27 16:17:11.167' AS DateTime), CAST(N'2023-12-27 16:17:11.167' AS DateTime), 1, 1, N'', 1, 2, 3)
INSERT [dbo].[teacher_class] ([id], [createdAt], [updateAt], [createdBy], [updatedBy], [note], [status], [teacherId], [classesId]) VALUES (6, CAST(N'2024-01-11 13:32:48.103' AS DateTime), CAST(N'2024-01-11 13:32:48.103' AS DateTime), 1, 1, N'Test', 1, 1, 3)
INSERT [dbo].[teacher_class] ([id], [createdAt], [updateAt], [createdBy], [updatedBy], [note], [status], [teacherId], [classesId]) VALUES (7, CAST(N'2024-01-11 13:41:30.547' AS DateTime), CAST(N'2024-01-11 13:41:30.547' AS DateTime), 1, 1, N'', 1, 1, 2)
SET IDENTITY_INSERT [dbo].[teacher_class] OFF
SET IDENTITY_INSERT [dbo].[teachers] ON 

INSERT [dbo].[teachers] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [name], [citizenIdentification], [dateOfBirth], [nation], [sex], [phone], [avatar], [status], [userId]) VALUES (1, CAST(N'2023-12-19 09:05:00.000' AS DateTime), CAST(N'2023-12-27 05:55:08.817' AS DateTime), 1, 8, N'Test', N'123010', CAST(N'2023-12-27' AS Date), N'Việt nam', 1, N'01230120', N'/Images/User\admin1.png', 1, 8)
INSERT [dbo].[teachers] ([id], [createdAt], [updatedAt], [createdBy], [updatedBy], [name], [citizenIdentification], [dateOfBirth], [nation], [sex], [phone], [avatar], [status], [userId]) VALUES (2, CAST(N'2023-12-19 09:05:00.000' AS DateTime), CAST(N'2023-12-19 09:05:00.000' AS DateTime), 1, 1, N'Test', N'123010', CAST(N'2023-12-19' AS Date), N'Việt nam', 1, N'01230120', N'test', 1, 9)
SET IDENTITY_INSERT [dbo].[teachers] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (1, N'admin', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'admin@admin.com', 1, CAST(N'2023-12-13 13:03:00.000' AS DateTime), CAST(N'2023-12-23 21:38:26.053' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (2, N'test', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'test@test.com', 1, CAST(N'2023-12-13 13:03:00.000' AS DateTime), CAST(N'2023-12-13 13:03:00.000' AS DateTime), 2)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (6, N'test1', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'test1@test.com', 1, CAST(N'2023-12-13 13:03:00.000' AS DateTime), CAST(N'2023-12-13 13:03:00.000' AS DateTime), 2)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (7, N'test2', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'test2@test.com', 1, CAST(N'2023-12-13 13:03:00.000' AS DateTime), CAST(N'2023-12-13 13:03:00.000' AS DateTime), 3)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (8, N'admin1', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'admin1@admin.com', 1, CAST(N'2023-12-13 13:03:00.000' AS DateTime), CAST(N'2023-12-13 13:03:00.000' AS DateTime), 4)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (9, N'admin2', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'admin2@admin.com', 2, CAST(N'2023-12-13 13:03:00.000' AS DateTime), CAST(N'2023-12-13 13:03:00.000' AS DateTime), 4)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (10, N'quang01', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'quang@gmail.com', 1, CAST(N'2023-12-23 20:07:05.377' AS DateTime), CAST(N'2023-12-23 20:07:05.377' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (11, N'quang', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'quang@gmail.com', 1, CAST(N'2023-12-23 20:26:42.087' AS DateTime), CAST(N'2023-12-23 20:26:42.087' AS DateTime), 2)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (12, N'a1', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'a@gmail.com', 1, CAST(N'2023-12-23 21:16:41.620' AS DateTime), CAST(N'2023-12-23 21:27:55.583' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (13, N'hocsinh', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'hocsinh@gmail.com', 1, CAST(N'2024-01-09 10:20:07.557' AS DateTime), CAST(N'2024-01-09 10:20:07.557' AS DateTime), 2)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (14, N'testph', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'ph@ph.com', 1, CAST(N'2024-01-11 13:43:57.563' AS DateTime), CAST(N'2024-01-11 13:43:57.563' AS DateTime), 3)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (15, N'ph', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'ph@ph.com', 1, CAST(N'2024-01-11 13:44:53.693' AS DateTime), CAST(N'2024-01-11 13:44:53.693' AS DateTime), 3)
INSERT [dbo].[users] ([id], [username], [password], [email], [status], [createdAt], [updatedAt], [roleId]) VALUES (16, N'ph1', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'ph@ph.com', 1, CAST(N'2024-01-11 14:08:25.870' AS DateTime), CAST(N'2024-01-11 14:08:25.870' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[users] OFF
ALTER TABLE [dbo].[bonus]  WITH CHECK ADD  CONSTRAINT [FK_bonus_teachers] FOREIGN KEY([teacherId])
REFERENCES [dbo].[teachers] ([id])
GO
ALTER TABLE [dbo].[bonus] CHECK CONSTRAINT [FK_bonus_teachers]
GO
ALTER TABLE [dbo].[classes]  WITH CHECK ADD  CONSTRAINT [FK_classes_semester] FOREIGN KEY([semesterId])
REFERENCES [dbo].[semester] ([id])
GO
ALTER TABLE [dbo].[classes] CHECK CONSTRAINT [FK_classes_semester]
GO
ALTER TABLE [dbo].[discipline]  WITH CHECK ADD  CONSTRAINT [FK_discipline_teachers] FOREIGN KEY([teacherId])
REFERENCES [dbo].[teachers] ([id])
GO
ALTER TABLE [dbo].[discipline] CHECK CONSTRAINT [FK_discipline_teachers]
GO
ALTER TABLE [dbo].[lesson_count]  WITH CHECK ADD  CONSTRAINT [FK_lesson_count_teachers] FOREIGN KEY([teacherId])
REFERENCES [dbo].[teachers] ([id])
GO
ALTER TABLE [dbo].[lesson_count] CHECK CONSTRAINT [FK_lesson_count_teachers]
GO
ALTER TABLE [dbo].[parents]  WITH CHECK ADD  CONSTRAINT [FK_parents_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([id])
GO
ALTER TABLE [dbo].[parents] CHECK CONSTRAINT [FK_parents_students]
GO
ALTER TABLE [dbo].[parents]  WITH CHECK ADD  CONSTRAINT [FK_parents_users] FOREIGN KEY([usersId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[parents] CHECK CONSTRAINT [FK_parents_users]
GO
ALTER TABLE [dbo].[salary]  WITH CHECK ADD  CONSTRAINT [FK_salary_base_salary] FOREIGN KEY([baseSalaryId])
REFERENCES [dbo].[base_salary] ([id])
GO
ALTER TABLE [dbo].[salary] CHECK CONSTRAINT [FK_salary_base_salary]
GO
ALTER TABLE [dbo].[salary]  WITH CHECK ADD  CONSTRAINT [FK_salary_teachers] FOREIGN KEY([teacherId])
REFERENCES [dbo].[teachers] ([id])
GO
ALTER TABLE [dbo].[salary] CHECK CONSTRAINT [FK_salary_teachers]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_users]
GO
ALTER TABLE [dbo].[students_classes]  WITH CHECK ADD  CONSTRAINT [FK_students_classes_classes] FOREIGN KEY([classId])
REFERENCES [dbo].[classes] ([id])
GO
ALTER TABLE [dbo].[students_classes] CHECK CONSTRAINT [FK_students_classes_classes]
GO
ALTER TABLE [dbo].[students_classes]  WITH CHECK ADD  CONSTRAINT [FK_students_classes_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([id])
GO
ALTER TABLE [dbo].[students_classes] CHECK CONSTRAINT [FK_students_classes_students]
GO
ALTER TABLE [dbo].[teacher_class]  WITH CHECK ADD  CONSTRAINT [FK_teacher_class_classes] FOREIGN KEY([classesId])
REFERENCES [dbo].[classes] ([id])
GO
ALTER TABLE [dbo].[teacher_class] CHECK CONSTRAINT [FK_teacher_class_classes]
GO
ALTER TABLE [dbo].[teacher_class]  WITH CHECK ADD  CONSTRAINT [FK_teacher_class_teachers] FOREIGN KEY([teacherId])
REFERENCES [dbo].[teachers] ([id])
GO
ALTER TABLE [dbo].[teacher_class] CHECK CONSTRAINT [FK_teacher_class_teachers]
GO
ALTER TABLE [dbo].[teachers]  WITH CHECK ADD  CONSTRAINT [FK_teachers_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[teachers] CHECK CONSTRAINT [FK_teachers_users]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_role] FOREIGN KEY([roleId])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_role]
GO
USE [master]
GO
ALTER DATABASE [HanoiConnection] SET  READ_WRITE 
GO
