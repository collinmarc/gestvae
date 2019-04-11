namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParamTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Params", "Test", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Params", "Test");
        }
    }
}
