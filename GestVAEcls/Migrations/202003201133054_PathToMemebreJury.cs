namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PathToMemebreJury : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "PathToMemebreJury" + "Start");
            Sql(@"UPDATE Params SET PathToBaseJury = './DOCS/BD Globale convertie Jurés en fonction.csv'");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "PathToMemebreJury" + "Start");
        }
        
        public override void Down()
        {
        }
    }
}
