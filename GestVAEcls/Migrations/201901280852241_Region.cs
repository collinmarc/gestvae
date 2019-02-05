namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Region : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regions");
        }
    }
}
