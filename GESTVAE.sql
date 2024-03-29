USE [master]
GO
/****** Object:  Database [GESTVAE]    Script Date: 06/03/2019 19:03:37 ******/
CREATE DATABASE [GESTVAE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GESTVAETU', FILENAME = N'C:\Users\COLLIN\GESTVAETU.mdf' , SIZE = 5184KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GESTVAETU_log', FILENAME = N'C:\Users\COLLIN\GESTVAETU_log.ldf' , SIZE = 1856KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GESTVAE] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GESTVAE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GESTVAE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GESTVAE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GESTVAE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GESTVAE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GESTVAE] SET ARITHABORT OFF 
GO
ALTER DATABASE [GESTVAE] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GESTVAE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GESTVAE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GESTVAE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GESTVAE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GESTVAE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GESTVAE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GESTVAE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GESTVAE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GESTVAE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GESTVAE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GESTVAE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GESTVAE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GESTVAE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GESTVAE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GESTVAE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GESTVAE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GESTVAE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GESTVAE] SET  MULTI_USER 
GO
ALTER DATABASE [GESTVAE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GESTVAE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GESTVAE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GESTVAE] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [GESTVAE]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Candidats]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Civilite] [nvarchar](max) NULL,
	[Nom] [nvarchar](max) NULL,
	[Prenom] [nvarchar](max) NULL,
	[Prenom2] [nvarchar](max) NULL,
	[Prenom3] [nvarchar](max) NULL,
	[Sexe] [int] NULL,
	[IdVAE] [nvarchar](max) NULL,
	[IdSiscole] [nvarchar](max) NULL,
	[NomJeuneFille] [nvarchar](max) NULL,
	[Nationnalite] [nvarchar](max) NULL,
	[DateNaissance] [datetime] NULL,
	[CPNaissance] [nvarchar](max) NULL,
	[VilleNaissance] [nvarchar](max) NULL,
	[NationaliteNaissance] [nvarchar](max) NULL,
	[Adresse] [nvarchar](max) NULL,
	[CodePostal] [nvarchar](max) NULL,
	[Ville] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
	[Pays] [nvarchar](max) NULL,
	[RegionTravail] [nvarchar](max) NULL,
	[CPTravail] [nvarchar](max) NULL,
	[VilleTravail] [nvarchar](max) NULL,
	[Mail1] [nvarchar](max) NULL,
	[Mail2] [nvarchar](max) NULL,
	[Mail3] [nvarchar](max) NULL,
	[Tel1] [nvarchar](max) NULL,
	[Tel2] [nvarchar](max) NULL,
	[Tel3] [nvarchar](max) NULL,
	[bHandicap] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Candidats] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DCLivrets]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DCLivrets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Decision] [nvarchar](max) NULL,
	[MotifGeneral] [nvarchar](max) NULL,
	[MotifDetail] [nvarchar](max) NULL,
	[MotifCommentaire] [nvarchar](max) NULL,
	[IsAValider] [bit] NOT NULL,
	[Statut] [nvarchar](max) NULL,
	[DateObtention] [datetime] NULL,
	[ModeObtention] [nvarchar](max) NULL,
	[Commentaire] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[oDomaineCompetence_ID] [int] NULL,
	[oLivret2_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DCLivrets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiplomeCands]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiplomeCands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Statut] [nvarchar](max) NULL,
	[DateObtention] [datetime] NULL,
	[NumeroDiplome] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Candidat_ID] [int] NOT NULL,
	[Diplome_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DiplomeCands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Diplomes]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diplomes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Diplomes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DomaineCompetenceCands]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomaineCompetenceCands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Statut] [nvarchar](max) NULL,
	[DateObtention] [datetime] NULL,
	[ModeObtention] [nvarchar](max) NULL,
	[Commentaire] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Diplome_ID] [int] NOT NULL,
	[DomaineCompetence_ID] [int] NULL,
 CONSTRAINT [PK_dbo.DomaineCompetenceCands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DomaineCompetences]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomaineCompetences](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Diplome_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DomaineCompetences] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EchangeL1]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EchangeL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateEch] [datetime] NULL,
	[MotifEch] [nvarchar](max) NULL,
	[DateEcheanceEch] [datetime] NULL,
	[DateReceptionEch] [datetime] NULL,
	[IsOK] [bit] NOT NULL,
	[CommentaireEch] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Livret1_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EchangeL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EchangeL2]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EchangeL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateEch] [datetime] NULL,
	[MotifEch] [nvarchar](max) NULL,
	[DateEcheanceEch] [datetime] NULL,
	[DateReceptionEch] [datetime] NULL,
	[IsOK] [bit] NOT NULL,
	[CommentaireEch] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Livret2_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EchangeL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Juries]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumeroOrdre] [int] NOT NULL,
	[NomJury] [nvarchar](max) NULL,
	[DateJury] [datetime] NULL,
	[HeureJury] [datetime] NULL,
	[HeureConvoc] [datetime] NULL,
	[DateLimiteRecours] [datetime] NULL,
	[LieuJury] [nvarchar](max) NULL,
	[Decision] [nvarchar](max) NULL,
	[MotifGeneral] [nvarchar](max) NULL,
	[MotifDetail] [nvarchar](max) NULL,
	[MotifCommentaire] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Livret1_ID] [int] NULL,
	[Livret2_ID] [int] NULL,
	[DateNotificationJury] [datetime] NULL,
	[DateNotificationJuryRecours] [datetime] NULL,
	[IsRecours] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Juries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Livret1]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livret1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](max) NULL,
	[DateDemande] [datetime] NULL,
	[DateLimiteEnvoiEHESP] [datetime] NULL,
	[DateLimiteReceptEHESP] [datetime] NULL,
	[DateLimiteJury] [datetime] NULL,
	[DateValidite] [datetime] NULL,
	[Date1ereDemandePieceManquantes] [datetime] NULL,
	[Date2emeDemandePieceManquantes] [datetime] NULL,
	[DateDemandePieceManquantesRetour] [datetime] NULL,
	[DateEcheance] [datetime] NULL,
	[isContrat] [bit] NOT NULL,
	[TypeDemande] [nvarchar](max) NULL,
	[EtatLivret] [nvarchar](max) NULL,
	[DateEnvoiEHESP] [datetime] NULL,
	[DateEnvoiCandidat] [datetime] NULL,
	[DateReceptEHESP] [datetime] NULL,
	[DateReceptEHESPComplet] [datetime] NULL,
	[isClos] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Candidat_ID] [int] NOT NULL,
	[Diplome_ID] [int] NOT NULL,
	[DateReceptionPiecesManquantes] [datetime] NULL,
	[VecteurInformation] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Livret1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Livret2]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livret2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](max) NULL,
	[DateDemande] [datetime] NULL,
	[DateLimiteEnvoiEHESP] [datetime] NULL,
	[DateLimiteReceptEHESP] [datetime] NULL,
	[DatePrevJury1] [datetime] NULL,
	[DatePrevJury2] [datetime] NULL,
	[SessionJury] [nvarchar](max) NULL,
	[DateLimiteJury] [datetime] NULL,
	[DateValidite] [datetime] NULL,
	[IsAttestationOK] [bit] NOT NULL,
	[IsCNIOK] [bit] NOT NULL,
	[IsDispenseArt2] [bit] NOT NULL,
	[DateEcheance] [datetime] NULL,
	[isContrat] [bit] NOT NULL,
	[EtatLivret] [nvarchar](max) NULL,
	[DateEnvoiEHESP] [datetime] NULL,
	[DateEnvoiCandidat] [datetime] NULL,
	[DateReceptEHESP] [datetime] NULL,
	[DateReceptEHESPComplet] [datetime] NULL,
	[isClos] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Candidat_ID] [int] NOT NULL,
	[Diplome_ID] [int] NOT NULL,
	[Date1ereDemandePieceManquantes] [datetime] NULL,
	[Date2emeDemandePieceManquantes] [datetime] NULL,
	[DateDemandePieceManquantesRetour] [datetime] NULL,
	[DateReceptionPiecesManquantes] [datetime] NULL,
	[NumPassage] [int] NOT NULL DEFAULT ((0)),
	[IsOuvertureApresRecours] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Livret2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LockCandidats]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LockCandidats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCandidat] [int] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LockCandidats] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MembreJuries]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembreJuries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[College] [nvarchar](max) NULL,
	[Origine] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Livret2_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MembreJuries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotifDetailleL1]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotifDetailleL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[MotifGL1_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MotifDetailleL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotifDetailleL2]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotifDetailleL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[MotifGL2_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MotifDetailleL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotifGeneralL1]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotifGeneralL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MotifGeneralL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotifGeneralL2]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotifGeneralL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MotifGeneralL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParamColleges]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParamColleges](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ParamColleges] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParamOrigines]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParamOrigines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ParamOrigines] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParamTypeDemandes]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParamTypeDemandes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ParamTypeDemandes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParamVecteurInformations]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParamVecteurInformations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ParamVecteurInformations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PieceJointeCategories]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Livret] [nvarchar](max) NULL,
	[Categorie] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PieceJointeCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PieceJointeItems]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Categorie_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PieceJointeItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PieceJointeL1]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Categorie] [nvarchar](max) NULL,
	[Libelle] [nvarchar](max) NULL,
	[IsRecu] [bit] NOT NULL,
	[IsOK] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Livret1_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PieceJointeL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PieceJointeL2]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Categorie] [nvarchar](max) NULL,
	[Libelle] [nvarchar](max) NULL,
	[IsRecu] [bit] NOT NULL,
	[IsOK] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[Livret2_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PieceJointeL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recours]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recours](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateDepot] [datetime] NULL,
	[TypeRecours] [int] NOT NULL,
	[MotifRecours] [nvarchar](max) NULL,
	[MotifRecoursCommentaire] [nvarchar](max) NULL,
	[NomJury] [nvarchar](max) NULL,
	[DateJury] [datetime] NULL,
	[LieuJury] [nvarchar](max) NULL,
	[Decision] [nvarchar](max) NULL,
	[MotifGeneral] [nvarchar](max) NULL,
	[MotifDetail] [nvarchar](max) NULL,
	[MotifCommentaire] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
	[DateLimiteJury] [datetime] NULL,
	[Jury_ID] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Recours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regions]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Regions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[Livret1_NonClos]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Livret1_NonClos]
