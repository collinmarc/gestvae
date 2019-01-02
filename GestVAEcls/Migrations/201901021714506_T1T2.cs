namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T1T2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.T2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        oT1_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T1", t => t.oT1_ID, cascadeDelete: true)
                .Index(t => t.oT1_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T2", "oT1_ID", "dbo.T1");
            DropIndex("dbo.T2", new[] { "oT1_ID" });
            DropTable("dbo.T2");
            DropTable("dbo.T1");
        }
    }
}
