USE [GESTVAE]
GO

/****** Object:  View [dbo].[RQ_LIVRET1]    Script Date: 15/01/2019 12:18:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[RQ_LIVRET1]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Sexe, dbo.Candidats.IdVAE, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationnalite, dbo.Candidats.Region, dbo.Candidats.RegionTravail, 
                         dbo.Livret1.Numero, dbo.Livret1.DateDemande, dbo.Livret1.EtatLivret, dbo.Recours.DateDepot, dbo.Recours.TypeRecours, dbo.Recours.MotifRecours, dbo.Recours.Decision, dbo.Diplomes.Nom AS Expr1, 
                         dbo.Livret1.OrigineDemande, dbo.Livret1.TypeDemande
FROM            dbo.Candidats INNER JOIN
                         dbo.Livret1 ON dbo.Candidats.ID = dbo.Livret1.oCandidat_ID INNER JOIN
                         dbo.Diplomes ON dbo.Livret1.oDiplome_ID = dbo.Diplomes.ID LEFT OUTER JOIN
                         dbo.Recours ON dbo.Livret1.ID = dbo.Recours.oLivret_ID AND dbo.Livret1.ID = dbo.Recours.oLivret_ID

GO