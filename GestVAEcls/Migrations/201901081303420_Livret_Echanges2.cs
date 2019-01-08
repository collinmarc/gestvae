namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Livret_Echanges2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2");
            DropIndex("dbo.EchangeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.EchangeL2", new[] { "oLivret_ID" });
            AlterColumn("dbo.EchangeL1", "oLivret_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.EchangeL2", "oLivret_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.EchangeL1", "oLivret_ID");
            CreateIndex("dbo.EchangeL2", "oLivret_ID");
            AddForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1");
            DropIndex("dbo.EchangeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.EchangeL1", new[] { "oLivret_ID" });
            AlterColumn("dbo.EchangeL2", "oLivret_ID", c => c.Int());
            AlterColumn("dbo.EchangeL1", "oLivret_ID", c => c.Int());
            CreateIndex("dbo.EchangeL2", "oLivret_ID");
            CreateIndex("dbo.EchangeL1", "oLivret_ID");
            AddForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2", "ID");
            AddForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1", "ID");
        }
    }
}
