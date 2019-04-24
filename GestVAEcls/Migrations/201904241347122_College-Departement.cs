namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollegeDepartement : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ParamOrigines", newName: "ParamDepartements");
            Sql("Delete from ParamDepartements");

            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'01-Ain', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'02-Aisne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'03-Allier', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'05-Hautes-Alpes', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'04-Alpes-de-Haute-Provence', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'06-Alpes-Maritimes', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'07-Ardèche', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'08-Ardennes', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'09-Ariège', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'10-Aube', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'11-Aude', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'12-Aveyron', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'13-Bouches-du-Rhône', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'14-Calvados', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'15-Cantal', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'16-Charente', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'17-Charente-Maritime', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'18-Cher', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'19-Corrèze', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'2a-Corse-du-sud', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'2b-Haute-corse', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'21-Côte-d''or', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'22-Côtes-d''armor', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'23-Creuse', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'24-Dordogne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'25-Doubs', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'26-Drôme', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'27-Eure', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'28-Eure-et-Loir', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'29-Finistère', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'30-Gard', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'31-Haute-Garonne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'32-Gers', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'33-Gironde', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'34-Hérault', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'35-Ile-et-Vilaine', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'36-Indre', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'37-Indre-et-Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'38-Isère', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'39-Jura', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'40-Landes', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'41-Loir-et-Cher', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'42-Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'43-Haute-Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'44-Loire-Atlantique', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'45-Loiret', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'46-Lot', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'47-Lot-et-Garonne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'48-Lozère', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'49-Maine-et-Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'50-Manche', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'51-Marne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'52-Haute-Marne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'53-Mayenne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'54-Meurthe-et-Moselle', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'55-Meuse', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'56-Morbihan', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'57-Moselle', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'58-Nièvre', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'59-Nord', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'60-Oise', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'61-Orne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'62-Pas-de-Calais', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'63-Puy-de-Dôme', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'64-Pyrénées-Atlantiques', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'65-Hautes-Pyrénées', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'66-Pyrénées-Orientales', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'67-Bas-Rhin', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'68-Haut-Rhin', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'69-Rhône', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'70-Haute-Saône', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'71-Saône-et-Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'72-Sarthe', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'73-Savoie', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'74-Haute-Savoie', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'75-Paris', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'76-Seine-Maritime', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'77-Seine-et-Marne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'78-Yvelines', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'79-Deux-Sèvres', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'80-Somme', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'81-Tarn', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'82-Tarn-et-Garonne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'83-Var', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'84-Vaucluse', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'85-Vendée', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'86-Vienne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'87-Haute-Vienne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'88-Vosges', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'89-Yonne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'90-Territoire de Belfort', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'91-Essonne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'92-Hauts-de-Seine', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'93-Seine-Saint-Denis', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'94-Val-de-Marne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'95-Val-d''oise', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'976-Mayotte', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'971-Guadeloupe', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'973-Guyane', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'972-Martinique', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamDepartements] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'974-Réunion', 2019-02-26,2019-02-26,0, N'')");

            Sql("DELETE FROM  [dbo].[Regions]" );
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Guadeloupe', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Martinique', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Guyane', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'La Réunion', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Mayotte', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Île-de-France', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Centre-Val de Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Bourgogne-Franche-Comté', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Normandie', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Hauts-de-France', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Grand Est', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Pays de la Loire', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Bretagne', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Nouvelle-Aquitaine', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Occitanie', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Auvergne-Rhône-Alpes', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Provence-Alpes-Côte d''Azur', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'Corse', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[Regions] ([Nom], [dateCreation], [dateModif], [bDeleted], [AttSup] )VALUES( N'', 2019-02-26,2019-02-26,0, N'')");
        }

        public override void Down()
        {
            Sql("Delete from ParamDepartements");
            Sql("Delete from Regions");
            RenameTable(name: "dbo.ParamDepartements", newName: "ParamOrigines");
        }
    }
}
