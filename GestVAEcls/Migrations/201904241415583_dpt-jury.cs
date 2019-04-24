namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dptjury : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembreJuries", "DptDomicile", c => c.String());
            AddColumn("dbo.MembreJuries", "DptTravail", c => c.String());
            DropColumn("dbo.MembreJuries", "Origine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembreJuries", "Origine", c => c.String());
            DropColumn("dbo.MembreJuries", "DptTravail");
            DropColumn("dbo.MembreJuries", "DptDomicile");
        }
    }
}
