namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKDiplomeID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Livret1", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret2", "oDiplome_ID", "dbo.Diplomes");
            DropIndex("dbo.Livret1", new[] { "oDiplome_ID" });
            DropIndex("dbo.Livret2", new[] { "oDiplome_ID" });
            RenameColumn(table: "dbo.Livret1", name: "oDiplome_ID", newName: "Diplome_ID");
            RenameColumn(table: "dbo.Livret2", name: "oDiplome_ID", newName: "Diplome_ID");
            AlterColumn("dbo.Livret1", "Diplome_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Livret2", "Diplome_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Livret1", "Diplome_ID");
            CreateIndex("dbo.Livret2", "Diplome_ID");
            AddForeignKey("dbo.Livret1", "Diplome_ID", "dbo.Diplomes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Livret2", "Diplome_ID", "dbo.Diplomes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livret2", "Diplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret1", "Diplome_ID", "dbo.Diplomes");
            DropIndex("dbo.Livret2", new[] { "Diplome_ID" });
            DropIndex("dbo.Livret1", new[] { "Diplome_ID" });
            AlterColumn("dbo.Livret2", "Diplome_ID", c => c.Int());
            AlterColumn("dbo.Livret1", "Diplome_ID", c => c.Int());
            RenameColumn(table: "dbo.Livret2", name: "Diplome_ID", newName: "oDiplome_ID");
            RenameColumn(table: "dbo.Livret1", name: "Diplome_ID", newName: "oDiplome_ID");
            CreateIndex("dbo.Livret2", "oDiplome_ID");
            CreateIndex("dbo.Livret1", "oDiplome_ID");
            AddForeignKey("dbo.Livret2", "oDiplome_ID", "dbo.Diplomes", "ID");
            AddForeignKey("dbo.Livret1", "oDiplome_ID", "dbo.Diplomes", "ID");
        }
    }
}