AS
SELECT        dbo.Livret1.*
FROM            dbo.Livret1
WHERE        (isClos = 0)

GO
/****** Object:  View [dbo].[L1_RECUS_COMPLETS]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_RECUS_COMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1_NonClos.Numero, dbo.Livret1_NonClos.ID AS IDLivret1, dbo.Livret1_NonClos.DateEnvoiCandidat, dbo.Livret1_NonClos.DateLimiteReceptEHESP, dbo.Livret1_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret1_NonClos.EtatLivret, dbo.Juries.DateJury, 
                         dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Livret1_NonClos.DateLimiteJury, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, 
                         dbo.Livret1_NonClos.DateDemandePieceManquantesRetour
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1_NonClos ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
WHERE        (dbo.Livret1_NonClos.EtatLivret LIKE N'40%')


GO
/****** Object:  View [dbo].[L1_RECUS_INCOMPLETS]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Adresse, dbo.Livret1_NonClos.ID AS IDLIVRET1, dbo.Livret1_NonClos.Numero, dbo.Livret1_NonClos.DateReceptEHESP, 
                         dbo.Livret1_NonClos.DateLimiteReceptEHESP, dbo.Livret1_NonClos.EtatLivret, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, dbo.Livret1_NonClos.DateDemandePieceManquantesRetour
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1_NonClos ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID
WHERE        (dbo.Livret1_NonClos.EtatLivret LIKE N'30%')


GO
/****** Object:  View [dbo].[L1_RECUS_INCOMPLETS_PJ]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS_PJ]
AS
SELECT        dbo.PieceJointeL1.Categorie, dbo.PieceJointeL1.Libelle, dbo.L1_RECUS_INCOMPLETS.IDLIVRET1
FROM            dbo.PieceJointeL1 INNER JOIN
                         dbo.L1_RECUS_INCOMPLETS ON dbo.PieceJointeL1.Livret1_ID = dbo.L1_RECUS_INCOMPLETS.IDLIVRET1
WHERE        (dbo.PieceJointeL1.IsOK = 0)


GO
/****** Object:  View [dbo].[L1_VALIDATION_ACCEPTE]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_VALIDATION_ACCEPTE]
AS
SELECT        Candidats.ID, Candidats.Civilite, Candidats.Nom, Candidats.Prenom, Candidats.Prenom2, Candidats.Prenom3, Candidats.Adresse, Candidats.CodePostal, Candidats.Ville, Livret1_NonClos.Numero, 
                         Livret1_NonClos.ID AS IDLivret1, Livret1_NonClos.DateEnvoiCandidat, Livret1_NonClos.DateLimiteReceptEHESP, Livret1_NonClos.DateReceptEHESP, Candidats.Pays, Livret1_NonClos.EtatLivret, Juries.DateJury, 
                         Juries.NomJury, Juries.LieuJury, Juries.HeureJury, Juries.HeureConvoc, Juries.Decision, Candidats.Sexe, Candidats.NomJeuneFille, Candidats.DateNaissance, Candidats.CPNaissance, Candidats.VilleNaissance, 
                         Livret1_NonClos.DateValidite, dbo.juries.IsRecours, Juries.DateLimiteRecours, Recours.DateDepot, Recours.TypeRecours, Juries.MotifGeneral, Juries.MotifDetail, Juries.MotifCommentaire, 
                         Juries.IsRecours AS Expr1
FROM            Juries LEFT OUTER JOIN
                         Recours ON Juries.ID = Recours.Jury_ID RIGHT OUTER JOIN
                         Candidats INNER JOIN
                         Livret1_NonClos ON Candidats.ID = Livret1_NonClos.Candidat_ID ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE        (Juries.Decision LIKE N'10-%')


GO
/****** Object:  View [dbo].[L1_VALIDATION_APRESRECOURS]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_VALIDATION_APRESRECOURS]
AS
SELECT        Candidats.ID, Candidats.Civilite, Candidats.Nom, Candidats.Prenom, Candidats.Prenom2, Candidats.Prenom3, Candidats.Adresse, Candidats.CodePostal, Candidats.Ville, Livret1_NonClos.Numero, 
                         Livret1_NonClos.ID AS IDLivret1, Livret1_NonClos.DateEnvoiCandidat, Livret1_NonClos.DateLimiteReceptEHESP, Livret1_NonClos.DateReceptEHESP, Candidats.Pays, Livret1_NonClos.EtatLivret, Juries.DateJury, 
                         Juries.NomJury, Juries.LieuJury, Juries.HeureJury, Juries.HeureConvoc, Juries.Decision, Candidats.Sexe, Candidats.NomJeuneFille, Candidats.DateNaissance, Candidats.CPNaissance, Candidats.VilleNaissance, 
                         Livret1_NonClos.DateValidite, juries.IsRecours, Juries.DateLimiteRecours, Recours.Decision AS DecisionRecours, Recours.MotifGeneral, Recours.MotifDetail, Recours.MotifCommentaire
FROM            Recours RIGHT OUTER JOIN
                         Juries ON Recours.Jury_ID = Juries.ID RIGHT OUTER JOIN
                         Candidats INNER JOIN
                         Livret1_NonClos ON Candidats.ID = Livret1_NonClos.Candidat_ID ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE        (Juries.Decision LIKE N'20-%') AND (dbo.juries.IsRecours = 1) AND (Recours.Decision LIKE N'10-%')


GO
/****** Object:  View [dbo].[L1_VALIDATION_REFUSE]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_VALIDATION_REFUSE]
AS
SELECT        Candidats.ID, Candidats.Civilite, Candidats.Nom, Candidats.Prenom, Candidats.Prenom2, Candidats.Prenom3, Candidats.Adresse, Candidats.CodePostal, Candidats.Ville, Livret1_NonClos.Numero, 
                         Livret1_NonClos.ID AS IDLivret1, Livret1_NonClos.DateEnvoiCandidat, Livret1_NonClos.DateLimiteReceptEHESP, Livret1_NonClos.DateReceptEHESP, Candidats.Pays, Livret1_NonClos.EtatLivret, Juries.DateJury, 
                         Juries.NomJury, Juries.LieuJury, Juries.HeureJury, Juries.HeureConvoc, Juries.Decision, Candidats.Sexe, Candidats.NomJeuneFille, Candidats.DateNaissance, Candidats.CPNaissance, Candidats.VilleNaissance, 
                         Livret1_NonClos.DateValidite, Juries.IsRecours, Juries.DateLimiteRecours, Recours.DateDepot, Recours.TypeRecours, Juries.MotifGeneral, Juries.MotifDetail, Juries.MotifCommentaire, Recours.Jury_ID
FROM            Recours RIGHT OUTER JOIN
                         Juries ON Recours.Jury_ID = Juries.ID RIGHT OUTER JOIN
                         Candidats INNER JOIN
                         Livret1_NonClos ON Candidats.ID = Livret1_NonClos.Candidat_ID ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE        (Juries.Decision LIKE N'20-%')

GO
/****** Object:  View [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]
AS
SELECT        Candidats.ID, Candidats.Civilite, Candidats.Nom, Candidats.Prenom, Candidats.Prenom2, Candidats.Prenom3, Candidats.Adresse, Candidats.CodePostal, Candidats.Ville, Livret1_NonClos.Numero, 
                         Livret1_NonClos.ID AS IDLivret1, Livret1_NonClos.DateEnvoiCandidat, Livret1_NonClos.DateLimiteReceptEHESP, Livret1_NonClos.DateReceptEHESP, Candidats.Pays, Livret1_NonClos.EtatLivret, Juries.DateJury, 
                         Juries.NomJury, Juries.LieuJury, Juries.HeureJury, Juries.HeureConvoc, Juries.Decision, Candidats.Sexe, Candidats.NomJeuneFille, Candidats.DateNaissance, Candidats.CPNaissance, Candidats.VilleNaissance, 
                         Livret1_NonClos.DateValidite, dbo.Juries.IsRecours, Juries.DateLimiteRecours, Recours.Decision AS DecisionRecours, Recours.MotifGeneral, Recours.MotifDetail, Recours.MotifCommentaire
FROM            Recours RIGHT OUTER JOIN
                         Juries ON Recours.Jury_ID = Juries.ID RIGHT OUTER JOIN
                         Candidats INNER JOIN
                         Livret1_NonClos ON Candidats.ID = Livret1_NonClos.Candidat_ID ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE        (Juries.Decision LIKE N'20-%') AND (Juries.IsRecours = 1) AND (Recours.Decision LIKE N'20-%')


GO
/****** Object:  View [dbo].[Livret2_NonClos]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Livret2_NonClos]
AS
SELECT        dbo.Livret2.*
FROM            dbo.Livret2
WHERE        (isClos = 0)

GO
/****** Object:  View [dbo].[L2_DC]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_DC]
AS
SELECT        ID, EtatLivret, 
(SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 1) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC1,
(SELECT        DCLivrets.DateObtention 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 1) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC1_DATE,
 (SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 2) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) as DC2,
 (SELECT        DCLivrets.DateObtention 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 2) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) as DC2_DATE,
 (SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 3) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) as DC3, 
 (SELECT        DCLivrets.DateObtention 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 3) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) as DC3_DATE, 
 (SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 4) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) as DC4,
 (SELECT        DCLivrets.DateObtention
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 4) AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) as DC4_DATE


FROM            dbo.Livret2_NonClos




GO
/****** Object:  View [dbo].[L2_DC_DECISION]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_DC_DECISION]
AS
SELECT        ID, EtatLivret,
                             (SELECT        dbo.DCLivrets.Decision
                               FROM            dbo.DCLivrets INNER JOIN
                                                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                               WHERE        (dbo.DomaineCompetences.Numero = 1) AND (dbo.DCLivrets.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC1,
                             (SELECT        dbo.DCLivrets.DateObtention
                               FROM            dbo.DCLivrets INNER JOIN
                                                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                               WHERE        (dbo.DomaineCompetences.Numero = 1) AND (dbo.DCLivrets.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC1_DATE,
                             (SELECT        DCLivrets_3.Decision
                               FROM            dbo.DCLivrets AS DCLivrets_3 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_3 ON DCLivrets_3.oDomaineCompetence_ID = DomaineCompetences_3.ID
                               WHERE        (DomaineCompetences_3.Numero = 2) AND (DCLivrets_3.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC2,
                             (SELECT        DCLivrets_3.DateObtention
                               FROM            dbo.DCLivrets AS DCLivrets_3 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_3 ON DCLivrets_3.oDomaineCompetence_ID = DomaineCompetences_3.ID
                               WHERE        (DomaineCompetences_3.Numero = 2) AND (DCLivrets_3.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC2_DATE,
                             (SELECT        DCLivrets_2.Decision
                               FROM            dbo.DCLivrets AS DCLivrets_2 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_2 ON DCLivrets_2.oDomaineCompetence_ID = DomaineCompetences_2.ID
                               WHERE        (DomaineCompetences_2.Numero = 3) AND (DCLivrets_2.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC3,
                             (SELECT        DCLivrets_2.DateObtention
                               FROM            dbo.DCLivrets AS DCLivrets_2 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_2 ON DCLivrets_2.oDomaineCompetence_ID = DomaineCompetences_2.ID
                               WHERE        (DomaineCompetences_2.Numero = 3) AND (DCLivrets_2.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC3_DATE,
                             (SELECT        DCLivrets_1.Decision
                               FROM            dbo.DCLivrets AS DCLivrets_1 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_1 ON DCLivrets_1.oDomaineCompetence_ID = DomaineCompetences_1.ID
                               WHERE        (DomaineCompetences_1.Numero = 4) AND (DCLivrets_1.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC4,
							 (SELECT        DCLivrets_1.DAteObtention
                               FROM            dbo.DCLivrets AS DCLivrets_1 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_1 ON DCLivrets_1.oDomaineCompetence_ID = DomaineCompetences_1.ID
                               WHERE        (DomaineCompetences_1.Numero = 4) AND (DCLivrets_1.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC4_DATE
FROM            dbo.Livret2_NonClos



GO
/****** Object:  View [dbo].[L2_RECUS_COMPLETS]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.ID AS IDLIVRET2, dbo.Livret2_NonClos.DateEnvoiCandidat, dbo.Livret2_NonClos.DateLimiteReceptEHESP, dbo.Livret2_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2_NonClos.EtatLivret, dbo.Livret2_NonClos.SessionJury, 
                         dbo.Livret2_NonClos.DatePrevJury2, dbo.Livret2_NonClos.DatePrevJury1, dbo.Livret2_NonClos.isAttestationOK, dbo.Livret2_NonClos.isCNIOK, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'40%')


GO
/****** Object:  View [dbo].[L2_RECUS_COMPLETS_DC]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_DC]
AS
SELECT        dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom3, dbo.Candidats.Prenom2, dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.EtatLivret, dbo.L2_DC.DC1, dbo.L2_DC.DC2, dbo.L2_DC.DC3, dbo.L2_DC.DC4
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID INNER JOIN
                         dbo.L2_DC ON dbo.Livret2_NonClos.ID = dbo.L2_DC.ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'40-%')


GO
/****** Object:  View [dbo].[L2_RECUS_COMPLETS_JURY]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_JURY]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.ID AS IDLIVRET2, dbo.Livret2_NonClos.DateEnvoiCandidat, dbo.Livret2_NonClos.DateLimiteReceptEHESP, dbo.Livret2_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2_NonClos.EtatLivret, dbo.Livret2_NonClos.SessionJury, 
                         dbo.Livret2_NonClos.DatePrevJury2, dbo.Livret2_NonClos.DatePrevJury1, dbo.Livret2_NonClos.isAttestationOK, dbo.Livret2_NonClos.isCNIOK
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'40%') AND (dbo.Livret2_NonClos.isAttestationOK = 1) AND (dbo.Livret2_NonClos.isCNIOK = 1)



GO
/****** Object:  View [dbo].[L2_RECUS_INCOMPLETS]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_RECUS_INCOMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.ID AS IDLIVRET2, dbo.Livret2_NonClos.DateEnvoiCandidat, dbo.Livret2_NonClos.DateLimiteReceptEHESP, dbo.Livret2_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2_NonClos.EtatLivret, dbo.Livret2_NonClos.isAttestationOK, 
                         dbo.Livret2_NonClos.isCNIOK
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'30%') AND (dbo.Livret2_NonClos.isAttestationOK = 1) AND (dbo.Livret2_NonClos.isCNIOK = 1)


GO
/****** Object:  View [dbo].[L2_RECUS_INCOMPLETS_PJ]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_RECUS_INCOMPLETS_PJ]
AS
SELECT        dbo.PieceJointeL2.Livret2_ID, dbo.PieceJointeL2.Categorie, dbo.PieceJointeL2.Libelle
FROM            dbo.L2_RECUS_INCOMPLETS INNER JOIN
                         dbo.PieceJointeL2 ON dbo.L2_RECUS_INCOMPLETS.IDLIVRET2 = dbo.PieceJointeL2.Livret2_ID
WHERE        (dbo.PieceJointeL2.IsOK = 0)


GO
/****** Object:  View [dbo].[L2_VALIDATION_PARTIELLE]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_VALIDATION_PARTIELLE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.ID AS IDLIVRET2, dbo.Livret2_NonClos.DateEnvoiCandidat, dbo.Livret2_NonClos.DateLimiteReceptEHESP, dbo.Livret2_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2_NonClos.EtatLivret, dbo.Livret2_NonClos.SessionJury, 
                         dbo.Livret2_NonClos.DatePrevJury2, dbo.Livret2_NonClos.DatePrevJury1, dbo.Livret2_NonClos.isAttestationOK, dbo.Livret2_NonClos.isCNIOK, dbo.Livret2_NonClos.IsDispenseArt2, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, 
                         dbo.Juries.HeureConvoc, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance,
						 dbo.L2_DC_DECISION.DC1, dbo.L2_DC_DECISION.DC1_DATE,
						 dbo.L2_DC_DECISION.DC2, dbo.L2_DC_DECISION.DC2_DATE, 
                         dbo.L2_DC_DECISION.DC3, dbo.L2_DC_DECISION.DC3_DATE, 
						 dbo.L2_DC_DECISION.DC4,dbo.L2_DC_DECISION.DC4_DATE, 
						  dbo.Livret2_NonClos.DateValidite
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID INNER JOIN
                         dbo.L2_DC_DECISION ON dbo.Livret2_NonClos.ID = dbo.L2_DC_DECISION.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'70%') AND (dbo.Juries.Decision LIKE N'30-%')



GO
/****** Object:  View [dbo].[L2_VALIDATION_REFUSE]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_VALIDATION_REFUSE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.ID AS IDLIVRET2, dbo.Livret2_NonClos.DateEnvoiCandidat, dbo.Livret2_NonClos.DateLimiteReceptEHESP, dbo.Livret2_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2_NonClos.EtatLivret, dbo.Livret2_NonClos.SessionJury, 
                         dbo.Livret2_NonClos.DatePrevJury2, dbo.Livret2_NonClos.DatePrevJury1, dbo.Livret2_NonClos.isAttestationOK, dbo.Livret2_NonClos.isCNIOK, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, 
                         dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance, dbo.Livret2_NonClos.DateValidite
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'50-%') AND (dbo.Juries.Decision LIKE N'20-%')


GO
/****** Object:  View [dbo].[L2_VALIDATION_TOTALE]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[L2_VALIDATION_TOTALE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.ID AS IDLIVRET2, dbo.Livret2_NonClos.DateEnvoiCandidat, dbo.Livret2_NonClos.DateLimiteReceptEHESP, dbo.Livret2_NonClos.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2_NonClos.EtatLivret, dbo.Livret2_NonClos.SessionJury, 
                         dbo.Livret2_NonClos.DatePrevJury2, dbo.Livret2_NonClos.DatePrevJury1, dbo.Livret2_NonClos.isAttestationOK, dbo.Livret2_NonClos.isCNIOK, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, 
                         dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'40%')


GO
/****** Object:  View [dbo].[RQ_L1_STAT]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RQ_L1_STAT]
AS
SELECT        Livret1.DateDemande, Livret1.TypeDemande, YEAR(Livret1.DateDemande) AS ANNEE, DATENAME(month, Livret1.DateDemande) AS MOIS, DATENAME(day, Livret1.DateDemande) AS JOUR, FLOOR(DATENAME(day, 
                         Livret1.DateDemande) / 16) + 1 AS QUINZAINE, DATENAME(quarter, Livret1.DateDemande) AS TRIMESTRE, Livret1.VecteurInformation, Livret1.Numero, Livret1.EtatLivret, Juries.IsRecours, Juries.Decision, 
                         Recours.Decision AS DecisionRecours, Juries.MotifGeneral AS MotifGJury, Juries.MotifDetail AS MotifDJury, Juries.MotifCommentaire AS MotifCJury, Recours.MotifGeneral AS MotifGRecours, 
                         Recours.MotifDetail AS MotifDrecours, Recours.MotifCommentaire AS MotifCRecours, Candidats.Nom, Candidats.Sexe, Candidats.Ville, Candidats.Region
FROM            Juries LEFT OUTER JOIN
                         Recours ON Juries.ID = Recours.Jury_ID RIGHT OUTER JOIN
                         Livret1 INNER JOIN
                         Candidats ON Livret1.Candidat_ID = Candidats.ID ON Juries.Livret1_ID = Livret1.ID

GO
/****** Object:  View [dbo].[RQ_L2_DECISION_DC]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT        dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.DomaineCompetences.Nom, dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider
FROM            dbo.Livret2 INNER JOIN
                         dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
WHERE        (dbo.DCLivrets.IsAValider = 1)


GO
/****** Object:  View [dbo].[RQ_L2_STAT]    Script Date: 06/03/2019 19:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RQ_L2_STAT]
AS
SELECT        dbo.Livret2.Numero, dbo.Livret2.DateDemande, dbo.Candidats.Nom, dbo.Juries.Decision, dbo.Recours.Decision AS [Decision Recours], dbo.Livret2.EtatLivret, dbo.Livret2.NumPassage, dbo.Livret2.DateEnvoiEHESP, 
                         dbo.Juries.DateJury, dbo.Livret2.DateReceptEHESP, dbo.Livret2.DateReceptEHESPComplet, DATENAME(month, dbo.Juries.DateJury) AS MoisJury, dbo.Candidats.Sexe, dbo.Candidats.Ville, dbo.Candidats.Region, 
                         dbo.Livret2.IsOuvertureApresRecours, dbo.DiplomeCands.Statut AS StatutCAFDES
FROM            dbo.Livret2 INNER JOIN
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                         dbo.Diplomes ON dbo.Livret2.Diplome_ID = dbo.Diplomes.ID LEFT OUTER JOIN
                         dbo.DiplomeCands ON dbo.Diplomes.ID = dbo.DiplomeCands.Diplome_ID AND dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID LEFT OUTER JOIN
                         dbo.Recours ON dbo.Livret2.ID = dbo.Recours.ID


GO
/****** Object:  Index [IX_oDomaineCompetence_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_oDomaineCompetence_ID] ON [dbo].[DCLivrets]
(
	[oDomaineCompetence_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_oLivret2_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_oLivret2_ID] ON [dbo].[DCLivrets]
(
	[oLivret2_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Candidat_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Candidat_ID] ON [dbo].[DiplomeCands]
(
	[Candidat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Diplome_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Diplome_ID] ON [dbo].[DiplomeCands]
(
	[Diplome_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Diplome_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Diplome_ID] ON [dbo].[DomaineCompetenceCands]
(
	[Diplome_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DomaineCompetence_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_DomaineCompetence_ID] ON [dbo].[DomaineCompetenceCands]
(
	[DomaineCompetence_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Diplome_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Diplome_ID] ON [dbo].[DomaineCompetences]
(
	[Diplome_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Numero]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Numero] ON [dbo].[DomaineCompetences]
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret1_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret1_ID] ON [dbo].[EchangeL1]
(
	[Livret1_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret2_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret2_ID] ON [dbo].[EchangeL2]
(
	[Livret2_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret1_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret1_ID] ON [dbo].[Juries]
(
	[Livret1_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret2_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret2_ID] ON [dbo].[Juries]
(
	[Livret2_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Candidat_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Candidat_ID] ON [dbo].[Livret1]
(
	[Candidat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Diplome_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Diplome_ID] ON [dbo].[Livret1]
(
	[Diplome_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Candidat_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Candidat_ID] ON [dbo].[Livret2]
(
	[Candidat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Diplome_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Diplome_ID] ON [dbo].[Livret2]
(
	[Diplome_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret2_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret2_ID] ON [dbo].[MembreJuries]
(
	[Livret2_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MotifGL1_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_MotifGL1_ID] ON [dbo].[MotifDetailleL1]
(
	[MotifGL1_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MotifGL2_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_MotifGL2_ID] ON [dbo].[MotifDetailleL2]
(
	[MotifGL2_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categorie_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Categorie_ID] ON [dbo].[PieceJointeItems]
(
	[Categorie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret1_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret1_ID] ON [dbo].[PieceJointeL1]
(
	[Livret1_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livret2_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Livret2_ID] ON [dbo].[PieceJointeL2]
(
	[Livret2_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Jury_ID]    Script Date: 06/03/2019 19:03:37 ******/
