namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L2numPassage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret2", "NumPassage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret2", "NumPassage");
        }
    }
}
