namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T1T2Optional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T2", "oT1_ID", "dbo.T1");
            DropIndex("dbo.T2", new[] { "oT1_ID" });
            AlterColumn("dbo.T2", "oT1_ID", c => c.Int());
            CreateIndex("dbo.T2", "oT1_ID");
            AddForeignKey("dbo.T2", "oT1_ID", "dbo.T1", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T2", "oT1_ID", "dbo.T1");
            DropIndex("dbo.T2", new[] { "oT1_ID" });
            AlterColumn("dbo.T2", "oT1_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.T2", "oT1_ID");
            AddForeignKey("dbo.T2", "oT1_ID", "dbo.T1", "ID", cascadeDelete: true);
        }
    }
}
