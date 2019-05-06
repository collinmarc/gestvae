namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnvoiL2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "DateEnvoiL2", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret1", "DateEnvoiL2");
        }
    }
}
