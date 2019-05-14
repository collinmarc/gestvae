namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Diplomes : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM [dbo].[Diplomes] Where Nom='CAFERUIS'");
            Sql("DELETE FROM [dbo].[Diplomes] Where Nom='DEIS'");
            Sql("INSERT INTO [dbo].[Diplomes] ([Nom], [Description], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES ( N'CAFERUIS', N'CAFERUIS', '24-06-1905 00:00:00', '24-06-1905 00:00:00', 0, NULL)");
            Sql("INSERT INTO [dbo].[Diplomes] ([Nom], [Description], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES ( N'DEIS', N'DEIS', '24-06-1905 00:00:00', '24-06-1905 00:00:00', 0, NULL)");

            AddColumn("dbo.DiplomeCands", "ModeObtention", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiplomeCands", "ModeObtention");
        }
    }
}
