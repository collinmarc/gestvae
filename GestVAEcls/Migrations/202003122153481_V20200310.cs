namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V20200310 : DbMigration
    {
        public override void Up()
        {
            Sql(@"delete from ParamColleges");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] ON");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'repr�sentant de l''Etat ou d''une collectivit� territoriale ou personne qualifi�e', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'formateur issu d''un �tablissement de formation public ou priv� pr�parant au CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'repr�sentant qualifi� du secteur professionnel Employeur', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'repr�sentant qualifi� du secteur professionnel Salari�', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] OFF");
        }

        public override void Down()
        {
        }
    }
}
