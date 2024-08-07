namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPJ : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM  PieceJointeCategories");
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

            Sql("DELETE FROM  PieceJointeItems");
            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeItems] ON");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, 3, N'Une justification de votre emploi actuel', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, 3, N'Les copies justifiant des emplois et activit�s b�n�voles mentionn�s en page 7 et 8 (certificats de travail et/ou attestations)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, 3, N'De plus l''exp�rience que vous avez choisi datant de plus de 10 ans, ne peut pas �tre l''unique exp�rience de travail d�velopp�e', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, 4, N'Au (date des ans), une attestation sign�e de votre employeur indiquant que vous �tes toujours en poste', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, 5, N'La copie du compte rendu du conseil d''administration attestant de votre �lection au sein du bureau en tant que pr�sident de l''association(nom de l''association)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, 6, N'Le relev� de parcours de formation au sein du groupe COMPASS', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (7, 6, N'La copie de votre diplome CAFERUIS', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (8, 6, N'La copie des dipl�mes et/ou certificats des formations', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (9, 7, N'La description d''une seconde exp�rience car l''exp�rience qui constitue votre Livret2 � ce jour ne permet pas de justifier d''au moins 3 ann�es d''activit�s �quivalent Temps plein (voir page 10 de la notice d''accompagnement pour remplir le Livret2)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (10, 7, N'Si vous ne souhaitez pas d�velopper une seconde exp�rience, vous voudrez bien fournir une attestation sur l''honneur mentionnant au jury v�tre choix de ne d�velopper qu''une seule exp�rience qui concerne �ventuellement les exp�riences pr�c�dentes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (11, 8, N'Le sommaire de votre livret de pr�sentation des acquis de l''exp�rience.', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (12, 9, N'La signature originale de l''attestation sur l''honneur  et de la demande d''inscription en vue de l''obtention du CAFDES (voir Page 5 du Livret 2)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (13, 10, N'La page explicative du livret2 o� figure un cadre sur votre identiti� � compl�ter ainsi qu''un cadre r�serv� � l''administration', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (14, 10, N'La page de couverture compl�t�e de votre nom, pr�nom et num�ro de dossier', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (15, 10, N'Le tableau rubrique 2 (vos exp�riences salari�es) d�ment compl�t�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (16, 10, N'Le tableau rubrique 3 (votre parcours de formation) d�ment compl�t�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (17, 10, N'Le point 4.1.1 : Votre emploi ou votre fonction b�n�vole d�ment compl�t�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (18, 10, N'Le point 4.2.4 : votre quatri�me situation de travail (gestion �conomique, financi�re et logistique d''un �tablissement ou d''un service)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (19, 10, N'Le point 5.3 : Analyse globale de votre exp�rience n� 2', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (20, 11, N'Le tableau de synth�se des documents annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (21, 11, N'Le tableau de synth�se des documents annexes d�ment compl�t� des fonction en lien avec les annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (22, 12, N'Vos annexes en fran�ais d�ment traduites en fran�ais par un traducteur asserment�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (23, 12, N'Vos certificats de travail ou attestations non anonymis�s', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (24, 12, N'4 exemplaires suppl�mentaires de l''ensemble des annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (25, 13, N'La copie de relev� de d�cision de jury', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (26, 13, N'La copie du dernier relev� de d�cision de jury qui vous a �t� adress�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (27, 14, N'Votre convention ou contrat relatif � un parcours de validation des acquis de l''exp�rience d�ment compl�t� et sign� (en 3 exemplaires)', 2019-04-15, 2019-04-15,0,N'')");

            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (28, 15, N'Une justification de votre emploi actuel', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (29, 15, N'Les copies justifiant des emplois et activit�s b�n�voles mentionn�s en page 7 et 8 (certificats de travail et/ou attestations)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (30, 15, N'De plus l''exp�rience que vous avez choisi datant de plus de 10 ans, ne peut pas �tre l''unique exp�rience de travail d�velopp�e', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (31, 16, N'Au (date des ans), une attestation sign�e de votre employeur indiquant que vous �tes toujours en poste', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (32, 17, N'La copie du compte rendu du conseil d''administration attestant de votre �lection au sein du bureau en tant que pr�sident de l''association(nom de l''association)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (33, 18, N'Le relev� de parcours de formation au sein du groupe COMPASS', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (34, 18, N'La copie de votre diplome CAFERUIS', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (35, 18, N'La copie des dipl�mes et/ou certificats des formations', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (36, 19, N'La description d''une seconde exp�rience car l''exp�rience qui constitue votre Livret2 � ce jour ne permet pas de justifier d''au moins 3 ann�es d''activit�s �quivalent Temps plein (voir page 10 de la notice d''accompagnement pour remplir le Livret2)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (37, 19, N'Si vous ne souhaitez pas d�velopper une seconde exp�rience, vous voudrez bien fournir une attestation sur l''honneur mentionnant au jury v�tre choix de ne d�velopper qu''une seule exp�rience qui concerne �ventuellement les exp�riences pr�c�dentes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (38, 20, N'Le sommaire de votre livret de pr�sentation des acquis de l''exp�rience.', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (39, 21, N'La signature originale de l''attestation sur l''honneur  et de la demande d''inscription en vue de l''obtention du CAFDES (voir Page 5 du Livret 2)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (40, 22, N'La page explicative du livret2 o� figure un cadre sur votre identiti� � compl�ter ainsi qu''un cadre r�serv� � l''administration', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (41, 22, N'La page de couverture compl�t�e de votre nom, pr�nom et num�ro de dossier', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (42, 22, N'Le tableau rubrique 2 (vos exp�riences salari�es) d�ment compl�t�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (43, 22, N'Le tableau rubrique 3 (votre parcours de formation) d�ment compl�t�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (44, 22, N'Le point 4.1.1 : Votre emploi ou votre fonction b�n�vole d�ment compl�t�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (45, 22, N'Le point 4.2.4 : votre quatri�me situation de travail (gestion �conomique, financi�re et logistique d''un �tablissement ou d''un service)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (46, 22, N'Le point 5.3 : Analyse globale de votre exp�rience n� 2', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (47, 23, N'Le tableau de synth�se des documents annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (48, 23, N'Le tableau de synth�se des documents annexes d�ment compl�t� des fonction en lien avec les annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (49, 24, N'Vos annexes en fran�ais d�ment traduites en fran�ais par un traducteur asserment�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (50, 24, N'Vos certificats de travail ou attestations non anonymis�s', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (51, 24, N'4 exemplaires suppl�mentaires de l''ensemble des annexes', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (52, 25, N'La copie de relev� de d�cision de jury', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (53, 25, N'La copie du dernier relev� de d�cision de jury qui vous a �t� adress�', 2019-04-15, 2019-04-15,0,N'')");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([ID], [Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (54, 26, N'Votre convention ou contrat relatif � un parcours de validation des acquis de l''exp�rience d�ment compl�t� et sign� (en 3 exemplaires)', 2019-04-15, 2019-04-15,0,N'')");
            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeItems] OFF");

            Sql("DELETE FROM  MotifGeneralL1");
            Sql("SET IDENTITY_INSERT [dbo].[MotifGeneralL1] ON");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'Pas d''activit� dans au moins 1 DC',2019-02-07 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'Pas d''activit� dans au moins 2 DC',2019-02-07 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'Pas d''activit� dans au moins 3 DC',2019-02-26,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'Pas d''activit� dans au moins 4 DC',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, N'L''objet des activit�s mentionn�es dans le DC1 ne porte pas sur les politiques sanitaires et sociales.',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, N'Derni�re exp�rience en lien avec le dipl�me date de plus de 10 ans.',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (7, N'Exp�rience de moins de 3 ans �quivalent temps plein en lien avec le r�f�rentiel de comp�tences CAFDES, � la date de l''analyse du livret de recevabilit�',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL1] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (8, N'Pi�ces manquantes demand�es non r�ceptionn�es dans le d�lai imparti.',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[MotifGeneralL1] OFF");

            Sql("DELETE FROM  MotifGeneralL2");
            Sql("SET IDENTITY_INSERT [dbo].[MotifGeneralL2] ON");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'Pas d''activit� dans au moins 1 DC',2019-02-07 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'Pas d''activit� dans au moins 2 DC',2019-02-07 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'Pas d''activit� dans au moins 3 DC',2019-02-26,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'Pas d''activit� dans au moins 4 DC',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, N'L''objet des activit�s mentionn�es dans le DC1 ne porte pas sur les politiques sanitaires et sociales.',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, N'Derni�re exp�rience en lien avec le dipl�me date de plus de 10 ans.',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (7, N'Exp�rience de moins de 3 ans �quivalent temps plein en lien avec le r�f�rentiel de comp�tences CAFDES, � la date de l''analyse du livret de recevabilit�',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("INSERT INTO [dbo].[MotifGeneralL2] ([ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (8, N'Pi�ces manquantes demand�es non r�ceptionn�es dans le d�lai imparti.',2019-02-26 ,2019-02-07, 0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[MotifGeneralL2] OFF");

            Sql("DELETE FROM  [dbo].[ParamTypeDemandes] ");
            Sql("SET IDENTITY_INSERT [dbo].[ParamTypeDemandes] ON");
            Sql("INSERT INTO [dbo].[ParamTypeDemandes] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'Courrier', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamTypeDemandes] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'T�l�phone', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamTypeDemandes] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'Mail', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamTypeDemandes] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'Retrait au secretariat VAE', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamTypeDemandes] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, N'Non renseign�', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamTypeDemandes] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, N'Fax', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamTypeDemandes] OFF");
            Sql("DELETE FROM  [dbo].[ParamVecteurInformations]");
            Sql("SET IDENTITY_INSERT [dbo].[ParamVecteurInformations] ON");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'EHESP(autre)', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'Site EHESP', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'Etablissement de formation CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'Site �tablissements de formation CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (5, N'Organisme de formation (suite � une prestation)', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (6, N'Directeur, RH', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (7, N'Coll�gues', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (8, N'DRASS', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (9, N'PIC/PRC', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (10, N'ASH', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (11, N'Gazette des communes', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (12, N'Direction', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (13, N'TSA', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (14, N'Autres', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (15, N'Presse', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (16, N'Salon G�ront''Expo', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (17, N'Pole Emploi', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (18, N'ASP (CNASEA)', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (19, N'Internet (Autres sites...)', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamVecteurInformations] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (20, N'Non renseign�', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamVecteurInformations] OFF");
            Sql("DELETE FROM  [dbo].[ParamColleges]");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] ON");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'1 - repr�sentant de l''Etat ou d''une collectivit� territoriale ou personne qualifi�e', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'2 � formateur issu d''un �tablissement de formation public ou priv� pr�parant au CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'3 � repr�sentant qualifi� du secteur professionnel Employeur', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'4 -  repr�sentant qualifi� du secteur professionnel Salari�', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] OFF");

        }

        public override void Down()
        {
            Sql("DELETE FROM [dbo].[PieceJointeItems]");
            Sql("DELETE FROM [dbo].[PieceJointeCategories]");
        }
    }
}
