namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumDiplomesurLivret2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret2", "NumDiplome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret2", "NumDiplome");
        }
    }
}
