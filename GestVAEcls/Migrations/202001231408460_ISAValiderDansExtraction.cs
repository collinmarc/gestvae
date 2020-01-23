namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISAValiderDansExtraction : DbMigration
    {
        public override void Up()
        {
            // ajout de IsAvalider1234
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT        choose(dbo.Livret2.isContrat + 1, 'Faux', 'Vrai') AS iscontrat, choose(dbo.Livret2.IsConvention + 1, 'Faux', 'Vrai') AS Isconvention, choose(dbo.Livret2.IsNonRecu + 1, 'Faux', 'Vrai') AS Isnonrecu, 
                         choose(dbo.Livret2.IsEnregistre + 1, 'Faux', 'Vrai') AS IsEnregistre, choose(dbo.Livret2.IsPaye + 1, 'Faux', 'Vrai') AS IsPaye, choose(dbo.Livret2.IsTrtSpecial + 1, 'Faux', 'Vrai') AS IsTrtSpecial, dbo.Livret2.Numero, 
                         dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, choose(dbo.Candidats.Sexe + 1, 'H', 'F') AS sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, 
                         dbo.Candidats.IdSiscole, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, CONVERT(nvarchar, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, 
                         dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, 
                         dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, choose(dbo.Candidats.bHandicap + 1, 'Faux', 'Vrai') AS bHandicap, CONVERT(nvarchar, dbo.Juries.DateJury, 103) 
                         AS DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Vrai', 'Faux') AS IsOuvertureApresRecours, CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, 
                         CONVERT(nvarchar, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.Date2emeDemandePieceManquantes, 103) 
                         AS Date2emeDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, choose(dbo.Livret2.IsAttestationOK + 1, 'Faux', 
                         'Vrai') AS IsAttestationOK, choose(dbo.Livret2.IsCNIOK + 1, 'Faux', 'Vrai') AS IsCNIOK, CONVERT(nvarchar, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Faux', 'Vrai') 
                         AS IsDispenseArt2,  dbo.Livret2.EtatLivret, CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(nvarchar, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat,
                          CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, choose(dbo.Livret2.isClos + 1, 'Faux', 'Vrai') 
                         AS isClos, FORMAT(dbo.Juries.HeureJury, N'hh:mm') AS HeureJury, FORMAT(dbo.Juries.HeureConvoc, N'hh:mm') AS HeureConvoc, dbo.Juries.LieuJury, CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) 
                         AS dateNotificationJury, CONVERT(nvarchar, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, CONVERT(nvarchar, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, CONVERT(nvarchar, 
                         dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, CONVERT(nvarchar, dbo.Livret2.DateValidite, 103) AS DateValidite, CONVERT(nvarchar, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, 
                         dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR,
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
                             (SELECT        choose(IsAValider + 1, 'Faux', 'Vrai')
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS ISAValiderDC1Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_3
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS DecisionDC2Livret,
                             (SELECT        choose(IsAValider + 1, 'Faux', 'Vrai')
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS ISAValiderDC2Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_2
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS DecisionDC3Livret,
                             (SELECT        choose(IsAValider + 1, 'Faux', 'Vrai')
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS ISAValiderDC3Livret,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_1
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret,
                             (SELECT        choose(IsAValider + 1, 'Faux', 'Vrai')
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS ISAValiderDC4Livret
FROM            dbo.Livret2 INNER JOIN
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                         dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
");

        }

        public override void Down()
        {
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT        choose(dbo.Livret2.isContrat + 1, 'Faux', 'Vrai') AS iscontrat, choose(dbo.Livret2.IsConvention + 1, 'Faux', 'Vrai') AS Isconvention, choose(dbo.Livret2.IsNonRecu + 1, 'Faux', 'Vrai') AS Isnonrecu, 
                         choose(dbo.Livret2.IsEnregistre + 1, 'Faux', 'Vrai') AS IsEnregistre, choose(dbo.Livret2.IsPaye + 1, 'Faux', 'Vrai') AS IsPaye, choose(dbo.Livret2.IsTrtSpecial + 1, 'Faux', 'Vrai') AS IsTrtSpecial, dbo.Livret2.Numero, 
                         dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, choose(dbo.Candidats.Sexe + 1, 'H', 'F') AS sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, 
                         dbo.Candidats.IdSiscole, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, CONVERT(nvarchar, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, 
                         dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, 
                         dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, choose(dbo.Candidats.bHandicap + 1, 'Faux', 'Vrai') AS bHandicap, CONVERT(nvarchar, dbo.Juries.DateJury, 103) 
                         AS DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Vrai', 'Faux') AS IsOuvertureApresRecours, CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, 
                         CONVERT(nvarchar, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.Date2emeDemandePieceManquantes, 103) 
                         AS Date2emeDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, choose(dbo.Livret2.IsAttestationOK + 1, 'Faux', 
                         'Vrai') AS IsAttestationOK, choose(dbo.Livret2.IsCNIOK + 1, 'Faux', 'Vrai') AS IsCNIOK, CONVERT(nvarchar, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Faux', 'Vrai') 
                         AS IsDispenseArt2,  dbo.Livret2.EtatLivret, CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(nvarchar, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat,
                          CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, choose(dbo.Livret2.isClos + 1, 'Faux', 'Vrai') 
                         AS isClos, FORMAT(dbo.Juries.HeureJury, N'hh:mm') AS HeureJury, FORMAT(dbo.Juries.HeureConvoc, N'hh:mm') AS HeureConvoc, dbo.Juries.LieuJury, CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) 
                         AS dateNotificationJury, CONVERT(nvarchar, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, CONVERT(nvarchar, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, CONVERT(nvarchar, 
                         dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, CONVERT(nvarchar, dbo.Livret2.DateValidite, 103) AS DateValidite, CONVERT(nvarchar, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, 
                         dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR,
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
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                         dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
");

        }
    }
}
