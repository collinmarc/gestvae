namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DCLivret2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DCLivrets", "Livret2_ID", "dbo.Livret2");
            DropIndex("dbo.DCLivrets", new[] { "Livret2_ID" });
            RenameColumn(table: "dbo.DCLivrets", name: "Livret2_ID", newName: "oLivret2_ID");
            AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.DCLivrets", "oLivret2_ID");
            AddForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
            DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
            AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int());
            RenameColumn(table: "dbo.DCLivrets", name: "oLivret2_ID", newName: "Livret2_ID");
            CreateIndex("dbo.DCLivrets", "Livret2_ID");
            AddForeignKey("dbo.DCLivrets", "Livret2_ID", "dbo.Livret2", "ID");
        }
    }
}
