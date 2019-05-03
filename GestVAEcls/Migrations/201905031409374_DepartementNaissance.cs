namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartementNaissance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "DptNaissance", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "DptNaissance");
        }
    }
}
