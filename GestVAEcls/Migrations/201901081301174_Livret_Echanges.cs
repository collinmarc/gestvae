namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Livret_Echanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EchangeL1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateEch = c.DateTime(),
                        MotifEch = c.String(),
                        DateEcheanceEch = c.DateTime(),
                        DateReceptionEch = c.DateTime(),
                        IsOK = c.Boolean(nullable: false),
                        CommentaireEch = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oLivret_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret1", t => t.oLivret_ID)
                .Index(t => t.oLivret_ID);
            
            CreateTable(
                "dbo.EchangeL2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateEch = c.DateTime(),
                        MotifEch = c.String(),
                        DateEcheanceEch = c.DateTime(),
                        DateReceptionEch = c.DateTime(),
                        IsOK = c.Boolean(nullable: false),
                        CommentaireEch = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oLivret_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret_ID)
                .Index(t => t.oLivret_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1");
            DropIndex("dbo.EchangeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.EchangeL1", new[] { "oLivret_ID" });
            DropTable("dbo.EchangeL2");
            DropTable("dbo.EchangeL1");
        }
    }
}
