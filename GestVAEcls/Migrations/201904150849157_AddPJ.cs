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
            Sql("SET IDENTITY_INSERT [dbo].[PieceJointeItems] OFF");
        }

        public override void Down()
        {
            Sql("DELETE FROM [dbo].[PieceJointeItems]");
            Sql("DELETE FROM [dbo].[PieceJointeCategories]");
        }
    }
}
