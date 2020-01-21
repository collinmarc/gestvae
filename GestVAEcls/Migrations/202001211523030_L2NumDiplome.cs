namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L2NumDiplome : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livret2", "NumDiplome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livret2", "NumDiplome", c => c.String());
        }
    }
}
