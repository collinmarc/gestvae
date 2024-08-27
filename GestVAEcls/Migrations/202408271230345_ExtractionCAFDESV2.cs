namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtractionCAFDESV2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE OR ALTER VIEW [dbo].[L1_BLOC_AVALIDER]
                    AS
                    SELECT L1.ID AS L1_ID, diplomes.Nom as NOM_DIPLOME,
                    (SELECT DCLivrets.IsAValider AS B1
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 1
                    ) AS B1,
                    (SELECT DCLivrets.IsAValider AS B1
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 2
                    ) AS B2,
                    (SELECT DCLivrets.IsAValider AS B1
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 3
                    ) AS B3,
                    (SELECT DCLivrets.IsAValider AS B1
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 4
                    ) AS B4

                    FROM Livret1 L1, Diplomes
                    WHERE L1.Diplome_ID = Diplomes.ID 
                    ");

            Sql(@"CREATE OR ALTER VIEW [dbo].[RQ_L1_DOC]
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
                        TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateValiditeCNI, 103) AS DateValiditeCNI,
                        choose(dbo.Candidats.IsPostFormation + 1, 'Non', 'Oui') AS IsPostFormation,
						L1_BLOC_AVALIDER.NOM_DIPLOME,
                        L1_BLOC_AVALIDER.B1,
                        L1_BLOC_AVALIDER.B2,
                        L1_BLOC_AVALIDER.B3,
                        L1_BLOC_AVALIDER.B4

                        FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID INNER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID JOIN
						 dbo.L1_BLOC_AVALIDER on L1_BLOC_AVALIDER.L1_ID = Livret1_NonClos.ID");

            Sql(@"CREATE OR ALTER VIEW [dbo].[RQ_STATUT_DC_CAND]
                    AS
                    SELECT        dbo.DiplomeCands.ID, dbo.DiplomeCands.Candidat_ID, dbo.DiplomeCands.Diplome_ID, dbo.DomaineCompetences.Nom, dbo.DomaineCompetenceCands.Statut, CONVERT(nvarchar, 
                                             dbo.DomaineCompetenceCands.DateObtention, 103) AS DateObtention, dbo.DomaineCompetenceCands.ModeObtention, dbo.DomaineCompetences.Numero, dbo.Diplomes.Nom AS NomDiplome, DomaineCompetences.Nom as NomDC
                    FROM            dbo.DiplomeCands INNER JOIN
                                             dbo.DomaineCompetenceCands ON dbo.DiplomeCands.ID = dbo.DomaineCompetenceCands.Diplome_ID INNER JOIN
                                             dbo.DomaineCompetences ON dbo.DomaineCompetenceCands.DomaineCompetence_ID = dbo.DomaineCompetences.ID INNER JOIN
                                             dbo.Diplomes ON dbo.DiplomeCands.Diplome_ID = dbo.Diplomes.ID AND dbo.DomaineCompetences.Diplome_ID = dbo.Diplomes.ID
                ");

            Sql(@"CREATE OR ALTER   VIEW[dbo].[RQ_L2_DOC]
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
						         diplomes.nom as NOM_DIPLOME,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC1')) AS STATUT_DC1,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC1')) AS DATE_OBTENTION_DC1,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC1')) AS MODE_OBTENTION_DC1,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC2')) AS STATUT_DC2,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC2')) AS DATE_OBTENTION_DC2,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC2')) AS MODE_OBTENTION_DC2,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC3')) AS STATUT_DC3,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC3')) AS DATE_OBTENTION_DC3,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC3')) AS MODE_OBTENTION_DC3,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC4')) AS STATUT_DC4,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC4')) AS DATE_OBTENTION_DC4,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC4')) AS MODE_OBTENTION_DC4,

                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS DecisionDC1Livret,

                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS DecisionDC2Livret,
                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS DecisionDC3Livret,
                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret,

                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS ISAValiderDC1Livret,
                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS ISAValiderDC2Livret,
                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS ISAValiderDC3Livret,
                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS ISAValiderDC4Livret,
                             
							         (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS PropositionDC1Livret,
                                     (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS PropositionDC2Livret,
                                     (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS PropositionDC3Livret,
                                     (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS PropositionDC4Livret, 
							   

                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC1')) AS STATUT_BC1,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC1')) AS DATE_OBTENTION_BC1,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC1')) AS MODE_OBTENTION_BC1,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC2')) AS STATUT_BC2,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC2')) AS DATE_OBTENTION_BC2,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC2')) AS MODE_OBTENTION_BC2,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC3')) AS STATUT_BC3,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC3')) AS DATE_OBTENTION_BC3,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC3')) AS MODE_OBTENTION_BC3,
                                     (SELECT        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC4')) AS STATUT_BC4,
                                     (SELECT        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC4')) AS DATE_OBTENTION_BC4,
                                     (SELECT        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC4')) AS MODE_OBTENTION_BC4,

                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC1')) AS DecisionBC1Livret,

                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC2')) AS DecisionBC2Livret,
                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC3')) AS DecisionBC3Livret,
                                     (SELECT        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC4')) AS DecisionBC4Livret,

                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC1')) AS ISAValiderBC1Livret,
                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC2')) AS ISAValiderBC2Livret,
                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC3')) AS ISAValiderBC3Livret,
                                     (SELECT        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC4')) AS ISAValiderBC4Livret,
                             
							         (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC1')) AS PropositionBC1Livret,
                                     (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC2')) AS PropositionBC2Livret,
                                     (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC3')) AS PropositionBC3Livret,
                                     (SELECT        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC4')) AS PropositionBC4Livret, 

							           dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR, choose(dbo.Candidats.ISPostFormation + 1, 'Non', 'Oui') 
                                 AS IsPostFormation, choose(dbo.Livret2.isClos + 1, 'Non', 'Oui') AS isClos, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Non', 'Oui') AS IsDispenseArt2, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                                 choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Non', 'Oui') AS IsOuvertureApresRecours, choose(dbo.Livret2.IsTrtSpecial + 1, 'Non', 'Oui') AS IsTrtSpecial, choose(dbo.Livret2.IsNonRecu + 1, 'Non', 'Oui') AS Isnonrecu, 
                                 choose(dbo.Livret2.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, CONVERT(smalldatetime, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, CONVERT(smalldatetime, 
                                 dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, dbo.RQ_L2_PJ.Piecejointe

                FROM            dbo.Livret2 
                                INNER JOIN dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID 
                                INNER JOIN dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID 
                                LEFT OUTER JOIN dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID 
                                LEFT OUTER JOIN dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
						        INNER JOIN Diplomes ON Livret2.Diplome_ID = Diplomes.id
        ");

            Sql(@"CREATE OR ALTER VIEW [dbo].[RQ_ATTESTATION]
                    AS
                    SELECT        Civilite, NomJeuneFille, Nom, Prenom, Prenom2, Prenom3, Adresse, CodePostal, Ville, Region, Pays, Nationalite, sexe, DateNaissance, VilleNaissance, NationaliteNaissance, DptNaissance, PaysNaissance, Decision, 
                                             NOM_DIPLOME, STATUT_BC1, STATUT_BC2, STATUT_BC3, STATUT_BC4
                    FROM            dbo.RQ_L2_DOC
                    WHERE        (NOM_DIPLOME = 'CAFDESV2')
                    ");
        }
        
        public override void Down()
        {
            Sql(@"DROP VIEW [dbo].[RQ_ATTESTATION]");


            Sql(@" CREATE OR ALTER VIEW [dbo].[RQ_L1_DOC]
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
                TRY_CONVERT(smalldatetime, dbo.Livret1_NonClos.DateValiditeCNI, 103) AS DateValiditeCNI,
                choose(dbo.Candidats.IsPostFormation + 1, 'Non', 'Oui') AS IsPostFormation


                FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID INNER JOIN
                                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                                         dbo.Juries LEFT OUTER JOIN
                                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID
                ");

            Sql(@"DROP VIEW [dbo].[L1_BLOC_AVALIDER]");


            Sql(@"CREATE OR ALTER VIEW[dbo].[RQ_L2_DOC]
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
                               WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 1)) AS STATUT_DC1,
                             (SELECT        DateObtention

                      FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_1

                      WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 1)) AS DATE_OBTENTION_DC1,
                             (SELECT        ModeObtention

             FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_2

             WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 1)) AS MODE_OBTENTION_DC1,
                             (SELECT        Statut

    FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_3

    WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 2)) AS STATUT_DC2,
                             (SELECT        DateObtention

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_4

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 2)) AS DATE_OBTENTION_DC2,
                             (SELECT        ModeObtention

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_5

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 2)) AS MODE_OBTENTION_DC2,
                             (SELECT        Statut

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_6

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 3)) AS STATUT_DC3,
                             (SELECT        DateObtention

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_7

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 3)) AS DATE_OBTENTION_DC3,
                             (SELECT        ModeObtention

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_8

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 3)) AS MODE_OBTENTION_DC3,
                             (SELECT        Statut

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_9

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 4)) AS STATUT_DC4,
                             (SELECT        DateObtention

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_10

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 4)) AS DATE_OBTENTION_DC4,
                             (SELECT        ModeObtention

FROM            dbo.RQ_STATUT_DC_CAND AS RQ_STATUS_DC_CAND_11

WHERE(Candidat_ID = dbo.Candidats.ID) AND(Numero = 4)) AS MODE_OBTENTION_DC4,
                             (SELECT        DecisionJury

FROM            dbo.RQ_L2_DECISION_DC

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC1')) AS DecisionDC1Livret,
                             (SELECT        DecisionJury

FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_3

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC2')) AS DecisionDC2Livret,
                             (SELECT        DecisionJury

FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_2

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC3')) AS DecisionDC3Livret,
                             (SELECT        DecisionJury

FROM            dbo.RQ_L2_DECISION_DC AS RQ_STATUT_DC_L2_1

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC4')) AS DecisionDC4Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_4

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC1')) AS ISAValiderDC1Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_3

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC2')) AS ISAValiderDC2Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_2

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC3')) AS ISAValiderDC3Livret,
                             (SELECT        choose(IsAValider + 1, 'Non', 'Oui') AS Expr1

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_1

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC4')) AS ISAValiderDC4Livret,
                             (SELECT        PropositionDecision

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_1

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC1')) AS PropositionDC1Livret,
                             (SELECT        PropositionDecision

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_2

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC2')) AS PropositionDC2Livret,
                             (SELECT        PropositionDecision

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_3

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC3')) AS PropositionDC3Livret,
                             (SELECT        PropositionDecision

FROM            dbo.RQ_L2_DECISION_DC AS RQ_L2_DECISION_DC_4

WHERE(IDLivret = dbo.Livret2.ID) AND(Nom = 'DC4')) AS PropositionDC4Livret, dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR, choose(dbo.Candidats.ISPostFormation + 1, 'Non', 'Oui')
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

            Sql(@"CREATE OR ALTER VIEW [dbo].[RQ_STATUT_DC_CAND]
                    AS
                    SELECT        dbo.DiplomeCands.ID, dbo.DiplomeCands.Candidat_ID, dbo.DiplomeCands.Diplome_ID, dbo.DomaineCompetences.Nom, dbo.DomaineCompetenceCands.Statut, CONVERT(nvarchar, 
                                             dbo.DomaineCompetenceCands.DateObtention, 103) AS DateObtention, dbo.DomaineCompetenceCands.ModeObtention, dbo.DomaineCompetences.Numero, dbo.Diplomes.Nom AS NomDiplome
                    FROM            dbo.DiplomeCands INNER JOIN
                                             dbo.DomaineCompetenceCands ON dbo.DiplomeCands.ID = dbo.DomaineCompetenceCands.Diplome_ID INNER JOIN
                                             dbo.DomaineCompetences ON dbo.DomaineCompetenceCands.DomaineCompetence_ID = dbo.DomaineCompetences.ID INNER JOIN
                                             dbo.Diplomes ON dbo.DiplomeCands.Diplome_ID = dbo.Diplomes.ID AND dbo.DomaineCompetences.Diplome_ID = dbo.Diplomes.ID
                    WHERE        (dbo.Diplomes.Nom = N'CAFDES')");
        }
    }
}
