namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaysNaissance : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "PaysNaissance " + "start");
            AddColumn("dbo.Candidats", "PaysNaissance", c => c.String());
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "PaysNaissance " + "End");
        }

        public override void Down()
        {
            DropColumn("dbo.Candidats", "PaysNaissance");
        }
    }
}
