namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateview : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Updateview " + "start");
            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC] ");
            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
                    AS
                    SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                         dbo.Livret1_NonClos.Numero AS NumeroLivret, dbo.Livret1_NonClos.ID AS IDLivret1, dbo.Livret1_NonClos.DateEnvoiCandidat, dbo.Livret1_NonClos.DateLimiteReceptEHESP, 
                         dbo.Livret1_NonClos.DateReceptEHESP AS date1ereReceptEHESP, dbo.Candidats.Pays, dbo.Livret1_NonClos.EtatLivret, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, 
                         dbo.Juries.HeureConvoc, dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance, dbo.Livret1_NonClos.DateValidite, 
                         dbo.Juries.IsRecours, dbo.Juries.DateLimiteRecours, dbo.Recours.DateDepot AS DateDepotRecours, dbo.Recours.TypeRecours, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, 
                         dbo.Livret1_NonClos.TypeDemande, dbo.Livret1_NonClos.VecteurInformation, dbo.Livret1_NonClos.DateDemande, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, 
                         dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, dbo.Livret1_NonClos.DateDemandePieceManquantesRetour AS DateRetourPM1erCourrier, 
                         dbo.Livret1_NonClos.DateReceptionPiecesManquantes AS DateRetour2ndCourrier, dbo.Livret1_NonClos.DateEcheance, dbo.Livret1_NonClos.isContrat, dbo.Livret1_NonClos.DateEnvoiEHESP, 
                         dbo.Livret1_NonClos.DateReceptEHESPComplet, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, dbo.Candidats.Nationalite, dbo.Candidats.NationaliteNaissance, dbo.Candidats.Region, dbo.Candidats.Mail1, 
                         dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Juries.DateNotificationJury, dbo.Juries.DateNotificationJuryRecours, 
                         dbo.Recours.MotifRecours, dbo.Recours.DateJury AS DateJuryRecours, dbo.Recours.LieuJury AS LieuJuryRecours, dbo.Recours.Decision AS DecisionRecours, dbo.Recours.MotifGeneral AS MotifGeneralRecours, 
                         dbo.Recours.MotifDetail AS MotifDetailRecours, dbo.Recours.MotifCommentaire AS MotifCommentaireRecours, dbo.Recours.NomJury AS NomJuryRecours, dbo.Recours.MotifRecoursCommentaire, dbo.Recours.DateLimiteJury, 
                         dbo.Candidats.DptNaissance
                    FROM   dbo.Juries LEFT OUTER JOIN
                            dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID RIGHT OUTER JOIN
                            dbo.Candidats INNER JOIN
                            dbo.Livret1_NonClos ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID ON dbo.Juries.Livret1_ID = dbo.Livret1_NonClos.ID
                    ");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC] ");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
                    AS
                        SELECT        dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, dbo.Livret2.Date1ereDemandePieceManquantes, 
                         dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateDemandePieceManquantesRetour, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC1
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC1,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC2
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC2,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC3
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC3,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC4
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC4, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Juries.DateNotificationJuryRecours
                        FROM            dbo.Livret2 LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
                    ");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Updateview " + "End");
        }

        public override void Down()
        {
            Sql(@"DROP VIEW [dbo].[Livret1_NonClos] ");
            Sql(@"CREATE VIEW [dbo].[Livret1_NonClos]
                    AS
                    SELECT        dbo.Livret1.*
                    FROM            dbo.Livret1
                    WHERE        (isClos = 0)");
            Sql(@"DROP VIEW [dbo].[Livret2_NonClos] ");
            Sql(@"CREATE VIEW [dbo].[Livret2_NonClos]
                    AS
                    SELECT        dbo.Livret2.*
                    FROM            dbo.Livret2
                    WHERE        (isClos = 0)");

            Sql(@"DROP VIEW [dbo].[RQ_L1_DOC] ");
            Sql(@"CREATE VIEW [dbo].[RQ_L1_DOC]
                    AS
                    SELECT dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, 
                            dbo.Livret1_NonClos.Numero as NumeroLivret, dbo.Livret1_NonClos.ID AS IDLivret1, dbo.Livret1_NonClos.DateEnvoiCandidat, dbo.Livret1_NonClos.DateLimiteReceptEHESP, dbo.Livret1_NonClos.DateReceptEHESP as date1ereReceptEHESP, dbo.Candidats.Pays, 
                            dbo.Livret1_NonClos.EtatLivret, dbo.Juries.DateJury, dbo.Juries.NomJury, dbo.Juries.LieuJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.Decision, dbo.Candidats.Sexe, dbo.Candidats.NomJeuneFille, 
                            dbo.Candidats.DateNaissance, dbo.Candidats.CPNaissance, dbo.Candidats.VilleNaissance, dbo.Livret1_NonClos.DateValidite, dbo.Juries.IsRecours, dbo.Juries.DateLimiteRecours, dbo.Recours.DateDepot as DateDepotRecours, 
                            dbo.Recours.TypeRecours, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, dbo.Livret1_NonClos.TypeDemande, dbo.Livret1_NonClos.VecteurInformation, 
                            dbo.Livret1_NonClos.DateDemande, dbo.Livret1_NonClos.Date1ereDemandePieceManquantes, dbo.Livret1_NonClos.Date2emeDemandePieceManquantes, dbo.Livret1_NonClos.DateDemandePieceManquantesRetour as DateRetourPM1erCourrier, 
                            dbo.Livret1_NonClos.DateReceptionPiecesManquantes as DateRetour2ndCourrier, dbo.Livret1_NonClos.DateEcheance, dbo.Livret1_NonClos.isContrat, dbo.Livret1_NonClos.DateEnvoiEHESP, dbo.Livret1_NonClos.DateReceptEHESPComplet, 
                            dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, dbo.Candidats.Nationalite, dbo.Candidats.NationaliteNaissance, dbo.Candidats.Region, dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, 
                            dbo.Candidats.Tel2, dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Juries.DateNotificationJury, dbo.Juries.DateNotificationJuryRecours, dbo.Recours.MotifRecours, dbo.Recours.DateJury AS DateJuryRecours, 
                            dbo.Recours.LieuJury AS LieuJuryRecours, dbo.Recours.Decision AS DecisionRecours, dbo.Recours.MotifGeneral AS MotifGeneralRecours, dbo.Recours.MotifDetail AS MotifDetailRecours, dbo.Recours.MotifCommentaire AS MotifCommentaireRecours, dbo.Recours.NomJury AS NomJuryRecours, 
                            dbo.Recours.MotifRecoursCommentaire, dbo.Recours.DateLimiteJury
                    FROM   dbo.Juries LEFT OUTER JOIN
                            dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID RIGHT OUTER JOIN
                            dbo.Candidats INNER JOIN
                            dbo.Livret1_NonClos ON dbo.Candidats.ID = dbo.Livret1_NonClos.Candidat_ID ON dbo.Juries.Livret1_ID = dbo.Livret1_NonClos.ID
                    ");

            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC] ");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
                    AS
                    SELECT        dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, dbo.Livret2.Date1ereDemandePieceManquantes, 
                         dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateDemandePieceManquantesRetour, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC1
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC1,
							 (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC2
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC2,

							 (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC3
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC3,
							   							 (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DOC_DC4
                               WHERE        (IDLivret = dbo.Livret2.ID)) AS DecisionDC4

                        FROM            dbo.Livret2 LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID");

        }
    }
}
