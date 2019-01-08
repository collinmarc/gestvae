namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class etatLivret : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "EtatLivret", c => c.String());
            AddColumn("dbo.Livret2", "EtatLivret", c => c.String());
            DropColumn("dbo.Livret1", "EtatDossier");
            DropColumn("dbo.Livret2", "EtatDossier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livret2", "EtatDossier", c => c.String());
            AddColumn("dbo.Livret1", "EtatDossier", c => c.String());
            DropColumn("dbo.Livret2", "EtatLivret");
            DropColumn("dbo.Livret1", "EtatLivret");
        }
    }
}
