namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0001014 : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "BG0001014 " + "start");
            Sql("DELETE FROM [dbo].[PieceJointeItems] where [Categorie_ID] = 12 and [Libelle]= '...'");
            Sql("INSERT INTO [dbo].[PieceJointeItems] ([Categorie_ID], [Libelle], [dateCreation], [dateModif], [bDeleted], [AttSup]) VALUES (12, N'...', 2019-09-01, 20109-09-01, 0, N'')");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "BG0001014 " + "End");

        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001014 " + "start");
            Sql("DELETE FROM [dbo].[PieceJointeItems] where [Categorie_ID] = 12 and [Libelle]= '...'");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "BG0001014 " + "End");
        }
    }
}
