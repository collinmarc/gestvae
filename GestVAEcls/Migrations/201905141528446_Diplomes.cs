namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Diplomes : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Diplomes " + "start");
            Sql("DELETE FROM [dbo].[Diplomes] Where Nom='CAFERUIS'");
            Sql("DELETE FROM [dbo].[Diplomes] Where Nom='DEIS'");
            Sql("INSERT INTO [dbo].[Diplomes] ([Nom], [Description], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES ( N'CAFERUIS', N'CAFERUIS', 2019-05-15, 2019-05-15, 0, NULL)");
            Sql("INSERT INTO [dbo].[Diplomes] ([Nom], [Description], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES ( N'DEIS', N'DEIS', 2019-05-15, 2019-05-15, 0, NULL)");

            AddColumn("dbo.DiplomeCands", "ModeObtention", c => c.String());
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "Diplomes " + "End");
        }

        public override void Down()
        {
            DropColumn("dbo.DiplomeCands", "ModeObtention");
        }
    }
}
