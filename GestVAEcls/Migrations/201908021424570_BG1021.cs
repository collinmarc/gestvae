namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public partial class BG1021 : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "BG0001021 " + "Start");

            if (ViewExists("dbo.RQ_STATUT_DC_CAND"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_STATUT_DC_CAND]");
            }
            Sql(@"CREATE VIEW [dbo].[RQ_STATUT_DC_CAND]
AS
SELECT        dbo.DiplomeCands.ID, dbo.DiplomeCands.Candidat_ID, dbo.DiplomeCands.Diplome_ID, dbo.DomaineCompetences.Nom, dbo.DomaineCompetenceCands.Statut, dbo.DomaineCompetenceCands.DateObtention, 
                         dbo.DomaineCompetenceCands.ModeObtention, dbo.DomaineCompetences.Numero, dbo.Diplomes.Nom AS NomDiplome
FROM            dbo.DiplomeCands INNER JOIN
                         dbo.DomaineCompetenceCands ON dbo.DiplomeCands.ID = dbo.DomaineCompetenceCands.Diplome_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DomaineCompetenceCands.DomaineCompetence_ID = dbo.DomaineCompetences.ID INNER JOIN
                         dbo.Diplomes ON dbo.DiplomeCands.Diplome_ID = dbo.Diplomes.ID AND dbo.DomaineCompetences.Diplome_ID = dbo.Diplomes.ID
WHERE        (dbo.Diplomes.Nom = N'CAFDES')");

            if (ViewExists("dbo.RQ_L2_DECISION_DC"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DECISION_DC]");
            }

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DECISION_DC]
AS
SELECT        dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.DomaineCompetences.Nom, dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, dbo.Livret2.NumPassage, 
                         dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, 
                         dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, 
                         dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury, dbo.DCLivrets.DateObtention, dbo.Livret2.ID AS IDLivret
FROM            dbo.Livret2 INNER JOIN
                         dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                         dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
WHERE        (dbo.DCLivrets.IsAValider = 1)");

            if (ViewExists("dbo.RQ_L2_DOC2"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC2]");
            }

            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC2]
AS
SELECT        dbo.Candidats.ID, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.NomJeuneFille, dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Prenom2, 
                         dbo.Candidats.Prenom3, dbo.Candidats.IdVAE,
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
                               WHERE        (Candidat_ID = dbo.Candidats.ID) AND (Numero = 4)) AS MODE_OBTENTION_DC4
FROM            dbo.Candidats INNER JOIN
                         dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID INNER JOIN
                         dbo.Diplomes ON dbo.DiplomeCands.Diplome_ID = dbo.Diplomes.ID
WHERE        (dbo.Candidats.ID IN
                             (SELECT        ID
                               FROM            dbo.Livret2_NonClos)) AND (dbo.Diplomes.Nom = N'CAFDES')
");

            if (ViewExists("dbo.RQ_L2_DOC"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            }
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT        dbo.Livret2.Numero, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, 
                         dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, 
                         dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, 
                         dbo.Livret2.Date1ereDemandePieceManquantes, dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.DateNotificationJury, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Livret2.DateDemande1erRetour, dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu, dbo.RQ_L2_PJ.Piecejointe,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Numero = 1)) AS DecisionDC1,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_3
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Numero = 2)) AS DecisionDC2,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_2
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Numero = 3)) AS DecisionDC3,
                             (SELECT        DecisionJury
                               FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_1
                               WHERE        (IDLivret = dbo.Livret2.ID) AND (Numero = 4)) AS DecisionDC4
