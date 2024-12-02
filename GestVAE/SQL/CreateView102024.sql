        
CREATE VIEW [dbo].[RQ_ATTESTATION]
                    AS
                    SELECT        Civilite, NomJeuneFille, Nom, Prenom, Prenom2, Prenom3, Adresse, CodePostal, Ville, Region, Pays, Nationalite, sexe, DateNaissance, VilleNaissance, NationaliteNaissance, DptNaissance, PaysNaissance, Decision, 
                                             NOM_DIPLOME, STATUT_BC1, STATUT_BC2, STATUT_BC3, STATUT_BC4
                    FROM            dbo.RQ_L2_DOC
                    WHERE        (NOM_DIPLOME = 'CAFDESV2');
					
CREATE   VIEW [dbo].[L1_BLOC_AVALIDER]
                    AS
                    SELECT L1.ID AS L1_ID, diplomes.Nom as NOM_DIPLOME,
                    (SELECT DCLivrets.IsAValider 
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 1
                    ) AS B1_DEMANDE,
                    (SELECT DCLivrets.IsAValider 
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 2
                    ) AS B2_DEMANDE,
                    (SELECT DCLivrets.IsAValider 
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 3
                    ) AS B3_DEMANDE,
                    (SELECT DCLivrets.IsAValider
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 4
                    ) AS B4_DEMANDE,

                    (SELECT DCLivrets.Statut 
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 1
                    ) AS B1_STATUT,
                    (SELECT DCLivrets.Statut
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 2
                    ) AS B2_STATUT,
                    (SELECT DCLivrets.Statut
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 3
                    ) AS B3_STATUT,
                    (SELECT DCLivrets.Statut
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 4
                    ) AS B4_STATUT, 

					(SELECT DCLivrets.MotifGeneral 
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 1
                    ) AS B1_MOTIF_GENERAL,
                    (SELECT DCLivrets.MotifGeneral
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 2
                    ) AS B2_MOTIF_GENERAL,
                    (SELECT DCLivrets.MotifGeneral
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 3
                    ) AS B3_MOTIF_GENERAL,
                    (SELECT DCLivrets.MotifGeneral
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 4
                    ) AS B4_MOTIF_GENERAL,

                    (SELECT DCLivrets.MotifCommentaire 
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 1
                    ) AS B1_MOTIF_COMMENTAIRE,
                    (SELECT DCLivrets.MotifCommentaire
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 2
                    ) AS B2_MOTIF_COMMENTAIRE,
                    (SELECT DCLivrets.MotifCommentaire
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 3
                    ) AS B3_MOTIF_COMMENTAIRE,
                    (SELECT DCLivrets.MotifCommentaire
                    from DCLivrets, DomaineCompetences
                    WHERE L1.ID = DCLivrets.oLivret1_ID AND DomaineCompetences.ID = DCLivrets.oDomaineCompetence_ID
                    AND DomaineCompetences.Numero = 4
                    ) AS B4_MOTIF_COMMENTAIRE


                    FROM Livret1 L1, Diplomes
                    WHERE L1.Diplome_ID = Diplomes.ID 
                ;
CREATE   VIEW [dbo].[RQ_L1_DOC]
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
                        dbo.Juries.MotifGeneral AS MotifGeneral, 
                        dbo.Juries.MotifCommentaire, 
                        choose(L1_BLOC_AVALIDER.B1_DEMANDE + 1, 'Non', 'Oui') AS B1_DEMANDE,
                        choose(L1_BLOC_AVALIDER.B2_DEMANDE + 1, 'Non', 'Oui') AS B2_DEMANDE,
                        choose(L1_BLOC_AVALIDER.B3_DEMANDE + 1, 'Non', 'Oui') AS B3_DEMANDE,
                        choose(L1_BLOC_AVALIDER.B4_DEMANDE + 1, 'Non', 'Oui') AS B4_DEMANDE,
                        L1_BLOC_AVALIDER.B1_STATUT,
                        L1_BLOC_AVALIDER.B2_STATUT,
                        L1_BLOC_AVALIDER.B3_STATUT,
                        L1_BLOC_AVALIDER.B4_STATUT,
						L1_BLOC_AVALIDER.B1_MOTIF_GENERAL,
                        L1_BLOC_AVALIDER.B2_MOTIF_GENERAL,
                        L1_BLOC_AVALIDER.B3_MOTIF_GENERAL,
                        L1_BLOC_AVALIDER.B4_MOTIF_GENERAL,
						L1_BLOC_AVALIDER.B1_MOTIF_COMMENTAIRE,
                        L1_BLOC_AVALIDER.B2_MOTIF_COMMENTAIRE,
                        L1_BLOC_AVALIDER.B3_MOTIF_COMMENTAIRE,
                        L1_BLOC_AVALIDER.B4_MOTIF_COMMENTAIRE


                        FROM            dbo.RQ_L1_PJ RIGHT OUTER JOIN
                         dbo.Livret1_NonClos ON dbo.RQ_L1_PJ.LIVRET1_ID = dbo.Livret1_NonClos.ID INNER JOIN
                         dbo.Candidats ON dbo.Livret1_NonClos.Candidat_ID = dbo.Candidats.ID LEFT OUTER JOIN
                         dbo.Juries LEFT OUTER JOIN
                         dbo.Recours ON dbo.Juries.ID = dbo.Recours.Jury_ID ON dbo.Livret1_NonClos.ID = dbo.Juries.Livret1_ID JOIN
						 dbo.L1_BLOC_AVALIDER on L1_BLOC_AVALIDER.L1_ID = Livret1_NonClos.ID
                    ;
