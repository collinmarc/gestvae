namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidats", "Sexe", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidats", "Sexe", c => c.String());
        }
    }
}
