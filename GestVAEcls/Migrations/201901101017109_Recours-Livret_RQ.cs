namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecoursLivret_RQ : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recours", "oLivret_ID", "dbo.Livret1");
            DropIndex("dbo.Recours", new[] { "oLivret_ID" });
            AlterColumn("dbo.Recours", "oLivret_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recours", "oLivret_ID");
            AddForeignKey("dbo.Recours", "oLivret_ID", "dbo.Livret1", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recours", "oLivret_ID", "dbo.Livret1");
            DropIndex("dbo.Recours", new[] { "oLivret_ID" });
            AlterColumn("dbo.Recours", "oLivret_ID", c => c.Int());
            CreateIndex("dbo.Recours", "oLivret_ID");
            AddForeignKey("dbo.Recours", "oLivret_ID", "dbo.Livret1", "ID");
        }
    }
}
