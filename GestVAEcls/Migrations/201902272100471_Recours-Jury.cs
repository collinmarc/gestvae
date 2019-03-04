namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecoursJury : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recours", "Livret1_ID", "dbo.Livret1");
            DropIndex("dbo.Recours", new[] { "Livret1_ID" });
            AddColumn("dbo.Juries", "IsRecours", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recours", "Jury_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recours", "Jury_ID");
            AddForeignKey("dbo.Recours", "Jury_ID", "dbo.Juries", "ID", cascadeDelete: true);
            DropColumn("dbo.Livret1", "IsRecours");
//            DropColumn("dbo.Recours", "Livret1_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recours", "Livret1_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Livret1", "IsRecours", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Recours", "Jury_ID", "dbo.Juries");
            DropIndex("dbo.Recours", new[] { "Jury_ID" });
            DropColumn("dbo.Recours", "Jury_ID");
            DropColumn("dbo.Juries", "IsRecours");
            CreateIndex("dbo.Recours", "Livret1_ID");
            AddForeignKey("dbo.Recours", "Livret1_ID", "dbo.Livret1", "ID", cascadeDelete: true);
        }
    }
}
