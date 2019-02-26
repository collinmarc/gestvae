namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OuvertureAprèsRecours2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret2", "IsOuvertureApresRecours", c => c.Boolean(nullable: false));
            DropColumn("dbo.Livret2", "bOuvertureApresRecours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livret2", "bOuvertureApresRecours", c => c.Boolean(nullable: false));
            DropColumn("dbo.Livret2", "IsOuvertureApresRecours");
        }
    }
}
