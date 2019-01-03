namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SexeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidats", "Sexe", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidats", "Sexe", c => c.Int(nullable: false));
        }
    }
}
