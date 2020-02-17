namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryConvert : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "TRYTRY_CONVERT " + "start");


            Sql(@"UPDATE Livret2 
                    SET DateValidite = DATEADD(year,3,dateDemande)
                    WHERE YEAR(DateValidite) >2030");

            Sql(@"UPDATE Livret1 
                    SET ISCONTRAT = 0 
                    where ISCONTRAT IS NULL");
            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");

            Sql(@"DROP VIEW [dbo].[RQ_L1_STAT]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_STAT]");
            //================ RQ_L1-DOC
            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
AS
SELECT        
choose(dbo.Livret1_NonClos.isContrat + 1, 'Non', 'Oui') AS IsContrat,
choose(dbo.Livret1_NonClos.IsConvention + 1, 'Non', 'Oui') AS IsConvention, 
choose(dbo.Livret1_NonClos.IsNonRecu + 1, 'Non', 'Oui') AS IsNonRecu, 
Choose(dbo.Livret1_NonClos.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, 
Choose(dbo.Livret1_NonClos.IsPaye + 1, 'Non', 'Oui') AS IsPaye, 
dbo.Livret1_NonClos.Numero AS NumeroLivret, 
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
choose(dbo.Candidats.Sexe + 1, 'F', 'H') AS Sexe, 
TRY_CONVERT(smalldatetime,dbo.Candidats.DateNaissance, 103) AS DateNaissance, 
dbo.Candidats.VilleNaissance, 
dbo.Candidats.DptNaissance, 
dbo.Candidats.PaysNaissance, 
dbo.Candidats.NationaliteNaissance, 
TRY_CONVERT(smalldatetime,dbo.Livret1_NonClos.DateDemande, 103)  AS DateDemande, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, 
TRY_CONVERT(smalldatetime,dbo.Candidats.dateCreation ,103 ) AS dateCreation, 
dbo.Livret1_NonClos.TypeDemande, 
dbo.Livret1_NonClos.VecteurInformation, 
dbo.Candidats.Mail3 AS [Situation Particulière], 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateReceptEHESP, 103) AS [date reception], 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateReceptEHESPComplet, 103) AS [Date courrier completude], 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquantes, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateDemande1erRetour, 103) AS DateDemande1erRetour, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes,103) AS Date2emeDemandePieceManquantes, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateDemande2emeRetour, 103) AS DateDemande2emeRetour, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, 
dbo.RQ_L1_PJ.Piecejointe, 
dbo.Livret1_NonClos.EtatLivret, 
TRY_CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS [Date Recevabilité], 
dbo.Juries.Decision, 
TRY_CONVERT(smalldatetime, dbo.Juries.DateLimiteRecours, 103) AS DateLimiteRecours, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateValidite, 103) AS DateValidite, 
choose(dbo.Juries.IsRecours + 1, 'Non', 'Oui') AS IsRecours, 
TRY_CONVERT(smalldatetime, dbo.Recours.DateDepot, 103) AS DateDepotRecours, 
choose(dbo.Recours.TypeRecours + 1, 'Gracieux', 'Contentieux') AS TypeRecours, 
dbo.Juries.MotifGeneral AS [Motif du recours], 
dbo.Juries.MotifCommentaire, 
TRY_CONVERT(smalldatetime, dbo.Juries.DateNotificationJuryRecours, 103) AS DateNotificationJuryRecours, 
dbo.Recours.Decision AS DecisionRecours, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateEnvoiL2, 103) AS DateEnvoiL2, 
choose(dbo.Candidats.bHandicap + 1, 'Non', 'Oui') AS bHandicap, 
dbo.Candidats.ID, 
dbo.Livret1_NonClos.ID AS IDLivret1, 
dbo.Candidats.IdVAE, 
dbo.Candidats.IdSiscole, 
choose(dbo.Livret1_NonClos.isClos + 1, 'Non', 'Oui') AS isClos, 
choose(dbo.Livret1_NonClos.IsCNIOK + 1, 'Non', 'Oui') AS isCNIOK, 
TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateValiditeCNI, 103) AS DateValiditeCNI

FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID INNER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
");

            //================================== RQ_L2_DOC
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
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
            TRY_CONVERT(smalldatetime, dbo.Candidats.DateNaissance, 103) AS DateNaissance, 
            dbo.Candidats.VilleNaissance, 
            dbo.Candidats.NationaliteNaissance, 
            dbo.Candidats.DptNaissance, 
            dbo.Candidats.PaysNaissance, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateValidite, 103) AS DateValidite, 
            choose(dbo.Candidats.bHandicap + 1, 'Non', 'Oui') AS bHandicap, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, 
            choose(dbo.Livret2.IsCNIOK + 1, 'Non', 'Oui') AS IsCNIOK, 
            choose(dbo.Livret2.IsAttestationOK + 1, 'Non', 'Oui') AS IsAttestationOK, 
            dbo.Livret2.EtatLivret, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateDemande, 103) AS DateDemande, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP,
            TRY_CONVERT(smalldatetime, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante,
            dbo.Livret2.SessionJury, 
            TRY_CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS DateJury, 
            FORMAT(dbo.Juries.HeureJury, N'HH:mm') AS HeureJury, 
            FORMAT(dbo.Juries.HeureConvoc, N'HH:mm') AS HeureConvoc, 
            dbo.Juries.LieuJury, 
            TRY_CONVERT(smalldatetime, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, 
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
            choose(dbo.Livret2.isClos + 1, 'Non', 'Oui') AS isClos, 
            choose(dbo.Livret2.IsDispenseArt2 + 1, 'Non', 'Oui') AS IsDispenseArt2, 
            dbo.Candidats.ID, 
            dbo.Candidats.IdVAE, 
            dbo.Candidats.IdSiscole,
            choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Non', 'Oui') AS IsOuvertureApresRecours, 
            choose(dbo.Livret2.IsTrtSpecial + 1, 'Non', 'Oui') AS IsTrtSpecial,
            choose(dbo.Livret2.IsNonRecu + 1, 'Non', 'Oui') AS Isnonrecu, 
            choose(dbo.Livret2.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, 
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes,
            TRY_CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour 

            FROM            dbo.Livret2 INNER JOIN
                                     dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                                     dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID LEFT OUTER JOIN
                                     dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
            ");
            // =============================== RQ_L1_STAT

            Sql(@"
            CREATE VIEW [dbo].[RQ_L1_STAT]
            AS
            SELECT  choose(dbo.Livret1.isContrat+1,'Non','Oui') as IsContrat, 
                    choose(dbo.Livret1.IsConvention+1,'Non','Oui') as IsConvention,
                    choose(dbo.Livret1.IsNonRecu+1,'Non','Oui') as IsNonRecu, 
                    dbo.Livret1.Numero AS NumeroLivret, 
                    dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Nationalite, 
                    choose(dbo.Candidats.Sexe+1,'F','H') as Sexe, 
                    TRY_CONVERT(smalldatetime,dbo.Candidats.DateNaissance,103) as DateNaissance, 
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateDemande,103) as DateDemande, 
                    YEAR(dbo.Livret1.DateDemande) AS ANNEE, DATENAME(month, dbo.Livret1.DateDemande) AS MOIS, DATENAME(day, dbo.Livret1.DateDemande) AS JOUR, 
                                     FLOOR(DATENAME(day, dbo.Livret1.DateDemande) / 16) + 1 AS QUINZAINE, DATENAME(quarter, dbo.Livret1.DateDemande) AS TRIMESTRE,
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateEnvoiEHESP,103) as DateEnvoiEHESP, 
                    TRY_CONVERT(smalldatetime,dbo.Candidats.dateCreation,103) as dateCreation, 
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateReceptEHESP,103) AS [date reception], 
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateReceptEHESPComplet,103) as [Date courrier completude],
                    TRY_CONVERT(smalldatetime,dbo.Livret1.Date1ereDemandePieceManquantes, 103) as Date1ereDemandePieceManquantes,
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateDemande1erRetour, 103) as DateDemande1erRetour,
                    TRY_CONVERT(smalldatetime,dbo.Livret1.Date2emeDemandePieceManquantes, 103) as Date2emeDemandePieceManquantes,
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateDemande2emeRetour, 103) as DateDemande2emeRetour,
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateReceptionPiecesManquantes, 103) as DateReceptionPiecesManquantes,
                    TRY_CONVERT(smalldatetime,dbo.Juries.DateJury ,103) AS [Date Recevabilité],
                    dbo.Juries.Decision, 
                    TRY_CONVERT(smalldatetime,dbo.Juries.DateLimiteRecours, 103) as DateLimiteRecours,
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateValidite, 103) as DateValidite,
                    choose(dbo.Juries.IsRecours+1,'Non','Oui') as IsRecours, 
                    TRY_CONVERT(smalldatetime,dbo.Recours.DateDepot , 103) as DateDepotRecours,
                    choose(dbo.Recours.TypeRecours+1,'Gracieux','Contentieux') as TypeRecours, 
                    dbo.Juries.MotifGeneral AS [Motif du recours], dbo.Juries.MotifCommentaire, 
                    TRY_CONVERT(smalldatetime,dbo.Juries.DateNotificationJuryRecours, 103) as DateNotificationJuryRecours,
                    dbo.Recours.Decision AS DecisionRecours, 
                    TRY_CONVERT(smalldatetime,dbo.Livret1.DateEnvoiL2, 103) as DateEnvoiL2,
                    choose (dbo.Candidats.bHandicap+1,'Oui','Non') as bHandicap, 
                    dbo.Candidats.ID, dbo.Livret1.ID AS IDLivret1,dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                    choose(dbo.Livret1.isClos+1,'Oui','Non') as isClos
            FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                                     dbo.Livret1 ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1.ID RIGHT OUTER JOIN
                                     dbo.Candidats ON dbo.Livret1.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                                     dbo.Juries LEFT OUTER JOIN
                                     dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1.ID = dbo.Juries.Livret1_ID

            ");

            Sql(@"
            CREATE VIEW [dbo].[RQ_L2_STAT]
            AS
            SELECT        choose(dbo.Livret2.isContrat + 1, 'Faux', 'Vrai') AS iscontrat, choose(dbo.Livret2.IsConvention + 1, 'Faux', 'Vrai') AS Isconvention, choose(dbo.Livret2.IsNonRecu + 1, 'Faux', 'Vrai') AS Isnonrecu, choose(dbo.Candidats.Sexe + 1, 
                                     'F', 'H') AS sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, dbo.Candidats.Nationalite, TRY_CONVERT(smalldatetime, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, 
                                     dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, 
                                     choose(dbo.Candidats.bHandicap + 1, 'Faux', 'Vrai') AS bHandicap, TRY_CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, dbo.Livret2.Numero, dbo.Livret2.NumPassage, 
                                     choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Faux', 'Vrai') AS IsOuvertureApresRecours, TRY_CONVERT(smalldatetime, dbo.Livret2.DateDemande, 103) AS DateDemande, TRY_CONVERT(smalldatetime, 
                                     dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, TRY_CONVERT(smalldatetime, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante, 
                                     TRY_CONVERT(smalldatetime, dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, choose(dbo.Livret2.IsAttestationOK + 1, 'Faux', 'Vrai') AS IsAttestationOK, 
                                     choose(dbo.Livret2.IsCNIOK + 1, 'Faux', 'Vrai') AS IsCNIOK, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Faux', 'Vrai') AS IsDispenseArt2,  dbo.Livret2.EtatLivret, TRY_CONVERT(smalldatetime, 
                                     dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, TRY_CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, TRY_CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, 
                                     TRY_CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, choose(dbo.Livret2.isClos + 1, 'Faux', 'Vrai') AS isClos, FORMAT(dbo.Juries.HeureJury, N'hh:mm') AS HeureJury, 
                                     FORMAT(dbo.Juries.HeureConvoc, N'hh:mm') AS HeureConvoc, dbo.Juries.LieuJury, TRY_CONVERT(smalldatetime, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, TRY_CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCourrierJury, 
                                     103) AS DateEnvoiCourrierJury, TRY_CONVERT(smalldatetime, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, TRY_CONVERT(smalldatetime, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, TRY_CONVERT(smalldatetime, dbo.Livret2.DateValidite, 103)
                                      AS DateValidite, TRY_CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour,
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
                                           WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret, dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR
            FROM            dbo.Livret2 INNER JOIN
                                     dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                                     dbo.Diplomes ON dbo.Livret2.Diplome_ID = dbo.Diplomes.ID INNER JOIN
                                     dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Diplomes.ID = dbo.DiplomeCands.Diplome_ID LEFT OUTER JOIN
                                     dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
            ");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "TRYTRY_CONVERT " + "end");
    }

    public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "TRYCONVERT " + "start");

            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");

            Sql(@"DROP VIEW [dbo].[RQ_L1_STAT]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_STAT]");
            //================ RQ_L1-DOC
            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
AS
SELECT        
choose(dbo.Livret1_NonClos.isContrat + 1, 'Non', 'Oui') AS IsContrat,
choose(dbo.Livret1_NonClos.IsConvention + 1, 'Non', 'Oui') AS IsConvention, 
choose(dbo.Livret1_NonClos.IsNonRecu + 1, 'Non', 'Oui') AS IsNonRecu, 
Choose(dbo.Livret1_NonClos.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, 
Choose(dbo.Livret1_NonClos.IsPaye + 1, 'Non', 'Oui') AS IsPaye, 
dbo.Livret1_NonClos.Numero AS NumeroLivret, 
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
choose(dbo.Candidats.Sexe + 1, 'F', 'H') AS Sexe, 
CONVERT(smalldatetime,dbo.Candidats.DateNaissance, 103) AS DateNaissance, 
dbo.Candidats.VilleNaissance, 
dbo.Candidats.DptNaissance, 
dbo.Candidats.PaysNaissance, 
dbo.Candidats.NationaliteNaissance, 
CONVERT(smalldatetime,dbo.Livret1_NonClos.DateDemande, 103)  AS DateDemande, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, 
CONVERT(smalldatetime,dbo.Candidats.dateCreation ,103 ) AS dateCreation, 
dbo.Livret1_NonClos.TypeDemande, 
dbo.Livret1_NonClos.VecteurInformation, 
dbo.Candidats.Mail3 AS [Situation Particulière], 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateReceptEHESP, 103) AS [date reception], 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateReceptEHESPComplet, 103) AS [Date courrier completude], 
CONVERT(smalldatetime, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquantes, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateDemande1erRetour, 103) AS DateDemande1erRetour, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes,103) AS Date2emeDemandePieceManquantes, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateDemande2emeRetour, 103) AS DateDemande2emeRetour, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, 
dbo.RQ_L1_PJ.Piecejointe, 
dbo.Livret1_NonClos.EtatLivret, 
CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS [Date Recevabilité], 
dbo.Juries.Decision, 
CONVERT(smalldatetime, dbo.Juries.DateLimiteRecours, 103) AS DateLimiteRecours, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateValidite, 103) AS DateValidite, 
choose(dbo.Juries.IsRecours + 1, 'Non', 'Oui') AS IsRecours, 
CONVERT(smalldatetime, dbo.Recours.DateDepot, 103) AS DateDepotRecours, 
choose(dbo.Recours.TypeRecours + 1, 'Gracieux', 'Contentieux') AS TypeRecours, 
dbo.Juries.MotifGeneral AS [Motif du recours], 
dbo.Juries.MotifCommentaire, 
CONVERT(smalldatetime, dbo.Juries.DateNotificationJuryRecours, 103) AS DateNotificationJuryRecours, 
dbo.Recours.Decision AS DecisionRecours, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateEnvoiL2, 103) AS DateEnvoiL2, 
choose(dbo.Candidats.bHandicap + 1, 'Non', 'Oui') AS bHandicap, 
dbo.Candidats.ID, 
dbo.Livret1_NonClos.ID AS IDLivret1, 
dbo.Candidats.IdVAE, 
dbo.Candidats.IdSiscole, 
choose(dbo.Livret1_NonClos.isClos + 1, 'Non', 'Oui') AS isClos, 
choose(dbo.Livret1_NonClos.IsCNIOK + 1, 'Non', 'Oui') AS isCNIOK, 
CONVERT(smalldatetime, dbo.Livret1_NonClos.DateValiditeCNI, 103) AS DateValiditeCNI

FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID RIGHT OUTER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
");

            //================================== RQ_L2_DOC
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
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
            FORMAT(dbo.Juries.HeureJury, N'HH:mm') AS HeureJury, 
            FORMAT(dbo.Juries.HeureConvoc, N'HH:mm') AS HeureConvoc, 
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
            // =============================== RQ_L1_STAT

            Sql(@"
            CREATE VIEW [dbo].[RQ_L1_STAT]
            AS
            SELECT  choose(dbo.Livret1.isContrat+1,'Non','Oui') as IsContrat, 
                    choose(dbo.Livret1.IsConvention+1,'Non','Oui') as IsConvention,
                    choose(dbo.Livret1.IsNonRecu+1,'Non','Oui') as IsNonRecu, 
                    dbo.Livret1.Numero AS NumeroLivret, 
                    dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Nationalite, 
                    choose(dbo.Candidats.Sexe+1,'F','H') as Sexe, 
                    CONVERT(smalldatetime,dbo.Candidats.DateNaissance,103) as DateNaissance, 
                    CONVERT(smalldatetime,dbo.Livret1.DateDemande,103) as DateDemande, 
                    YEAR(dbo.Livret1.DateDemande) AS ANNEE, DATENAME(month, dbo.Livret1.DateDemande) AS MOIS, DATENAME(day, dbo.Livret1.DateDemande) AS JOUR, 
                                     FLOOR(DATENAME(day, dbo.Livret1.DateDemande) / 16) + 1 AS QUINZAINE, DATENAME(quarter, dbo.Livret1.DateDemande) AS TRIMESTRE,
                    CONVERT(smalldatetime,dbo.Livret1.DateEnvoiEHESP,103) as DateEnvoiEHESP, 
                    CONVERT(smalldatetime,dbo.Candidats.dateCreation,103) as dateCreation, 
                    CONVERT(smalldatetime,dbo.Livret1.DateReceptEHESP,103) AS [date reception], 
                    CONVERT(smalldatetime,dbo.Livret1.DateReceptEHESPComplet,103) as [Date courrier completude],
                    CONVERT(smalldatetime,dbo.Livret1.Date1ereDemandePieceManquantes, 103) as Date1ereDemandePieceManquantes,
                    CONVERT(smalldatetime,dbo.Livret1.DateDemande1erRetour, 103) as DateDemande1erRetour,
                    CONVERT(smalldatetime,dbo.Livret1.Date2emeDemandePieceManquantes, 103) as Date2emeDemandePieceManquantes,
                    CONVERT(smalldatetime,dbo.Livret1.DateDemande2emeRetour, 103) as DateDemande2emeRetour,
                    CONVERT(smalldatetime,dbo.Livret1.DateReceptionPiecesManquantes, 103) as DateReceptionPiecesManquantes,
                    CONVERT(smalldatetime,dbo.Juries.DateJury ,103) AS [Date Recevabilité],
                    dbo.Juries.Decision, 
                    CONVERT(smalldatetime,dbo.Juries.DateLimiteRecours, 103) as DateLimiteRecours,
                    CONVERT(smalldatetime,dbo.Livret1.DateValidite, 103) as DateValidite,
                    choose(dbo.Juries.IsRecours+1,'Non','Oui') as IsRecours, 
                    CONVERT(smalldatetime,dbo.Recours.DateDepot , 103) as DateDepotRecours,
                    choose(dbo.Recours.TypeRecours+1,'Gracieux','Contentieux') as TypeRecours, 
                    dbo.Juries.MotifGeneral AS [Motif du recours], dbo.Juries.MotifCommentaire, 
                    CONVERT(smalldatetime,dbo.Juries.DateNotificationJuryRecours, 103) as DateNotificationJuryRecours,
                    dbo.Recours.Decision AS DecisionRecours, 
                    CONVERT(smalldatetime,dbo.Livret1.DateEnvoiL2, 103) as DateEnvoiL2,
                    choose (dbo.Candidats.bHandicap+1,'Oui','Non') as bHandicap, 
                    dbo.Candidats.ID, dbo.Livret1.ID AS IDLivret1,dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                    choose(dbo.Livret1.isClos+1,'Oui','Non') as isClos
            FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                                     dbo.Livret1 ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1.ID RIGHT OUTER JOIN
                                     dbo.Candidats ON dbo.Livret1.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                                     dbo.Juries LEFT OUTER JOIN
                                     dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1.ID = dbo.Juries.Livret1_ID

            ");

            Sql(@"
            CREATE VIEW [dbo].[RQ_L2_STAT]
            AS
            SELECT        choose(dbo.Livret2.isContrat + 1, 'Faux', 'Vrai') AS iscontrat, choose(dbo.Livret2.IsConvention + 1, 'Faux', 'Vrai') AS Isconvention, choose(dbo.Livret2.IsNonRecu + 1, 'Faux', 'Vrai') AS Isnonrecu, choose(dbo.Candidats.Sexe + 1, 
                                     'F', 'H') AS sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, dbo.Candidats.Nationalite, CONVERT(smalldatetime, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, 
                                     dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, 
                                     choose(dbo.Candidats.bHandicap + 1, 'Faux', 'Vrai') AS bHandicap, CONVERT(smalldatetime, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, dbo.Livret2.Numero, dbo.Livret2.NumPassage, 
                                     choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Faux', 'Vrai') AS IsOuvertureApresRecours, CONVERT(smalldatetime, dbo.Livret2.DateDemande, 103) AS DateDemande, CONVERT(smalldatetime, 
                                     dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, CONVERT(smalldatetime, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante, 
                                     CONVERT(smalldatetime, dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, choose(dbo.Livret2.IsAttestationOK + 1, 'Faux', 'Vrai') AS IsAttestationOK, 
                                     choose(dbo.Livret2.IsCNIOK + 1, 'Faux', 'Vrai') AS IsCNIOK, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Faux', 'Vrai') AS IsDispenseArt2,  dbo.Livret2.EtatLivret, CONVERT(smalldatetime, 
                                     dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, 
                                     CONVERT(smalldatetime, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, choose(dbo.Livret2.isClos + 1, 'Faux', 'Vrai') AS isClos, FORMAT(dbo.Juries.HeureJury, N'hh:mm') AS HeureJury, 
                                     FORMAT(dbo.Juries.HeureConvoc, N'hh:mm') AS HeureConvoc, dbo.Juries.LieuJury, CONVERT(smalldatetime, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, CONVERT(smalldatetime, dbo.Livret2.DateEnvoiCourrierJury, 
                                     103) AS DateEnvoiCourrierJury, CONVERT(smalldatetime, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, CONVERT(smalldatetime, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, CONVERT(smalldatetime, dbo.Livret2.DateValidite, 103)
                                      AS DateValidite, CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour,
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
                                           WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret, dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR
            FROM            dbo.Livret2 INNER JOIN
                                     dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID INNER JOIN
                                     dbo.Diplomes ON dbo.Livret2.Diplome_ID = dbo.Diplomes.ID INNER JOIN
                                     dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Diplomes.ID = dbo.DiplomeCands.Diplome_ID LEFT OUTER JOIN
                                     dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
            ");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "TRYCONVERT" + "start");
    }
}
}
