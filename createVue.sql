USE [GESTVAE]
GO

/****** Object:  View [dbo].[L1_RECUS_COMPLETS]    Script Date: 19/02/2019 18:22:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW [dbo].[L1_RECUS_COMPLETS]
GO
CREATE VIEW [dbo].[L1_RECUS_COMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1.Numero, dbo.Livret1.ID AS IDLivret1, dbo.Livret1.DateEnvoiCandidat, dbo.Livret1.DateLimiteReceptEHESP, dbo.Livret1.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret1.EtatLivret, dbo.Juries.DateJury, 
                         dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Livret1.DateLimiteJury, dbo.Livret1.Date1ereDemandePieceManquantes, dbo.Livret1.Date2emeDemandePieceManquantes, 
                         dbo.Livret1.DateDemandePieceManquantesRetour
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret1.ID = dbo.Juries.Livret1_ID
WHERE        (dbo.Livret1.EtatLivret LIKE N'40%')

GO


/****** Object:  View [dbo].[L1_RECUS_INCOMPLETS]    Script Date: 19/02/2019 18:23:07 ******/

DROP VIEW [dbo].[L1_RECUS_INCOMPLETS]
GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Adresse, dbo.Livret1.ID AS IDLIVRET1, dbo.Livret1.Numero, dbo.Livret1.DateReceptEHESP, 
                         dbo.Livret1.DateLimiteReceptEHESP, dbo.Livret1.EtatLivret, dbo.Livret1.Date1ereDemandePieceManquantes, dbo.Livret1.Date2emeDemandePieceManquantes, dbo.Livret1.DateDemandePieceManquantesRetour
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.Candidat_ID
WHERE        (dbo.Livret1.EtatLivret LIKE N'30%')

GO

/****** Object:  View [dbo].[L1_RECUS_INCOMPLETS_PJ]    Script Date: 19/02/2019 18:23:20 ******/

DROP VIEW [dbo].[L1_RECUS_INCOMPLETS_PJ]
GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS_PJ]
AS
SELECT        dbo.PieceJointeL1.Categorie, dbo.PieceJointeL1.Libelle, dbo.L1_RECUS_INCOMPLETS.IDLIVRET1
FROM            dbo.PieceJointeL1 INNER JOIN
                         dbo.L1_RECUS_INCOMPLETS ON dbo.PieceJointeL1.Livret1_ID = dbo.L1_RECUS_INCOMPLETS.IDLIVRET1
WHERE        (dbo.PieceJointeL1.IsOK = 0)

GO