FROM            dbo.Livret2 INNER JOIN
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID LEFT OUTER JOIN
                         dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID");

            if (ViewExists("dbo.RQ_L2_DOC_DC1"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC1]");
            }
            if (ViewExists("dbo.RQ_L2_DOC_DC2"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC2]");
            }
            if (ViewExists("dbo.RQ_L2_DOC_DC3"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC3]");
            }
            if (ViewExists("dbo.RQ_L2_DOC_DC4"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC4]");
            }

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "BG0001021 " + "End");
        }//up

        public override void Down()
        {
 
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001021 " + "start");

            // Recreation Vues
            if (ViewExists("[dbo].[RQ_L2_DOC_DC1]"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC1]");
            }
            if (ViewExists("[dbo].[RQ_L2_DOC_DC2]"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC2]");
            }
            if (ViewExists("[dbo].[RQ_L2_DOC_DC3]"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC3]");
            }
            if (ViewExists("[dbo].[RQ_L2_DOC_DC4]"))
            {
                Sql(@"DROP VIEW [dbo].[RQ_L2_DOC_DC4]");
            }
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC_DC1]
                    AS
                    SELECT        dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, dbo.DCLivrets.DateObtention, dbo.Livret2.ID AS IDLivret, dbo.DCLivrets.MotifGeneral, dbo.DCLivrets.MotifDetail, dbo.DCLivrets.MotifCommentaire, 
                                             dbo.DCLivrets.Statut, dbo.DomaineCompetences.Nom, dbo.DomaineCompetences.Numero
                    FROM            dbo.Livret2 INNER JOIN
                                             dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                                             dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                    WHERE       (dbo.DomaineCompetences.Numero = 1)
                    ");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC_DC2]
                    AS
                    SELECT        dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, dbo.DCLivrets.DateObtention, dbo.Livret2.ID AS IDLivret, dbo.DCLivrets.MotifGeneral, dbo.DCLivrets.MotifDetail, dbo.DCLivrets.MotifCommentaire, 
                                             dbo.DCLivrets.Statut, dbo.DomaineCompetences.Nom, dbo.DomaineCompetences.Numero
                    FROM            dbo.Livret2 INNER JOIN
                                             dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                                             dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                    WHERE       (dbo.DomaineCompetences.Numero = 2)
                    ");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC_DC3]
                    AS
                    SELECT        dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, dbo.DCLivrets.DateObtention, dbo.Livret2.ID AS IDLivret, dbo.DCLivrets.MotifGeneral, dbo.DCLivrets.MotifDetail, dbo.DCLivrets.MotifCommentaire, 
                                             dbo.DCLivrets.Statut, dbo.DomaineCompetences.Nom, dbo.DomaineCompetences.Numero
                    FROM            dbo.Livret2 INNER JOIN
                                             dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                                             dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                    WHERE       (dbo.DomaineCompetences.Numero = 3)
                    ");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC_DC4]
                    AS
                    SELECT        dbo.DCLivrets.Decision AS DecisionJury, dbo.DCLivrets.IsAValider, dbo.DCLivrets.DateObtention, dbo.Livret2.ID AS IDLivret, dbo.DCLivrets.MotifGeneral, dbo.DCLivrets.MotifDetail, dbo.DCLivrets.MotifCommentaire, 
                                             dbo.DCLivrets.Statut, dbo.DomaineCompetences.Nom, dbo.DomaineCompetences.Numero
                    FROM            dbo.Livret2 INNER JOIN
                                             dbo.DCLivrets ON dbo.Livret2.ID = dbo.DCLivrets.oLivret2_ID INNER JOIN
                                             dbo.DomaineCompetences ON dbo.DCLivrets.oDomaineCompetence_ID = dbo.DomaineCompetences.ID
                    WHERE       (dbo.DomaineCompetences.Numero = 4)
                    ");


            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            Sql(@"CREATE VIEW [dbo].[RQ_L2_DOC]
AS
SELECT        dbo.Livret2.Numero, dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, 
                         dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, 
                         dbo.Candidats.Tel3, dbo.Candidats.bHandicap, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, 
                         dbo.Livret2.Date1ereDemandePieceManquantes, dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.DateNotificationJury, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, 
                         dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Livret2.DateDemande1erRetour, dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu, dbo.RQ_L2_PJ.Piecejointe,
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
FROM            dbo.Livret2 INNER JOIN
                         dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID LEFT OUTER JOIN
                         dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID"
        );



            Sql(@"DROP VIEW [dbo].[RQ_L2_DECISION_DC]");
            Sql(@"DROP VIEW [dbo].[RQ_STATUT_DC_CAND]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC2]");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001021 " + "End");
        }//down

        private bool ViewExists(string pViewName)
        {
            using (var context = new Context(new NullDatabaseInitializer<Context>()))
//            using (var context = new Context())
            {
                var count = context.Database.SqlQuery<int>("SELECT COUNT(OBJECT_ID(@p0, 'V'))", pViewName);

                return count.Any() && count.First() > 0;
            }
        }//Exists
        private bool TableExists(string pViewName)
        {
            using (var context = new Context(new NullDatabaseInitializer<Context>()))
            //            using (var context = new Context())
            {
                var count = context.Database.SqlQuery<int>("SELECT COUNT(OBJECT_ID(@p0, 'U'))", pViewName);

                return count.Any() && count.First() > 0;
            }
        }//Exists
    }//BG1021

}


