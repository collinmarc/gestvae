namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParamTestundo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Params", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Params", "Test", c => c.Int(nullable: false));
        }
    }
}