/****** Object:  View [dbo].[L1_VALIDATION_ACCEPTE]    Script Date: 19/02/2019 18:23:42 ******/
DROP VIEW [dbo].[L1_VALIDATION_ACCEPTE]
GO
CREATE VIEW [dbo].[L1_VALIDATION_ACCEPTE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1.Numero, dbo.Livret1.ID AS IDLivret1, dbo.Livret1.DateEnvoiCandidat, dbo.Livret1.DateLimiteReceptEHESP, dbo.Livret1.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret1.EtatLivret, dbo.Juries.DateJury, 
                         dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, 
                         dbo.Candidats.VilleNaissance, dbo.Livret1.DateValidite, dbo.Livret1.IsRecours, dbo.Juries.DateLimiteRecours, dbo.Recours.DateDepot, dbo.Recours.TypeRecours, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.Candidat_ID LEFT OUTER JOIN
                         dbo.Recours ON dbo.Livret1.ID = dbo.Recours.Livret1_ID AND dbo.Livret1.ID = dbo.Recours.Livret1_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret1.ID = dbo.Juries.Livret1_ID
WHERE        (dbo.Juries.Decision LIKE N'10-%')


GO
/****** Object:  View [dbo].[L1_VALIDATION_APRESRECOURS]    Script Date: 19/02/2019 18:23:56 ******/
DROP VIEW [dbo].[L1_VALIDATION_APRESRECOURS]
GO
CREATE VIEW [dbo].[L1_VALIDATION_APRESRECOURS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1.Numero, dbo.Livret1.ID AS IDLivret1, dbo.Livret1.DateEnvoiCandidat, dbo.Livret1.DateLimiteReceptEHESP, dbo.Livret1.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret1.EtatLivret, dbo.Juries.DateJury, 
                         dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, 
                         dbo.Candidats.VilleNaissance, dbo.Livret1.DateValidite, dbo.Livret1.IsRecours, dbo.Juries.DateLimiteRecours, dbo.Recours.Decision AS DecisionRecours, dbo.Recours.MotifGeneral, dbo.Recours.MotifDetail, 
                         dbo.Recours.MotifCommentaire
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.Candidat_ID INNER JOIN
                         dbo.Recours ON dbo.Livret1.ID = dbo.Recours.Livret1_ID AND dbo.Livret1.ID = dbo.Recours.Livret1_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret1.ID = dbo.Juries.Livret1_ID
WHERE        (dbo.Juries.Decision LIKE N'20-%') AND (dbo.Livret1.IsRecours = 1) AND (dbo.Recours.Decision LIKE N'10-%')

GO
/****** Object:  View [dbo].[L1_VALIDATION_REFUSE]    Script Date: 19/02/2019 18:24:20 ******/
DROP VIEW [dbo].[L1_VALIDATION_REFUSE]
GO
CREATE VIEW [dbo].[L1_VALIDATION_REFUSE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1.Numero, dbo.Livret1.ID AS IDLivret1, dbo.Livret1.DateEnvoiCandidat, dbo.Livret1.DateLimiteReceptEHESP, dbo.Livret1.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret1.EtatLivret, dbo.Juries.DateJury, 
                         dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, 
                         dbo.Candidats.VilleNaissance, dbo.Livret1.DateValidite, dbo.Livret1.IsRecours, dbo.Juries.DateLimiteRecours, dbo.Recours.DateDepot, dbo.Recours.TypeRecours, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.Candidat_ID LEFT OUTER JOIN
                         dbo.Recours ON dbo.Livret1.ID = dbo.Recours.Livret1_ID AND dbo.Livret1.ID = dbo.Recours.Livret1_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret1.ID = dbo.Juries.Livret1_ID
WHERE        (dbo.Juries.Decision LIKE N'20-%')

GO
/****** Object:  View [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]    Script Date: 19/02/2019 18:24:35 ******/
DROP VIEW [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]
GO
CREATE VIEW [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1.Numero, dbo.Livret1.ID AS IDLivret1, dbo.Livret1.DateEnvoiCandidat, dbo.Livret1.DateLimiteReceptEHESP, dbo.Livret1.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret1.EtatLivret, dbo.Juries.DateJury, 
                         dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, 
                         dbo.Candidats.VilleNaissance, dbo.Livret1.DateValidite, dbo.Livret1.IsRecours, dbo.Juries.DateLimiteRecours, dbo.Recours.Decision AS DecisionRecours, dbo.Recours.MotifGeneral, dbo.Recours.MotifDetail, 
                         dbo.Recours.MotifCommentaire
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.Candidat_ID INNER JOIN
                         dbo.Recours ON dbo.Livret1.ID = dbo.Recours.Livret1_ID AND dbo.Livret1.ID = dbo.Recours.Livret1_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret1.ID = dbo.Juries.Livret1_ID
WHERE        (dbo.Juries.Decision LIKE N'20-%') AND (dbo.Livret1.IsRecours = 1) AND (dbo.Recours.Decision LIKE N'20-%')

GO
/****** Object:  View [dbo].[L2_DC]    Script Date: 19/02/2019 18:24:52 ******/

DROP VIEW [dbo].[L2_DC]
GO
CREATE VIEW [dbo].[L2_DC]
AS
SELECT        ID, EtatLivret, 
(SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 1) AND (DCLivrets.oLivret2_ID = Livret2.ID)) AS DC1,
(SELECT        DCLivrets.DateObtention 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 1) AND (DCLivrets.oLivret2_ID = Livret2.ID)) AS DC1_DATE,
 (SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 2) AND (DCLivrets.oLivret2_ID = Livret2.ID)) as DC2,
 (SELECT        DCLivrets.DateObtention 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 2) AND (DCLivrets.oLivret2_ID = Livret2.ID)) as DC2_DATE,
 (SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 3) AND (DCLivrets.oLivret2_ID = Livret2.ID)) as DC3, 
 (SELECT        DCLivrets.DateObtention 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 3) AND (DCLivrets.oLivret2_ID = Livret2.ID)) as DC3_DATE, 
 (SELECT        DCLivrets.Statut 
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 4) AND (DCLivrets.oLivret2_ID = Livret2.ID)) as DC4,
 (SELECT        DCLivrets.DateObtention
FROM            DCLivrets INNER JOIN
                         DomaineCompetences ON DCLivrets.oDomaineCompetence_ID = DomaineCompetences.ID
WHERE        (DomaineCompetences.Numero = 4) AND (DCLivrets.oLivret2_ID = Livret2.ID)) as DC4_DATE


FROM            dbo.Livret2



