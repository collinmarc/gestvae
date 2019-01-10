namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DCLivret : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DCLivrets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Decision = c.String(),
                        MotifGeneral = c.String(),
                        MotifDetail = c.String(),
                        MotifCommentaire = c.String(),
                        IsAValider = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oDomaineCompetence_ID = c.Int(),
                        Livret2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomaineCompetences", t => t.oDomaineCompetence_ID)
                .ForeignKey("dbo.Livret2", t => t.Livret2_ID)
                .Index(t => t.oDomaineCompetence_ID)
                .Index(t => t.Livret2_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DCLivrets", "Livret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.DCLivrets", "oDomaineCompetence_ID", "dbo.DomaineCompetences");
            DropIndex("dbo.DCLivrets", new[] { "Livret2_ID" });
            DropIndex("dbo.DCLivrets", new[] { "oDomaineCompetence_ID" });
            DropTable("dbo.DCLivrets");
        }
    }
}
