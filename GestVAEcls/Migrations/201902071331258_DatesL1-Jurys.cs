namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatesL1Jurys : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livret1", "DateJury");
            DropColumn("dbo.Livret1", "DateLimiteRecours");
            DropColumn("dbo.Livret1", "DateRecours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livret1", "DateRecours", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateLimiteRecours", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateJury", c => c.DateTime());
        }
    }
}
