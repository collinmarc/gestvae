namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PJRequiered : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2");
            DropIndex("dbo.PieceJointeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.PieceJointeL2", new[] { "oLivret_ID" });
            AlterColumn("dbo.PieceJointeL1", "oLivret_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.PieceJointeL2", "oLivret_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.PieceJointeL1", "oLivret_ID");
            CreateIndex("dbo.PieceJointeL2", "oLivret_ID");
            AddForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1");
            DropIndex("dbo.PieceJointeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.PieceJointeL1", new[] { "oLivret_ID" });
            AlterColumn("dbo.PieceJointeL2", "oLivret_ID", c => c.Int());
            AlterColumn("dbo.PieceJointeL1", "oLivret_ID", c => c.Int());
            CreateIndex("dbo.PieceJointeL2", "oLivret_ID");
            CreateIndex("dbo.PieceJointeL1", "oLivret_ID");
            AddForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2", "ID");
            AddForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1", "ID");
        }
    }
}
