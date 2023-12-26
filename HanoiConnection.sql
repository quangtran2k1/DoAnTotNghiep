USE [HanoiConnection]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[exercise]    Script Date: 12/23/2023 3:19:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[exercise](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[fileName] [varchar](max) NOT NULL,
	[startDate] [datetime] NOT NULL,
	[dueDate] [datetime] NOT NULL,
	[status] [tinyint] NOT NULL,
	[classesTeacherId] [int] NOT NULL,
 CONSTRAINT [PK_exercise] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[homework_student]    Script Date: 12/23/2023 3:19:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[homework_student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[point] [float] NULL,
	[status] [tinyint] NOT NULL,
	[exerciseId] [int] NOT NULL,
	[studentId] [int] NOT NULL,
 CONSTRAINT [PK_homework_student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[parents]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[role]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[semester]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[students]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[students_classes]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[teacher_class]    Script Date: 12/23/2023 3:19:56 PM ******/
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
/****** Object:  Table [dbo].[teachers]    Script Date: 12/23/2023 3:19:56 PM ******/
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
	[nation] [varchar](20) NOT NULL,
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
/****** Object:  Table [dbo].[users]    Script Date: 12/23/2023 3:19:56 PM ******/
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
ALTER TABLE [dbo].[classes]  WITH CHECK ADD  CONSTRAINT [FK_classes_semester] FOREIGN KEY([semesterId])
REFERENCES [dbo].[semester] ([id])
GO
ALTER TABLE [dbo].[classes] CHECK CONSTRAINT [FK_classes_semester]
GO
ALTER TABLE [dbo].[exercise]  WITH CHECK ADD  CONSTRAINT [FK_exercise_teacher_class] FOREIGN KEY([classesTeacherId])
REFERENCES [dbo].[teacher_class] ([id])
GO
ALTER TABLE [dbo].[exercise] CHECK CONSTRAINT [FK_exercise_teacher_class]
GO
ALTER TABLE [dbo].[homework_student]  WITH CHECK ADD  CONSTRAINT [FK_homework_student_exercise] FOREIGN KEY([exerciseId])
REFERENCES [dbo].[exercise] ([id])
GO
ALTER TABLE [dbo].[homework_student] CHECK CONSTRAINT [FK_homework_student_exercise]
GO
ALTER TABLE [dbo].[homework_student]  WITH CHECK ADD  CONSTRAINT [FK_homework_student_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([id])
GO
ALTER TABLE [dbo].[homework_student] CHECK CONSTRAINT [FK_homework_student_students]
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
