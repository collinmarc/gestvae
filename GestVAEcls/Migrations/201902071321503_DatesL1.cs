namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatesL1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "DateJury", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateLimiteRecours", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateRecours", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateReceptEHESPComplet", c => c.DateTime());
            AddColumn("dbo.Livret2", "DateReceptEHESPComplet", c => c.DateTime());
            DropColumn("dbo.Livret1", "DateReceptCandidat");
            DropColumn("dbo.Livret1", "isEnvoiEHESP_AR");
            DropColumn("dbo.Livret1", "isEnvoiCand_AR");
            DropColumn("dbo.Livret2", "DateReceptCandidat");
            DropColumn("dbo.Livret2", "isEnvoiEHESP_AR");
            DropColumn("dbo.Livret2", "isEnvoiCand_AR");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livret2", "isEnvoiCand_AR", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret2", "isEnvoiEHESP_AR", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret2", "DateReceptCandidat", c => c.DateTime());
            AddColumn("dbo.Livret1", "isEnvoiCand_AR", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret1", "isEnvoiEHESP_AR", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret1", "DateReceptCandidat", c => c.DateTime());
            DropColumn("dbo.Livret2", "DateReceptEHESPComplet");
            DropColumn("dbo.Livret1", "DateReceptEHESPComplet");
            DropColumn("dbo.Livret1", "DateRecours");
            DropColumn("dbo.Livret1", "DateLimiteRecours");
            DropColumn("dbo.Livret1", "DateJury");
        }
    }
}
