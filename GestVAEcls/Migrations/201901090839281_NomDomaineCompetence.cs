namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomDomaineCompetence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID", c => c.Int());
            CreateIndex("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID");
            AddForeignKey("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID", "dbo.DomaineCompetences", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID", "dbo.DomaineCompetences");
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDomaineCompetence_ID" });
            DropColumn("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID");
        }
    }
}
