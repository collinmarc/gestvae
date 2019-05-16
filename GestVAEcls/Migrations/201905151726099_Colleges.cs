namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Colleges : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Colleges " + "start");
            Sql("DELETE FROM  [dbo].[ParamColleges]");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] ON");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'1 - représentant de l''Etat ou d''une collectivité territoriale ou personne qualifiée', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'2 – formateur issu d''un établissement de formation public ou privé préparant au CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'3 – représentant qualifié du secteur professionnel Employeur', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'4 -  représentant qualifié du secteur professionnel Salarié', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] OFF");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Colleges " + "end");
        }

        public override void Down()
        {
        }
    }
}