CREATE     VIEW[dbo].[RQ_L2_DOC]
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
							           dbo.DiplomeCands.NumeroDiplome, dbo.DiplomeCands.NumeroEURODIR, choose(dbo.Candidats.ISPostFormation + 1, 'Non', 'Oui') 
                                 AS IsPostFormation, choose(dbo.Livret2.isClos + 1, 'Non', 'Oui') AS isClos, choose(dbo.Livret2.IsDispenseArt2 + 1, 'Non', 'Oui') AS IsDispenseArt2, dbo.Candidats.ID, dbo.Candidats.IdVAE, dbo.Candidats.IdSiscole, 
                                 choose(dbo.Livret2.IsOuvertureApresRecours + 1, 'Non', 'Oui') AS IsOuvertureApresRecours, choose(dbo.Livret2.IsTrtSpecial + 1, 'Non', 'Oui') AS IsTrtSpecial, choose(dbo.Livret2.IsNonRecu + 1, 'Non', 'Oui') AS Isnonrecu, 
                                 choose(dbo.Livret2.IsEnregistre + 1, 'Non', 'Oui') AS IsEnregistre, CONVERT(smalldatetime, dbo.Livret2.Date1ereDemandePieceManquantes, 103) AS Date1ereDemandePieceManquante, CONVERT(smalldatetime, 
                                 dbo.Livret2.DateReceptionPiecesManquantes, 103) AS DateReceptionPiecesManquantes, CONVERT(smalldatetime, dbo.Livret2.DateDemande1erRetour, 103) AS DateDemande1erRetour, dbo.RQ_L2_PJ.Piecejointe,
						         diplomes.nom as NOM_DIPLOME,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC1')) AS STATUT_DC1,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC1')) AS DATE_OBTENTION_DC1,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC1')) AS MODE_OBTENTION_DC1,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC2')) AS STATUT_DC2,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC2')) AS DATE_OBTENTION_DC2,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC2')) AS MODE_OBTENTION_DC2,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC3')) AS STATUT_DC3,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC3')) AS DATE_OBTENTION_DC3,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC3')) AS MODE_OBTENTION_DC3,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC4')) AS STATUT_DC4,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC4')) AS DATE_OBTENTION_DC4,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'DC4')) AS MODE_OBTENTION_DC4,

                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS DecisionDC1Livret,

                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS DecisionDC2Livret,
                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS DecisionDC3Livret,
                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS DecisionDC4Livret,

                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS ISAValiderDC1Livret,
                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS ISAValiderDC2Livret,
                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS ISAValiderDC3Livret,
                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS ISAValiderDC4Livret,
                             
							         (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC1')) AS PropositionDC1Livret,
                                     (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC2')) AS PropositionDC2Livret,
                                     (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC3')) AS PropositionDC3Livret,
                                     (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'DC4')) AS PropositionDC4Livret, 
							   

                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC1')) AS STATUT_BC1,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC1')) AS DATE_OBTENTION_BC1,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC1')) AS MODE_OBTENTION_BC1,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC2')) AS STATUT_BC2,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC2')) AS DATE_OBTENTION_BC2,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC2')) AS MODE_OBTENTION_BC2,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC3')) AS STATUT_BC3,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC3')) AS DATE_OBTENTION_BC3,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC3')) AS MODE_OBTENTION_BC3,
                                     (SELECT TOP 1        Statut
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC4')) AS STATUT_BC4,
                                     (SELECT TOP 1        DateObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC4')) AS DATE_OBTENTION_BC4,
                                     (SELECT TOP 1        ModeObtention
                                       FROM            dbo.RQ_STATUT_DC_CAND 
                                       WHERE        (Candidat_ID = dbo.Candidats.ID) AND (NomDC = 'BLOC4')) AS MODE_OBTENTION_BC4,

                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC1')) AS DecisionBC1Livret,

                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC2')) AS DecisionBC2Livret,
                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC3')) AS DecisionBC3Livret,
                                     (SELECT TOP 1        DecisionJury
                                       FROM            dbo.RQ_L2_DECISION_DC
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC4')) AS DecisionBC4Livret,

                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC1')) AS ISAValiderBC1Livret,
                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC2')) AS ISAValiderBC2Livret,
                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC3')) AS ISAValiderBC3Livret,
                                     (SELECT TOP 1        choose(IsAValider + 1, 'Non', 'Oui') 
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC4')) AS ISAValiderBC4Livret,
                             
							         (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC1')) AS PropositionBC1Livret,
                                     (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC2')) AS PropositionBC2Livret,
                                     (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC3')) AS PropositionBC3Livret,
                                     (SELECT TOP 1        PropositionDecision
                                       FROM            dbo.RQ_L2_DECISION_DC 
                                       WHERE        (IDLivret = dbo.Livret2.ID) AND (Nom = 'BLOC4')) AS PropositionBC4Livret 


                FROM            dbo.Livret2 
                                INNER JOIN dbo.Candidats ON dbo.Livret2.Candidat_ID = dbo.Candidats.ID 
                                INNER JOIN dbo.DiplomeCands ON dbo.Candidats.ID = dbo.DiplomeCands.Candidat_ID AND dbo.Livret2.Diplome_ID = dbo.DiplomeCands.Diplome_ID 
                                LEFT OUTER JOIN dbo.RQ_L2_PJ ON dbo.Livret2.ID = dbo.RQ_L2_PJ.LIVRET2_ID 
                                LEFT OUTER JOIN dbo.Juries ON dbo.Livret2.ID = dbo.Juries.Livret2_ID
						        INNER JOIN Diplomes ON Livret2.Diplome_ID = Diplomes.id
