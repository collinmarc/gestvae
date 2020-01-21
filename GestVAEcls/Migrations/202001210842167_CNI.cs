namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CNI : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CNI " + "start");
            AddColumn("dbo.Livret1", "IsCNIOK", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret1", "DateValiditeCNI", c => c.DateTime());

            Sql(@"DROP VIEW [dbo].[Livret1_NonClos]");

            Sql(@"CREATE VIEW [dbo].[Livret1_NonClos]
                    AS
                    SELECT        dbo.Livret1.*
                    FROM            dbo.Livret1
                    WHERE        (isClos = 0)");

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

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CNI " + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CNI " + "start");
            DropColumn("dbo.Livret1", "DateValiditeCNI");
            DropColumn("dbo.Livret1", "IsCNIOK");

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
		iif(dbo.Livret1_NonClos.isClos=1,'Vrai','Faux') as isClos
FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID RIGHT OUTER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CNI " + "end");
        }
    }
}