CREATE NONCLUSTERED INDEX [IX_Jury_ID] ON [dbo].[Recours]
(
	[Jury_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DCLivrets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DCLivrets_dbo.DomaineCompetences_oDomaineCompetence_ID] FOREIGN KEY([oDomaineCompetence_ID])
REFERENCES [dbo].[DomaineCompetences] ([ID])
GO
ALTER TABLE [dbo].[DCLivrets] CHECK CONSTRAINT [FK_dbo.DCLivrets_dbo.DomaineCompetences_oDomaineCompetence_ID]
GO
ALTER TABLE [dbo].[DCLivrets]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DCLivrets_dbo.Livret2_oLivret2_ID] FOREIGN KEY([oLivret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DCLivrets] CHECK CONSTRAINT [FK_dbo.DCLivrets_dbo.Livret2_oLivret2_ID]
GO
ALTER TABLE [dbo].[DiplomeCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DiplomeCands_dbo.Candidats_oCandidat_ID] FOREIGN KEY([Candidat_ID])
REFERENCES [dbo].[Candidats] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiplomeCands] CHECK CONSTRAINT [FK_dbo.DiplomeCands_dbo.Candidats_oCandidat_ID]
GO
ALTER TABLE [dbo].[DiplomeCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DiplomeCands_dbo.Diplomes_oDiplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiplomeCands] CHECK CONSTRAINT [FK_dbo.DiplomeCands_dbo.Diplomes_oDiplome_ID]
GO
ALTER TABLE [dbo].[DomaineCompetenceCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DiplomeCands_oDiplomeCand_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[DiplomeCands] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DomaineCompetenceCands] CHECK CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DiplomeCands_oDiplomeCand_ID]
GO
ALTER TABLE [dbo].[DomaineCompetenceCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DomaineCompetences_oDomaineCompetence_ID] FOREIGN KEY([DomaineCompetence_ID])
REFERENCES [dbo].[DomaineCompetences] ([ID])
GO
ALTER TABLE [dbo].[DomaineCompetenceCands] CHECK CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DomaineCompetences_oDomaineCompetence_ID]
GO
ALTER TABLE [dbo].[DomaineCompetences]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DomaineCompetences_dbo.Diplomes_oDiplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DomaineCompetences] CHECK CONSTRAINT [FK_dbo.DomaineCompetences_dbo.Diplomes_oDiplome_ID]
GO
ALTER TABLE [dbo].[EchangeL1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EchangeL1_dbo.Livret1_oLivret_ID] FOREIGN KEY([Livret1_ID])
REFERENCES [dbo].[Livret1] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EchangeL1] CHECK CONSTRAINT [FK_dbo.EchangeL1_dbo.Livret1_oLivret_ID]
GO
ALTER TABLE [dbo].[EchangeL2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EchangeL2_dbo.Livret2_oLivret_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EchangeL2] CHECK CONSTRAINT [FK_dbo.EchangeL2_dbo.Livret2_oLivret_ID]
GO
ALTER TABLE [dbo].[Juries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Juries_dbo.Livret1_oLivret1_ID] FOREIGN KEY([Livret1_ID])
REFERENCES [dbo].[Livret1] ([ID])
GO
ALTER TABLE [dbo].[Juries] CHECK CONSTRAINT [FK_dbo.Juries_dbo.Livret1_oLivret1_ID]
GO
ALTER TABLE [dbo].[Juries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Juries_dbo.Livret2_oLivret2_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
GO
ALTER TABLE [dbo].[Juries] CHECK CONSTRAINT [FK_dbo.Juries_dbo.Livret2_oLivret2_ID]
GO
ALTER TABLE [dbo].[Livret1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret1_dbo.Candidats_oCandidat_ID] FOREIGN KEY([Candidat_ID])
REFERENCES [dbo].[Candidats] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret1] CHECK CONSTRAINT [FK_dbo.Livret1_dbo.Candidats_oCandidat_ID]
GO
ALTER TABLE [dbo].[Livret1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret1_dbo.Diplomes_Diplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret1] CHECK CONSTRAINT [FK_dbo.Livret1_dbo.Diplomes_Diplome_ID]
GO
ALTER TABLE [dbo].[Livret2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret2_dbo.Candidats_oCandidat_ID] FOREIGN KEY([Candidat_ID])
REFERENCES [dbo].[Candidats] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret2] CHECK CONSTRAINT [FK_dbo.Livret2_dbo.Candidats_oCandidat_ID]
GO
ALTER TABLE [dbo].[Livret2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret2_dbo.Diplomes_Diplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret2] CHECK CONSTRAINT [FK_dbo.Livret2_dbo.Diplomes_Diplome_ID]
GO
ALTER TABLE [dbo].[MembreJuries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MembreJuries_dbo.Livret2_Livret2_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MembreJuries] CHECK CONSTRAINT [FK_dbo.MembreJuries_dbo.Livret2_Livret2_ID]
GO
ALTER TABLE [dbo].[MotifDetailleL1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotifDetailleL1_dbo.MotifGeneralL1_MotifGL1_ID] FOREIGN KEY([MotifGL1_ID])
REFERENCES [dbo].[MotifGeneralL1] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotifDetailleL1] CHECK CONSTRAINT [FK_dbo.MotifDetailleL1_dbo.MotifGeneralL1_MotifGL1_ID]
GO
ALTER TABLE [dbo].[MotifDetailleL2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotifDetailleL2_dbo.MotifGeneralL2_MotifGL2_ID] FOREIGN KEY([MotifGL2_ID])
REFERENCES [dbo].[MotifGeneralL2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotifDetailleL2] CHECK CONSTRAINT [FK_dbo.MotifDetailleL2_dbo.MotifGeneralL2_MotifGL2_ID]
GO
ALTER TABLE [dbo].[PieceJointeItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PieceJointeItems_dbo.PieceJointeCategories_CategoriePJ_ID] FOREIGN KEY([Categorie_ID])
REFERENCES [dbo].[PieceJointeCategories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PieceJointeItems] CHECK CONSTRAINT [FK_dbo.PieceJointeItems_dbo.PieceJointeCategories_CategoriePJ_ID]
GO
ALTER TABLE [dbo].[PieceJointeL1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PieceJointeL1_dbo.Livret1_oLivret_ID] FOREIGN KEY([Livret1_ID])
REFERENCES [dbo].[Livret1] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PieceJointeL1] CHECK CONSTRAINT [FK_dbo.PieceJointeL1_dbo.Livret1_oLivret_ID]
GO
ALTER TABLE [dbo].[PieceJointeL2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PieceJointeL2_dbo.Livret2_oLivret_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PieceJointeL2] CHECK CONSTRAINT [FK_dbo.PieceJointeL2_dbo.Livret2_oLivret_ID]
GO
ALTER TABLE [dbo].[Recours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recours_dbo.Juries_Jury_ID] FOREIGN KEY([Jury_ID])
REFERENCES [dbo].[Juries] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recours] CHECK CONSTRAINT [FK_dbo.Recours_dbo.Juries_Jury_ID]
GO
USE [master]
GO
ALTER DATABASE [GESTVAE] SET  READ_WRITE 
GO
