namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDCLivrets : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "UpdateDCLivrets" + "Start");
            Sql(@"UPDATE DCLivrets
SET Statut = 'En Cours'
from DCLivrets inner join Livret2 on DCLivrets.oLivret2_ID = Livret2.ID
Where Livret2.NumPassage = 1 and dcLivrets.Statut = '';");

            Sql(@"UPDATE DCLivrets
SET Statut = 'Refusé'
from DCLivrets inner join Livret2 on DCLivrets.oLivret2_ID = Livret2.ID
Where Livret2.NumPassage > 1 and dcLivrets.Statut = '';");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "UpdateDCLivrets" + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "UpdateDCLivrets" + "Start");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "UpdateDCLivrets" + "End");
        }
    }
}
