namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelaiValiditeL1 : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DelaiValiditeL1" + "start");
            AddColumn("dbo.Params", "DelaiValiditeL1", c => c.Int(nullable: false));
            AddColumn("dbo.Params", "CouleurTolerance", c => c.String());
            Sql(@"UPDATE PARAMS SET DelaiValiditeL1=0");
            Sql(@"UPDATE PARAMS SET CouleurTolerance='orange'");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DelaiValiditeL1" + "end");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "DelaiValiditeL1" + "start");
            DropColumn("dbo.Params", "DelaiValiditeL1");
            DropColumn("dbo.Params", "CouleurTolerance");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "DelaiValiditeL1" + "end");
        }
    }
}
