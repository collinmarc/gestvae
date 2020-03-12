namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coultol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Params", "CouleurTolerance", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Params", "CouleurTolerance");
        }
    }
}
