namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPJ : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeCategories] ON");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'L1', N'EMPLOI', 2019-04-15 , 2019-04-15, 0, NULL)");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'L1', N'SI MOINS DE 3 ANS ET QU''IL Y AURA 3 ANS LE JOUR DU JURY', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, N'L1', N'CONSEIL D''ADMNISTRATION', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, N'L1', N'FORMATION DIPLOME', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (7, N'L1', N'DUREE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (8, N'L1', N'SOMMAIRE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (9, N'L1', N'SIGNATURE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (10, N'L1', N'RUBRIQUES', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (11, N'L1', N'SYNTHESE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (12, N'L1', N'ANNEXES', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (13, N'L1', N'2EME PASSAGE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (14, N'L1', N'ENGAGEMENT PARCOURS', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (15, N'L2', N'EMPLOI', 2019-04-15, 2019-04-15 , 1, NULL)");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (16, N'L2', N'SI MOINS DE 3 ANS ET QU''IL Y AURA 3 ANS LE JOUR DU JURY', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (17, N'L2', N'CONSEIL D''ADMNISTRATION', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (18, N'L2', N'FORMATION DIPLOME', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (19, N'L2', N'DUREE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (20, N'L2', N'SOMMAIRE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (21, N'L2', N'SIGNATURE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (22, N'L2', N'RUBRIQUES', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (23, N'L2', N'SYNTHESE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (24, N'L2', N'ANNEXES', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (25, N'L2', N'2EME PASSAGE', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("INSERT INTO [dbo].[PieceJointeCategories] ([ID], [Livret], [Categorie], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (26, N'L2', N'ENGAGEMENT PARCOURS', 2019-04-15, 2019-04-15, 0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeCategories] OFF");

            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeItems] ON");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, 3, N'Un justification de votre emploi actuel', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, 3, N'Les copies justifiant des emplois et activités bénévoles mentionnés en page 7 et 8 (certificats de travail et/ou attestations)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, 3, N'De plus l''expérience que vous avez choisi datant de plus de 10 ans, ne peut pas être l''unique expérience de travail développée', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, 4, N'Au (date des ans), une attestation signée de votre employeur indiquant que vous êtes toujours en poste', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, 5, N'La copie du compte rendu du conseil d''administration attestant de votre élection au sein du bureau en tant que président de l''association(nom de l''association)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, 6, N'Le relevé de parcours de formation au sein du groupe COMPASS', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (7, 6, N'La copie de votre diplome CAFERUIS', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (8, 6, N'La copie des diplômes et/ou certificats des formations', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (9, 7, N'La description d''une seconde expérience car l''expérience qui constitue votre Livret2 à ce jour ne permet pas de justifier d''au moins 3 années d''activités équivalent Temps plein (voir page 10 de la notice d''accompagnement pour remplir le Livret2)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (10, 7, N'Si vous ne souhaitez pas développer une seconde expérience, vous voudrez bien fournir une attestation sur l''honneur mentionnant au jury vôtre choix de ne développer qu''une seule expérience qui concerne éventuellement les expériences précédentes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (11, 8, N'Le sommaire de votre livret de présentation des acquis de l''expérience.', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (12, 9, N'La signature originale de l''attestation sur l''honneur  et de la demande d''inscription en vue de l''obtention du CAFDES (voir Page 5 du Livret 2)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (13, 10, N'La page explicative du livret2 où figure un cadre sur votre identitié à compléter ainsi qu''un cadre réservé à l''administration', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (14, 10, N'La page de couverture complétée de votre nom, prénom et numéro de dossier', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (15, 10, N'Le tableau rubrique 2 (vos expériences salariées) dûment complété', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (16, 10, N'Le tableau rubrique 3 (votre parcours de formation) dûment complété', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (17, 10, N'Le point 4.1.1 : Votre emploi ou votre fonction bénévole dûment complété', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (18, 10, N'Le point 4.2.4 : votre quatrième situation de travail (gestion économique, financière et logistique d''un établissement ou d''un service)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (19, 10, N'Le point 5.3 : Analyse globale de votre expérience n° 2', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (20, 11, N'Le tableau de synthèse des documents annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (21, 11, N'Le tableau de synthèse des documents annexes dûment complété des fonction en lien avec les annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (22, 12, N'Vos annexes en français dûment traduites en français par un traducteur assermenté', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (23, 12, N'Vos certificats de travail ou attestations non anonymisés', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (24, 12, N'4 exemplaires supplémentaires de l''ensemble des annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (25, 13, N'La copie de relevé de décision de jury', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (26, 13, N'La copie du dernier relevé de décision de jury qui vous a été adressé', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (27, 14, N'Votre convention ou contrat relatif à un parcours de validation des acquis de l''expérience dûment complété et signé (en 3 exemplaires)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeItems] OFF");
        }

        public override void Down()
        {
            Sql("DELETE FROM [dbo].[PieceJointeItems]");
            Sql("DELETE FROM [dbo].[PieceJointeCategories]");
        }
    }
}
