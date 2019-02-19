namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Prenom2 = c.String(),
                        Prenom3 = c.String(),
                        Sexe = c.Int(),
                        IdVAE = c.String(),
                        IdSiscole = c.String(),
                        NomJeuneFille = c.String(),
                        Nationnalite = c.String(),
                        DateNaissance = c.DateTime(),
                        CPNaissance = c.String(),
                        VilleNaissance = c.String(),
                        NationaliteNaissance = c.String(),
                        Adresse = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                        Region = c.String(),
                        Pays = c.String(),
                        RegionTravail = c.String(),
                        CPTravail = c.String(),
                        VilleTravail = c.String(),
                        Mail1 = c.String(),
                        Mail2 = c.String(),
                        Mail3 = c.String(),
                        Tel1 = c.String(),
                        Tel2 = c.String(),
                        Tel3 = c.String(),
                        bHandicap = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DiplomeCands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Statut = c.String(),
                        DateObtention = c.DateTime(),
                        NumeroDiplome = c.String(),
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
                        DateLimiteEnvoiEHESP = c.DateTime(),
                        DateLimiteReceptEHESP = c.DateTime(),
                        DateLimiteJury = c.DateTime(),
                        DateValidite = c.DateTime(),
                        Date1ereDemandePieceManquantes = c.DateTime(),
                        Date2emeDemandePieceManquantes = c.DateTime(),
                        DateDemandePieceManquantesRetour = c.DateTime(),
                        IsRecours = c.Boolean(nullable: false),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        TypeDemande = c.String(),
                        OrigineDemande = c.String(),
                        EtatLivret = c.String(),
                        DateEnvoiEHESP = c.DateTime(),
                        DateEnvoiCandidat = c.DateTime(),
                        DateReceptEHESP = c.DateTime(),
                        DateReceptEHESPComplet = c.DateTime(),
                        isClos = c.Boolean(nullable: false),
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
                        HeureJury = c.DateTime(),
                        HeureConvoc = c.DateTime(),
                        DateLimiteRecours = c.DateTime(),
                        LieuJury = c.String(),
                        Decision = c.String(),
                        MotifGeneral = c.String(),
                        MotifDetail = c.String(),
                        MotifCommentaire = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oLivret1_ID = c.Int(),
                        oLivret2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret1", t => t.oLivret1_ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret2_ID)
                .Index(t => t.oLivret1_ID)
                .Index(t => t.oLivret2_ID);
            
            CreateTable(
                "dbo.Livret2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        DateDemande = c.DateTime(),
                        DateLimiteEnvoiEHESP = c.DateTime(),
                        DateLimiteReceptEHESP = c.DateTime(),
                        DatePrevJury1 = c.DateTime(),
                        DatePrevJury2 = c.DateTime(),
                        SessionJury = c.String(),
                        DateLimiteJury = c.DateTime(),
                        DateValidite = c.DateTime(),
                        IsAttestationOK = c.Boolean(nullable: false),
                        IsCNIOK = c.Boolean(nullable: false),
                        IsDispenseArt2 = c.Boolean(nullable: false),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        TypeDemande = c.String(),
                        OrigineDemande = c.String(),
                        EtatLivret = c.String(),
                        DateEnvoiEHESP = c.DateTime(),
                        DateEnvoiCandidat = c.DateTime(),
                        DateReceptEHESP = c.DateTime(),
                        DateReceptEHESPComplet = c.DateTime(),
                        isClos = c.Boolean(nullable: false),
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
                "dbo.DCLivrets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Decision = c.String(),
                        MotifGeneral = c.String(),
                        MotifDetail = c.String(),
                        MotifCommentaire = c.String(),
                        IsAValider = c.Boolean(nullable: false),
                        Statut = c.String(),
                        DateObtention = c.DateTime(),
                        ModeObtention = c.String(),
                        Commentaire = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oDomaineCompetence_ID = c.Int(),
                        oLivret2_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomaineCompetences", t => t.oDomaineCompetence_ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret2_ID, cascadeDelete: true)
                .Index(t => t.oDomaineCompetence_ID)
                .Index(t => t.oLivret2_ID);
            
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
                "dbo.MembreJuries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        College = c.String(),
                        Origine = c.String(),
                        Region = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        oLivret2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret2", t => t.oLivret2_ID)
                .Index(t => t.oLivret2_ID);
            
            CreateTable(
                "dbo.PieceJointeL2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Categorie = c.String(),
                        Libelle = c.String(),
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
            
            CreateTable(
                "dbo.PieceJointeL1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Categorie = c.String(),
                        Libelle = c.String(),
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
                        MotifRecoursCommentaire = c.String(),
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
                        oLivret_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Livret1", t => t.oLivret_ID, cascadeDelete: true)
                .Index(t => t.oLivret_ID);
            
            CreateTable(
                "dbo.MotifGeneralL1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MotifDetailleL1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        MotifGL1_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MotifGeneralL1", t => t.MotifGL1_ID, cascadeDelete: true)
                .Index(t => t.MotifGL1_ID);
            
            CreateTable(
                "dbo.MotifGeneralL2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MotifDetailleL2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        MotifGL2_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MotifGeneralL2", t => t.MotifGL2_ID, cascadeDelete: true)
                .Index(t => t.MotifGL2_ID);
            
            CreateTable(
                "dbo.ParamColleges",
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
            
            CreateTable(
                "dbo.ParamOrigines",
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
            
            CreateTable(
                "dbo.PieceJointeCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Livret = c.String(),
                        Categorie = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PieceJointeItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                        CategoriePJ_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PieceJointeCategories", t => t.CategoriePJ_ID, cascadeDelete: true)
                .Index(t => t.CategoriePJ_ID);
            
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
            DropForeignKey("dbo.PieceJointeItems", "CategoriePJ_ID", "dbo.PieceJointeCategories");
            DropForeignKey("dbo.MotifDetailleL2", "MotifGL2_ID", "dbo.MotifGeneralL2");
            DropForeignKey("dbo.MotifDetailleL1", "MotifGL1_ID", "dbo.MotifGeneralL1");
            DropForeignKey("dbo.Livret1", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret1", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.Recours", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.PieceJointeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.Livret2", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.Livret2", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.PieceJointeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.MembreJuries", "oLivret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.Juries", "oLivret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.EchangeL2", "oLivret_ID", "dbo.Livret2");
            DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
            DropForeignKey("dbo.DCLivrets", "oDomaineCompetence_ID", "dbo.DomaineCompetences");
            DropForeignKey("dbo.Juries", "oLivret1_ID", "dbo.Livret1");
            DropForeignKey("dbo.EchangeL1", "oLivret_ID", "dbo.Livret1");
            DropForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDomaineCompetence_ID", "dbo.DomaineCompetences");
            DropForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands");
            DropIndex("dbo.PieceJointeItems", new[] { "CategoriePJ_ID" });
            DropIndex("dbo.MotifDetailleL2", new[] { "MotifGL2_ID" });
            DropIndex("dbo.MotifDetailleL1", new[] { "MotifGL1_ID" });
            DropIndex("dbo.Recours", new[] { "oLivret_ID" });
            DropIndex("dbo.PieceJointeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.PieceJointeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.MembreJuries", new[] { "oLivret2_ID" });
            DropIndex("dbo.EchangeL2", new[] { "oLivret_ID" });
            DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
            DropIndex("dbo.DCLivrets", new[] { "oDomaineCompetence_ID" });
            DropIndex("dbo.Livret2", new[] { "oDiplome_ID" });
            DropIndex("dbo.Livret2", new[] { "oCandidat_ID" });
            DropIndex("dbo.Juries", new[] { "oLivret2_ID" });
            DropIndex("dbo.Juries", new[] { "oLivret1_ID" });
            DropIndex("dbo.EchangeL1", new[] { "oLivret_ID" });
            DropIndex("dbo.Livret1", new[] { "oDiplome_ID" });
            DropIndex("dbo.Livret1", new[] { "oCandidat_ID" });
            DropIndex("dbo.DomaineCompetences", new[] { "oDiplome_ID" });
            DropIndex("dbo.DomaineCompetences", new[] { "Numero" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDomaineCompetence_ID" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDiplomeCand_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oDiplome_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oCandidat_ID" });
            DropTable("dbo.Regions");
            DropTable("dbo.PieceJointeItems");
            DropTable("dbo.PieceJointeCategories");
            DropTable("dbo.ParamOrigines");
            DropTable("dbo.ParamColleges");
            DropTable("dbo.MotifDetailleL2");
            DropTable("dbo.MotifGeneralL2");
            DropTable("dbo.MotifDetailleL1");
            DropTable("dbo.MotifGeneralL1");
            DropTable("dbo.Recours");
            DropTable("dbo.PieceJointeL1");
            DropTable("dbo.PieceJointeL2");
            DropTable("dbo.MembreJuries");
            DropTable("dbo.EchangeL2");
            DropTable("dbo.DCLivrets");
            DropTable("dbo.Livret2");
            DropTable("dbo.Juries");
            DropTable("dbo.EchangeL1");
            DropTable("dbo.Livret1");
            DropTable("dbo.Diplomes");
            DropTable("dbo.DomaineCompetences");
            DropTable("dbo.DomaineCompetenceCands");
            DropTable("dbo.DiplomeCands");
            DropTable("dbo.Candidats");
        }
    }
}
