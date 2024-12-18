USE [GESTVAE]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/04/2019 10:22:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Candidats]    Script Date: 11/04/2019 10:22:41 ******/
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
	[Nationalite] [nvarchar](max) NULL,
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
/****** Object:  Table [dbo].[DCLivrets]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[DiplomeCands]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiplomeCands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Candidat_ID] [int] NOT NULL,
	[Diplome_ID] [int] NOT NULL,
	[Statut] [nvarchar](max) NULL,
	[DateObtention] [datetime] NULL,
	[NumeroDiplome] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DiplomeCands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diplomes]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[DomaineCompetenceCands]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomaineCompetenceCands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Diplome_ID] [int] NOT NULL,
	[DomaineCompetence_ID] [int] NULL,
	[Statut] [nvarchar](max) NULL,
	[DateObtention] [datetime] NULL,
	[ModeObtention] [nvarchar](max) NULL,
	[Commentaire] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DomaineCompetenceCands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomaineCompetences]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomaineCompetences](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[Diplome_ID] [int] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DomaineCompetences] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EchangeL1]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EchangeL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Livret1_ID] [int] NOT NULL,
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
 CONSTRAINT [PK_dbo.EchangeL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EchangeL2]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EchangeL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Livret2_ID] [int] NOT NULL,
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
 CONSTRAINT [PK_dbo.EchangeL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juries]    Script Date: 11/04/2019 10:22:41 ******/
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
	[Livret1_ID] [int] NULL,
	[Livret2_ID] [int] NULL,
	[DateNotificationJury] [datetime] NULL,
	[DateNotificationJuryRecours] [datetime] NULL,
	[IsRecours] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Juries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livret1]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livret1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](max) NULL,
	[TypeDemande] [nvarchar](max) NULL,
	[VecteurInformation] [nvarchar](max) NULL,
	[DateDemande] [datetime] NULL,
	[DateLimiteEnvoiEHESP] [datetime] NULL,
	[DateLimiteReceptEHESP] [datetime] NULL,
	[DateLimiteJury] [datetime] NULL,
	[DateValidite] [datetime] NULL,
	[Date1ereDemandePieceManquantes] [datetime] NULL,
	[Date2emeDemandePieceManquantes] [datetime] NULL,
	[DateDemandePieceManquantesRetour] [datetime] NULL,
	[DateReceptionPiecesManquantes] [datetime] NULL,
	[Candidat_ID] [int] NOT NULL,
	[DateEcheance] [datetime] NULL,
	[isContrat] [bit] NOT NULL,
	[EtatLivret] [nvarchar](max) NULL,
	[DateEnvoiEHESP] [datetime] NULL,
	[DateEnvoiCandidat] [datetime] NULL,
	[DateReceptEHESP] [datetime] NULL,
	[DateReceptEHESPComplet] [datetime] NULL,
	[Diplome_ID] [int] NOT NULL,
	[isClos] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Livret1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livret2]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livret2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](max) NULL,
	[NumPassage] [int] NOT NULL,
	[IsOuvertureApresRecours] [bit] NOT NULL,
	[DateDemande] [datetime] NULL,
	[DateLimiteEnvoiEHESP] [datetime] NULL,
	[DateLimiteReceptEHESP] [datetime] NULL,
	[Date1ereDemandePieceManquantes] [datetime] NULL,
	[Date2emeDemandePieceManquantes] [datetime] NULL,
	[DateDemandePieceManquantesRetour] [datetime] NULL,
	[DateReceptionPiecesManquantes] [datetime] NULL,
	[DatePrevJury1] [datetime] NULL,
	[DatePrevJury2] [datetime] NULL,
	[SessionJury] [nvarchar](max) NULL,
	[DateLimiteJury] [datetime] NULL,
	[DateValidite] [datetime] NULL,
	[IsAttestationOK] [bit] NOT NULL,
	[IsCNIOK] [bit] NOT NULL,
	[IsDispenseArt2] [bit] NOT NULL,
	[NumDiplome] [nvarchar](max) NULL,
	[Candidat_ID] [int] NOT NULL,
	[DateEcheance] [datetime] NULL,
	[isContrat] [bit] NOT NULL,
	[EtatLivret] [nvarchar](max) NULL,
	[DateEnvoiEHESP] [datetime] NULL,
	[DateEnvoiCandidat] [datetime] NULL,
	[DateReceptEHESP] [datetime] NULL,
	[DateReceptEHESPComplet] [datetime] NULL,
	[Diplome_ID] [int] NOT NULL,
	[isClos] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Livret2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LockCandidats]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LockCandidats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDLockCandidat] [int] NOT NULL,
	[IDUser] [int] NOT NULL,
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
/****** Object:  Table [dbo].[MembreJuries]    Script Date: 11/04/2019 10:22:41 ******/
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
	[Livret2_ID] [int] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MembreJuries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MotifDetailleL1]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotifDetailleL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MotifGL1_ID] [int] NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MotifDetailleL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MotifDetailleL2]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotifDetailleL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MotifGL2_ID] [int] NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MotifDetailleL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MotifGeneralL1]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[MotifGeneralL2]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[ParamColleges]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[ParamOrigines]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[Params]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Params](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumLivret] [int] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Params] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParamTypeDemandes]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[ParamVecteurInformations]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[PieceJointeCategories]    Script Date: 11/04/2019 10:22:41 ******/
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
/****** Object:  Table [dbo].[PieceJointeItems]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Categorie_ID] [int] NOT NULL,
	[Libelle] [nvarchar](max) NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PieceJointeItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PieceJointeL1]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeL1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Livret1_ID] [int] NOT NULL,
	[Categorie] [nvarchar](max) NULL,
	[Libelle] [nvarchar](max) NULL,
	[IsRecu] [bit] NOT NULL,
	[IsOK] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PieceJointeL1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PieceJointeL2]    Script Date: 11/04/2019 10:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PieceJointeL2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Livret2_ID] [int] NOT NULL,
	[Categorie] [nvarchar](max) NULL,
	[Libelle] [nvarchar](max) NULL,
	[IsRecu] [bit] NOT NULL,
	[IsOK] [bit] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PieceJointeL2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recours]    Script Date: 11/04/2019 10:22:41 ******/
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
	[DateLimiteJury] [datetime] NULL,
	[DateJury] [datetime] NULL,
	[LieuJury] [nvarchar](max) NULL,
	[Decision] [nvarchar](max) NULL,
	[MotifGeneral] [nvarchar](max) NULL,
	[MotifDetail] [nvarchar](max) NULL,
	[MotifCommentaire] [nvarchar](max) NULL,
	[Jury_ID] [int] NOT NULL,
	[dateCreation] [datetime] NOT NULL,
	[dateModif] [datetime] NOT NULL,
	[bDeleted] [bit] NOT NULL,
	[AttSup] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Recours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 11/04/2019 10:22:41 ******/
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
ALTER TABLE [dbo].[DiplomeCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DiplomeCands_dbo.Candidats_Candidat_ID] FOREIGN KEY([Candidat_ID])
REFERENCES [dbo].[Candidats] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiplomeCands] CHECK CONSTRAINT [FK_dbo.DiplomeCands_dbo.Candidats_Candidat_ID]
GO
ALTER TABLE [dbo].[DiplomeCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DiplomeCands_dbo.Diplomes_Diplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiplomeCands] CHECK CONSTRAINT [FK_dbo.DiplomeCands_dbo.Diplomes_Diplome_ID]
GO
ALTER TABLE [dbo].[DomaineCompetenceCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DiplomeCands_Diplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[DiplomeCands] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DomaineCompetenceCands] CHECK CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DiplomeCands_Diplome_ID]
GO
ALTER TABLE [dbo].[DomaineCompetenceCands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DomaineCompetences_DomaineCompetence_ID] FOREIGN KEY([DomaineCompetence_ID])
REFERENCES [dbo].[DomaineCompetences] ([ID])
GO
ALTER TABLE [dbo].[DomaineCompetenceCands] CHECK CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DomaineCompetences_DomaineCompetence_ID]
GO
ALTER TABLE [dbo].[DomaineCompetences]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DomaineCompetences_dbo.Diplomes_Diplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DomaineCompetences] CHECK CONSTRAINT [FK_dbo.DomaineCompetences_dbo.Diplomes_Diplome_ID]
GO
ALTER TABLE [dbo].[EchangeL1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EchangeL1_dbo.Livret1_Livret1_ID] FOREIGN KEY([Livret1_ID])
REFERENCES [dbo].[Livret1] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EchangeL1] CHECK CONSTRAINT [FK_dbo.EchangeL1_dbo.Livret1_Livret1_ID]
GO
ALTER TABLE [dbo].[EchangeL2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EchangeL2_dbo.Livret2_Livret2_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EchangeL2] CHECK CONSTRAINT [FK_dbo.EchangeL2_dbo.Livret2_Livret2_ID]
GO
ALTER TABLE [dbo].[Juries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Juries_dbo.Livret1_Livret1_ID] FOREIGN KEY([Livret1_ID])
REFERENCES [dbo].[Livret1] ([ID])
GO
ALTER TABLE [dbo].[Juries] CHECK CONSTRAINT [FK_dbo.Juries_dbo.Livret1_Livret1_ID]
GO
ALTER TABLE [dbo].[Juries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Juries_dbo.Livret2_Livret2_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
GO
ALTER TABLE [dbo].[Juries] CHECK CONSTRAINT [FK_dbo.Juries_dbo.Livret2_Livret2_ID]
GO
ALTER TABLE [dbo].[Livret1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret1_dbo.Candidats_Candidat_ID] FOREIGN KEY([Candidat_ID])
REFERENCES [dbo].[Candidats] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret1] CHECK CONSTRAINT [FK_dbo.Livret1_dbo.Candidats_Candidat_ID]
GO
ALTER TABLE [dbo].[Livret1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret1_dbo.Diplomes_Diplome_ID] FOREIGN KEY([Diplome_ID])
REFERENCES [dbo].[Diplomes] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret1] CHECK CONSTRAINT [FK_dbo.Livret1_dbo.Diplomes_Diplome_ID]
GO
ALTER TABLE [dbo].[Livret2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Livret2_dbo.Candidats_Candidat_ID] FOREIGN KEY([Candidat_ID])
REFERENCES [dbo].[Candidats] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Livret2] CHECK CONSTRAINT [FK_dbo.Livret2_dbo.Candidats_Candidat_ID]
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
ALTER TABLE [dbo].[PieceJointeItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PieceJointeItems_dbo.PieceJointeCategories_Categorie_ID] FOREIGN KEY([Categorie_ID])
REFERENCES [dbo].[PieceJointeCategories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PieceJointeItems] CHECK CONSTRAINT [FK_dbo.PieceJointeItems_dbo.PieceJointeCategories_Categorie_ID]
GO
ALTER TABLE [dbo].[PieceJointeL1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PieceJointeL1_dbo.Livret1_Livret1_ID] FOREIGN KEY([Livret1_ID])
REFERENCES [dbo].[Livret1] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PieceJointeL1] CHECK CONSTRAINT [FK_dbo.PieceJointeL1_dbo.Livret1_Livret1_ID]
GO
ALTER TABLE [dbo].[PieceJointeL2]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PieceJointeL2_dbo.Livret2_Livret2_ID] FOREIGN KEY([Livret2_ID])
REFERENCES [dbo].[Livret2] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PieceJointeL2] CHECK CONSTRAINT [FK_dbo.PieceJointeL2_dbo.Livret2_Livret2_ID]
GO
ALTER TABLE [dbo].[Recours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recours_dbo.Juries_Jury_ID] FOREIGN KEY([Jury_ID])
REFERENCES [dbo].[Juries] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recours] CHECK CONSTRAINT [FK_dbo.Recours_dbo.Juries_Jury_ID]
GO
