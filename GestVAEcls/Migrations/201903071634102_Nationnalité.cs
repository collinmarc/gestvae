namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nationnalité : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "Nationalite", c => c.String());
            DropColumn("dbo.Candidats", "Nationnalite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidats", "Nationnalite", c => c.String());
            DropColumn("dbo.Candidats", "Nationalite");
        }
    }
}
