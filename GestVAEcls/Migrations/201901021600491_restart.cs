namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiplomeCands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Statut = c.String(),
                        DateObtention = c.DateTime(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        oCandidat_ID = c.Int(),
                        oDiplome_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidats", t => t.oCandidat_ID)
                .ForeignKey("dbo.Diplomes", t => t.oDiplome_ID)
                .Index(t => t.oCandidat_ID)
                .Index(t => t.oDiplome_ID);
            
            CreateTable(
                "dbo.DomaineCompetenceCands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Statut = c.String(),
                        DateObtention = c.DateTime(),
                        ModeObtention = c.String(),
                        Commentaire = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        oDiplomeCand_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DiplomeCands", t => t.oDiplomeCand_ID)
                .Index(t => t.oDiplomeCand_ID);
            
            CreateTable(
                "dbo.Diplomes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DomaineCompetences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Nom = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        oDiplome_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Diplomes", t => t.oDiplome_ID)
                .Index(t => t.Numero)
                .Index(t => t.oDiplome_ID);
            
            AddColumn("dbo.Candidats", "Nom", c => c.String());
            AddColumn("dbo.Candidats", "Prenom", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands");
            DropIndex("dbo.DomaineCompetences", new[] { "oDiplome_ID" });
            DropIndex("dbo.DomaineCompetences", new[] { "Numero" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDiplomeCand_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oDiplome_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oCandidat_ID" });
            DropColumn("dbo.Candidats", "Prenom");
            DropColumn("dbo.Candidats", "Nom");
            DropTable("dbo.DomaineCompetences");
            DropTable("dbo.Diplomes");
            DropTable("dbo.DomaineCompetenceCands");
            DropTable("dbo.DiplomeCands");
        }
    }
}