GO
/****** Object:  View [dbo].[L2_DC_DECISION]    Script Date: 19/02/2019 18:25:09 ******/
DROP VIEW [dbo].[L2_DC_DECISION]
GO
CREATE VIEW [dbo].[L2_DC_DECISION]
AS
SELECT        ID, EtatLivret,
                             (SELECT        dbo.DCLivrets.Decision
                               FROM            dbo.DCLivrets INNER JOIN
                                                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                               WHERE        (dbo.DomaineCompetences.Numero = 1) AND (dbo.DCLivrets.oLivret2_ID = dbo.Livret2.ID)) AS DC1,
                             (SELECT        dbo.DCLivrets.DateObtention
                               FROM            dbo.DCLivrets INNER JOIN
                                                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                               WHERE        (dbo.DomaineCompetences.Numero = 1) AND (dbo.DCLivrets.oLivret2_ID = dbo.Livret2.ID)) AS DC1_DATE,
                             (SELECT        DCLivrets_3.Decision
                               FROM            dbo.DCLivrets AS DCLivrets_3 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_3 ON DCLivrets_3.oDomaineCompetence_ID = DomaineCompetences_3.ID
                               WHERE        (DomaineCompetences_3.Numero = 2) AND (DCLivrets_3.oLivret2_ID = dbo.Livret2.ID)) AS DC2,
                             (SELECT        DCLivrets_3.DateObtention
                               FROM            dbo.DCLivrets AS DCLivrets_3 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_3 ON DCLivrets_3.oDomaineCompetence_ID = DomaineCompetences_3.ID
                               WHERE        (DomaineCompetences_3.Numero = 2) AND (DCLivrets_3.oLivret2_ID = dbo.Livret2.ID)) AS DC2_DATE,
                             (SELECT        DCLivrets_2.Decision
                               FROM            dbo.DCLivrets AS DCLivrets_2 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_2 ON DCLivrets_2.oDomaineCompetence_ID = DomaineCompetences_2.ID
                               WHERE        (DomaineCompetences_2.Numero = 3) AND (DCLivrets_2.oLivret2_ID = dbo.Livret2.ID)) AS DC3,
                             (SELECT        DCLivrets_2.DateObtention
                               FROM            dbo.DCLivrets AS DCLivrets_2 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_2 ON DCLivrets_2.oDomaineCompetence_ID = DomaineCompetences_2.ID
                               WHERE        (DomaineCompetences_2.Numero = 3) AND (DCLivrets_2.oLivret2_ID = dbo.Livret2.ID)) AS DC3_DATE,
                             (SELECT        DCLivrets_1.Decision
                               FROM            dbo.DCLivrets AS DCLivrets_1 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_1 ON DCLivrets_1.oDomaineCompetence_ID = DomaineCompetences_1.ID
                               WHERE        (DomaineCompetences_1.Numero = 4) AND (DCLivrets_1.oLivret2_ID = dbo.Livret2.ID)) AS DC4,
							 (SELECT        DCLivrets_1.DAteObtention
                               FROM            dbo.DCLivrets AS DCLivrets_1 INNER JOIN
                                                         dbo.DomaineCompetences AS DomaineCompetences_1 ON DCLivrets_1.oDomaineCompetence_ID = DomaineCompetences_1.ID
                               WHERE        (DomaineCompetences_1.Numero = 4) AND (DCLivrets_1.oLivret2_ID = dbo.Livret2.ID)) AS DC4_DATE
FROM            dbo.Livret2


GO

/****** Object:  View [dbo].[L2_RECUS_COMPLETS]    Script Date: 19/02/2019 18:25:23 ******/
DROP VIEW [dbo].[L2_RECUS_COMPLETS]
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2.Numero, dbo.Livret2.ID AS IDLIVRET2, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateLimiteReceptEHESP, dbo.Livret2.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2.EtatLivret, dbo.Livret2.SessionJury, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DatePrevJury1, dbo.Livret2.isAttestationOK, dbo.Livret2.isCNIOK, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'40%')

GO

/****** Object:  View [dbo].[L2_RECUS_COMPLETS_DC]    Script Date: 19/02/2019 18:25:39 ******/
DROP VIEW [dbo].[L2_RECUS_COMPLETS_DC]
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_DC]
AS
SELECT        dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom3, dbo.Candidats.Prenom2, dbo.Livret2.Numero, dbo.Livret2.EtatLivret, dbo.L2_DC.DC1, dbo.L2_DC.DC2, dbo.L2_DC.DC3, dbo.L2_DC.DC4
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID INNER JOIN
                         dbo.L2_DC ON dbo.Livret2.ID = dbo.L2_DC.ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'40-%')

GO
/****** Object:  View [dbo].[L2_RECUS_COMPLETS_JURY]    Script Date: 19/02/2019 18:25:54 ******/
DROP VIEW [dbo].[L2_RECUS_COMPLETS_JURY]
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_JURY]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2.Numero, dbo.Livret2.ID AS IDLIVRET2, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateLimiteReceptEHESP, dbo.Livret2.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2.EtatLivret, dbo.Livret2.SessionJury, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DatePrevJury1, dbo.Livret2.isAttestationOK, dbo.Livret2.isCNIOK
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'40%') AND (dbo.Livret2.isAttestationOK = 1) AND (dbo.Livret2.isCNIOK = 1)


