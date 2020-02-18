namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADEL : DbMigration
    {
        public override void Up()
        {
        //    DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
        //    DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
        //    AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int());
        //    CreateIndex("dbo.DCLivrets", "oLivret2_ID");
        //    AddForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2", "ID");
        }
        
        public override void Down()
        {
        //    DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
        //    DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
        //    AlterColumn("dbo.DCLivrets", "oLivret2_ID", c => c.Int(nullable: false));
        //    CreateIndex("dbo.DCLivrets", "oLivret2_ID");
        //    AddForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2", "ID", cascadeDelete: true);
        }
    }
}
