CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL
);

GO
CREATE TABLE [dbo].[Candidats] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Civilite]             NVARCHAR (MAX) NULL,
    [Nom]                  NVARCHAR (MAX) NULL,
    [Prenom]               NVARCHAR (MAX) NULL,
    [Prenom2]              NVARCHAR (MAX) NULL,
    [Prenom3]              NVARCHAR (MAX) NULL,
    [Sexe]                 INT            NULL,
    [IdVAE]                NVARCHAR (MAX) NULL,
    [IdSiscole]            NVARCHAR (MAX) NULL,
    [NomJeuneFille]        NVARCHAR (MAX) NULL,
    [Nationnalite]         NVARCHAR (MAX) NULL,
    [DateNaissance]        DATETIME       NULL,
    [CPNaissance]          NVARCHAR (MAX) NULL,
    [VilleNaissance]       NVARCHAR (MAX) NULL,
    [NationaliteNaissance] NVARCHAR (MAX) NULL,
    [Adresse]              NVARCHAR (MAX) NULL,
    [CodePostal]           NVARCHAR (MAX) NULL,
    [Ville]                NVARCHAR (MAX) NULL,
    [Region]               NVARCHAR (MAX) NULL,
    [Pays]                 NVARCHAR (MAX) NULL,
    [RegionTravail]        NVARCHAR (MAX) NULL,
    [CPTravail]            NVARCHAR (MAX) NULL,
    [VilleTravail]         NVARCHAR (MAX) NULL,
    [Mail1]                NVARCHAR (MAX) NULL,
    [Mail2]                NVARCHAR (MAX) NULL,
    [Mail3]                NVARCHAR (MAX) NULL,
    [Tel1]                 NVARCHAR (MAX) NULL,
    [Tel2]                 NVARCHAR (MAX) NULL,
    [Tel3]                 NVARCHAR (MAX) NULL,
    [bHandicap]            BIT            NOT NULL,
    [dateCreation]         DATETIME       NOT NULL,
    [dateModif]            DATETIME       NOT NULL,
    [bDeleted]             BIT            NOT NULL,
    [AttSup]               NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[DCLivrets] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [Decision]              NVARCHAR (MAX) NULL,
    [MotifGeneral]          NVARCHAR (MAX) NULL,
    [MotifDetail]           NVARCHAR (MAX) NULL,
    [MotifCommentaire]      NVARCHAR (MAX) NULL,
    [IsAValider]            BIT            NOT NULL,
    [Statut]                NVARCHAR (MAX) NULL,
    [DateObtention]         DATETIME       NULL,
    [ModeObtention]         NVARCHAR (MAX) NULL,
    [Commentaire]           NVARCHAR (MAX) NULL,
    [dateCreation]          DATETIME       NOT NULL,
    [dateModif]             DATETIME       NOT NULL,
    [bDeleted]              BIT            NOT NULL,
    [AttSup]                NVARCHAR (MAX) NULL,
    [oDomaineCompetence_ID] INT            NULL,
    [oLivret2_ID]           INT            NOT NULL
);

GO
CREATE TABLE [dbo].[DiplomeCands] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Statut]        NVARCHAR (MAX) NULL,
    [DateObtention] DATETIME       NULL,
    [NumeroDiplome] NVARCHAR (MAX) NULL,
    [dateCreation]  DATETIME       NOT NULL,
    [dateModif]     DATETIME       NOT NULL,
    [bDeleted]      BIT            NOT NULL,
    [AttSup]        NVARCHAR (MAX) NULL,
    [Candidat_ID]   INT            NOT NULL,
    [Diplome_ID]    INT            NOT NULL
);

GO
CREATE TABLE [dbo].[Diplomes] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[DomaineCompetenceCands] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Statut]               NVARCHAR (MAX) NULL,
    [DateObtention]        DATETIME       NULL,
    [ModeObtention]        NVARCHAR (MAX) NULL,
    [Commentaire]          NVARCHAR (MAX) NULL,
    [dateCreation]         DATETIME       NOT NULL,
    [dateModif]            DATETIME       NOT NULL,
    [bDeleted]             BIT            NOT NULL,
    [AttSup]               NVARCHAR (MAX) NULL,
    [Diplome_ID]           INT            NOT NULL,
    [DomaineCompetence_ID] INT            NULL
);

GO
CREATE TABLE [dbo].[DomaineCompetences] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Numero]       INT            NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [Diplome_ID]   INT            NOT NULL
);

GO
CREATE TABLE [dbo].[EchangeL1] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [DateEch]          DATETIME       NULL,
    [MotifEch]         NVARCHAR (MAX) NULL,
    [DateEcheanceEch]  DATETIME       NULL,
    [DateReceptionEch] DATETIME       NULL,
    [IsOK]             BIT            NOT NULL,
    [CommentaireEch]   NVARCHAR (MAX) NULL,
    [dateCreation]     DATETIME       NOT NULL,
    [dateModif]        DATETIME       NOT NULL,
    [bDeleted]         BIT            NOT NULL,
    [AttSup]           NVARCHAR (MAX) NULL,
    [Livret1_ID]       INT            NOT NULL
);

GO
CREATE TABLE [dbo].[EchangeL2] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [DateEch]          DATETIME       NULL,
    [MotifEch]         NVARCHAR (MAX) NULL,
    [DateEcheanceEch]  DATETIME       NULL,
    [DateReceptionEch] DATETIME       NULL,
    [IsOK]             BIT            NOT NULL,
    [CommentaireEch]   NVARCHAR (MAX) NULL,
    [dateCreation]     DATETIME       NOT NULL,
    [dateModif]        DATETIME       NOT NULL,
    [bDeleted]         BIT            NOT NULL,
    [AttSup]           NVARCHAR (MAX) NULL,
    [Livret2_ID]       INT            NOT NULL
);

