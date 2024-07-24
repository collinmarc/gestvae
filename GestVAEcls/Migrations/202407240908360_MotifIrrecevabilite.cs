namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotifIrrecevabilite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Params", "MotifIrrecevabilite", c => c.String(defaultValue:"Non conforme � la r�glementation"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Params", "MotifIrrecevabilite");
        }
    }
}
