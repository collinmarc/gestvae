namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandTypeDemande : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "TypeDemande", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "TypeDemande");
        }
    }
}
