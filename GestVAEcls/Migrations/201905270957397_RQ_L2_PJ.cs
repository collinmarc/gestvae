namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RQ_L2_PJ : DbMigration
    {
        public override void Up()
        {
            // Création de la Vue sur les Pièces jointes
            Sql(@"CREATE VIEW [dbo].[RQ_L2_PJ]
                AS
                    SELECT        LIVRET2_ID,
                                                 (SELECT        Libelle + CHAR(10)
                                                   FROM            PieceJointeL2
                                                   WHERE        Libelle IS NOT NULL AND L2.Livret2_ID = PieceJointeL2.Livret2_ID FOR XML Path('')) AS Piecejointe
                    FROM            PieceJointeL2 L2
                    GROUP BY Livret2_ID
                ");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            Sql(@"CREATE VIEW[dbo].[RQ_L2_DOC]
                    AS
                    SELECT
                         dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, 
                         dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, 
                         dbo.Candidats.Tel3, dbo.Candidats.bHandicap, 
                         dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, 
                         dbo.Livret2.Date1ereDemandePieceManquantes, dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Juries.DateNotificationJuryRecours, 
                         dbo.Livret2.DateDemande1erRetour, dbo.Livret2.DateDemande2emeRetour, dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu,
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
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID"
        );

            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            Sql(@"CREATE VIEW[dbo].[RQ_L2_DOC]
                    AS
                    SELECT
                         dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, 
                         dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, 
                         dbo.Candidats.Tel3, dbo.Candidats.bHandicap, 
                         dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, 
                         dbo.Livret2.Date1ereDemandePieceManquantes, dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Juries.DateNotificationJuryRecours, 
                         dbo.Livret2.DateDemande1erRetour, dbo.Livret2.DateDemande2emeRetour, dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu,
                         dbo.RQ_L2_PJ.Piecejointe,
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


        }

        public override void Down()
        {
            Sql(@"DROP VIEW [dbo].[RQ_L2_PJ]");
            Sql(@"DROP VIEW [dbo].[RQ_L2_DOC]");
            Sql(@"CREATE VIEW[dbo].[RQ_L2_DOC]
                    AS
                    SELECT
                         dbo.Candidats.Civilite, dbo.Candidats.Nom, dbo.Candidats.Prenom, dbo.Candidats.Prenom2, dbo.Candidats.Prenom3, dbo.Candidats.Sexe, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                         dbo.Candidats.NomJeuneFille, dbo.Candidats.Nationalite, dbo.Candidats.DateNaissance, dbo.Candidats.VilleNaissance, dbo.Candidats.NationaliteNaissance, dbo.Candidats.DptNaissance, dbo.Candidats.PaysNaissance, 
                         dbo.Candidats.Adresse, dbo.Candidats.CodePostal, dbo.Candidats.Ville, dbo.Candidats.Region, dbo.Candidats.Pays, dbo.Candidats.Mail1, dbo.Candidats.Mail2, dbo.Candidats.Mail3, dbo.Candidats.Tel1, dbo.Candidats.Tel2, 
                         dbo.Candidats.Tel3, dbo.Candidats.bHandicap, 
                         dbo.Livret2.Numero, dbo.Juries.DateJury, dbo.Juries.Decision, dbo.Livret2.NumPassage, dbo.Livret2.IsOuvertureApresRecours, dbo.Livret2.DateDemande, 
                         dbo.Livret2.Date1ereDemandePieceManquantes, dbo.Livret2.Date2emeDemandePieceManquantes, dbo.Livret2.DateReceptionPiecesManquantes, dbo.Livret2.SessionJury, dbo.Livret2.IsAttestationOK, dbo.Livret2.IsCNIOK, 
                         dbo.Livret2.IsDispenseArt2, dbo.Livret2.NumDiplome, dbo.Livret2.isContrat, dbo.Livret2.EtatLivret, dbo.Livret2.DateEnvoiEHESP, dbo.Livret2.DateEnvoiCandidat, dbo.Livret2.DateReceptEHESP, 
                         dbo.Livret2.DateReceptEHESPComplet, dbo.Livret2.isClos, dbo.Juries.NomJury, dbo.Juries.HeureJury, dbo.Juries.HeureConvoc, dbo.Juries.LieuJury, dbo.Juries.MotifGeneral, dbo.Juries.MotifDetail, 
                         dbo.Juries.MotifCommentaire, dbo.Juries.DateNotificationJury, dbo.Livret2.DateEnvoiCourrierJury, dbo.Livret2.DatePrevJury1, dbo.Livret2.DatePrevJury2, dbo.Livret2.DateValidite, dbo.Juries.DateNotificationJuryRecours, 
                         dbo.Livret2.DateDemande1erRetour, dbo.Livret2.DateDemande2emeRetour, dbo.Livret2.IsConvention, dbo.Livret2.IsNonRecu,
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
                         dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID"
        );

        }
    }
}
