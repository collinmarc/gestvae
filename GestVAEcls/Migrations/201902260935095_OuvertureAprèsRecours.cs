namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OuvertureAprèsRecours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret2", "bOuvertureApresRecours", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret2", "bOuvertureApresRecours");
        }
    }
}
