namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Livret_PJ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livret1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        DateDemande = c.DateTime(),
                        EtatDossier = c.String(),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        TypeDemande = c.String(),
                        OrigineDemande = c.String(),
                        DateEnvoiEHESP = c.DateTime(),
                        DateEnvoiCandidat = c.DateTime(),
                        DateReceptEHESP = c.DateTime(),
                        DateReceptCandidat = c.DateTime(),
                        isEnvoiEHESP_AR = c.Boolean(nullable: false),
                        isEnvoiCand_AR = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oCandidat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidats", t => t.oCandidat_ID, cascadeDelete: true)
                .Index(t => t.oCandidat_ID);
            
            CreateTable(
                "dbo.Juries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumeroOrdre = c.Int(nullable: false),
                        NomJury = c.String(),
                        DateJury = c.DateTime(nullable: false),
                        LieuJury = c.String(),
                        Decision = c.String(),
                        MotifGeneral = c.String(),
                        MotifDetail = c.String(),
                        MotifCommentaire = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        Livret1_ID = c.Int(),
                        Livret2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret1", t => t.Livret1_ID)
                .ForeignKey("dbo.Livret2", t => t.Livret2_ID)
                .Index(t => t.Livret1_ID)
                .Index(t => t.Livret2_ID);
            
            CreateTable(
                "dbo.PieceJointeL1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        IsRecu = c.Boolean(nullable: false),
                        IsOK = c.Boolean(nullable: false),
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
                "dbo.Livret2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        DateDemande = c.DateTime(),
                        EtatDossier = c.String(),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        TypeDemande = c.String(),
                        OrigineDemande = c.String(),
                        DateEnvoiEHESP = c.DateTime(),
                        DateEnvoiCandidat = c.DateTime(),
                        DateReceptEHESP = c.DateTime(),
                        DateReceptCandidat = c.DateTime(),
                        isEnvoiEHESP_AR = c.Boolean(nullable: false),
                        isEnvoiCand_AR = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oCandidat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidats", t => t.oCandidat_ID, cascadeDelete: true)
                .Index(t => t.oCandidat_ID);
            
            CreateTable(
                "dbo.PieceJointeL2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        IsRecu = c.Boolean(nullable: false),
                        IsOK = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oLivret_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret_ID)
                .Index(t => t.oLivret_ID);
            
            //AddColumn("dbo.Candidats", "AttSup", c => c.String());
            //AddColumn("dbo.DiplomeCands", "AttSup", c => c.String());
            //AddColumn("dbo.DomaineCompetenceCands", "AttSup", c => c.String());
            //AddColumn("dbo.Diplomes", "AttSup", c => c.String());
            //AddColumn("dbo.DomaineCompetences", "AttSup", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livret2", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.Juries", "Livret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.Livret1", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.Juries", "Livret1_ID", "dbo.Livret1");
            DropIndex("dbo.PieceJointeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.Livret2", new[] { "oCandidat_ID" });
            DropIndex("dbo.PieceJointeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.Juries", new[] { "Livret2_ID" });
            DropIndex("dbo.Juries", new[] { "Livret1_ID" });
            DropIndex("dbo.Livret1", new[] { "oCandidat_ID" });
            DropColumn("dbo.DomaineCompetences", "AttSup");
            DropColumn("dbo.Diplomes", "AttSup");
            DropColumn("dbo.DomaineCompetenceCands", "AttSup");
            DropColumn("dbo.DiplomeCands", "AttSup");
            DropColumn("dbo.Candidats", "AttSup");
            DropTable("dbo.PieceJointeL2");
            DropTable("dbo.Livret2");
            DropTable("dbo.PieceJointeL1");
            DropTable("dbo.Juries");
            DropTable("dbo.Livret1");
        }
    }
}
