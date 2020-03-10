namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembreJury : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Params", "PathToBaseJury", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Params", "PathToBaseJury");
        }
    }
}
