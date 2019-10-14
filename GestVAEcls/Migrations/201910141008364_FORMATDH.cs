namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FORMATDH : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "FORMATDH " + "start");

            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DECISION_DC]");
            Sql(@"DROP VIEW [dbo].[RQ_STATUT_DC_CAND]");

            Sql(@"CREATE VIEW [dbo].[RQ_STATUT_DC_CAND]
AS
SELECT        dbo.DiplomeCands.ID, dbo.DiplomeCands.Candidat_ID, dbo.DiplomeCands.Diplome_ID, dbo.DomaineCompetences.Nom, dbo.DomaineCompetenceCands.Statut, CONVERT(nvarchar, 
                         dbo.DomaineCompetenceCands.DateObtention, 103) AS DateObtention, dbo.DomaineCompetenceCands.ModeObtention, dbo.DomaineCompetences.Numero, dbo.Diplomes.Nom AS NomDiplome
FROM            dbo.DiplomeCands INNER JOIN
                         dbo.DomaineCompetenceCands ON dbo.DiplomeCands.ID = dbo.DomaineCompetenceCands.Diplome_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DomaineCompetenceCands.DomaineCompetence_ID = dbo.DomaineCompetences.ID INNER JOIN
                         dbo.Diplomes ON dbo.DiplomeCands.Diplome_ID = dbo.Diplomes.ID AND dbo.DomaineCompetences.Diplome_ID = dbo.Diplomes.ID
WHERE        (dbo.Diplomes.Nom = N'CAFDES')");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT        dbo.Livret2.Numero, CONVERT(nvarchar, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, dbo.DomaineCompetences.Nom, dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, 
                         dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(nvarchar, 
                         dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) 
                         AS DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, CONVERT(nvarchar, dbo.Juries.HeureJury, 8) AS HeureJury, CONVERT(nvarchar, dbo.Juries.HeureConvoc, 8) AS HeureConvoc, dbo.Juries.LieuJury, 
                         dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) AS DateNotificationJury, CONVERT(nvarchar, dbo.DCLivrets.DateObtention, 103) 
                         AS DateObtention, dbo.Livret2.ID AS IDLivret
FROM            dbo.Livret2 INNER JOIN
                         dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.DCLivrets.IsAValider = 1)");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT        dbo.Livret2.Numero, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, CONVERT(nvarchar, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         dbo.Candidats.Mail3 AS SituationParticuliere, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.bHandicap, CONVERT(nvarchar, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, 
                         dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, CONVERT(nvarchar, dbo.Livret2.Date1ereDemandePieceManquantes, 103) 
                         AS Date1ereDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.DateReceptionPiecesManquantes, 
                         103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, 
                         CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(nvarchar, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) 
                         AS DateReceptEHESP, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, dbo.Livret2.isClos, CONVERT(nvarchar, dbo.Juries.HeureJury, 8) AS HeureJury, CONVERT(nvarchar, 
                         dbo.Juries.HeureConvoc, 8) AS HeureConvoc, dbo.Juries.LieuJury, CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, CONVERT(nvarchar, dbo.Livret2.DateEnvoiCourrierJury, 103) 
                         AS DateEnvoiCourrierJury, CONVERT(nvarchar, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, CONVERT(nvarchar, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, CONVERT(nvarchar, dbo.Livret2.DateValidite, 103) 
                         AS DateValidite, CONVERT(nvarchar, dbo.Livret2.DateDemande1erRetour, 103) AS [DateDemande1erRetour], dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu, dbo.RQ_L2_PJ.Piecejointe,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 1)) AS STATUT_DC1,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_1
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 1)) AS DATE_OBTENTION_DC1,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_2
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 1)) AS MODE_OBTENTION_DC1,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_3
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 2)) AS STATUT_DC2,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_4
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 2)) AS DATE_OBTENTION_DC2,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_5
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 2)) AS MODE_OBTENTION_DC2,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_6
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 3)) AS STATUT_DC3,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_7
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 3)) AS DATE_OBTENTION_DC3,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_8
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 3)) AS MODE_OBTENTION_DC3,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_9
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS STATUT_DC4,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_10
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS DATE_OBTENTION_DC4,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_11
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS MODE_OBTENTION_DC4,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS DecisionDC1Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_3
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS DecisionDC2Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_2
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS DecisionDC3Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_1
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret
FROM            dbo.Livret2 INNER JOIN
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID LEFT OUTER JOIN
                         dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID");




            //Cette migration permet juste de fixer la Livraison
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "FORMATDH " + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "FORMATDH " + "start");
            //Cette migration permet juste de fixer la Livraison
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DECISION_DC]");
            Sql(@"DROP VIEW [dbo].[RQ_STATUT_DC_CAND]");

            Sql(@"CREATE VIEW [dbo].[RQ_STATUT_DC_CAND]
AS
SELECT        dbo.DiplomeCands.ID, dbo.DiplomeCands.Candidat_ID, dbo.DiplomeCands.Diplome_ID, dbo.DomaineCompetences.Nom, dbo.DomaineCompetenceCands.Statut, dbo.DomaineCompetenceCands.DateObtention, dbo.DomaineCompetenceCands.ModeObtention, dbo.DomaineCompetences.Numero, dbo.Diplomes.Nom AS NomDiplome
FROM            dbo.DiplomeCands INNER JOIN
                         dbo.DomaineCompetenceCands ON dbo.DiplomeCands.ID = dbo.DomaineCompetenceCands.Diplome_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DomaineCompetenceCands.DomaineCompetence_ID = dbo.DomaineCompetences.ID INNER JOIN
                         dbo.Diplomes ON dbo.DiplomeCands.Diplome_ID = dbo.Diplomes.ID AND dbo.DomaineCompetences.Diplome_ID = dbo.Diplomes.ID
WHERE        (dbo.Diplomes.Nom = N'CAFDES')");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT        dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.DomaineCompetences.Nom, dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, 
                         dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, 
                         dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury, dbo.DCLivrets.DateObtention, dbo.Livret2.ID AS IDLivret
FROM            dbo.Livret2 INNER JOIN
                         dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.DCLivrets.IsAValider = 1)");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT        dbo.Livret2.Numero, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         dbo.Candidats.Mail3 AS SituationParticuliere, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Juries.DateJury, dbo.Juries.Decision, 
                         dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, dbo.Livret2.Date1ereDemandePieceManquantes, dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, 
                         dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.DateNotificationJury, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Livret2.DateDemande1erRetour, dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu, dbo.RQ_L2_PJ.Piecejointe,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 1)) AS STATUT_DC1,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_1
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 1)) AS DATE_OBTENTION_DC1,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_2
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 1)) AS MODE_OBTENTION_DC1,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_3
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 2)) AS STATUT_DC2,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_4
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 2)) AS DATE_OBTENTION_DC2,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_5
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 2)) AS MODE_OBTENTION_DC2,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_6
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 3)) AS STATUT_DC3,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_7
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 3)) AS DATE_OBTENTION_DC3,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_8
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 3)) AS MODE_OBTENTION_DC3,
                             (SELECT        Statut
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_9
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS STATUT_DC4,
                             (SELECT        DateObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_10
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS DATE_OBTENTION_DC4,
                             (SELECT        ModeObtention
                               FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_11
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS MODE_OBTENTION_DC4,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS DecisionDC1Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_3
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS DecisionDC2Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_2
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS DecisionDC3Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_1
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret
FROM            dbo.Livret2 INNER JOIN
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID LEFT OUTER JOIN
                         dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "FORMATDH " + "End");
        }
    }
}
