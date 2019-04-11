namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParamNumCandidat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Params", "NumCandidat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Params", "NumCandidat");
        }
    }
}
