namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RQ_L2_DECISION_DC : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "RQ_L2_DECISION_DC " + "start");
            Sql(@"DROP VIEW RQ_L2_DECISION_DC");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT        dbo.Livret2.Numero, CONVERT(nvarchar, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, dbo.DomaineCompetences.Nom, dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, 
                         dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2,  dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(nvarchar, 
                         dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) 
                         AS DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, CONVERT(nvarchar, dbo.Juries.HeureJury, 8) AS HeureJury, CONVERT(nvarchar, dbo.Juries.HeureConvoc, 8) AS HeureConvoc, dbo.Juries.LieuJury, 
                         dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) AS DateNotificationJury, CONVERT(nvarchar, dbo.DCLivrets.DateObtention, 103) 
                         AS DateObtention, dbo.Livret2.ID AS IDLivret
FROM            dbo.Livret2 INNER JOIN
                         dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.DCLivrets.IsAValider = 1)");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "RQ_L2_DECISION_DC " + "end");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "RQ_L2_DECISION_DC " + "start");
            Sql(@"DROP VIEW RQ_L2_DECISION_DC");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT        dbo.Livret2.Numero, CONVERT(nvarchar, dbo.Juries.DateJury, 103) AS DateJury, dbo.Juries.Decision, dbo.DomaineCompetences.Nom, dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, 
                         dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, CONVERT(nvarchar, dbo.Livret2.DateDemande, 103) AS DateDemande, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2,  dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, CONVERT(nvarchar, dbo.Livret2.DateEnvoiEHESP, 103) AS DateEnvoiEHESP, CONVERT(nvarchar, 
                         dbo.Livret2.DateEnvoiCandidat, 103) AS DateEnvoiCandidat, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESP, 103) AS DateReceptEHESP, CONVERT(nvarchar, dbo.Livret2.DateReceptEHESPComplet, 103) 
                         AS DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, CONVERT(nvarchar, dbo.Juries.HeureJury, 8) AS HeureJury, CONVERT(nvarchar, dbo.Juries.HeureConvoc, 8) AS HeureConvoc, dbo.Juries.LieuJury, 
                         dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, CONVERT(nvarchar, dbo.Juries.DateNotificationJury, 103) AS DateNotificationJury, CONVERT(nvarchar, dbo.DCLivrets.DateObtention, 103) 
                         AS DateObtention, dbo.Livret2.ID AS IDLivret
FROM            dbo.Livret2 INNER JOIN
                         dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.DCLivrets.IsAValider = 1)");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "RQ_L2_DECISION_DC " + "end");
        }
    }
}
