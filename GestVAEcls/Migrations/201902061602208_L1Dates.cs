namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L1Dates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "DateLimiteJury", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateValidite", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret1", "DateValidite");
            DropColumn("dbo.Livret1", "DateLimiteJury");
        }
    }
}
