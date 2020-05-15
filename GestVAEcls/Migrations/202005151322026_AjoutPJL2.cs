namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutPJL2 : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutPJL2" + "Start");

            Sql(@"DROP VIEW RQ_L2_DOC");

            Sql(@"CREATE VIEW[dbo].[RQ_L2_DOC]
            AS
            SELECT        choose(dbo.Livret2.IsConvention + 1, 'Non', 'Oui') AS Isconvention, choose(dbo.Livret2.isContrat + 1, 'Non', 'Oui') AS iscontrat, choose(dbo.Livret2.IsPaye + 1, 'Non', 'Oui') AS IsPaye, dbo.Livret2.Numero, 
                         dbo.Livret2.NumPassage, dbo.Candidats.Civilite, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, 
                         dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Nationalite, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         choose(dbo.Candidats.Sexe + 1, 'H', 'F') AS sexe, CONVERT(smalldatetime, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, CONVERT(smalldatetime, dbo.Livret2.DateValidite, 103) AS DateValidite, choose(dbo.Candidats.bHandicap + 1, 'Non', 'Oui') AS bHandicap, CONVERT(smalldatetime, 
                         dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESPComplet, 103) 
                         AS DateReceptEHESPComplet, CONVERT(smalldatetime, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, choose(dbo.Livret2.IsCNIOK + 1, 'Non', 'Oui') AS IsCNIOK, choose(dbo.Livret2.IsAttestationOK + 1, 'Non', 'Oui') 
                         AS IsAttestationOK, dbo.Livret2.EtatLivret, CONVERT(smalldatetime, dbo.Livret2.DateDemande, 103) AS DateDemande, CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, 
                         CONVERT(smalldatetime, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante, dbo.Livret2.SessionJury, CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS DateJury, 
                         FORMAT(dbo.Juries.HeureJury, N'HH\hmm') AS HeureJury, FORMAT(dbo.Juries.HeureConvoc, N'HH\hmm') AS HeureConvoc, dbo.Juries.LieuJury, CONVERT(smalldatetime, dbo.Juries.DateNotificationJury, 103) 
                         AS dateNotificationJury, CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, CONVERT(smalldatetime, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, CONVERT(smalldatetime, 
                         dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, dbo.Juries.Decision,
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
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_4
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS ISAValiderDC1Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_3
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS ISAValiderDC2Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_2
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS ISAValiderDC3Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_1
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS ISAValiderDC4Livret,
                             (SELECT        PropositionDecision
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_1
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS PropositionDC1Livret,
                             (SELECT        PropositionDecision
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_2
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS PropositionDC2Livret,
                             (SELECT        PropositionDecision
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_3
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS PropositionDC3Livret,
                             (SELECT        PropositionDecision
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_4
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS PropositionDC4Livret, dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR, choose(dbo.Candidats.ISPostFormation + 1, 'Non', 'Oui') 
                         AS IsPostFormation, choose(dbo.Livret2.isClos + 1, 'Non', 'Oui') AS isClos, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Non', 'Oui') AS IsDispenseArt2, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Non', 'Oui') AS IsOuvertureApresRecours, choose(dbo.Livret2.IsTrtSpecial + 1, 'Non', 'Oui') AS IsTrtSpecial, choose(dbo.Livret2.IsNonRecu + 1, 'Non', 'Oui') AS Isnonrecu, 
                         choose(dbo.Livret2.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, CONVERT(smalldatetime, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, CONVERT(smalldatetime, 
                         dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, dbo.RQ_L2_PJ.Piecejointe
        FROM            dbo.Livret2 
                        INNER JOIN dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID 
                        INNER JOIN dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID 
                        LEFT OUTER JOIN dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID 
                        LEFT OUTER JOIN dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
");


            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutPJL2" + "Start");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutPJL2" + "Start");

            Sql(@"DROP VIEW RQ_L2_DOC");

            Sql(@"CREATE VIEW[dbo].[RQ_L2_DOC]
            AS
            SELECT        
            choose(dbo.Livret2.IsConvention + 1, 'Non', 'Oui') AS Isconvention, 
            choose(dbo.Livret2.isContrat + 1, 'Non', 'Oui') AS iscontrat, 
            choose(dbo.Livret2.IsPaye + 1, 'Non', 'Oui') AS IsPaye, 
            dbo.Livret2.Numero,
            dbo.Livret2.NumPassage, 
            dbo.Candidats.Civilite, 
            dbo.Candidats.NomJeuneFille, 
            dbo.Candidats.Nom, 
            dbo.Candidats.Prenom, 
            dbo.Candidats.Prenom2, 
            dbo.Candidats.Prenom3, 
            dbo.Candidats.Adresse, 
            dbo.Candidats.CodePostal, 
            dbo.Candidats.Ville, 
            dbo.Candidats.Region, 
            dbo.Candidats.Pays, 
            dbo.Candidats.Nationalite,
            dbo.Candidats.Tel1, 
            dbo.Candidats.Tel2, 
            dbo.Candidats.Tel3, 
            dbo.Candidats.Mail1, 
            dbo.Candidats.Mail2, 
            choose(dbo.Candidats.Sexe + 1, 'H', 'F') AS sexe, 
            CONVERT(smalldatetime, dbo.Candidats.DateNaissance, 103) AS DateNaissance, 
            dbo.Candidats.VilleNaissance, 
            dbo.Candidats.NationaliteNaissance, 
            dbo.Candidats.DptNaissance, 
            dbo.Candidats.PaysNaissance, 
            CONVERT(smalldatetime, dbo.Livret2.DateValidite, 103) AS DateValidite, 
            choose(dbo.Candidats.bHandicap + 1, 'Non', 'Oui') AS bHandicap, 
            CONVERT(smalldatetime, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, 
            CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, 
            CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, 
            CONVERT(smalldatetime, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, 
            choose(dbo.Livret2.IsCNIOK + 1, 'Non', 'Oui') AS IsCNIOK, 
            choose(dbo.Livret2.IsAttestationOK + 1, 'Non', 'Oui') AS IsAttestationOK, 
            dbo.Livret2.EtatLivret, 
            CONVERT(smalldatetime, dbo.Livret2.DateDemande, 103) AS DateDemande, 
            CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP,
            CONVERT(smalldatetime, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante,
            dbo.Livret2.SessionJury, 
            CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS DateJury, 
            FORMAT(dbo.Juries.HeureJury, N'HH\hmm') AS HeureJury, 
            FORMAT(dbo.Juries.HeureConvoc, N'HH\hmm') AS HeureConvoc, 
            dbo.Juries.LieuJury, 
            CONVERT(smalldatetime, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, 
            CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, 
            CONVERT(smalldatetime, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, 
            CONVERT(smalldatetime, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, 
            dbo.Juries.Decision, 
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
            WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret,
            (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
            FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_4
            WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS ISAValiderDC1Livret,
            (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
            FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_3
            WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS ISAValiderDC2Livret,
            (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
            FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_2
            WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS ISAValiderDC3Livret,
            (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1
            FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_1
            WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS ISAValiderDC4Livret,
            dbo.DiplomeCands.NumeroDiplome, 
            dbo.DiplomeCands.NumeroEURODIR,
            choose(dbo.Candidats.IsPostFormation + 1, 'Non', 'Oui') AS IsPostFormation, 
            choose(dbo.Livret2.isClos + 1, 'Non', 'Oui') AS isClos, 
            choose(dbo.Livret2.IsDispenseArt2 + 1, 'Non', 'Oui') AS IsDispenseArt2, 
            dbo.Candidats.ID, 
            dbo.Candidats.IdVAE, 
            dbo.Candidats.IdSiscole,
            choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Non', 'Oui') AS IsOuvertureApresRecours, 
            choose(dbo.Livret2.IsTrtSpecial + 1, 'Non', 'Oui') AS IsTrtSpecial,
            choose(dbo.Livret2.IsNonRecu + 1, 'Non', 'Oui') AS Isnonrecu, 
            choose(dbo.Livret2.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, 
            CONVERT(smalldatetime, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, 
            CONVERT(smalldatetime, dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes,
            CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour 

            FROM            dbo.Livret2 INNER JOIN
                                     dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                                     dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID LEFT OUTER JOIN
                                     dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutPJL2" + "Start");
        }
    }
}
