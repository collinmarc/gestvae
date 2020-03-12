namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentaireClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "Commentaire", c => c.String());
            AddColumn("dbo.Candidats", "TypeCommentaire", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "TypeCommentaire");
            DropColumn("dbo.Candidats", "Commentaire");
        }
    }
}
