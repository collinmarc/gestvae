namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropCandidat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "Prenom2", c => c.String());
            AddColumn("dbo.Candidats", "Prenom3", c => c.String());
            AddColumn("dbo.Candidats", "Sexe", c => c.String());
            AddColumn("dbo.Candidats", "IdVAE", c => c.String());
            AddColumn("dbo.Candidats", "IdSiscole", c => c.String());
            AddColumn("dbo.Candidats", "NomJeuneFille", c => c.String());
            AddColumn("dbo.Candidats", "Nationnalite", c => c.String());
            AddColumn("dbo.Candidats", "DateNaissance", c => c.DateTime(nullable: false));
            AddColumn("dbo.Candidats", "CPNaissance", c => c.String());
            AddColumn("dbo.Candidats", "VilleNaissance", c => c.String());
            AddColumn("dbo.Candidats", "NationnaliteNaissance", c => c.String());
            AddColumn("dbo.Candidats", "Adresse", c => c.String());
            AddColumn("dbo.Candidats", "CodePostal", c => c.String());
            AddColumn("dbo.Candidats", "Ville", c => c.String());
            AddColumn("dbo.Candidats", "Region", c => c.String());
            AddColumn("dbo.Candidats", "RegionTravail", c => c.String());
            AddColumn("dbo.Candidats", "CPTravail", c => c.String());
            AddColumn("dbo.Candidats", "VilleTravail", c => c.String());
            AddColumn("dbo.Candidats", "Mail", c => c.String());
            AddColumn("dbo.Candidats", "Tel1", c => c.String());
            AddColumn("dbo.Candidats", "Tel2", c => c.String());
            AddColumn("dbo.Candidats", "Tel3", c => c.String());
            AddColumn("dbo.Candidats", "bHandicap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "bHandicap");
            DropColumn("dbo.Candidats", "Tel3");
            DropColumn("dbo.Candidats", "Tel2");
            DropColumn("dbo.Candidats", "Tel1");
            DropColumn("dbo.Candidats", "Mail");
            DropColumn("dbo.Candidats", "VilleTravail");
            DropColumn("dbo.Candidats", "CPTravail");
            DropColumn("dbo.Candidats", "RegionTravail");
            DropColumn("dbo.Candidats", "Region");
            DropColumn("dbo.Candidats", "Ville");
            DropColumn("dbo.Candidats", "CodePostal");
            DropColumn("dbo.Candidats", "Adresse");
            DropColumn("dbo.Candidats", "NationnaliteNaissance");
            DropColumn("dbo.Candidats", "VilleNaissance");
            DropColumn("dbo.Candidats", "CPNaissance");
            DropColumn("dbo.Candidats", "DateNaissance");
            DropColumn("dbo.Candidats", "Nationnalite");
            DropColumn("dbo.Candidats", "NomJeuneFille");
            DropColumn("dbo.Candidats", "IdSiscole");
            DropColumn("dbo.Candidats", "IdVAE");
            DropColumn("dbo.Candidats", "Sexe");
            DropColumn("dbo.Candidats", "Prenom3");
            DropColumn("dbo.Candidats", "Prenom2");
        }
    }
}