GO
CREATE TABLE [dbo].[Juries] (
    [ID]                          INT            IDENTITY (1, 1) NOT NULL,
    [NumeroOrdre]                 INT            NOT NULL,
    [NomJury]                     NVARCHAR (MAX) NULL,
    [DateJury]                    DATETIME       NULL,
    [HeureJury]                   DATETIME       NULL,
    [HeureConvoc]                 DATETIME       NULL,
    [DateLimiteRecours]           DATETIME       NULL,
    [LieuJury]                    NVARCHAR (MAX) NULL,
    [Decision]                    NVARCHAR (MAX) NULL,
    [MotifGeneral]                NVARCHAR (MAX) NULL,
    [MotifDetail]                 NVARCHAR (MAX) NULL,
    [MotifCommentaire]            NVARCHAR (MAX) NULL,
    [dateCreation]                DATETIME       NOT NULL,
    [dateModif]                   DATETIME       NOT NULL,
    [bDeleted]                    BIT            NOT NULL,
    [AttSup]                      NVARCHAR (MAX) NULL,
    [Livret1_ID]                  INT            NULL,
    [Livret2_ID]                  INT            NULL,
    [DateNotificationJury]        DATETIME       NULL,
    [DateNotificationJuryRecours] DATETIME       NULL,
    [IsRecours]                   BIT            DEFAULT ((0)) NOT NULL
);

GO
CREATE TABLE [dbo].[Livret1] (
    [ID]                               INT            IDENTITY (1, 1) NOT NULL,
    [Numero]                           NVARCHAR (MAX) NULL,
    [DateDemande]                      DATETIME       NULL,
    [DateLimiteEnvoiEHESP]             DATETIME       NULL,
    [DateLimiteReceptEHESP]            DATETIME       NULL,
    [DateLimiteJury]                   DATETIME       NULL,
    [DateValidite]                     DATETIME       NULL,
    [Date1ereDemandePieceManquantes]   DATETIME       NULL,
    [Date2emeDemandePieceManquantes]   DATETIME       NULL,
    [DateDemandePieceManquantesRetour] DATETIME       NULL,
    [DateEcheance]                     DATETIME       NULL,
    [isContrat]                        BIT            NOT NULL,
    [TypeDemande]                      NVARCHAR (MAX) NULL,
    [EtatLivret]                       NVARCHAR (MAX) NULL,
    [DateEnvoiEHESP]                   DATETIME       NULL,
    [DateEnvoiCandidat]                DATETIME       NULL,
    [DateReceptEHESP]                  DATETIME       NULL,
    [DateReceptEHESPComplet]           DATETIME       NULL,
    [isClos]                           BIT            NOT NULL,
    [dateCreation]                     DATETIME       NOT NULL,
    [dateModif]                        DATETIME       NOT NULL,
    [bDeleted]                         BIT            NOT NULL,
    [AttSup]                           NVARCHAR (MAX) NULL,
    [Candidat_ID]                      INT            NOT NULL,
    [Diplome_ID]                       INT            NOT NULL,
    [DateReceptionPiecesManquantes]    DATETIME       NULL,
    [VecteurInformation]               NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[Livret2] (
    [ID]                               INT            IDENTITY (1, 1) NOT NULL,
    [Numero]                           NVARCHAR (MAX) NULL,
    [DateDemande]                      DATETIME       NULL,
    [DateLimiteEnvoiEHESP]             DATETIME       NULL,
    [DateLimiteReceptEHESP]            DATETIME       NULL,
    [DatePrevJury1]                    DATETIME       NULL,
    [DatePrevJury2]                    DATETIME       NULL,
    [SessionJury]                      NVARCHAR (MAX) NULL,
    [DateLimiteJury]                   DATETIME       NULL,
    [DateValidite]                     DATETIME       NULL,
    [IsAttestationOK]                  BIT            NOT NULL,
    [IsCNIOK]                          BIT            NOT NULL,
    [IsDispenseArt2]                   BIT            NOT NULL,
    [DateEcheance]                     DATETIME       NULL,
    [isContrat]                        BIT            NOT NULL,
    [EtatLivret]                       NVARCHAR (MAX) NULL,
    [DateEnvoiEHESP]                   DATETIME       NULL,
    [DateEnvoiCandidat]                DATETIME       NULL,
    [DateReceptEHESP]                  DATETIME       NULL,
    [DateReceptEHESPComplet]           DATETIME       NULL,
    [isClos]                           BIT            NOT NULL,
    [dateCreation]                     DATETIME       NOT NULL,
    [dateModif]                        DATETIME       NOT NULL,
    [bDeleted]                         BIT            NOT NULL,
    [AttSup]                           NVARCHAR (MAX) NULL,
    [Candidat_ID]                      INT            NOT NULL,
    [Diplome_ID]                       INT            NOT NULL,
    [Date1ereDemandePieceManquantes]   DATETIME       NULL,
    [Date2emeDemandePieceManquantes]   DATETIME       NULL,
    [DateDemandePieceManquantesRetour] DATETIME       NULL,
    [DateReceptionPiecesManquantes]    DATETIME       NULL,
    [NumPassage]                       INT            DEFAULT ((0)) NOT NULL,
    [IsOuvertureApresRecours]          BIT            DEFAULT ((0)) NOT NULL
);

GO
CREATE TABLE [dbo].[LockCandidats] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [IDCandidat]   INT            NOT NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[MembreJuries] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [College]      NVARCHAR (MAX) NULL,
    [Origine]      NVARCHAR (MAX) NULL,
    [Region]       NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [Livret2_ID]   INT            NOT NULL
);

GO
CREATE TABLE [dbo].[MotifDetailleL1] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [MotifGL1_ID]  INT            NOT NULL
);

GO
CREATE TABLE [dbo].[MotifDetailleL2] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [MotifGL2_ID]  INT            NOT NULL
);

GO
CREATE TABLE [dbo].[MotifGeneralL1] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[MotifGeneralL2] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[ParamColleges] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[ParamOrigines] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[ParamTypeDemandes] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[ParamVecteurInformations] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[PieceJointeCategories] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Livret]       NVARCHAR (MAX) NULL,
    [Categorie]    NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[PieceJointeItems] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [Categorie_ID] INT            NOT NULL
);

GO
CREATE TABLE [dbo].[PieceJointeL1] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Categorie]    NVARCHAR (MAX) NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [IsRecu]       BIT            NOT NULL,
    [IsOK]         BIT            NOT NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [Livret1_ID]   INT            NOT NULL
);

GO
CREATE TABLE [dbo].[PieceJointeL2] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Categorie]    NVARCHAR (MAX) NULL,
    [Libelle]      NVARCHAR (MAX) NULL,
    [IsRecu]       BIT            NOT NULL,
    [IsOK]         BIT            NOT NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL,
    [Livret2_ID]   INT            NOT NULL
);

