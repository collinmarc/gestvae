namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropCandidats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "NationaliteNaissance", c => c.String());
            AddColumn("dbo.Candidats", "Mail1", c => c.String());
            AddColumn("dbo.Candidats", "Mail2", c => c.String());
            AddColumn("dbo.Candidats", "Mail3", c => c.String());
            AlterColumn("dbo.Candidats", "DateNaissance", c => c.DateTime());
            DropColumn("dbo.Candidats", "NationnaliteNaissance");
            DropColumn("dbo.Candidats", "Mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidats", "Mail", c => c.String());
            AddColumn("dbo.Candidats", "NationnaliteNaissance", c => c.String());
            AlterColumn("dbo.Candidats", "DateNaissance", c => c.DateTime(nullable: false));
            DropColumn("dbo.Candidats", "Mail3");
            DropColumn("dbo.Candidats", "Mail2");
            DropColumn("dbo.Candidats", "Mail1");
            DropColumn("dbo.Candidats", "NationaliteNaissance");
        }
    }
}
