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
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'1 - repr�sentant de l''Etat ou d''une collectivit� territoriale ou personne qualifi�e', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'2 � formateur issu d''un �tablissement de formation public ou priv� pr�parant au CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'3 � repr�sentant qualifi� du secteur professionnel Employeur', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'4 -  repr�sentant qualifi� du secteur professionnel Salari�', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] OFF");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Colleges " + "end");
        }

        public override void Down()
        {
        }
    }
}
