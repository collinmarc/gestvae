namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jury : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Juries", "DateJury", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Juries", "DateJury", c => c.DateTime(nullable: false));
        }
    }
}
