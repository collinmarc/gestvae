namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LivretIsRecours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "IsRecours", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret1", "IsRecours");
        }
    }
}
