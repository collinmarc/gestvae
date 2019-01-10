namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotifRecours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recours", "MotifRecoursCommentaire", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recours", "MotifRecoursCommentaire");
        }
    }
}