GO
CREATE TABLE [dbo].[Recours] (
    [ID]                      INT            IDENTITY (1, 1) NOT NULL,
    [DateDepot]               DATETIME       NULL,
    [TypeRecours]             INT            NOT NULL,
    [MotifRecours]            NVARCHAR (MAX) NULL,
    [MotifRecoursCommentaire] NVARCHAR (MAX) NULL,
    [NomJury]                 NVARCHAR (MAX) NULL,
    [DateJury]                DATETIME       NULL,
    [LieuJury]                NVARCHAR (MAX) NULL,
    [Decision]                NVARCHAR (MAX) NULL,
    [MotifGeneral]            NVARCHAR (MAX) NULL,
    [MotifDetail]             NVARCHAR (MAX) NULL,
    [MotifCommentaire]        NVARCHAR (MAX) NULL,
    [dateCreation]            DATETIME       NOT NULL,
    [dateModif]               DATETIME       NOT NULL,
    [bDeleted]                BIT            NOT NULL,
    [AttSup]                  NVARCHAR (MAX) NULL,
    [DateLimiteJury]          DATETIME       NULL,
    [Jury_ID]                 INT            DEFAULT ((0)) NOT NULL
);

GO
CREATE TABLE [dbo].[Regions] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [dateCreation] DATETIME       NOT NULL,
    [dateModif]    DATETIME       NOT NULL,
    [bDeleted]     BIT            NOT NULL,
    [AttSup]       NVARCHAR (MAX) NULL
);

GO
CREATE VIEW [dbo].[L1_RECUS_COMPLETS]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret1_NonClos.Numero,
       dbo.Livret1_NonClos.ID AS IDLivret1,
       dbo.Livret1_NonClos.DateEnvoiCandidat,
       dbo.Livret1_NonClos.DateLimiteReceptEHESP,
       dbo.Livret1_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret1_NonClos.EtatLivret,
       dbo.Juries.DateJury,
       dbo.Juries.NomJury,
       dbo.Juries.LieuJury,
       dbo.Juries.HeureJury,
       dbo.Juries.HeureConvoc,
       dbo.Livret1_NonClos.DateLimiteJury,
       dbo.Livret1_NonClos.Date1ereDemandePieceManquantes,
       dbo.Livret1_NonClos.Date2emeDemandePieceManquantes,
       dbo.Livret1_NonClos.DateDemandePieceManquantesRetour
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret1_NonClos
       ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID
       LEFT OUTER JOIN
       dbo.Juries
       ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
WHERE  (dbo.Livret1_NonClos.EtatLivret LIKE N'40%');

GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Candidats.Adresse,
       dbo.Livret1_NonClos.ID AS IDLIVRET1,
       dbo.Livret1_NonClos.Numero,
       dbo.Livret1_NonClos.DateReceptEHESP,
       dbo.Livret1_NonClos.DateLimiteReceptEHESP,
       dbo.Livret1_NonClos.EtatLivret,
       dbo.Livret1_NonClos.Date1ereDemandePieceManquantes,
       dbo.Livret1_NonClos.Date2emeDemandePieceManquantes,
       dbo.Livret1_NonClos.DateDemandePieceManquantesRetour
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret1_NonClos
       ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID
WHERE  (dbo.Livret1_NonClos.EtatLivret LIKE N'30%');

GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS_PJ]
AS
SELECT dbo.PieceJointeL1.Categorie,
       dbo.PieceJointeL1.Libelle,
       dbo.L1_RECUS_INCOMPLETS.IDLIVRET1
FROM   dbo.PieceJointeL1
       INNER JOIN
       dbo.L1_RECUS_INCOMPLETS
       ON dbo.PieceJointeL1.Livret1_ID = dbo.L1_RECUS_INCOMPLETS.IDLIVRET1
WHERE  (dbo.PieceJointeL1.IsOK = 0);

GO
CREATE VIEW [dbo].[L1_VALIDATION_ACCEPTE]
AS
SELECT Candidats.ID,
       Candidats.Civilite,
       Candidats.Nom,
       Candidats.Prenom,
       Candidats.Prenom2,
       Candidats.Prenom3,
       Candidats.Adresse,
       Candidats.CodePostal,
       Candidats.Ville,
       Livret1_NonClos.Numero,
       Livret1_NonClos.ID AS IDLivret1,
       Livret1_NonClos.DateEnvoiCandidat,
       Livret1_NonClos.DateLimiteReceptEHESP,
       Livret1_NonClos.DateReceptEHESP,
       Candidats.Pays,
       Livret1_NonClos.EtatLivret,
       Juries.DateJury,
       Juries.NomJury,
       Juries.LieuJury,
       Juries.HeureJury,
       Juries.HeureConvoc,
       Juries.Decision,
       Candidats.Sexe,
       Candidats.NomJeuneFille,
       Candidats.DateNaissance,
       Candidats.CPNaissance,
       Candidats.VilleNaissance,
       Livret1_NonClos.DateValidite,
       dbo.juries.IsRecours,
       Juries.DateLimiteRecours,
       Recours.DateDepot,
       Recours.TypeRecours,
       Juries.MotifGeneral,
       Juries.MotifDetail,
       Juries.MotifCommentaire,
       Juries.IsRecours AS Expr1
FROM   Juries
       LEFT OUTER JOIN
       Recours
       ON Juries.ID = Recours.Jury_ID
       RIGHT OUTER JOIN
       Candidats
       INNER JOIN
       Livret1_NonClos
       ON Candidats.ID = Livret1_NonClos.Candidat_ID
       ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE  (Juries.Decision LIKE N'10-%');

