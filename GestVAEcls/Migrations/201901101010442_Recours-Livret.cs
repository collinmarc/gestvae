namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecoursLivret : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recours", "Livret2_ID", "dbo.Livret2");
            DropIndex("dbo.Recours", new[] { "Livret2_ID" });
            RenameColumn(table: "dbo.Recours", name: "Livret1_ID", newName: "oLivret_ID");
            RenameIndex(table: "dbo.Recours", name: "IX_Livret1_ID", newName: "IX_oLivret_ID");
            DropColumn("dbo.Recours", "Livret2_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recours", "Livret2_ID", c => c.Int());
            RenameIndex(table: "dbo.Recours", name: "IX_oLivret_ID", newName: "IX_Livret1_ID");
            RenameColumn(table: "dbo.Recours", name: "oLivret_ID", newName: "Livret1_ID");
            CreateIndex("dbo.Recours", "Livret2_ID");
            AddForeignKey("dbo.Recours", "Livret2_ID", "dbo.Livret2", "ID");
        }
    }
}
