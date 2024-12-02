namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;

    public partial class MotifIrrecevabilite : DbMigration
    {
        public override void Up()
        {
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "MotifIrrecevabilite" + "start");
            AddColumn("dbo.Params", "MotifIrrecevabilite", c => c.String(defaultValue:"Non conforme � la r�glementation"));
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "MotifIrrecevabilite" + "End");
        }

        public override void Down()
        {
            DropColumn("dbo.Params", "MotifIrrecevabilite");
        }
    }
}
