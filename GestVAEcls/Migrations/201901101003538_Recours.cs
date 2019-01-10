namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recours : DbMigration
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
                        AttSup = c.String(),
                        oCandidat_ID = c.Int(nullable: false),
                        oDiplome_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidats", t => t.oCandidat_ID, cascadeDelete: true)
                .ForeignKey("dbo.Diplomes", t => t.oDiplome_ID, cascadeDelete: true)
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
                        AttSup = c.String(),
                        oDiplomeCand_ID = c.Int(nullable: false),
                        oDomaineCompetence_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DiplomeCands", t => t.oDiplomeCand_ID, cascadeDelete: true)
                .ForeignKey("dbo.DomaineCompetences", t => t.oDomaineCompetence_ID)
                .Index(t => t.oDiplomeCand_ID)
                .Index(t => t.oDomaineCompetence_ID);
            
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
                        AttSup = c.String(),
                        oDiplome_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Diplomes", t => t.oDiplome_ID, cascadeDelete: true)
                .Index(t => t.Numero)
                .Index(t => t.oDiplome_ID);
            
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
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Livret1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        DateDemande = c.DateTime(),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        TypeDemande = c.String(),
                        OrigineDemande = c.String(),
                        EtatLivret = c.String(),
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
                        oDiplome_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidats", t => t.oCandidat_ID, cascadeDelete: true)
                .ForeignKey("dbo.Diplomes", t => t.oDiplome_ID)
                .Index(t => t.oCandidat_ID)
                .Index(t => t.oDiplome_ID);
            
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
                        oLivret_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret1", t => t.oLivret_ID, cascadeDelete: true)
                .Index(t => t.oLivret_ID);
            
            CreateTable(
                "dbo.Juries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumeroOrdre = c.Int(nullable: false),
                        NomJury = c.String(),
                        DateJury = c.DateTime(),
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
                        oLivret_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret1", t => t.oLivret_ID, cascadeDelete: true)
                .Index(t => t.oLivret_ID);
            
            CreateTable(
                "dbo.Recours",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateDepot = c.DateTime(),
                        TypeRecours = c.Int(nullable: false),
                        MotifRecours = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oJury_ID = c.Int(),
                        Livret1_ID = c.Int(),
                        Livret2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Juries", t => t.oJury_ID)
                .ForeignKey("dbo.Livret1", t => t.Livret1_ID)
                .ForeignKey("dbo.Livret2", t => t.Livret2_ID)
                .Index(t => t.oJury_ID)
                .Index(t => t.Livret1_ID)
                .Index(t => t.Livret2_ID);
            
            CreateTable(
                "dbo.Livret2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        DateDemande = c.DateTime(),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        TypeDemande = c.String(),
                        OrigineDemande = c.String(),
                        EtatLivret = c.String(),
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
                        oDiplome_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidats", t => t.oCandidat_ID, cascadeDelete: true)
                .ForeignKey("dbo.Diplomes", t => t.oDiplome_ID)
                .Index(t => t.oCandidat_ID)
                .Index(t => t.oDiplome_ID);
            
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
                        oLivret_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret_ID, cascadeDelete: true)
                .Index(t => t.oLivret_ID);
            
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
                        oLivret_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret_ID, cascadeDelete: true)
                .Index(t => t.oLivret_ID);
            
            AddColumn("dbo.Candidats", "Nom", c => c.String());
            AddColumn("dbo.Candidats", "Prenom", c => c.String());
            AddColumn("dbo.Candidats", "Prenom2", c => c.String());
            AddColumn("dbo.Candidats", "Prenom3", c => c.String());
            AddColumn("dbo.Candidats", "Sexe", c => c.Int());
            AddColumn("dbo.Candidats", "IdVAE", c => c.String());
            AddColumn("dbo.Candidats", "IdSiscole", c => c.String());
            AddColumn("dbo.Candidats", "NomJeuneFille", c => c.String());
            AddColumn("dbo.Candidats", "Nationnalite", c => c.String());
            AddColumn("dbo.Candidats", "DateNaissance", c => c.DateTime());
            AddColumn("dbo.Candidats", "CPNaissance", c => c.String());
            AddColumn("dbo.Candidats", "VilleNaissance", c => c.String());
            AddColumn("dbo.Candidats", "NationaliteNaissance", c => c.String());
            AddColumn("dbo.Candidats", "Adresse", c => c.String());
            AddColumn("dbo.Candidats", "CodePostal", c => c.String());
            AddColumn("dbo.Candidats", "Ville", c => c.String());
            AddColumn("dbo.Candidats", "Region", c => c.String());
            AddColumn("dbo.Candidats", "RegionTravail", c => c.String());
            AddColumn("dbo.Candidats", "CPTravail", c => c.String());
            AddColumn("dbo.Candidats", "VilleTravail", c => c.String());
            AddColumn("dbo.Candidats", "Mail1", c => c.String());
            AddColumn("dbo.Candidats", "Mail2", c => c.String());
            AddColumn("dbo.Candidats", "Mail3", c => c.String());
            AddColumn("dbo.Candidats", "Tel1", c => c.String());
            AddColumn("dbo.Candidats", "Tel2", c => c.String());
            AddColumn("dbo.Candidats", "Tel3", c => c.String());
            AddColumn("dbo.Candidats", "bHandicap", c => c.Boolean(nullable: false));
            AddColumn("dbo.Candidats", "AttSup", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livret2", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret2", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.Recours", "Livret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.Juries", "Livret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.Livret1", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret1", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.Recours", "Livret1_ID", "dbo.Livret1");
            DropForeignKey("dbo.Recours", "oJury_ID", "dbo.Juries");
            DropForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.Juries", "Livret1_ID", "dbo.Livret1");
            DropForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID", "dbo.DomaineCompetences");
            DropForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands");
            DropIndex("dbo.PieceJointeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.EchangeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.Livret2", new[] { "oDiplome_ID" });
            DropIndex("dbo.Livret2", new[] { "oCandidat_ID" });
            DropIndex("dbo.Recours", new[] { "Livret2_ID" });
            DropIndex("dbo.Recours", new[] { "Livret1_ID" });
            DropIndex("dbo.Recours", new[] { "oJury_ID" });
            DropIndex("dbo.PieceJointeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.Juries", new[] { "Livret2_ID" });
            DropIndex("dbo.Juries", new[] { "Livret1_ID" });
            DropIndex("dbo.EchangeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.Livret1", new[] { "oDiplome_ID" });
            DropIndex("dbo.Livret1", new[] { "oCandidat_ID" });
            DropIndex("dbo.DomaineCompetences", new[] { "oDiplome_ID" });
            DropIndex("dbo.DomaineCompetences", new[] { "Numero" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDomaineCompetence_ID" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDiplomeCand_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oDiplome_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oCandidat_ID" });
            DropColumn("dbo.Candidats", "AttSup");
            DropColumn("dbo.Candidats", "bHandicap");
            DropColumn("dbo.Candidats", "Tel3");
            DropColumn("dbo.Candidats", "Tel2");
            DropColumn("dbo.Candidats", "Tel1");
            DropColumn("dbo.Candidats", "Mail3");
            DropColumn("dbo.Candidats", "Mail2");
            DropColumn("dbo.Candidats", "Mail1");
            DropColumn("dbo.Candidats", "VilleTravail");
            DropColumn("dbo.Candidats", "CPTravail");
            DropColumn("dbo.Candidats", "RegionTravail");
            DropColumn("dbo.Candidats", "Region");
            DropColumn("dbo.Candidats", "Ville");
            DropColumn("dbo.Candidats", "CodePostal");
            DropColumn("dbo.Candidats", "Adresse");
            DropColumn("dbo.Candidats", "NationaliteNaissance");
            DropColumn("dbo.Candidats", "VilleNaissance");
            DropColumn("dbo.Candidats", "CPNaissance");
            DropColumn("dbo.Candidats", "DateNaissance");
            DropColumn("dbo.Candidats", "Nationnalite");
            DropColumn("dbo.Candidats", "NomJeuneFille");
            DropColumn("dbo.Candidats", "IdSiscole");
            DropColumn("dbo.Candidats", "IdVAE");
            DropColumn("dbo.Candidats", "Sexe");
            DropColumn("dbo.Candidats", "Prenom3");
            DropColumn("dbo.Candidats", "Prenom2");
            DropColumn("dbo.Candidats", "Prenom");
            DropColumn("dbo.Candidats", "Nom");
            DropTable("dbo.PieceJointeL2");
            DropTable("dbo.EchangeL2");
            DropTable("dbo.Livret2");
            DropTable("dbo.Recours");
            DropTable("dbo.PieceJointeL1");
            DropTable("dbo.Juries");
            DropTable("dbo.EchangeL1");
            DropTable("dbo.Livret1");
            DropTable("dbo.Diplomes");
            DropTable("dbo.DomaineCompetences");
            DropTable("dbo.DomaineCompetenceCands");
            DropTable("dbo.DiplomeCands");
        }
    }
}