GO
/****** Object:  View [dbo].[L2_RECUS_INCOMPLETS]    Script Date: 19/02/2019 18:26:16 ******/
DROP VIEW [dbo].[L2_RECUS_INCOMPLETS]
GO
CREATE VIEW [dbo].[L2_RECUS_INCOMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2.Numero, dbo.Livret2.ID AS IDLIVRET2, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateLimiteReceptEHESP, dbo.Livret2.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2.EtatLivret, dbo.Livret2.isAttestationOK, 
                         dbo.Livret2.isCNIOK
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'30%') AND (dbo.Livret2.isAttestationOK = 1) AND (dbo.Livret2.isCNIOK = 1)

GO
/****** Object:  View [dbo].[L2_RECUS_INCOMPLETS_PJ]    Script Date: 19/02/2019 18:26:30 ******/
DROP VIEW [dbo].[L2_RECUS_INCOMPLETS_PJ]
GO
CREATE VIEW [dbo].[L2_RECUS_INCOMPLETS_PJ]
AS
SELECT        dbo.PieceJointeL2.Livret2_ID, dbo.PieceJointeL2.Categorie, dbo.PieceJointeL2.Libelle
FROM            dbo.L2_RECUS_INCOMPLETS INNER JOIN
                         dbo.PieceJointeL2 ON dbo.L2_RECUS_INCOMPLETS.IDLIVRET2 = dbo.PieceJointeL2.Livret2_ID
WHERE        (dbo.PieceJointeL2.IsOK = 0)

GO
/****** Object:  View [dbo].[L2_VALIDATION_PARTIELLE]    Script Date: 19/02/2019 18:26:48 ******/
DROP VIEW [dbo].[L2_VALIDATION_PARTIELLE]
GO
CREATE VIEW [dbo].[L2_VALIDATION_PARTIELLE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2.Numero, dbo.Livret2.ID AS IDLIVRET2, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateLimiteReceptEHESP, dbo.Livret2.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2.EtatLivret, dbo.Livret2.SessionJury, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DatePrevJury1, dbo.Livret2.isAttestationOK, dbo.Livret2.isCNIOK, dbo.Livret2.IsDispenseArt2, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, 
                         dbo.Juries.HeureConvoc, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance,
						 dbo.L2_DC_DECISION.DC1, dbo.L2_DC_DECISION.DC1_DATE,
						 dbo.L2_DC_DECISION.DC2, dbo.L2_DC_DECISION.DC2_DATE, 
                         dbo.L2_DC_DECISION.DC3, dbo.L2_DC_DECISION.DC3_DATE, 
						 dbo.L2_DC_DECISION.DC4,dbo.L2_DC_DECISION.DC4_DATE, 
						  dbo.Livret2.DateValidite
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID INNER JOIN
                         dbo.L2_DC_DECISION ON dbo.Livret2.ID = dbo.L2_DC_DECISION.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'70%') AND (dbo.Juries.Decision LIKE N'30-%')


GO
/****** Object:  View [dbo].[L2_VALIDATION_REFUSE]    Script Date: 19/02/2019 18:27:09 ******/
DROP VIEW [dbo].[L2_VALIDATION_REFUSE]
GO
CREATE VIEW [dbo].[L2_VALIDATION_REFUSE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2.Numero, dbo.Livret2.ID AS IDLIVRET2, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateLimiteReceptEHESP, dbo.Livret2.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2.EtatLivret, dbo.Livret2.SessionJury, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DatePrevJury1, dbo.Livret2.isAttestationOK, dbo.Livret2.isCNIOK, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, 
                         dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance, dbo.Livret2.DateValidite
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'50-%') AND (dbo.Juries.Decision LIKE N'20-%')

GO
/****** Object:  View [dbo].[L2_VALIDATION_TOTALE]    Script Date: 19/02/2019 18:27:28 ******/
DROP VIEW [dbo].[L2_VALIDATION_TOTALE]
GO
CREATE VIEW [dbo].[L2_VALIDATION_TOTALE]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret2.Numero, dbo.Livret2.ID AS IDLIVRET2, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateLimiteReceptEHESP, dbo.Livret2.DateReceptEHESP, dbo.Candidats.Pays, dbo.Livret2.EtatLivret, dbo.Livret2.SessionJury, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DatePrevJury1, dbo.Livret2.isAttestationOK, dbo.Livret2.isCNIOK, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, 
                         dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2 ON dbo.Candidats.ID = dbo.Livret2.Candidat_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.Livret2.EtatLivret LIKE N'40%')

GO