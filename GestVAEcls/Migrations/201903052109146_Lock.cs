namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LockCandidats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCandidat = c.Int(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LockCandidats");
        }
    }
}