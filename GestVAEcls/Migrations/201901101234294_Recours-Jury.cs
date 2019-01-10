namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecoursJury : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recours", "oJury_ID", "dbo.Juries");
            DropIndex("dbo.Recours", new[] { "oJury_ID" });
            AddColumn("dbo.Recours", "NomJury", c => c.String());
            AddColumn("dbo.Recours", "DateJury", c => c.DateTime());
            AddColumn("dbo.Recours", "LieuJury", c => c.String());
            AddColumn("dbo.Recours", "Decision", c => c.String());
            AddColumn("dbo.Recours", "MotifGeneral", c => c.String());
            AddColumn("dbo.Recours", "MotifDetail", c => c.String());
            AddColumn("dbo.Recours", "MotifCommentaire", c => c.String());
            DropColumn("dbo.Recours", "oJury_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recours", "oJury_ID", c => c.Int());
            DropColumn("dbo.Recours", "MotifCommentaire");
            DropColumn("dbo.Recours", "MotifDetail");
            DropColumn("dbo.Recours", "MotifGeneral");
            DropColumn("dbo.Recours", "Decision");
            DropColumn("dbo.Recours", "LieuJury");
            DropColumn("dbo.Recours", "DateJury");
            DropColumn("dbo.Recours", "NomJury");
            CreateIndex("dbo.Recours", "oJury_ID");
            AddForeignKey("dbo.Recours", "oJury_ID", "dbo.Juries", "ID");
        }
    }
}
