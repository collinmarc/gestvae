namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L2DateRecept2emeRetour : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "L2DateRecept2emeRetour " + "start");
            AddColumn("dbo.Livret2", "DateDemande1erRetour", c => c.DateTime());
            AddColumn("dbo.Livret2", "DateDemande2emeRetour", c => c.DateTime());
            DropColumn("dbo.Livret2", "DateDemandePieceManquantesRetour");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "L2DateRecept2emeRetour " + "end");
        }

        public override void Down()
        {
            AddColumn("dbo.Livret2", "DateDemandePieceManquantesRetour", c => c.DateTime());
            DropColumn("dbo.Livret2", "DateDemande2emeRetour");
            DropColumn("dbo.Livret2", "DateDemande1erRetour");
        }
    }
}
