namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateRecept2emeRetour : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DateRecept2emeRetour " + "start");
            AddColumn("dbo.Livret1", "DateDemande1erRetour", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateDemande2emeRetour", c => c.DateTime());
            DropColumn("dbo.Livret1", "DateDemandePieceManquantesRetour");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DateRecept2emeRetour " + "End");
        }

        public override void Down()
        {
            AddColumn("dbo.Livret1", "DateDemandePieceManquantesRetour", c => c.DateTime());
            DropColumn("dbo.Livret1", "DateDemande2emeRetour");
            DropColumn("dbo.Livret1", "DateDemande1erRetour");
        }
    }
}
