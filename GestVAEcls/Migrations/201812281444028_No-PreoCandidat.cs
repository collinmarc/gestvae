namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoPreoCandidat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "Nom", c => c.String());
            AddColumn("dbo.Candidats", "Prenom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "Prenom");
            DropColumn("dbo.Candidats", "Nom");
        }
    }
}
