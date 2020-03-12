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
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (1, N'représentant de l''Etat ou d''une collectivité territoriale ou personne qualifiée', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (2, N'formateur issu d''un établissement de formation public ou privé préparant au CAFDES', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (3, N'représentant qualifié du secteur professionnel Employeur', 2019-02-26,2019-02-26,0, N'')");
            Sql("INSERT INTO [dbo].[ParamColleges] ([ID], [Nom], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (4, N'représentant qualifié du secteur professionnel Salarié', 2019-02-26,2019-02-26,0, N'')");
            Sql("SET IDENTITY_INSERT [dbo].[ParamColleges] OFF");
        }

        public override void Down()
        {
        }
    }
}
