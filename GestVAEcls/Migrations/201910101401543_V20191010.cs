namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V20191010 : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "V20191010 " + "start");
            //Cette migration permet juste de fixer la Livraison
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "V20191010 " + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "V20191010 " + "start");
            //Cette migration permet juste de fixer la Livraison
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "V20191010 " + "End");
        }
    }
}
