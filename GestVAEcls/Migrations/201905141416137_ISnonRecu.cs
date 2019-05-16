namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISnonRecu : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "ISnonRecu " + "start");
            AddColumn("dbo.Livret1", "IsConvention", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret1", "IsNonRecu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret2", "IsConvention", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret2", "IsNonRecu", c => c.Boolean(nullable: false));
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "ISnonRecu " + "end");
        }

        public override void Down()
        {
            DropColumn("dbo.Livret2", "IsNonRecu");
            DropColumn("dbo.Livret2", "IsConvention");
            DropColumn("dbo.Livret1", "IsNonRecu");
            DropColumn("dbo.Livret1", "IsConvention");
        }
    }
}