GO
CREATE VIEW [dbo].[L1_VALIDATION_APRESRECOURS]
AS
SELECT Candidats.ID,
       Candidats.Civilite,
       Candidats.Nom,
       Candidats.Prenom,
       Candidats.Prenom2,
       Candidats.Prenom3,
       Candidats.Adresse,
       Candidats.CodePostal,
       Candidats.Ville,
       Livret1_NonClos.Numero,
       Livret1_NonClos.ID AS IDLivret1,
       Livret1_NonClos.DateEnvoiCandidat,
       Livret1_NonClos.DateLimiteReceptEHESP,
       Livret1_NonClos.DateReceptEHESP,
       Candidats.Pays,
       Livret1_NonClos.EtatLivret,
       Juries.DateJury,
       Juries.NomJury,
       Juries.LieuJury,
       Juries.HeureJury,
       Juries.HeureConvoc,
       Juries.Decision,
       Candidats.Sexe,
       Candidats.NomJeuneFille,
       Candidats.DateNaissance,
       Candidats.CPNaissance,
       Candidats.VilleNaissance,
       Livret1_NonClos.DateValidite,
       juries.IsRecours,
       Juries.DateLimiteRecours,
       Recours.Decision AS DecisionRecours,
       Recours.MotifGeneral,
       Recours.MotifDetail,
       Recours.MotifCommentaire
FROM   Recours
       RIGHT OUTER JOIN
       Juries
       ON Recours.Jury_ID = Juries.ID
       RIGHT OUTER JOIN
       Candidats
       INNER JOIN
       Livret1_NonClos
       ON Candidats.ID = Livret1_NonClos.Candidat_ID
       ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE  (Juries.Decision LIKE N'20-%')
       AND (dbo.juries.IsRecours = 1)
       AND (Recours.Decision LIKE N'10-%');

GO
CREATE VIEW [dbo].[L1_VALIDATION_REFUSE]
AS
SELECT Candidats.ID,
       Candidats.Civilite,
       Candidats.Nom,
       Candidats.Prenom,
       Candidats.Prenom2,
       Candidats.Prenom3,
       Candidats.Adresse,
       Candidats.CodePostal,
       Candidats.Ville,
       Livret1_NonClos.Numero,
       Livret1_NonClos.ID AS IDLivret1,
       Livret1_NonClos.DateEnvoiCandidat,
       Livret1_NonClos.DateLimiteReceptEHESP,
       Livret1_NonClos.DateReceptEHESP,
       Candidats.Pays,
       Livret1_NonClos.EtatLivret,
       Juries.DateJury,
       Juries.NomJury,
       Juries.LieuJury,
       Juries.HeureJury,
       Juries.HeureConvoc,
       Juries.Decision,
       Candidats.Sexe,
       Candidats.NomJeuneFille,
       Candidats.DateNaissance,
       Candidats.CPNaissance,
       Candidats.VilleNaissance,
       Livret1_NonClos.DateValidite,
       Juries.IsRecours,
       Juries.DateLimiteRecours,
       Recours.DateDepot,
       Recours.TypeRecours,
       Juries.MotifGeneral,
       Juries.MotifDetail,
       Juries.MotifCommentaire,
       Recours.Jury_ID
FROM   Recours
       RIGHT OUTER JOIN
       Juries
       ON Recours.Jury_ID = Juries.ID
       RIGHT OUTER JOIN
       Candidats
       INNER JOIN
       Livret1_NonClos
       ON Candidats.ID = Livret1_NonClos.Candidat_ID
       ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE  (Juries.Decision LIKE N'20-%');

GO
CREATE VIEW [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]
AS
SELECT Candidats.ID,
       Candidats.Civilite,
       Candidats.Nom,
       Candidats.Prenom,
       Candidats.Prenom2,
       Candidats.Prenom3,
       Candidats.Adresse,
       Candidats.CodePostal,
       Candidats.Ville,
       Livret1_NonClos.Numero,
       Livret1_NonClos.ID AS IDLivret1,
       Livret1_NonClos.DateEnvoiCandidat,
       Livret1_NonClos.DateLimiteReceptEHESP,
       Livret1_NonClos.DateReceptEHESP,
       Candidats.Pays,
       Livret1_NonClos.EtatLivret,
       Juries.DateJury,
       Juries.NomJury,
       Juries.LieuJury,
       Juries.HeureJury,
       Juries.HeureConvoc,
       Juries.Decision,
       Candidats.Sexe,
       Candidats.NomJeuneFille,
       Candidats.DateNaissance,
       Candidats.CPNaissance,
       Candidats.VilleNaissance,
       Livret1_NonClos.DateValidite,
       dbo.Juries.IsRecours,
       Juries.DateLimiteRecours,
       Recours.Decision AS DecisionRecours,
       Recours.MotifGeneral,
       Recours.MotifDetail,
       Recours.MotifCommentaire
FROM   Recours
       RIGHT OUTER JOIN
       Juries
       ON Recours.Jury_ID = Juries.ID
       RIGHT OUTER JOIN
       Candidats
       INNER JOIN
       Livret1_NonClos
       ON Candidats.ID = Livret1_NonClos.Candidat_ID
       ON Juries.Livret1_ID = Livret1_NonClos.ID
WHERE  (Juries.Decision LIKE N'20-%')
       AND (Juries.IsRecours = 1)
       AND (Recours.Decision LIKE N'20-%');

GO
CREATE VIEW [dbo].[L2_DC]
AS
SELECT ID,
       EtatLivret,
       (SELECT DCLivrets.Statut
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 1)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC1,
       (SELECT DCLivrets.DateObtention
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 1)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC1_DATE,
       (SELECT DCLivrets.Statut
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 2)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC2,
       (SELECT DCLivrets.DateObtention
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 2)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC2_DATE,
       (SELECT DCLivrets.Statut
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 3)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC3,
       (SELECT DCLivrets.DateObtention
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 3)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC3_DATE,
       (SELECT DCLivrets.Statut
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 4)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC4,
       (SELECT DCLivrets.DateObtention
        FROM   DCLivrets
               INNER JOIN
               DomaineCompetences
               ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
        WHERE  (DomaineCompetences.Numero = 4)
               AND (DCLivrets.oLivret2_ID = Livret2_NonClos.ID)) AS DC4_DATE
FROM   dbo.Livret2_NonClos;

