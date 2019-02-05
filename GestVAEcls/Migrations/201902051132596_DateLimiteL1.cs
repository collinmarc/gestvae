namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateLimiteL1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livret1", "DateLimiteEnvoiEHESP", c => c.DateTime());
            AddColumn("dbo.Livret1", "DateLimiteReceptEHESP", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livret1", "DateLimiteReceptEHESP");
            DropColumn("dbo.Livret1", "DateLimiteEnvoiEHESP");
        }
    }
}
