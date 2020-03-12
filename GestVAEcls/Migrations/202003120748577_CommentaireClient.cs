namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentaireClient : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CommentaireClient" + "Start");
            AddColumn("dbo.Candidats", "Commentaire", c => c.String());
            AddColumn("dbo.Candidats", "TypeCommentaire", c => c.Int());
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CommentaireClient" + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CommentaireClient" + "Start");
            DropColumn("dbo.Candidats", "TypeCommentaire");
            DropColumn("dbo.Candidats", "Commentaire");
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CommentaireClient" + "End");
        }
    }
}
