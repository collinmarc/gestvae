namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BG001017Mail3SituationParticuliere : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001017Mail3SituationParticuliere " + "start");

            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC]");


            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
AS
SELECT        dbo.Livret1_NonClos.Numero AS NumeroLivret, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, 
                         dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         dbo.Candidats.Mail3  AS [Situation Particulière], dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Livret1_NonClos.ID AS IDLivret1, dbo.Livret1_NonClos.DateReceptEHESP AS date1ereReceptEHESP, 
                         dbo.Livret1_NonClos.EtatLivret, dbo.Juries.DateJury AS [Date Recevabilité], dbo.Juries.HeureJury, dbo.Juries.Decision, dbo.Livret1_NonClos.DateValidite, dbo.Juries.IsRecours, dbo.Juries.DateLimiteRecours, 
                         dbo.Recours.DateDepot AS DateDepotRecours, dbo.Recours.TypeRecours, dbo.Juries.MotifGeneral, dbo.Juries.MotifCommentaire, dbo.Livret1_NonClos.TypeDemande, dbo.Livret1_NonClos.VecteurInformation, 
                         dbo.Livret1_NonClos.DateDemande, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, 
                         dbo.Livret1_NonClos.DateReceptionPiecesManquantes AS DateRetour2ndCourrier, dbo.Livret1_NonClos.DateEcheance, dbo.Livret1_NonClos.isContrat, dbo.Livret1_NonClos.DateEnvoiEHESP, 
                         dbo.Livret1_NonClos.DateReceptEHESPComplet, dbo.Juries.DateNotificationJuryRecours, dbo.Recours.MotifRecours, dbo.Recours.Decision AS DecisionRecours, dbo.Recours.MotifRecoursCommentaire, 
                         dbo.Recours.DateLimiteJury, dbo.Livret1_NonClos.DateDemande1erRetour, dbo.Livret1_NonClos.DateDemande2emeRetour, dbo.Livret1_NonClos.IsConvention, dbo.Livret1_NonClos.IsNonRecu, 
                         dbo.Livret1_NonClos.DateEnvoiL2, dbo.Livret1_NonClos.isClos, dbo.RQ_L1_PJ.Piecejointe, dbo.Candidats.dateCreation
FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID RIGHT OUTER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID"
         );
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001017Mail3SituationParticuliere " + "end");

        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001017Mail3SituationParticuliere " + "start");

            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC]");


            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
AS
SELECT        dbo.Livret1_NonClos.Numero AS NumeroLivret, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, 
                         dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, 
                         dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, 
                         dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Livret1_NonClos.ID AS IDLivret1, dbo.Livret1_NonClos.DateReceptEHESP AS date1ereReceptEHESP, 
                         dbo.Livret1_NonClos.EtatLivret, dbo.Juries.DateJury AS [Date Recevabilité], dbo.Juries.HeureJury, dbo.Juries.Decision, dbo.Livret1_NonClos.DateValidite, dbo.Juries.IsRecours, dbo.Juries.DateLimiteRecours, 
                         dbo.Recours.DateDepot AS DateDepotRecours, dbo.Recours.TypeRecours, dbo.Juries.MotifGeneral, dbo.Juries.MotifCommentaire, dbo.Livret1_NonClos.TypeDemande, dbo.Livret1_NonClos.VecteurInformation, 
                         dbo.Livret1_NonClos.DateDemande, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, 
                         dbo.Livret1_NonClos.DateReceptionPiecesManquantes AS DateRetour2ndCourrier, dbo.Livret1_NonClos.DateEcheance, dbo.Livret1_NonClos.isContrat, dbo.Livret1_NonClos.DateEnvoiEHESP, 
                         dbo.Livret1_NonClos.DateReceptEHESPComplet, dbo.Juries.DateNotificationJuryRecours, dbo.Recours.MotifRecours, dbo.Recours.Decision AS DecisionRecours, dbo.Recours.MotifRecoursCommentaire, 
                         dbo.Recours.DateLimiteJury, dbo.Livret1_NonClos.DateDemande1erRetour, dbo.Livret1_NonClos.DateDemande2emeRetour, dbo.Livret1_NonClos.IsConvention, dbo.Livret1_NonClos.IsNonRecu, 
                         dbo.Livret1_NonClos.DateEnvoiL2, dbo.Livret1_NonClos.isClos, dbo.RQ_L1_PJ.Piecejointe, dbo.Candidats.dateCreation
FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID RIGHT OUTER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID"
         );
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001017Mail3SituationParticuliere " + "end");

        }
    }
}
