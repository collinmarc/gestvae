namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LivretDiplome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "oDiplome_ID", c => c.Int());
            AddColumn("dbo.Livret2", "oDiplome_ID", c => c.Int());
            CreateIndex("dbo.Livret1", "oDiplome_ID");
            CreateIndex("dbo.Livret2", "oDiplome_ID");
            AddForeignKey("dbo.Livret1", "oDiplome_ID", "dbo.Diplomes", "ID");
            AddForeignKey("dbo.Livret2", "oDiplome_ID", "dbo.Diplomes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livret2", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret1", "oDiplome_ID", "dbo.Diplomes");
            DropIndex("dbo.Livret2", new[] { "oDiplome_ID" });
            DropIndex("dbo.Livret1", new[] { "oDiplome_ID" });
            DropColumn("dbo.Livret2", "oDiplome_ID");
            DropColumn("dbo.Livret1", "oDiplome_ID");
        }
    }
}
