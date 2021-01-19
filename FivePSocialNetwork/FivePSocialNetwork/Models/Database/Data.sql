USE [master]
GO
/****** Object:  Database [FivePSocialNetWork]    Script Date: 19/01/2021 5:59:05 PM ******/
CREATE DATABASE [FivePSocialNetWork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FivePSocialNetWork', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FivePSocialNetWork.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FivePSocialNetWork_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FivePSocialNetWork_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FivePSocialNetWork] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FivePSocialNetWork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FivePSocialNetWork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET ARITHABORT OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FivePSocialNetWork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FivePSocialNetWork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FivePSocialNetWork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FivePSocialNetWork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FivePSocialNetWork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FivePSocialNetWork] SET  MULTI_USER 
GO
ALTER DATABASE [FivePSocialNetWork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FivePSocialNetWork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FivePSocialNetWork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FivePSocialNetWork] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FivePSocialNetWork]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[advertisiment_id] [int] IDENTITY(1,1) NOT NULL,
	[advertisiment_companyname] [nvarchar](300) NULL,
	[advertisiment_note] [nvarchar](max) NULL,
	[advertisiment_activate] [bit] NULL,
	[advertisiment_dateCreate] [datetime] NULL,
	[advertisiment_dateEdit] [datetime] NULL,
	[advertisiment_recycleBin] [bit] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[advertisiment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answer]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[answer_id] [int] IDENTITY(1,1) NOT NULL,
	[answer_content] [nvarchar](max) NULL,
	[answer_dateCreate] [datetime] NULL,
	[answer_dateEdit] [datetime] NULL,
	[user_id] [int] NULL,
	[answer_activate] [bit] NULL,
	[answer_userStatus] [bit] NULL,
	[question_id] [int] NULL,
	[answer_totalRate] [int] NULL,
	[answer_medalCalculate] [int] NULL,
	[answer_recycleBin] [bit] NULL,
	[answer_admin_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[answer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment_Answer]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment_Answer](
	[commentAnswer_id] [int] IDENTITY(1,1) NOT NULL,
	[commentAnswer_content] [nvarchar](max) NULL,
	[commentAnswer_dateCreate] [datetime] NULL,
	[commentAnswer_dateEdit] [datetime] NULL,
	[user_id] [int] NULL,
	[answer_id] [int] NULL,
	[commentAnswer_recycleBin] [bit] NULL,
	[commentAnswer_activate] [bit] NULL,
	[commentAnswer_userStatus] [bit] NULL,
 CONSTRAINT [PK_Comment_Answer] PRIMARY KEY CLUSTERED 
(
	[commentAnswer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Commune]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commune](
	[commune_id] [int] IDENTITY(1,1) NOT NULL,
	[commune_name] [nvarchar](300) NULL,
	[commune_activate] [bit] NULL,
	[commune_dateCreate] [datetime] NULL,
	[commune_dateEdit] [datetime] NULL,
	[commune_recycleBin] [bit] NULL,
	[district_id] [int] NULL,
 CONSTRAINT [PK_Commune] PRIMARY KEY CLUSTERED 
(
	[commune_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Denounce_User]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Denounce_User](
	[denounceUser_id] [int] IDENTITY(1,1) NOT NULL,
	[accuser_id] [int] NULL,
	[discredit_id] [int] NULL,
	[denounceUser_content] [nvarchar](300) NULL,
	[denounceUser_dateCreate] [datetime] NULL,
	[denounceUser_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Denounce_User] PRIMARY KEY CLUSTERED 
(
	[denounceUser_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[district_id] [int] IDENTITY(1,1) NOT NULL,
	[district_name] [nvarchar](300) NULL,
	[district_activate] [bit] NULL,
	[district_dateCreate] [datetime] NULL,
	[district_dateEdit] [datetime] NULL,
	[district_recycleBin] [bit] NULL,
	[provincial_id] [int] NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Friend]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[friend_id] [int] IDENTITY(1,1) NOT NULL,
	[userRequest_id] [int] NULL,
	[userResponse_id] [int] NULL,
	[friend_status] [bit] NULL,
	[friend_dateRequest] [datetime] NULL,
	[friend_dateResponse] [datetime] NULL,
	[friend_dateUnfriend] [datetime] NULL,
	[friend_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[friend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image_Advertisement]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image_Advertisement](
	[ImageAdvertisement_id] [int] IDENTITY(1,1) NOT NULL,
	[ImageAdvertisement_image] [varchar](max) NULL,
	[advertisement_id] [int] NULL,
	[ImageAdvertisement_note] [nvarchar](max) NULL,
	[ImageAdvertisement_activate] [bit] NULL,
	[ImageAdvertisement_dateCreate] [datetime] NULL,
	[ImageAdvertisement_dateEdit] [datetime] NULL,
	[ImageAdvertisement_recycleBin] [bit] NULL,
	[positionAdvertisement_id] [int] NULL,
 CONSTRAINT [PK_Image_Advertisement] PRIMARY KEY CLUSTERED 
(
	[ImageAdvertisement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Letters]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Letters](
	[letters_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[letters_content] [nvarchar](max) NULL,
	[letters_status] [bit] NULL,
	[letters_recycleBin] [bit] NULL,
	[letters_dateCreate] [datetime] NULL,
	[letters_dateEdit] [datetime] NULL,
	[letters_statusSee] [bit] NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Letters] PRIMARY KEY CLUSTERED 
(
	[letters_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Letters_Idea]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Letters_Idea](
	[lettersIdea_id] [int] IDENTITY(1,1) NOT NULL,
	[lettersIdea_content] [nvarchar](300) NULL,
	[lettersIdea_activate] [bit] NULL,
	[lettersIdea_dateCreate] [datetime] NULL,
	[lettersIdea_dateEdit] [datetime] NULL,
	[lettersIdea_recycleBin] [bit] NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Letters_Idea] PRIMARY KEY CLUSTERED 
(
	[lettersIdea_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[message_id] [int] IDENTITY(1,1) NOT NULL,
	[message_content] [nvarchar](max) NULL,
	[messageSender_id] [int] NULL,
	[messageRecipients_id] [int] NULL,
	[message_dateSend] [datetime] NULL,
	[message_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notification]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[notification_id] [int] IDENTITY(1,1) NOT NULL,
	[notification_content] [nvarchar](300) NULL,
	[receiver_id] [int] NULL,
	[impactUser_id] [int] NULL,
	[question_id] [int] NULL,
	[notification_status] [bit] NULL,
	[notification_dateCreate] [datetime] NULL,
	[notification_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[notification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Position_Advertisement]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position_Advertisement](
	[positionAdvertisement_id] [int] IDENTITY(1,1) NOT NULL,
	[positionAdvertisement_positionName] [nvarchar](max) NULL,
	[positionAdvertisement_note] [nvarchar](max) NULL,
	[positionAdvertisement_activate] [bit] NULL,
	[positionAdvertisement_dateCreate] [datetime] NULL,
	[positionAdvertisement_dateEdit] [datetime] NULL,
 CONSTRAINT [PK_Position_Advertisement] PRIMARY KEY CLUSTERED 
(
	[positionAdvertisement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[post_id] [int] IDENTITY(1,1) NOT NULL,
	[post_content] [nvarchar](max) NULL,
	[post_dateCreate] [datetime] NULL,
	[post_dateEdit] [datetime] NULL,
	[user_id] [int] NULL,
	[post_activate] [bit] NULL,
	[post_title] [nvarchar](300) NULL,
	[post_view] [int] NULL,
	[post_totalLike] [int] NULL,
	[post_totalDislike] [int] NULL,
	[post_recycleBin] [bit] NULL,
	[post_userStatus] [bit] NULL,
	[post_admin_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincial]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincial](
	[provincial_id] [int] IDENTITY(1,1) NOT NULL,
	[provincial_name] [nvarchar](300) NULL,
	[provincial_activate] [bit] NULL,
	[provincial_dateCreate] [datetime] NULL,
	[provincial_dateEdit] [datetime] NULL,
	[provincial_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Provincial] PRIMARY KEY CLUSTERED 
(
	[provincial_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[question_id] [int] IDENTITY(1,1) NOT NULL,
	[question_content] [nvarchar](max) NULL,
	[question_dateCreate] [datetime] NULL,
	[question_dateEdit] [datetime] NULL,
	[user_id] [int] NULL,
	[question_activate] [bit] NULL,
	[question_title] [nvarchar](300) NULL,
	[question_Answer] [int] NULL,
	[question_totalComment] [int] NULL,
	[question_view] [int] NULL,
	[question_totalRate] [int] NULL,
	[question_medalCalculator] [int] NULL,
	[question_recycleBin] [bit] NULL,
	[question_userStatus] [bit] NULL,
	[question_popular] [int] NULL,
	[question_admin_recycleBin] [bit] NULL,
	[question_keywordSearch] [nvarchar](max) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rate_Answer]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate_Answer](
	[rateAnswer_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[answer_id] [int] NULL,
	[rateAnswer_rateStatus] [bit] NULL,
	[rateAnswer_dateCreate] [datetime] NULL,
 CONSTRAINT [PK_Rate_Answer] PRIMARY KEY CLUSTERED 
(
	[rateAnswer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rate_Post]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate_Post](
	[ratePost_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[post_id] [int] NULL,
	[ratePost_rateStatus] [bit] NULL,
	[ratePost_dateCreate] [datetime] NULL,
 CONSTRAINT [PK_Rate_Post] PRIMARY KEY CLUSTERED 
(
	[ratePost_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rate_Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate_Question](
	[rateQuestion_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[question_id] [int] NULL,
	[rateQuestion_rateStatus] [bit] NULL,
	[rateQuestion_dateCreate] [datetime] NULL,
 CONSTRAINT [PK_Rate_Question] PRIMARY KEY CLUSTERED 
(
	[rateQuestion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regulations]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regulations](
	[regulations_id] [int] IDENTITY(1,1) NOT NULL,
	[regulations_name] [nvarchar](max) NULL,
	[regulations_activate] [bit] NULL,
	[regulations_recycleBin] [bit] NULL,
	[regulations_dateCreate] [datetime] NULL,
	[regulations_dateEdit] [datetime] NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Regulations] PRIMARY KEY CLUSTERED 
(
	[regulations_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role_User]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_User](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](300) NULL,
	[role_activate] [bit] NULL,
	[role_dateCreate] [datetime] NULL,
	[role_dateEdit] [datetime] NULL,
	[role_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Role_User] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Search]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Search](
	[search_id] [int] IDENTITY(1,1) NOT NULL,
	[search_content] [nvarchar](max) NULL,
	[search_dateCreate] [datetime] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Search] PRIMARY KEY CLUSTERED 
(
	[search_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sex_User]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sex_User](
	[sex_id] [int] IDENTITY(1,1) NOT NULL,
	[sex_name] [nvarchar](100) NULL,
	[sex_activate] [bit] NULL,
	[sex_dateCreate] [datetime] NULL,
	[sex_dateEdit] [datetime] NULL,
	[sex_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Sex_User] PRIMARY KEY CLUSTERED 
(
	[sex_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Show_Activate_Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show_Activate_Question](
	[showActivateQ_id] [int] IDENTITY(1,1) NOT NULL,
	[showActivateQ_dateCreate] [datetime] NULL,
	[question_id] [int] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Show_Activate_Question] PRIMARY KEY CLUSTERED 
(
	[showActivateQ_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags_Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags_Question](
	[tagsQuestion_id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NULL,
	[tagsQuestion_name] [nvarchar](150) NULL,
	[tagsQuestion_dateCreate] [datetime] NULL,
 CONSTRAINT [PK_Tags_Question] PRIMARY KEY CLUSTERED 
(
	[tagsQuestion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachnology_Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachnology_Question](
	[teachnologyQuestion_id] [int] IDENTITY(1,1) NOT NULL,
	[technology_id] [int] NULL,
	[question_id] [int] NULL,
	[teachnologyQuestion_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Teachnology_Question] PRIMARY KEY CLUSTERED 
(
	[teachnologyQuestion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachnology_User]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachnology_User](
	[technologyUser_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[technology_id] [int] NULL,
	[technology_dateCreate] [datetime] NULL,
	[technology_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Teachnology_User] PRIMARY KEY CLUSTERED 
(
	[technologyUser_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Technology]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Technology](
	[technology_id] [int] IDENTITY(1,1) NOT NULL,
	[technology_name] [varchar](150) NULL,
	[technology_popular] [int] NULL,
	[technology_activate] [bit] NULL,
	[technology_recycleBin] [bit] NULL,
	[technology_dateCreate] [datetime] NULL,
	[technology_dateEdit] [datetime] NULL,
	[technology_note] [nvarchar](500) NULL,
	[technology_totalQuestion] [int] NULL,
 CONSTRAINT [PK_Technology] PRIMARY KEY CLUSTERED 
(
	[technology_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tick_Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tick_Question](
	[tickQuestion_id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NULL,
	[user_id] [int] NULL,
	[tickQuestion_dateCreate] [datetime] NULL,
	[tickQuestion_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Tick_Question] PRIMARY KEY CLUSTERED 
(
	[tickQuestion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_pass] [nvarchar](500) NULL,
	[user_firstName] [nvarchar](80) NULL,
	[user_lastName] [nvarchar](80) NULL,
	[user_email] [varchar](300) NULL,
	[user_token] [varchar](max) NULL,
	[role_id] [int] NULL,
	[user_code] [varchar](max) NULL,
	[user_avatar] [varchar](max) NULL,
	[user_coverImage] [varchar](max) NULL,
	[user_activate] [bit] NULL,
	[user_recycleBin] [bit] NULL,
	[user_dateCreate] [datetime] NULL,
	[user_dateEdit] [datetime] NULL,
	[user_dateLogin] [datetime] NULL,
	[user_emailAuthentication] [bit] NULL,
	[user_verifyPhoneNumber] [bit] NULL,
	[user_loginAuthentication] [bit] NULL,
	[provincial_id] [int] NULL,
	[district_id] [int] NULL,
	[commune_id] [int] NULL,
	[user_addressRemaining] [nvarchar](600) NULL,
	[sex_id] [int] NULL,
	[user_linkFacebook] [varchar](max) NULL,
	[user_linkGithub] [varchar](max) NULL,
	[user_anotherWeb] [nvarchar](max) NULL,
	[user_hobbyWork] [nvarchar](max) NULL,
	[user_hobby] [nvarchar](max) NULL,
	[user_birthday] [date] NULL,
	[user_popular] [int] NULL,
	[user_goldMedal] [int] NULL,
	[user_silverMedal] [int] NULL,
	[user_brozeMedal] [int] NULL,
	[user_vipMedal] [int] NULL,
	[user_phone] [varchar](15) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[View_Post]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[View_Post](
	[viewPost_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[post_id] [int] NULL,
	[viewPost_dateCreate] [datetime] NULL,
 CONSTRAINT [PK_View_Post] PRIMARY KEY CLUSTERED 
(
	[viewPost_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[View_Question]    Script Date: 19/01/2021 5:59:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[View_Question](
	[viewQuestion_id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NULL,
	[viewQuestion_dateCreate] [datetime] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_View_Question] PRIMARY KEY CLUSTERED 
(
	[viewQuestion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([answer_id], [answer_content], [answer_dateCreate], [answer_dateEdit], [user_id], [answer_activate], [answer_userStatus], [question_id], [answer_totalRate], [answer_medalCalculate], [answer_recycleBin], [answer_admin_recycleBin]) VALUES (1, N'<p>In our new requirement, there is something like a super account where all the account data can be viewed. For example, if account 1 and account 2 is selected in the user list page, users of account 1 and 2 should be combined and viewed along with search provision. Is there any way to combine more than one schema data in the apartment? or any other alternates</p>', CAST(0x0000ACB300C8E3FB AS DateTime), CAST(0x0000ACB300C8E3FB AS DateTime), 4, 1, 1, 2, 0, 0, 0, 0)
INSERT [dbo].[Answer] ([answer_id], [answer_content], [answer_dateCreate], [answer_dateEdit], [user_id], [answer_activate], [answer_userStatus], [question_id], [answer_totalRate], [answer_medalCalculate], [answer_recycleBin], [answer_admin_recycleBin]) VALUES (2, N'<p>In our new requirement, there is something like a super account where all the account data can be viewed. For example, if account 1 and account 2 is selected in the user list page, users of account 1 and 2 should be combined and viewed along with search provision. Is there any way to combine more than one schema data in the apartment? or any other alternates</p>', CAST(0x0000ACB300C8F9DD AS DateTime), CAST(0x0000ACB300C8F9DD AS DateTime), 4, 1, 1, 2, 0, 0, 0, 0)
INSERT [dbo].[Answer] ([answer_id], [answer_content], [answer_dateCreate], [answer_dateEdit], [user_id], [answer_activate], [answer_userStatus], [question_id], [answer_totalRate], [answer_medalCalculate], [answer_recycleBin], [answer_admin_recycleBin]) VALUES (3, N'<p>This package <code>react-quizzes</code>, looks not really great. Its final build not include all modules, and require importing things directly. But if you want, here''s the solution:</p><pre><code class="language-plaintext">import React, { useState } from "react";
import ReactDOM from "react-dom";
import { QuizzBuilder } from "react-quizzes";
import ToolBox from "react-quizzes/lib/ToolBox";
import "react-quizzes/lib/assets/antd.css";

const filteredToolBox = ToolBox().filter(el =&gt; el.field_name === "checkboxes_")

function App() {
  const [formdata, setFormData] = useState([]);

  return (
    &lt;div className="App"&gt;
      &lt;QuizzBuilder toolBox={filteredToolBox} onChange={setFormData} /&gt;
    &lt;/div&gt;
  );
}

const rootElement = document.getElementById("root");
ReactDOM.render(&lt;App /&gt;, rootElement);</code></pre><h2>Update #1</h2><p>Added logic to override <code>ToolBox</code> label</p><pre><code class="language-plaintext">import React, { useState } from "react";
import ReactDOM from "react-dom";
import { QuizzBuilder } from "react-quizzes";
import QuizExample from "./QuizExample";
import "react-quizzes/lib/assets/antd.css";
import ToolBox from "react-quizzes/lib/ToolBox";
import { defaultMessages } from "react-quizzes/lib/translations/TranslatedText";

const filteredToolBox = ToolBox().filter(
  (el) =&gt; el.field_name === "checkboxes_"
);

const messages = {
  en: {
    ...defaultMessages.en,
    "toolbox.checkboxes.name": "Here are Checkboxes"
  }
};

function App() {
  const [formdata, setFormData] = useState([]);

  return (
    &lt;div className="App"&gt;
      &lt;QuizzBuilder
        messages={messages}
        toolBox={filteredToolBox}
        onChange={setFormData}
      /&gt;
    &lt;/div&gt;
  );
}

const rootElement = document.getElementById("root");
ReactDOM.render(&lt;App /&gt;, rootElement);</code></pre><p>&nbsp;</p>', CAST(0x0000ACB301491F0A AS DateTime), CAST(0x0000ACB301491F0A AS DateTime), 4, 1, 1, 3, 0, 0, 0, 0)
INSERT [dbo].[Answer] ([answer_id], [answer_content], [answer_dateCreate], [answer_dateEdit], [user_id], [answer_activate], [answer_userStatus], [question_id], [answer_totalRate], [answer_medalCalculate], [answer_recycleBin], [answer_admin_recycleBin]) VALUES (4, N'<p>This package <code>react-quizzes</code>, looks not really great. Its final build not include all modules, and require importing things directly. But if you want, here''s the solution:</p><pre><code class="language-javascript">import React, { useState } from "react";
import ReactDOM from "react-dom";
import { QuizzBuilder } from "react-quizzes";
import ToolBox from "react-quizzes/lib/ToolBox";
import "react-quizzes/lib/assets/antd.css";</code></pre><p>&nbsp;</p>', CAST(0x0000ACB30151C5E8 AS DateTime), CAST(0x0000ACB30151C5E8 AS DateTime), 4, 1, 1, 3, 0, 0, 0, 0)
INSERT [dbo].[Answer] ([answer_id], [answer_content], [answer_dateCreate], [answer_dateEdit], [user_id], [answer_activate], [answer_userStatus], [question_id], [answer_totalRate], [answer_medalCalculate], [answer_recycleBin], [answer_admin_recycleBin]) VALUES (5, N'<p>I''ve got a very simple Spring Boot application with resources at <code>/repositories</code> and <code>/persons</code>.</p><p>Here is my <code>build.gradle</code> file.</p><pre><code class="language-javascript">plugins {
    id ''org.springframework.boot'' version ''2.4.0''
    id ''io.spring.dependency-management'' version ''1.0.10.RELEASE''
    id ''java''
}

// use java 11 until keycloak is fixed
sourceCompatibility = ''11''

repositories {
    mavenCentral()
}

dependencyManagement {
    imports {
        mavenBom "org.keycloak.bom:keycloak-adapter-bom:12.0.1"
    }
}

dependencies {
    implementation ''org.springframework.boot:spring-boot-starter-web''
    implementation ''org.springframework.boot:spring-boot-starter-data-jpa''

    implementation ''org.springframework.boot:spring-boot-starter-security''
    implementation ''org.keycloak:keycloak-spring-boot-starter''

    implementation ''org.flywaydb:flyway-core''
    runtime ''org.postgresql:postgresql''

    testImplementation ''org.springframework.boot:spring-boot-starter-test''
}
</code></pre>', CAST(0x0000ACB4000443A1 AS DateTime), CAST(0x0000ACB4000443A1 AS DateTime), 4, 1, 1, 1, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[Comment_Answer] ON 

INSERT [dbo].[Comment_Answer] ([commentAnswer_id], [commentAnswer_content], [commentAnswer_dateCreate], [commentAnswer_dateEdit], [user_id], [answer_id], [commentAnswer_recycleBin], [commentAnswer_activate], [commentAnswer_userStatus]) VALUES (1, N'I am very happy to know that you were able to find a solution solely based on Keycloak security.', CAST(0x0000ACB40007C729 AS DateTime), CAST(0x0000ACB40007C729 AS DateTime), 4, 3, 0, 1, 1)
INSERT [dbo].[Comment_Answer] ([commentAnswer_id], [commentAnswer_content], [commentAnswer_dateCreate], [commentAnswer_dateEdit], [user_id], [answer_id], [commentAnswer_recycleBin], [commentAnswer_activate], [commentAnswer_userStatus]) VALUES (2, N' find a solution solely based on Keycloak security.', CAST(0x0000ACB400097FBD AS DateTime), CAST(0x0000ACB400097FBD AS DateTime), 4, 3, 0, 1, 1)
INSERT [dbo].[Comment_Answer] ([commentAnswer_id], [commentAnswer_content], [commentAnswer_dateCreate], [commentAnswer_dateEdit], [user_id], [answer_id], [commentAnswer_recycleBin], [commentAnswer_activate], [commentAnswer_userStatus]) VALUES (3, N'viewed along with search provision.', CAST(0x0000ACB4000FA805 AS DateTime), CAST(0x0000ACB4000FA805 AS DateTime), 4, 2, 0, 1, 1)
INSERT [dbo].[Comment_Answer] ([commentAnswer_id], [commentAnswer_content], [commentAnswer_dateCreate], [commentAnswer_dateEdit], [user_id], [answer_id], [commentAnswer_recycleBin], [commentAnswer_activate], [commentAnswer_userStatus]) VALUES (4, N'or any other alternates', CAST(0x0000ACB40012E2DD AS DateTime), CAST(0x0000ACB40012E2DD AS DateTime), 4, 1, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Comment_Answer] OFF
SET IDENTITY_INSERT [dbo].[Commune] ON 

INSERT [dbo].[Commune] ([commune_id], [commune_name], [commune_activate], [commune_dateCreate], [commune_dateEdit], [commune_recycleBin], [district_id]) VALUES (1, N'Cây Trường', 1, CAST(0x0000ACB2013D850F AS DateTime), CAST(0x0000ACB2013D850F AS DateTime), 0, 1005)
INSERT [dbo].[Commune] ([commune_id], [commune_name], [commune_activate], [commune_dateCreate], [commune_dateEdit], [commune_recycleBin], [district_id]) VALUES (2, N'Lai Uyên', 1, CAST(0x0000ACB2014069E0 AS DateTime), CAST(0x0000ACB2014069E0 AS DateTime), 0, 1005)
SET IDENTITY_INSERT [dbo].[Commune] OFF
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([district_id], [district_name], [district_activate], [district_dateCreate], [district_dateEdit], [district_recycleBin], [provincial_id]) VALUES (1, N'Dĩ An', 1, CAST(0x0000ACAE00000000 AS DateTime), CAST(0x0000ACAE00000000 AS DateTime), 1, 1)
INSERT [dbo].[District] ([district_id], [district_name], [district_activate], [district_dateCreate], [district_dateEdit], [district_recycleBin], [provincial_id]) VALUES (2, N'Thuận An', 1, CAST(0x0000ACAE00000000 AS DateTime), CAST(0x0000ACAE00000000 AS DateTime), 0, 1)
INSERT [dbo].[District] ([district_id], [district_name], [district_activate], [district_dateCreate], [district_dateEdit], [district_recycleBin], [provincial_id]) VALUES (3, N'Quận 1', 1, CAST(0x0000ACAE00000000 AS DateTime), CAST(0x0000ACAE00000000 AS DateTime), 1, 2)
INSERT [dbo].[District] ([district_id], [district_name], [district_activate], [district_dateCreate], [district_dateEdit], [district_recycleBin], [provincial_id]) VALUES (4, N'Quận 2', 1, CAST(0x0000ACAE00000000 AS DateTime), CAST(0x0000ACAE00000000 AS DateTime), 0, 2)
INSERT [dbo].[District] ([district_id], [district_name], [district_activate], [district_dateCreate], [district_dateEdit], [district_recycleBin], [provincial_id]) VALUES (5, N'Thủ dầu một', 1, CAST(0x0000ACB200C38CA8 AS DateTime), CAST(0x0000ACB200C38CA8 AS DateTime), 0, 1)
INSERT [dbo].[District] ([district_id], [district_name], [district_activate], [district_dateCreate], [district_dateEdit], [district_recycleBin], [provincial_id]) VALUES (1005, N'Bàu Bàng', 1, CAST(0x0000ACB2013D6A74 AS DateTime), CAST(0x0000ACB2013D6A74 AS DateTime), 0, 1)
SET IDENTITY_INSERT [dbo].[District] OFF
SET IDENTITY_INSERT [dbo].[Provincial] ON 

INSERT [dbo].[Provincial] ([provincial_id], [provincial_name], [provincial_activate], [provincial_dateCreate], [provincial_dateEdit], [provincial_recycleBin]) VALUES (1, N'Bình Dương', 1, CAST(0x0000ACAE00000000 AS DateTime), CAST(0x0000ACAE00000000 AS DateTime), 0)
INSERT [dbo].[Provincial] ([provincial_id], [provincial_name], [provincial_activate], [provincial_dateCreate], [provincial_dateEdit], [provincial_recycleBin]) VALUES (2, N'TP. Hồ Chí Minh', 1, CAST(0x0000ACAE00000000 AS DateTime), CAST(0x0000ACAE00000000 AS DateTime), 0)
INSERT [dbo].[Provincial] ([provincial_id], [provincial_name], [provincial_activate], [provincial_dateCreate], [provincial_dateEdit], [provincial_recycleBin]) VALUES (3, N'Bình Thuận', 1, CAST(0x0000ACB000186B25 AS DateTime), CAST(0x0000ACB000186B25 AS DateTime), 0)
INSERT [dbo].[Provincial] ([provincial_id], [provincial_name], [provincial_activate], [provincial_dateCreate], [provincial_dateEdit], [provincial_recycleBin]) VALUES (4, N'Vũng Tàu', 1, CAST(0x0000ACB00019BD4D AS DateTime), CAST(0x0000ACB00019BD4D AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Provincial] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_Answer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin], [question_keywordSearch]) VALUES (1, N'<p>In our new requirement, there is something like a super account where all the account data can be viewed. For example, if account 1 and account 2 is selected in the user list page, users of account 1 and 2 should be combined and viewed along with search provision. Is there any way to combine more than one schema data in the apartment? or any other alternates</p>', CAST(0x0000ACB0018A9ED6 AS DateTime), CAST(0x0000ACB0018A9ED6 AS DateTime), 4, 1, N'Accessing data from two or more schemas in a multi tenant application', 0, 0, 0, 0, 0, 0, 1, 0, 0, N'<p>In our new requirement, there is something like a super account where all the account data can be viewed. For example, if account 1 and account 2 is selected in the user list page, users of account 1 and 2 should be combined and viewed along with search provision. Is there any way to combine more than one schema data in the apartment? or any other alternates</p>Accessing data from two or more schemas in a multi tenant application')
INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_Answer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin], [question_keywordSearch]) VALUES (2, N'<p>Got this error on an ubuntu server (100GB RAM) in anacondas py3.6 installation after it opened multiple files this way in a for loop (7 files * 4GB):</p><p><strong>The </strong><a href="https://stackoverflow.com/help/bounty"><strong>bounty</strong></a><strong> expires in 5 hours</strong>. Answers to this question are eligible for a +50 reputation bounty. <a href="https://stackoverflow.com/users/1601580/charlie-parker">Charlie Parker</a> is looking for a <strong>more detailed answer</strong> to this question:</p><blockquote><p>is your <code>num_workers=0</code>? (mine is and I am getting the error, where else could it be trying to open multiple files?)</p></blockquote><p>Got this error on an ubuntu server (100GB RAM) in anacondas py3.6 installation after it opened multiple files this way in a for loop (7 files * 4GB):</p><blockquote><p>temp_df = pd.read_csv(datafolder + str(file), encoding="ISO-8859-1", delimiter='';'',low_memory=False)</p></blockquote><p>this is the error, it appeared after i set</p><blockquote><p>low_memory=False</p></blockquote><p>Doesnt happen when low_memory = True</p><blockquote><p><strong>* Error in `python'': free(): invalid pointer: 0x00007fc3c90dc98e *</strong></p></blockquote><p>Anyone ideas? Thanks</p>', CAST(0x0000ACB10001507C AS DateTime), CAST(0x0000ACB10001507C AS DateTime), 4, 1, N'Error in `python'': free(): invalid pointer: 0x00007fc3c90dc98e', 0, 1, 0, 0, 0, 0, 1, 0, 0, N'<p>Got this error on an ubuntu server (100GB RAM) in anacondas py3.6 installation after it opened multiple files this way in a for loop (7 files * 4GB):</p><p><strong>The </strong><a href="https://stackoverflow.com/help/bounty"><strong>bounty</strong></a><strong> expires in 5 hours</strong>. Answers to this question are eligible for a +50 reputation bounty. <a href="https://stackoverflow.com/users/1601580/charlie-parker">Charlie Parker</a> is looking for a <strong>more detailed answer</strong> to this question:</p><blockquote><p>is your <code>num_workers=0</code>? (mine is and I am getting the error, where else could it be trying to open multiple files?)</p></blockquote><p>Got this error on an ubuntu server (100GB RAM) in anacondas py3.6 installation after it opened multiple files this way in a for loop (7 files * 4GB):</p><blockquote><p>temp_df = pd.read_csv(datafolder + str(file), encoding="ISO-8859-1", delimiter='';'',low_memory=False)</p></blockquote><p>this is the error, it appeared after i set</p><blockquote><p>low_memory=False</p></blockquote><p>Doesnt happen when low_memory = True</p><blockquote><p><strong>* Error in `python'': free(): invalid pointer: 0x00007fc3c90dc98e *</strong></p></blockquote><p>Anyone ideas? Thanks</p>Error in `python'': free(): invalid pointer: 0x00007fc3c90dc98eC#PHPangularcsshtmltest2test3')
INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_Answer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin], [question_keywordSearch]) VALUES (3, N'<p>I am using react quizzes library: <a href="https://codesandbox.io/s/react-quizzesexample-forked-2w1gj?file=/src/index.js:408-499">https://codesandbox.io/s/react-quizzesexample-forked-2w1gj?file=/src/index.js:408-499</a><br>According to the <a href="https://github.com/hugobarragon/react-quizzes">documentation</a> we can choose just these kind of builder items from menu that we want using <code>toolBox</code>.</p><p>I want to leave just Checkboxes in the menu but i didn''t find a solution for this. Who can help?</p><pre><code class="language-plaintext">function App() {
  const [formdata, setFormData] = useState([]);

  return (
    &lt;div className="App"&gt;
      &lt;QuizzBuilder onChange={setFormData} /&gt;
    &lt;/div&gt;
  );
}

const rootElement = document.getElementById("root");
ReactDOM.render(&lt;App /&gt;, rootElement);</code></pre><p>&nbsp;</p>', CAST(0x0000ACB3014884A6 AS DateTime), CAST(0x0000ACB3014884A6 AS DateTime), 4, 1, N'Limit the number of items in menu in react quizzes', 0, 0, 0, 0, 0, 0, 1, 0, 0, N'<p>I am using react quizzes library: <a href="https://codesandbox.io/s/react-quizzesexample-forked-2w1gj?file=/src/index.js:408-499">https://codesandbox.io/s/react-quizzesexample-forked-2w1gj?file=/src/index.js:408-499</a><br>According to the <a href="https://github.com/hugobarragon/react-quizzes">documentation</a> we can choose just these kind of builder items from menu that we want using <code>toolBox</code>.</p><p>I want to leave just Checkboxes in the menu but i didn''t find a solution for this. Who can help?</p><pre><code class="language-plaintext">function App() {
  const [formdata, setFormData] = useState([]);

  return (
    &lt;div className="App"&gt;
      &lt;QuizzBuilder onChange={setFormData} /&gt;
    &lt;/div&gt;
  );
}

const rootElement = document.getElementById("root");
ReactDOM.render(&lt;App /&gt;, rootElement);</code></pre><p>&nbsp;</p>Limit the number of items in menu in react quizzesjavascripthtml')
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Role_User] ON 

INSERT [dbo].[Role_User] ([role_id], [role_name], [role_activate], [role_dateCreate], [role_dateEdit], [role_recycleBin]) VALUES (1, N'Bình thường', 1, CAST(0x0000ACAC00000000 AS DateTime), CAST(0x0000ACB600000000 AS DateTime), 0)
INSERT [dbo].[Role_User] ([role_id], [role_name], [role_activate], [role_dateCreate], [role_dateEdit], [role_recycleBin]) VALUES (2, N'Nhà văn', 0, CAST(0x0000ACAC00000000 AS DateTime), CAST(0x0000ACAC00000000 AS DateTime), 0)
INSERT [dbo].[Role_User] ([role_id], [role_name], [role_activate], [role_dateCreate], [role_dateEdit], [role_recycleBin]) VALUES (3, N'Administrator', 1, CAST(0x0000ACAC00000000 AS DateTime), CAST(0x0000ACAC00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Role_User] OFF
SET IDENTITY_INSERT [dbo].[Sex_User] ON 

INSERT [dbo].[Sex_User] ([sex_id], [sex_name], [sex_activate], [sex_dateCreate], [sex_dateEdit], [sex_recycleBin]) VALUES (1, N'Nam', 1, CAST(0x0000ACAD00000000 AS DateTime), CAST(0x0000ACAD00000000 AS DateTime), 0)
INSERT [dbo].[Sex_User] ([sex_id], [sex_name], [sex_activate], [sex_dateCreate], [sex_dateEdit], [sex_recycleBin]) VALUES (2, N'Nữ', 1, CAST(0x0000ACAD00000000 AS DateTime), CAST(0x0000ACAD00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Sex_User] OFF
SET IDENTITY_INSERT [dbo].[Tags_Question] ON 

INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (1, 1, N'angular', CAST(0x0000ACB0018A9ED5 AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (2, 1, N'html', CAST(0x0000ACB0018A9ED6 AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (3, 1, N'css', CAST(0x0000ACB0018A9ED6 AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (4, 1, N'test1', CAST(0x0000ACB0018A9ED6 AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (5, 2, N'angular', CAST(0x0000ACB10001507B AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (6, 2, N'css', CAST(0x0000ACB10001507B AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (7, 2, N'html', CAST(0x0000ACB10001507B AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (8, 2, N'test2', CAST(0x0000ACB10001507B AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (9, 2, N'test3', CAST(0x0000ACB10001507C AS DateTime))
INSERT [dbo].[Tags_Question] ([tagsQuestion_id], [question_id], [tagsQuestion_name], [tagsQuestion_dateCreate]) VALUES (10, 3, N'html', CAST(0x0000ACB3014884A6 AS DateTime))
SET IDENTITY_INSERT [dbo].[Tags_Question] OFF
SET IDENTITY_INSERT [dbo].[Teachnology_Question] ON 

INSERT [dbo].[Teachnology_Question] ([teachnologyQuestion_id], [technology_id], [question_id], [teachnologyQuestion_recycleBin]) VALUES (1, 1, 1, 0)
INSERT [dbo].[Teachnology_Question] ([teachnologyQuestion_id], [technology_id], [question_id], [teachnologyQuestion_recycleBin]) VALUES (2, 2, 1, 0)
INSERT [dbo].[Teachnology_Question] ([teachnologyQuestion_id], [technology_id], [question_id], [teachnologyQuestion_recycleBin]) VALUES (3, 4, 1, 0)
INSERT [dbo].[Teachnology_Question] ([teachnologyQuestion_id], [technology_id], [question_id], [teachnologyQuestion_recycleBin]) VALUES (4, 1, 2, 0)
INSERT [dbo].[Teachnology_Question] ([teachnologyQuestion_id], [technology_id], [question_id], [teachnologyQuestion_recycleBin]) VALUES (5, 2, 2, 0)
INSERT [dbo].[Teachnology_Question] ([teachnologyQuestion_id], [technology_id], [question_id], [teachnologyQuestion_recycleBin]) VALUES (6, 3, 3, 0)
SET IDENTITY_INSERT [dbo].[Teachnology_Question] OFF
SET IDENTITY_INSERT [dbo].[Teachnology_User] ON 

INSERT [dbo].[Teachnology_User] ([technologyUser_id], [user_id], [technology_id], [technology_dateCreate], [technology_recycleBin]) VALUES (3, 3, 2, NULL, NULL)
INSERT [dbo].[Teachnology_User] ([technologyUser_id], [user_id], [technology_id], [technology_dateCreate], [technology_recycleBin]) VALUES (4, 3, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teachnology_User] OFF
SET IDENTITY_INSERT [dbo].[Technology] ON 

INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_popular], [technology_activate], [technology_recycleBin], [technology_dateCreate], [technology_dateEdit], [technology_note], [technology_totalQuestion]) VALUES (1, N'C#', 5, 1, 0, CAST(0x0000ACAD00000000 AS DateTime), CAST(0x0000ACAD00000000 AS DateTime), N'không có', 10)
INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_popular], [technology_activate], [technology_recycleBin], [technology_dateCreate], [technology_dateEdit], [technology_note], [technology_totalQuestion]) VALUES (2, N'PHP', 7, 1, 0, CAST(0x0000ACAD00000000 AS DateTime), CAST(0x0000ACAD00000000 AS DateTime), N'không có', 10)
INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_popular], [technology_activate], [technology_recycleBin], [technology_dateCreate], [technology_dateEdit], [technology_note], [technology_totalQuestion]) VALUES (3, N'javascript', 25, 1, 0, CAST(0x0000ACAF00127F52 AS DateTime), CAST(0x0000ACAF00127F52 AS DateTime), N'chưa bk', 0)
INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_popular], [technology_activate], [technology_recycleBin], [technology_dateCreate], [technology_dateEdit], [technology_note], [technology_totalQuestion]) VALUES (4, N'Java', 10, 1, 0, CAST(0x0000ACAF0187A180 AS DateTime), CAST(0x0000ACAF0187A180 AS DateTime), N'chưa bk', 0)
SET IDENTITY_INSERT [dbo].[Technology] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [user_pass], [user_firstName], [user_lastName], [user_email], [user_token], [role_id], [user_code], [user_avatar], [user_coverImage], [user_activate], [user_recycleBin], [user_dateCreate], [user_dateEdit], [user_dateLogin], [user_emailAuthentication], [user_verifyPhoneNumber], [user_loginAuthentication], [provincial_id], [district_id], [commune_id], [user_addressRemaining], [sex_id], [user_linkFacebook], [user_linkGithub], [user_anotherWeb], [user_hobbyWork], [user_hobby], [user_birthday], [user_popular], [user_goldMedal], [user_silverMedal], [user_brozeMedal], [user_vipMedal], [user_phone]) VALUES (3, N'1b4593bb82a798762b5b54204835ad40', N'Cương', N'Em', N'cuongembaubang@gmail.com', N'5d2ede6a-1a0d-4b98-a90f-f1d6f8b17b54', 3, N'#IOGHTKADM-445', N'Man.png', N'coverImage.png', 1, 0, CAST(0x0000ACAD000AEB54 AS DateTime), CAST(0x0000ACAD000AEB54 AS DateTime), CAST(0x0000ACB400F5B30B AS DateTime), 0, 0, 1, NULL, NULL, NULL, NULL, 1, N'https://www.facebook.com/hoangmaicuong.99/', N'https://www.facebook.com/hoangmaicuong.99/', N'https://www.facebook.com/hoangmaicuong.99/', N'thích nghiên cứu', N'thích nghiên cứu', CAST(0x08420B00 AS Date), 0, 0, 0, 0, 0, N'0377416055')
INSERT [dbo].[User] ([user_id], [user_pass], [user_firstName], [user_lastName], [user_email], [user_token], [role_id], [user_code], [user_avatar], [user_coverImage], [user_activate], [user_recycleBin], [user_dateCreate], [user_dateEdit], [user_dateLogin], [user_emailAuthentication], [user_verifyPhoneNumber], [user_loginAuthentication], [provincial_id], [district_id], [commune_id], [user_addressRemaining], [sex_id], [user_linkFacebook], [user_linkGithub], [user_anotherWeb], [user_hobbyWork], [user_hobby], [user_birthday], [user_popular], [user_goldMedal], [user_silverMedal], [user_brozeMedal], [user_vipMedal], [user_phone]) VALUES (4, N'1b4593bb82a798762b5b54204835ad40', N'Cương', N'Hoàng', N'hoangmaicuong99@gmail.com', N'5d2ede6a-1a0d-4b98-a90f-f1d6f8b17b54', 1, N'#IOGHTKADM-445', N'Man.png', N'coverImage.png', 1, 0, CAST(0x0000ACAD000AEB54 AS DateTime), CAST(0x0000ACAD000AEB54 AS DateTime), CAST(0x0000ACB40144F9D7 AS DateTime), 0, 0, 1, NULL, NULL, NULL, NULL, 1, N'https://www.facebook.com/hoangmaicuong.99/', N'https://www.facebook.com/hoangmaicuong.99/', N'https://www.facebook.com/hoangmaicuong.99/', N'thích nghiên cứu', N'thích nghiên cứu', CAST(0x08420B00 AS Date), 0, 0, 0, 0, 0, N'0377416055')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_User]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_User]
GO
ALTER TABLE [dbo].[Comment_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Answer_Answer] FOREIGN KEY([answer_id])
REFERENCES [dbo].[Answer] ([answer_id])
GO
ALTER TABLE [dbo].[Comment_Answer] CHECK CONSTRAINT [FK_Comment_Answer_Answer]
GO
ALTER TABLE [dbo].[Comment_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Answer_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Comment_Answer] CHECK CONSTRAINT [FK_Comment_Answer_User]
GO
ALTER TABLE [dbo].[Commune]  WITH CHECK ADD  CONSTRAINT [FK_Commune_District] FOREIGN KEY([district_id])
REFERENCES [dbo].[District] ([district_id])
GO
ALTER TABLE [dbo].[Commune] CHECK CONSTRAINT [FK_Commune_District]
GO
ALTER TABLE [dbo].[Denounce_User]  WITH CHECK ADD  CONSTRAINT [FK_Denounce_User_User] FOREIGN KEY([accuser_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Denounce_User] CHECK CONSTRAINT [FK_Denounce_User_User]
GO
ALTER TABLE [dbo].[Denounce_User]  WITH CHECK ADD  CONSTRAINT [FK_Denounce_User_User1] FOREIGN KEY([discredit_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Denounce_User] CHECK CONSTRAINT [FK_Denounce_User_User1]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_Provincial] FOREIGN KEY([provincial_id])
REFERENCES [dbo].[Provincial] ([provincial_id])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_Provincial]
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_User] FOREIGN KEY([userRequest_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_User]
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_User1] FOREIGN KEY([userResponse_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_User1]
GO
ALTER TABLE [dbo].[Image_Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Image_Advertisement_Advertisement] FOREIGN KEY([advertisement_id])
REFERENCES [dbo].[Advertisement] ([advertisiment_id])
GO
ALTER TABLE [dbo].[Image_Advertisement] CHECK CONSTRAINT [FK_Image_Advertisement_Advertisement]
GO
ALTER TABLE [dbo].[Image_Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Image_Advertisement_Position_Advertisement] FOREIGN KEY([positionAdvertisement_id])
REFERENCES [dbo].[Position_Advertisement] ([positionAdvertisement_id])
GO
ALTER TABLE [dbo].[Image_Advertisement] CHECK CONSTRAINT [FK_Image_Advertisement_Position_Advertisement]
GO
ALTER TABLE [dbo].[Letters]  WITH CHECK ADD  CONSTRAINT [FK_Letters_Role_User] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role_User] ([role_id])
GO
ALTER TABLE [dbo].[Letters] CHECK CONSTRAINT [FK_Letters_Role_User]
GO
ALTER TABLE [dbo].[Letters]  WITH CHECK ADD  CONSTRAINT [FK_Letters_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Letters] CHECK CONSTRAINT [FK_Letters_User]
GO
ALTER TABLE [dbo].[Letters_Idea]  WITH CHECK ADD  CONSTRAINT [FK_Letters_Idea_Role_User] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role_User] ([role_id])
GO
ALTER TABLE [dbo].[Letters_Idea] CHECK CONSTRAINT [FK_Letters_Idea_Role_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([messageSender_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User1] FOREIGN KEY([messageRecipients_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User1]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Question]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User] FOREIGN KEY([receiver_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User1] FOREIGN KEY([impactUser_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User1]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_User]
GO
ALTER TABLE [dbo].[Rate_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Answer_Answer] FOREIGN KEY([answer_id])
REFERENCES [dbo].[Answer] ([answer_id])
GO
ALTER TABLE [dbo].[Rate_Answer] CHECK CONSTRAINT [FK_Rate_Answer_Answer]
GO
ALTER TABLE [dbo].[Rate_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Answer_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Rate_Answer] CHECK CONSTRAINT [FK_Rate_Answer_User]
GO
ALTER TABLE [dbo].[Rate_Post]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Rate_Post] CHECK CONSTRAINT [FK_Rate_Post_Post]
GO
ALTER TABLE [dbo].[Rate_Post]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Rate_Post] CHECK CONSTRAINT [FK_Rate_Post_User]
GO
ALTER TABLE [dbo].[Rate_Question]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Question_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Rate_Question] CHECK CONSTRAINT [FK_Rate_Question_Question]
GO
ALTER TABLE [dbo].[Rate_Question]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Question_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Rate_Question] CHECK CONSTRAINT [FK_Rate_Question_User]
GO
ALTER TABLE [dbo].[Regulations]  WITH CHECK ADD  CONSTRAINT [FK_Regulations_Role_User] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role_User] ([role_id])
GO
ALTER TABLE [dbo].[Regulations] CHECK CONSTRAINT [FK_Regulations_Role_User]
GO
ALTER TABLE [dbo].[Search]  WITH CHECK ADD  CONSTRAINT [FK_Search_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Search] CHECK CONSTRAINT [FK_Search_User]
GO
ALTER TABLE [dbo].[Show_Activate_Question]  WITH CHECK ADD  CONSTRAINT [FK_Show_Activate_Question_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Show_Activate_Question] CHECK CONSTRAINT [FK_Show_Activate_Question_Question]
GO
ALTER TABLE [dbo].[Show_Activate_Question]  WITH CHECK ADD  CONSTRAINT [FK_Show_Activate_Question_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Show_Activate_Question] CHECK CONSTRAINT [FK_Show_Activate_Question_User]
GO
ALTER TABLE [dbo].[Tags_Question]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Question_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Tags_Question] CHECK CONSTRAINT [FK_Tags_Question_Question]
GO
ALTER TABLE [dbo].[Teachnology_Question]  WITH CHECK ADD  CONSTRAINT [FK_Teachnology_Question_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Teachnology_Question] CHECK CONSTRAINT [FK_Teachnology_Question_Question]
GO
ALTER TABLE [dbo].[Teachnology_Question]  WITH CHECK ADD  CONSTRAINT [FK_Teachnology_Question_Technology] FOREIGN KEY([technology_id])
REFERENCES [dbo].[Technology] ([technology_id])
GO
ALTER TABLE [dbo].[Teachnology_Question] CHECK CONSTRAINT [FK_Teachnology_Question_Technology]
GO
ALTER TABLE [dbo].[Teachnology_User]  WITH CHECK ADD  CONSTRAINT [FK_Teachnology_User_Technology] FOREIGN KEY([technology_id])
REFERENCES [dbo].[Technology] ([technology_id])
GO
ALTER TABLE [dbo].[Teachnology_User] CHECK CONSTRAINT [FK_Teachnology_User_Technology]
GO
ALTER TABLE [dbo].[Teachnology_User]  WITH CHECK ADD  CONSTRAINT [FK_Teachnology_User_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Teachnology_User] CHECK CONSTRAINT [FK_Teachnology_User_User]
GO
ALTER TABLE [dbo].[Tick_Question]  WITH CHECK ADD  CONSTRAINT [FK_Tick_Question_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[Tick_Question] CHECK CONSTRAINT [FK_Tick_Question_Question]
GO
ALTER TABLE [dbo].[Tick_Question]  WITH CHECK ADD  CONSTRAINT [FK_Tick_Question_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Tick_Question] CHECK CONSTRAINT [FK_Tick_Question_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Commune] FOREIGN KEY([commune_id])
REFERENCES [dbo].[Commune] ([commune_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Commune]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_District] FOREIGN KEY([district_id])
REFERENCES [dbo].[District] ([district_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_District]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Provincial] FOREIGN KEY([provincial_id])
REFERENCES [dbo].[Provincial] ([provincial_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Provincial]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_User] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role_User] ([role_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Sex_User] FOREIGN KEY([sex_id])
REFERENCES [dbo].[Sex_User] ([sex_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Sex_User]
GO
ALTER TABLE [dbo].[View_Post]  WITH CHECK ADD  CONSTRAINT [FK_View_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[View_Post] CHECK CONSTRAINT [FK_View_Post_Post]
GO
ALTER TABLE [dbo].[View_Post]  WITH CHECK ADD  CONSTRAINT [FK_View_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[View_Post] CHECK CONSTRAINT [FK_View_Post_User]
GO
ALTER TABLE [dbo].[View_Question]  WITH CHECK ADD  CONSTRAINT [FK_View_Question_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([question_id])
GO
ALTER TABLE [dbo].[View_Question] CHECK CONSTRAINT [FK_View_Question_Question]
GO
ALTER TABLE [dbo].[View_Question]  WITH CHECK ADD  CONSTRAINT [FK_View_Question_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[View_Question] CHECK CONSTRAINT [FK_View_Question_User]
GO
USE [master]
GO
ALTER DATABASE [FivePSocialNetWork] SET  READ_WRITE 
GO
