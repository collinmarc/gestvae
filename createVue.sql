USE [GESTVAE]
GO

/****** Object:  View [dbo].[L1_RECUS_COMPLETS]    Script Date: 19/02/2019 18:22:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP VIEW [dbo].[Livret1_NonClos]
GO
CREATE VIEW [dbo].[Livret1_NonClos]
AS
SELECT        dbo.Livret1.*
FROM            dbo.Livret1
WHERE        (isClos = 0)
GO

DROP VIEW [dbo].[Livret2_NonClos]
GO
CREATE VIEW [dbo].[Livret2_NonClos]
AS
SELECT        dbo.Livret2.*
FROM            dbo.Livret2
WHERE        (isClos = 0)
GO

DROP VIEW [dbo].[L1_RECUS_COMPLETS]
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


/****** Object:  View [dbo].[L1_RECUS_INCOMPLETS]    Script Date: 19/02/2019 18:23:07 ******/

DROP VIEW [dbo].[L1_RECUS_INCOMPLETS]
GO
CREATE VIEW [dbo].[L1_RECUS_INCOMPLETS]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Adresse, dbo.Livret1_NonClos.ID AS IDLIVRET1, dbo.Livret1_NonClos.Numero, dbo.Livret1_NonClos.DateReceptEHESP, 
                         dbo.Livret1_NonClos.DateLimiteReceptEHESP, dbo.Livret1_NonClos.EtatLivret, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, dbo.Livret1_NonClos.DateDemandePieceManquantesRetour
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1_NonClos ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID
WHERE        (dbo.Livret1_NonClos.EtatLivret LIKE N'30%')

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
/****** Object:  View [dbo].[L1_VALIDATION_APRESRECOURS]    Script Date: 19/02/2019 18:23:56 ******/
DROP VIEW [dbo].[L1_VALIDATION_APRESRECOURS]
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
/****** Object:  View [dbo].[L1_VALIDATION_REFUSE]    Script Date: 19/02/2019 18:24:20 ******/
DROP VIEW [dbo].[L1_VALIDATION_REFUSE]
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
/****** Object:  View [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]    Script Date: 19/02/2019 18:24:35 ******/
DROP VIEW [dbo].[L1_VALIDATION_REFUSE_APRESRECOURS]
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
/****** Object:  View [dbo].[L2_DC]    Script Date: 19/02/2019 18:24:52 ******/

DROP VIEW [dbo].[L2_DC]
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
/****** Object:  View [dbo].[L2_DC_DECISION]    Script Date: 19/02/2019 18:25:09 ******/
DROP VIEW [dbo].[L2_DC_DECISION]
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

/****** Object:  View [dbo].[L2_RECUS_COMPLETS]    Script Date: 19/02/2019 18:25:23 ******/
DROP VIEW [dbo].[L2_RECUS_COMPLETS]
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

/****** Object:  View [dbo].[L2_RECUS_COMPLETS_DC]    Script Date: 19/02/2019 18:25:39 ******/
DROP VIEW [dbo].[L2_RECUS_COMPLETS_DC]
GO
CREATE VIEW [dbo].[L2_RECUS_COMPLETS_DC]
AS
SELECT        dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom3, dbo.Candidats.Prenom2, dbo.Livret2_NonClos.Numero, dbo.Livret2_NonClos.EtatLivret, dbo.L2_DC.DC1, dbo.L2_DC.DC2, dbo.L2_DC.DC3, dbo.L2_DC.DC4
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret2_NonClos ON dbo.Candidats.ID = dbo.Livret2_NonClos.Candidat_ID INNER JOIN
                         dbo.L2_DC ON dbo.Livret2_NonClos.ID = dbo.L2_DC.ID
WHERE        (dbo.Livret2_NonClos.EtatLivret LIKE N'40-%')

GO
/****** Object:  View [dbo].[L2_RECUS_COMPLETS_JURY]    Script Date: 19/02/2019 18:25:54 ******/
DROP VIEW [dbo].[L2_RECUS_COMPLETS_JURY]
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
/****** Object:  View [dbo].[L2_RECUS_INCOMPLETS]    Script Date: 19/02/2019 18:26:16 ******/
DROP VIEW [dbo].[L2_RECUS_INCOMPLETS]
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
/****** Object:  View [dbo].[L2_VALIDATION_REFUSE]    Script Date: 19/02/2019 18:27:09 ******/
DROP VIEW [dbo].[L2_VALIDATION_REFUSE]
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
/****** Object:  View [dbo].[L2_VALIDATION_TOTALE]    Script Date: 19/02/2019 18:27:28 ******/
DROP VIEW [dbo].[L2_VALIDATION_TOTALE]
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

DROP VIEW [dbo].[RQ_L1_STAT]
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

DROP VIEW [dbo].[RQ_L2_STAT]
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

DROP VIEW [dbo].[RQ_L2_DECISION_DC]
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