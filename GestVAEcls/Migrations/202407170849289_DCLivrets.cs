namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;

    public partial class DCLivrets : DbMigration
    {
        public override void Up()
        {
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "start");
            DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            AddColumn("dbo.Livret1", "NumPassage", c => c.Int(nullable: false));
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            AddColumn("dbo.DCLivrets", "oLivret1_ID", c => c.Int());
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int());
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            CreateIndex("dbo.DCLivrets", "oLivret2_ID");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            CreateIndex("dbo.DCLivrets", "oLivret1_ID");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            AddForeignKey("dbo.DCLivrets", "oLivret1_ID", "dbo.Livret1", "ID");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "Step");
            AddForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2", "ID");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "DCLivrets " + "End");
        }

        public override void Down()
        {
            DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.DCLivrets", "oLivret1_ID", "dbo.Livret1");
            DropIndex("dbo.DCLivrets", new[] { "oLivret1_ID" });
            DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
            AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int(nullable: true));
            DropColumn("dbo.DCLivrets", "oLivret1_ID");
            DropColumn("dbo.Livret1", "NumPassage");
            CreateIndex("dbo.DCLivrets", "oLivret2_ID");
            AddForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2", "ID", cascadeDelete: true);
        }

        /*
         *         public override void Up()
        {
            AddColumn("dbo.Livret1", "NumPassage", c => c.Int(nullable: false));
            AddColumn("dbo.DCLivrets", "oLivret1_ID", c => c.Int(nullable: true));
            CreateIndex("dbo.DCLivrets", "oLivret1_ID");
            AddForeignKey("dbo.DCLivrets", "oLivret1_ID", "dbo.Livret1", "ID");
            AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.DCLivrets", "oLivret1_ID", "dbo.Livret1");
            DropIndex("dbo.DCLivrets", new[] { "oLivret1_ID" });
            DropColumn("dbo.DCLivrets", "oLivret1_ID");
            DropColumn("dbo.Livret1", "NumPassage");
        }

         */

    }
}
