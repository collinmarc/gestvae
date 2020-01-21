namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CNI : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CNI " + "start");
            AddColumn("dbo.Livret1", "IsCNIOK", c => c.Boolean(nullable: false));
            AddColumn("dbo.Livret1", "DateValiditeCNI", c => c.DateTime());
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CNI " + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CNI " + "start");
            DropColumn("dbo.Livret1", "DateValiditeCNI");
            DropColumn("dbo.Livret1", "IsCNIOK");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CNI " + "end");
        }
    }
}
