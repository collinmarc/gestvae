namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsEnregistreIsPaye : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "IsEnregistreIsPaye " + "start");
            AddColumn("dbo.Livret1", "IsEnregistre", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret1", "IsPaye", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret2", "IsEnregistre", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret2", "IsPaye", c => c.Boolean(nullable: false));

            Sql(@"DROP VIEW [dbo].[Livret1_NonClos]");

            Sql(@"CREATE VIEW [dbo].[Livret1_NonClos]
                    AS
                    SELECT        dbo.Livret1.*
                    FROM            dbo.Livret1
                    WHERE        (isClos = 0)");

            Sql(@"DROP VIEW [dbo].[Livret2_NonClos]");

            Sql(@"CREATE VIEW [dbo].[Livret2_NonClos]
                    AS
                    SELECT        dbo.Livret2.*
                    FROM            dbo.Livret2
                    WHERE        (isClos = 0)");

            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC]");
            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
AS
SELECT  iif(dbo.Livret1_NonClos.isContrat=1,'Vrai', 'Faux') as IsContrat, 
		iif(dbo.Livret1_NonClos.IsConvention=1,'Vrai', 'Faux') as IsConvention,
        iif(dbo.Livret1_NonClos.IsNonRecu=1,'Vrai', 'Faux') as IsNonRecu, 
        iif(dbo.Livret1_NonClos.IsEnregistre=1,'Vrai', 'Faux') as IsEnregistre, 
        iif(dbo.Livret1_NonClos.IsPaye=1,'Vrai', 'Faux') as IsPaye, 
        dbo.Livret1_NonClos.Numero AS NumeroLivret, dbo.Candidats.Civilite, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nom, 
        dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Nationalite, 
        dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
		iif(dbo.Candidats.Sexe=1,'H','F') as Sexe, 
		CONVERT(nvarchar,dbo.Candidats.DateNaissance,103) as DateNaissance, 
		dbo.Candidats.VilleNaissance, dbo.Candidats.DptNaissance,dbo.Candidats.PaysNaissance, dbo.Candidats.NationaliteNaissance, 
		CONVERT(nvarchar,dbo.Livret1_NonClos.DateDemande,103) as DateDemande, 
		CONVERT(nvarchar,dbo.Livret1_NonClos.DateEnvoiEHESP,103) as DateEnvoiEHESP, 
		CONVERT(nvarchar,dbo.Candidats.dateCreation,103) as dateCreation, 
		dbo.Livret1_NonClos.TypeDemande, dbo.Livret1_NonClos.VecteurInformation, dbo.Candidats.Mail3 AS [Situation Particulière], 
		Convert(nVarchar,dbo.Livret1_NonClos.DateReceptEHESP,103) AS [date reception], 
		Convert(nVarchar,dbo.Livret1_NonClos.DateReceptEHESPComplet,103) as [Date courrier completude],
		Convert(nVarchar,dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, 103) as Date1ereDemandePieceManquantes,
		Convert(nVarchar,dbo.Livret1_NonClos.DateDemande1erRetour, 103) as DateDemande1erRetour,
		Convert(nVarchar,dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, 103) as Date2emeDemandePieceManquantes,
		Convert(nVarchar,dbo.Livret1_NonClos.DateDemande2emeRetour, 103) as DateDemande2emeRetour,
		Convert(nVarchar,dbo.Livret1_NonClos.DateReceptionPiecesManquantes, 103) as DateReceptionPiecesManquantes,
		dbo.RQ_L1_PJ.Piecejointe, dbo.Livret1_NonClos.EtatLivret, 
		Convert(nVarchar,dbo.Juries.DateJury ,103) AS [Date Recevabilité],
		dbo.Juries.Decision, 
		Convert(nVarchar,dbo.Juries.DateLimiteRecours, 103) as DateLimiteRecours,
		Convert(nVarchar,dbo.Livret1_NonClos.DateValidite, 103) as DateValidite,
		iif(dbo.Juries.IsRecours=1,'Vrai', 'Faux') as IsRecours, 
		Convert(nVarchar,dbo.Recours.DateDepot , 103) as DateDepotRecours,
		iif(dbo.Recours.TypeRecours=1,'Contentieux','Gracieux') as TypeRecours, 
		dbo.Juries.MotifGeneral AS [Motif du recours], dbo.Juries.MotifCommentaire, 
		Convert(nVarchar,dbo.Juries.DateNotificationJuryRecours, 103) as DateNotificationJuryRecours,
		dbo.Recours.Decision AS DecisionRecours, 
		Convert(nVarchar,dbo.Livret1_NonClos.DateEnvoiL2, 103) as DateEnvoiL2,
		iif (dbo.Candidats.bHandicap=1,'Vrai','Faux') as bHandicap, 
		dbo.Candidats.ID, dbo.Livret1_NonClos.ID AS IDLivret1,dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
		iif(dbo.Livret1_NonClos.isClos=1,'Vrai','Faux') as isClos,
		iif(dbo.Livret1_NonClos.isCNIOK=1,'Vrai','Faux') as isCNIOK,
		Convert(nVarchar,dbo.Livret1_NonClos.DateValiditeCNI, 103) as DateValiditeCNI
FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID RIGHT OUTER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
");

            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT       iif(dbo.Livret2.isContrat=1,'Vrai','Faux') as iscontrat,
			iif(dbo.Livret2.isConvention=1,'Vrai','Faux') as Isconvention,
			iif(dbo.Livret2.IsNonRecu=1,'Vrai','Faux') as Isnonrecu,
			iif(dbo.Livret2.IsEnregistre=1,'Vrai','Faux') as IsEnregistre,
			iif(dbo.Livret2.IsPaye=1,'Vrai','Faux') as IsPaye,
			dbo.Livret2.Numero, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, 
			iif(dbo.Candidats.Sexe=1,'H','F') as sexe, 
			dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, CONVERT(nvarchar, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, 
						 iif(dbo.Candidats.bHandicap=1,'Vrai','Faux') as bHandicap, 
						 CONVERT(nvarchar, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, 
                         dbo.Livret2.NumPassage, 
						 iif(dbo.Livret2.IsOuvertureApresRecours=1,'Vrai','Faux') as IsOuvertureApresRecours, 
						 CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, CONVERT(nvarchar, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante,
						 CONVERT(nvarchar, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.DateReceptionPiecesManquantes, 
                         103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, 
						 iif(dbo.Livret2.IsAttestationOK=1,'Vrai','Faux') as IsAttestationOK, 
						 iif(dbo.Livret2.IsCNIOK=1,'Vrai','Faux') as IsCNIOK, 
                         CONVERT(nvarchar, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, 
						iif(dbo.Livret2.IsDispenseArt2=1,'Vrai','Faux') as IsDispenseArt2, 
						 dbo.Livret2.NumDiplome, 
						 dbo.Livret2.EtatLivret, 
                         CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, 
						 CONVERT(nvarchar, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, 
						 CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, 
						 CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, 
						 iif(dbo.Livret2.isClos=1,'Vrai','Faux') as isClos, 
						FORMAT( dbo.Juries.HeureJury, N'hh:mm') AS HeureJury, 
						FORMAT(dbo.Juries.HeureConvoc, N'hh:mm') as HeureConvoc,
						 dbo.Juries.LieuJury, 
						 CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, 
						 CONVERT(nvarchar, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, 
						 CONVERT(nvarchar, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, 
						 CONVERT(nvarchar, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, 
						 CONVERT(nvarchar, dbo.Livret2.DateValidite, 103) AS DateValidite, 
						 CONVERT(nvarchar, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, 
						 
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


            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "IsEnregistreIsPaye " + "end");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "IsEnregistreIsPaye " + "start");
            DropColumn("dbo.Livret2", "IsPaye");
            DropColumn("dbo.Livret2", "IsEnregistre");
            DropColumn("dbo.Livret1", "IsPaye");
            DropColumn("dbo.Livret1", "IsEnregistre");

            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC]");
            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
AS
SELECT  iif(dbo.Livret1_NonClos.isContrat=1,'Vrai', 'Faux') as IsContrat, 
		iif(dbo.Livret1_NonClos.IsConvention=1,'Vrai', 'Faux') as IsConvention,
        iif(dbo.Livret1_NonClos.IsNonRecu=1,'Vrai', 'Faux') as IsNonRecu, 
        dbo.Livret1_NonClos.Numero AS NumeroLivret, dbo.Candidats.Civilite, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nom, 
        dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Nationalite, 
        dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
		iif(dbo.Candidats.Sexe=1,'H','F') as Sexe, 
		CONVERT(nvarchar,dbo.Candidats.DateNaissance,103) as DateNaissance, 
		dbo.Candidats.VilleNaissance, dbo.Candidats.DptNaissance,dbo.Candidats.PaysNaissance, dbo.Candidats.NationaliteNaissance, 
		CONVERT(nvarchar,dbo.Livret1_NonClos.DateDemande,103) as DateDemande, 
		CONVERT(nvarchar,dbo.Livret1_NonClos.DateEnvoiEHESP,103) as DateEnvoiEHESP, 
		CONVERT(nvarchar,dbo.Candidats.dateCreation,103) as dateCreation, 
		dbo.Livret1_NonClos.TypeDemande, dbo.Livret1_NonClos.VecteurInformation, dbo.Candidats.Mail3 AS [Situation Particulière], 
		Convert(nVarchar,dbo.Livret1_NonClos.DateReceptEHESP,103) AS [date reception], 
		Convert(nVarchar,dbo.Livret1_NonClos.DateReceptEHESPComplet,103) as [Date courrier completude],
		Convert(nVarchar,dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, 103) as Date1ereDemandePieceManquantes,
		Convert(nVarchar,dbo.Livret1_NonClos.DateDemande1erRetour, 103) as DateDemande1erRetour,
		Convert(nVarchar,dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, 103) as Date2emeDemandePieceManquantes,
		Convert(nVarchar,dbo.Livret1_NonClos.DateDemande2emeRetour, 103) as DateDemande2emeRetour,
		Convert(nVarchar,dbo.Livret1_NonClos.DateReceptionPiecesManquantes, 103) as DateReceptionPiecesManquantes,
		dbo.RQ_L1_PJ.Piecejointe, dbo.Livret1_NonClos.EtatLivret, 
		Convert(nVarchar,dbo.Juries.DateJury ,103) AS [Date Recevabilité],
		dbo.Juries.Decision, 
		Convert(nVarchar,dbo.Juries.DateLimiteRecours, 103) as DateLimiteRecours,
		Convert(nVarchar,dbo.Livret1_NonClos.DateValidite, 103) as DateValidite,
		iif(dbo.Juries.IsRecours=1,'Vrai', 'Faux') as IsRecours, 
		Convert(nVarchar,dbo.Recours.DateDepot , 103) as DateDepotRecours,
		iif(dbo.Recours.TypeRecours=1,'Contentieux','Gracieux') as TypeRecours, 
		dbo.Juries.MotifGeneral AS [Motif du recours], dbo.Juries.MotifCommentaire, 
		Convert(nVarchar,dbo.Juries.DateNotificationJuryRecours, 103) as DateNotificationJuryRecours,
		dbo.Recours.Decision AS DecisionRecours, 
		Convert(nVarchar,dbo.Livret1_NonClos.DateEnvoiL2, 103) as DateEnvoiL2,
		iif (dbo.Candidats.bHandicap=1,'Vrai','Faux') as bHandicap, 
		dbo.Candidats.ID, dbo.Livret1_NonClos.ID AS IDLivret1,dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
		iif(dbo.Livret1_NonClos.isClos=1,'Vrai','Faux') as isClos,
		iif(dbo.Livret1_NonClos.isCNIOK=1,'Vrai','Faux') as isCNIOK,
		Convert(nVarchar,dbo.Livret1_NonClos.DateValiditeCNI, 103) as DateValiditeCNI
FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID RIGHT OUTER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
");

            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT       iif(dbo.Livret2.isContrat=1,'Vrai','Faux') as iscontrat,
			iif(dbo.Livret2.isConvention=1,'Vrai','Faux') as Isconvention,
			iif(dbo.Livret2.IsNonRecu=1,'Vrai','Faux') as Isnonrecu,
			dbo.Livret2.Numero, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, 
			iif(dbo.Candidats.Sexe=1,'H','F') as sexe, 
			dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, CONVERT(nvarchar, dbo.Candidats.DateNaissance, 103) AS DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, 
						 iif(dbo.Candidats.bHandicap=1,'Vrai','Faux') as bHandicap, 
						 CONVERT(nvarchar, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, 
                         dbo.Livret2.NumPassage, 
						 iif(dbo.Livret2.IsOuvertureApresRecours=1,'Vrai','Faux') as IsOuvertureApresRecours, 
						 CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, CONVERT(nvarchar, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante,
						 CONVERT(nvarchar, dbo.Livret2.Date2emeDemandePieceManquantes, 103) AS Date2emeDemandePieceManquante, CONVERT(nvarchar, dbo.Livret2.DateReceptionPiecesManquantes, 
                         103) AS DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, 
						 iif(dbo.Livret2.IsAttestationOK=1,'Vrai','Faux') as IsAttestationOK, 
						 iif(dbo.Livret2.IsCNIOK=1,'Vrai','Faux') as IsCNIOK, 
                         CONVERT(nvarchar, dbo.Livret2.DateValiditeCNI, 103) AS DateValiditeCNI, 
						iif(dbo.Livret2.IsDispenseArt2=1,'Vrai','Faux') as IsDispenseArt2, 
						 dbo.Livret2.NumDiplome, 
						 dbo.Livret2.EtatLivret, 
                         CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, 
						 CONVERT(nvarchar, dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, 
						 CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, 
						 CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) AS DateReceptEHESPComplet, 
						 iif(dbo.Livret2.isClos=1,'Vrai','Faux') as isClos, 
						FORMAT( dbo.Juries.HeureJury, N'hh:mm') AS HeureJury, 
						FORMAT(dbo.Juries.HeureConvoc, N'hh:mm') as HeureConvoc,
						 dbo.Juries.LieuJury, 
						 CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) AS dateNotificationJury, 
						 CONVERT(nvarchar, dbo.Livret2.DateEnvoiCourrierJury, 103) AS DateEnvoiCourrierJury, 
						 CONVERT(nvarchar, dbo.Livret2.DatePrevJury1, 103) AS datePrevJury1, 
						 CONVERT(nvarchar, dbo.Livret2.DatePrevJury2, 103) AS DatePrevJury2, 
						 CONVERT(nvarchar, dbo.Livret2.DateValidite, 103) AS DateValidite, 
						 CONVERT(nvarchar, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, 
						 
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



            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "IsEnregistreIsPaye " + "end");
        }
    }
}