GO
CREATE VIEW [dbo].[L2_DC_DECISION]
AS
SELECT ID,
       EtatLivret,
       (SELECT dbo.DCLivrets.Decision
        FROM   dbo.DCLivrets
               INNER JOIN
               dbo.DomaineCompetences
               ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
        WHERE  (dbo.DomaineCompetences.Numero = 1)
               AND (dbo.DCLivrets.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC1,
       (SELECT dbo.DCLivrets.DateObtention
        FROM   dbo.DCLivrets
               INNER JOIN
               dbo.DomaineCompetences
               ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
        WHERE  (dbo.DomaineCompetences.Numero = 1)
               AND (dbo.DCLivrets.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC1_DATE,
       (SELECT DCLivrets_3.Decision
        FROM   dbo.DCLivrets AS DCLivrets_3
               INNER JOIN
               dbo.DomaineCompetences AS DomaineCompetences_3
               ON DCLivrets_3.oDomaineCompetence_ID = DomaineCompetences_3.ID
        WHERE  (DomaineCompetences_3.Numero = 2)
               AND (DCLivrets_3.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC2,
       (SELECT DCLivrets_3.DateObtention
        FROM   dbo.DCLivrets AS DCLivrets_3
               INNER JOIN
               dbo.DomaineCompetences AS DomaineCompetences_3
               ON DCLivrets_3.oDomaineCompetence_ID = DomaineCompetences_3.ID
        WHERE  (DomaineCompetences_3.Numero = 2)
               AND (DCLivrets_3.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC2_DATE,
       (SELECT DCLivrets_2.Decision
        FROM   dbo.DCLivrets AS DCLivrets_2
               INNER JOIN
               dbo.DomaineCompetences AS DomaineCompetences_2
               ON DCLivrets_2.oDomaineCompetence_ID = DomaineCompetences_2.ID
        WHERE  (DomaineCompetences_2.Numero = 3)
               AND (DCLivrets_2.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC3,
       (SELECT DCLivrets_2.DateObtention
        FROM   dbo.DCLivrets AS DCLivrets_2
               INNER JOIN
               dbo.DomaineCompetences AS DomaineCompetences_2
               ON DCLivrets_2.oDomaineCompetence_ID = DomaineCompetences_2.ID
        WHERE  (DomaineCompetences_2.Numero = 3)
               AND (DCLivrets_2.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC3_DATE,
       (SELECT DCLivrets_1.Decision
        FROM   dbo.DCLivrets AS DCLivrets_1
               INNER JOIN
               dbo.DomaineCompetences AS DomaineCompetences_1
               ON DCLivrets_1.oDomaineCompetence_ID = DomaineCompetences_1.ID
        WHERE  (DomaineCompetences_1.Numero = 4)
               AND (DCLivrets_1.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC4,
       (SELECT DCLivrets_1.DAteObtention
        FROM   dbo.DCLivrets AS DCLivrets_1
               INNER JOIN
               dbo.DomaineCompetences AS DomaineCompetences_1
               ON DCLivrets_1.oDomaineCompetence_ID = DomaineCompetences_1.ID
        WHERE  (DomaineCompetences_1.Numero = 4)
               AND (DCLivrets_1.oLivret2_ID = dbo.Livret2_NonClos.ID)) AS DC4_DATE
FROM   dbo.Livret2_NonClos;

GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.ID AS IDLIVRET2,
       dbo.Livret2_NonClos.DateEnvoiCandidat,
       dbo.Livret2_NonClos.DateLimiteReceptEHESP,
       dbo.Livret2_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.Livret2_NonClos.SessionJury,
       dbo.Livret2_NonClos.DatePrevJury2,
       dbo.Livret2_NonClos.DatePrevJury1,
       dbo.Livret2_NonClos.isAttestationOK,
       dbo.Livret2_NonClos.isCNIOK,
       dbo.Juries.DateJury,
       dbo.Juries.NomJury,
       dbo.Juries.LieuJury,
       dbo.Juries.HeureJury,
       dbo.Juries.HeureConvoc
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
       LEFT OUTER JOIN
       dbo.Juries
       ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'40%');

GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_DC]
AS
SELECT dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Prenom2,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.L2_DC.DC1,
       dbo.L2_DC.DC2,
       dbo.L2_DC.DC3,
       dbo.L2_DC.DC4
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
       INNER JOIN
       dbo.L2_DC
       ON dbo.Livret2_NonClos.ID = dbo.L2_DC.ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'40-%');

GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_JURY]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.ID AS IDLIVRET2,
       dbo.Livret2_NonClos.DateEnvoiCandidat,
       dbo.Livret2_NonClos.DateLimiteReceptEHESP,
       dbo.Livret2_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.Livret2_NonClos.SessionJury,
       dbo.Livret2_NonClos.DatePrevJury2,
       dbo.Livret2_NonClos.DatePrevJury1,
       dbo.Livret2_NonClos.isAttestationOK,
       dbo.Livret2_NonClos.isCNIOK
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'40%')
       AND (dbo.Livret2_NonClos.isAttestationOK = 1)
       AND (dbo.Livret2_NonClos.isCNIOK = 1);

GO
CREATE VIEW [dbo].[L2_RECUS_INCOMPLETS]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.ID AS IDLIVRET2,
       dbo.Livret2_NonClos.DateEnvoiCandidat,
       dbo.Livret2_NonClos.DateLimiteReceptEHESP,
       dbo.Livret2_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.Livret2_NonClos.isAttestationOK,
       dbo.Livret2_NonClos.isCNIOK
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'30%')
       AND (dbo.Livret2_NonClos.isAttestationOK = 1)
       AND (dbo.Livret2_NonClos.isCNIOK = 1);

GO
CREATE VIEW [dbo].[L2_RECUS_INCOMPLETS_PJ]
AS
SELECT dbo.PieceJointeL2.Livret2_ID,
       dbo.PieceJointeL2.Categorie,
       dbo.PieceJointeL2.Libelle
FROM   dbo.L2_RECUS_INCOMPLETS
       INNER JOIN
       dbo.PieceJointeL2
       ON dbo.L2_RECUS_INCOMPLETS.IDLIVRET2 = dbo.PieceJointeL2.Livret2_ID
WHERE  (dbo.PieceJointeL2.IsOK = 0);

GO
CREATE VIEW [dbo].[L2_VALIDATION_PARTIELLE]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.ID AS IDLIVRET2,
       dbo.Livret2_NonClos.DateEnvoiCandidat,
       dbo.Livret2_NonClos.DateLimiteReceptEHESP,
       dbo.Livret2_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.Livret2_NonClos.SessionJury,
       dbo.Livret2_NonClos.DatePrevJury2,
       dbo.Livret2_NonClos.DatePrevJury1,
       dbo.Livret2_NonClos.isAttestationOK,
       dbo.Livret2_NonClos.isCNIOK,
       dbo.Livret2_NonClos.IsDispenseArt2,
       dbo.Juries.DateJury,
       dbo.Juries.NomJury,
       dbo.Juries.LieuJury,
       dbo.Juries.HeureJury,
       dbo.Juries.HeureConvoc,
       dbo.Candidats.Sexe,
       dbo.Candidats.NomJeuneFille,
       dbo.Candidats.DateNaissance,
       dbo.Candidats.CPNaissance,
       dbo.Candidats.VilleNaissance,
       dbo.L2_DC_DECISION.DC1,
       dbo.L2_DC_DECISION.DC1_DATE,
       dbo.L2_DC_DECISION.DC2,
       dbo.L2_DC_DECISION.DC2_DATE,
       dbo.L2_DC_DECISION.DC3,
       dbo.L2_DC_DECISION.DC3_DATE,
       dbo.L2_DC_DECISION.DC4,
       dbo.L2_DC_DECISION.DC4_DATE,
       dbo.Livret2_NonClos.DateValidite
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
       INNER JOIN
       dbo.L2_DC_DECISION
       ON dbo.Livret2_NonClos.ID = dbo.L2_DC_DECISION.ID
       LEFT OUTER JOIN
       dbo.Juries
       ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'70%')
       AND (dbo.Juries.Decision LIKE N'30-%');

GO
CREATE VIEW [dbo].[L2_VALIDATION_REFUSE]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.ID AS IDLIVRET2,
       dbo.Livret2_NonClos.DateEnvoiCandidat,
       dbo.Livret2_NonClos.DateLimiteReceptEHESP,
       dbo.Livret2_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.Livret2_NonClos.SessionJury,
       dbo.Livret2_NonClos.DatePrevJury2,
       dbo.Livret2_NonClos.DatePrevJury1,
       dbo.Livret2_NonClos.isAttestationOK,
       dbo.Livret2_NonClos.isCNIOK,
       dbo.Juries.DateJury,
       dbo.Juries.NomJury,
       dbo.Juries.LieuJury,
       dbo.Juries.HeureJury,
       dbo.Juries.HeureConvoc,
       dbo.Juries.Decision,
       dbo.Candidats.Sexe,
       dbo.Candidats.NomJeuneFille,
       dbo.Candidats.DateNaissance,
       dbo.Candidats.CPNaissance,
       dbo.Candidats.VilleNaissance,
       dbo.Livret2_NonClos.DateValidite
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
       LEFT OUTER JOIN
       dbo.Juries
       ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'50-%')
       AND (dbo.Juries.Decision LIKE N'20-%');

GO
CREATE VIEW [dbo].[L2_VALIDATION_TOTALE]
AS
SELECT dbo.Candidats.ID,
       dbo.Candidats.Civilite,
       dbo.Candidats.Nom,
       dbo.Candidats.Prenom,
       dbo.Candidats.Prenom2,
       dbo.Candidats.Prenom3,
       dbo.Candidats.Adresse,
       dbo.Candidats.CodePostal,
       dbo.Candidats.Ville,
       dbo.Livret2_NonClos.Numero,
       dbo.Livret2_NonClos.ID AS IDLIVRET2,
       dbo.Livret2_NonClos.DateEnvoiCandidat,
       dbo.Livret2_NonClos.DateLimiteReceptEHESP,
       dbo.Livret2_NonClos.DateReceptEHESP,
       dbo.Candidats.Pays,
       dbo.Livret2_NonClos.EtatLivret,
       dbo.Livret2_NonClos.SessionJury,
       dbo.Livret2_NonClos.DatePrevJury2,
       dbo.Livret2_NonClos.DatePrevJury1,
       dbo.Livret2_NonClos.isAttestationOK,
       dbo.Livret2_NonClos.isCNIOK,
       dbo.Juries.DateJury,
       dbo.Juries.NomJury,
       dbo.Juries.LieuJury,
       dbo.Juries.HeureJury,
       dbo.Juries.HeureConvoc,
       dbo.Juries.Decision,
       dbo.Candidats.Sexe,
       dbo.Candidats.NomJeuneFille,
       dbo.Candidats.DateNaissance,
       dbo.Candidats.CPNaissance,
       dbo.Candidats.VilleNaissance
FROM   dbo.Candidats
       INNER JOIN
       dbo.Livret2_NonClos
       ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID
       LEFT OUTER JOIN
       dbo.Juries
       ON dbo.Livret2_NonClos.ID = dbo.Juries.Livret2_ID
WHERE  (dbo.Livret2_NonClos.EtatLivret LIKE N'40%');

GO
CREATE VIEW [dbo].[Livret1_NonClos]
AS
SELECT dbo.Livret1.*
FROM   dbo.Livret1
WHERE  (isClos = 0);

GO
CREATE VIEW [dbo].[Livret2_NonClos]
AS
SELECT dbo.Livret2.*
FROM   dbo.Livret2
WHERE  (isClos = 0);

GO
CREATE VIEW [dbo].[RQ_L1_STAT]
AS
SELECT Livret1.DateDemande,
       Livret1.TypeDemande,
       YEAR(Livret1.DateDemande) AS ANNEE,
       DATENAME(month, Livret1.DateDemande) AS MOIS,
       DATENAME(day, Livret1.DateDemande) AS JOUR,
       FLOOR(DATENAME(day, Livret1.DateDemande) / 16) + 1 AS QUINZAINE,
       DATENAME(quarter, Livret1.DateDemande) AS TRIMESTRE,
       Livret1.VecteurInformation,
       Livret1.Numero,
       Livret1.EtatLivret,
       Juries.IsRecours,
       Juries.Decision,
       Recours.Decision AS DecisionRecours,
       Juries.MotifGeneral AS MotifGJury,
       Juries.MotifDetail AS MotifDJury,
       Juries.MotifCommentaire AS MotifCJury,
       Recours.MotifGeneral AS MotifGRecours,
       Recours.MotifDetail AS MotifDrecours,
       Recours.MotifCommentaire AS MotifCRecours,
       Candidats.Nom,
       Candidats.Sexe,
       Candidats.Ville,
       Candidats.Region
FROM   Juries
       LEFT OUTER JOIN
       Recours
       ON Juries.ID = Recours.Jury_ID
       RIGHT OUTER JOIN
       Livret1
       INNER JOIN
       Candidats
       ON Livret1.Candidat_ID = Candidats.ID
       ON Juries.Livret1_ID = Livret1.ID;

GO
CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT dbo.Livret2.Numero,
       dbo.Juries.DateJury,
       dbo.Juries.Decision,
       dbo.DomaineCompetences.Nom,
       dbo.DCLivrets.Decision AS DecisionJury,
       dbo.DCLivrets.IsAValider
FROM   dbo.Livret2
       INNER JOIN
       dbo.DCLivrets
       ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID
       INNER JOIN
       dbo.Juries
       ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
       INNER JOIN
       dbo.DomaineCompetences
       ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
WHERE  (dbo.DCLivrets.IsAValider = 1);

GO
CREATE VIEW [dbo].[RQ_L2_STAT]
AS
SELECT dbo.Livret2.Numero,
       dbo.Livret2.DateDemande,
       dbo.Candidats.Nom,
       dbo.Juries.Decision,
       dbo.Recours.Decision AS [Decision Recours],
       dbo.Livret2.EtatLivret,
       dbo.Livret2.NumPassage,
       dbo.Livret2.DateEnvoiEHESP,
       dbo.Juries.DateJury,
       dbo.Livret2.DateReceptEHESP,
       dbo.Livret2.DateReceptEHESPComplet,
       DATENAME(month, dbo.Juries.DateJury) AS MoisJury,
       dbo.Candidats.Sexe,
       dbo.Candidats.Ville,
       dbo.Candidats.Region,
       dbo.Livret2.IsOuvertureApresRecours,
       dbo.DiplomeCands.Statut AS StatutCAFDES
FROM   dbo.Livret2
       INNER JOIN
       dbo.Candidats
       ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID
       INNER JOIN
       dbo.Diplomes
       ON dbo.Livret2.Diplome_ID = dbo.Diplomes.ID
       LEFT OUTER JOIN
       dbo.DiplomeCands
       ON dbo.Diplomes.ID = dbo.DiplomeCands.Diplome_ID
          AND dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID
       LEFT OUTER JOIN
       dbo.Juries
       ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
       LEFT OUTER JOIN
       dbo.Recours
       ON dbo.Livret2.ID = dbo.Recours.ID;

GO
ALTER TABLE [dbo].[DCLivrets]
    ADD CONSTRAINT [FK_dbo.DCLivrets_dbo.DomaineCompetences_oDomaineCompetence_ID] FOREIGN KEY ([oDomaineCompetence_ID]) REFERENCES [dbo].[DomaineCompetences] ([ID]);

GO
ALTER TABLE [dbo].[DCLivrets]
    ADD CONSTRAINT [FK_dbo.DCLivrets_dbo.Livret2_oLivret2_ID] FOREIGN KEY ([oLivret2_ID]) REFERENCES [dbo].[Livret2] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[DiplomeCands]
    ADD CONSTRAINT [FK_dbo.DiplomeCands_dbo.Candidats_oCandidat_ID] FOREIGN KEY ([Candidat_ID]) REFERENCES [dbo].[Candidats] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[DiplomeCands]
    ADD CONSTRAINT [FK_dbo.DiplomeCands_dbo.Diplomes_oDiplome_ID] FOREIGN KEY ([Diplome_ID]) REFERENCES [dbo].[Diplomes] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[DomaineCompetenceCands]
    ADD CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DiplomeCands_oDiplomeCand_ID] FOREIGN KEY ([Diplome_ID]) REFERENCES [dbo].[DiplomeCands] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[DomaineCompetenceCands]
    ADD CONSTRAINT [FK_dbo.DomaineCompetenceCands_dbo.DomaineCompetences_oDomaineCompetence_ID] FOREIGN KEY ([DomaineCompetence_ID]) REFERENCES [dbo].[DomaineCompetences] ([ID]);

GO
ALTER TABLE [dbo].[DomaineCompetences]
    ADD CONSTRAINT [FK_dbo.DomaineCompetences_dbo.Diplomes_oDiplome_ID] FOREIGN KEY ([Diplome_ID]) REFERENCES [dbo].[Diplomes] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[EchangeL1]
    ADD CONSTRAINT [FK_dbo.EchangeL1_dbo.Livret1_oLivret_ID] FOREIGN KEY ([Livret1_ID]) REFERENCES [dbo].[Livret1] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[EchangeL2]
    ADD CONSTRAINT [FK_dbo.EchangeL2_dbo.Livret2_oLivret_ID] FOREIGN KEY ([Livret2_ID]) REFERENCES [dbo].[Livret2] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[Juries]
    ADD CONSTRAINT [FK_dbo.Juries_dbo.Livret1_oLivret1_ID] FOREIGN KEY ([Livret1_ID]) REFERENCES [dbo].[Livret1] ([ID]);

GO
ALTER TABLE [dbo].[Juries]
    ADD CONSTRAINT [FK_dbo.Juries_dbo.Livret2_oLivret2_ID] FOREIGN KEY ([Livret2_ID]) REFERENCES [dbo].[Livret2] ([ID]);

GO
ALTER TABLE [dbo].[Livret1]
    ADD CONSTRAINT [FK_dbo.Livret1_dbo.Candidats_oCandidat_ID] FOREIGN KEY ([Candidat_ID]) REFERENCES [dbo].[Candidats] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[Livret1]
    ADD CONSTRAINT [FK_dbo.Livret1_dbo.Diplomes_Diplome_ID] FOREIGN KEY ([Diplome_ID]) REFERENCES [dbo].[Diplomes] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[Livret2]
    ADD CONSTRAINT [FK_dbo.Livret2_dbo.Candidats_oCandidat_ID] FOREIGN KEY ([Candidat_ID]) REFERENCES [dbo].[Candidats] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[Livret2]
    ADD CONSTRAINT [FK_dbo.Livret2_dbo.Diplomes_Diplome_ID] FOREIGN KEY ([Diplome_ID]) REFERENCES [dbo].[Diplomes] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[MembreJuries]
    ADD CONSTRAINT [FK_dbo.MembreJuries_dbo.Livret2_Livret2_ID] FOREIGN KEY ([Livret2_ID]) REFERENCES [dbo].[Livret2] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[MotifDetailleL1]
    ADD CONSTRAINT [FK_dbo.MotifDetailleL1_dbo.MotifGeneralL1_MotifGL1_ID] FOREIGN KEY ([MotifGL1_ID]) REFERENCES [dbo].[MotifGeneralL1] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[MotifDetailleL2]
    ADD CONSTRAINT [FK_dbo.MotifDetailleL2_dbo.MotifGeneralL2_MotifGL2_ID] FOREIGN KEY ([MotifGL2_ID]) REFERENCES [dbo].[MotifGeneralL2] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[PieceJointeItems]
    ADD CONSTRAINT [FK_dbo.PieceJointeItems_dbo.PieceJointeCategories_CategoriePJ_ID] FOREIGN KEY ([Categorie_ID]) REFERENCES [dbo].[PieceJointeCategories] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[PieceJointeL1]
    ADD CONSTRAINT [FK_dbo.PieceJointeL1_dbo.Livret1_oLivret_ID] FOREIGN KEY ([Livret1_ID]) REFERENCES [dbo].[Livret1] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[PieceJointeL2]
    ADD CONSTRAINT [FK_dbo.PieceJointeL2_dbo.Livret2_oLivret_ID] FOREIGN KEY ([Livret2_ID]) REFERENCES [dbo].[Livret2] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[Recours]
    ADD CONSTRAINT [FK_dbo.Recours_dbo.Juries_Jury_ID] FOREIGN KEY ([Jury_ID]) REFERENCES [dbo].[Juries] ([ID]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[__MigrationHistory]
    ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC);

GO
ALTER TABLE [dbo].[Candidats]
    ADD CONSTRAINT [PK_dbo.Candidats] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[DCLivrets]
    ADD CONSTRAINT [PK_dbo.DCLivrets] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[DiplomeCands]
    ADD CONSTRAINT [PK_dbo.DiplomeCands] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Diplomes]
    ADD CONSTRAINT [PK_dbo.Diplomes] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[DomaineCompetenceCands]
    ADD CONSTRAINT [PK_dbo.DomaineCompetenceCands] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[DomaineCompetences]
    ADD CONSTRAINT [PK_dbo.DomaineCompetences] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[EchangeL1]
    ADD CONSTRAINT [PK_dbo.EchangeL1] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[EchangeL2]
    ADD CONSTRAINT [PK_dbo.EchangeL2] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Juries]
    ADD CONSTRAINT [PK_dbo.Juries] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Livret1]
    ADD CONSTRAINT [PK_dbo.Livret1] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Livret2]
    ADD CONSTRAINT [PK_dbo.Livret2] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[LockCandidats]
    ADD CONSTRAINT [PK_dbo.LockCandidats] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[MembreJuries]
    ADD CONSTRAINT [PK_dbo.MembreJuries] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[MotifDetailleL1]
    ADD CONSTRAINT [PK_dbo.MotifDetailleL1] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[MotifDetailleL2]
    ADD CONSTRAINT [PK_dbo.MotifDetailleL2] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[MotifGeneralL1]
    ADD CONSTRAINT [PK_dbo.MotifGeneralL1] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[MotifGeneralL2]
    ADD CONSTRAINT [PK_dbo.MotifGeneralL2] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[ParamColleges]
    ADD CONSTRAINT [PK_dbo.ParamColleges] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[ParamOrigines]
    ADD CONSTRAINT [PK_dbo.ParamOrigines] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[ParamTypeDemandes]
    ADD CONSTRAINT [PK_dbo.ParamTypeDemandes] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[ParamVecteurInformations]
    ADD CONSTRAINT [PK_dbo.ParamVecteurInformations] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[PieceJointeCategories]
    ADD CONSTRAINT [PK_dbo.PieceJointeCategories] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[PieceJointeItems]
    ADD CONSTRAINT [PK_dbo.PieceJointeItems] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[PieceJointeL1]
    ADD CONSTRAINT [PK_dbo.PieceJointeL1] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[PieceJointeL2]
    ADD CONSTRAINT [PK_dbo.PieceJointeL2] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Recours]
    ADD CONSTRAINT [PK_dbo.Recours] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Regions]
    ADD CONSTRAINT [PK_dbo.Regions] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_oDomaineCompetence_ID]
    ON [dbo].[DCLivrets]([oDomaineCompetence_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_oLivret2_ID]
    ON [dbo].[DCLivrets]([oLivret2_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Candidat_ID]
    ON [dbo].[DiplomeCands]([Candidat_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Diplome_ID]
    ON [dbo].[DiplomeCands]([Diplome_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Diplome_ID]
    ON [dbo].[DomaineCompetenceCands]([Diplome_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_DomaineCompetence_ID]
    ON [dbo].[DomaineCompetenceCands]([DomaineCompetence_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Diplome_ID]
    ON [dbo].[DomaineCompetences]([Diplome_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Numero]
    ON [dbo].[DomaineCompetences]([Numero] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret1_ID]
    ON [dbo].[EchangeL1]([Livret1_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret2_ID]
    ON [dbo].[EchangeL2]([Livret2_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret1_ID]
    ON [dbo].[Juries]([Livret1_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret2_ID]
    ON [dbo].[Juries]([Livret2_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Candidat_ID]
    ON [dbo].[Livret1]([Candidat_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Diplome_ID]
    ON [dbo].[Livret1]([Diplome_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Candidat_ID]
    ON [dbo].[Livret2]([Candidat_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Diplome_ID]
    ON [dbo].[Livret2]([Diplome_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret2_ID]
    ON [dbo].[MembreJuries]([Livret2_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_MotifGL1_ID]
    ON [dbo].[MotifDetailleL1]([MotifGL1_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_MotifGL2_ID]
    ON [dbo].[MotifDetailleL2]([MotifGL2_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Categorie_ID]
    ON [dbo].[PieceJointeItems]([Categorie_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret1_ID]
    ON [dbo].[PieceJointeL1]([Livret1_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Livret2_ID]
    ON [dbo].[PieceJointeL2]([Livret2_ID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Jury_ID]
    ON [dbo].[Recours]([Jury_ID] ASC);

GO
