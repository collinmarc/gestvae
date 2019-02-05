namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumDiplome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiplomeCands", "NumeroDiplome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiplomeCands", "NumeroDiplome");
        }
    }
}
