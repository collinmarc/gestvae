namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaysNaissance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "PaysNaissance", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "PaysNaissance");
        }
    }
}
