
namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public partial class Installdu11042019 : DbMigration
    {
        public override void Up()
        {
            if (!Exists("dbo.Candidats"))
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
                        Nationalite = c.String(),
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
                        Candidat_ID = c.Int(nullable: false),
                        Diplome_ID = c.Int(nullable: false),
                        Statut = c.String(),
                        DateObtention = c.DateTime(),
                        NumeroDiplome = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Candidats", t => t.Candidat_ID, cascadeDelete: true)
                    .ForeignKey("dbo.Diplomes", t => t.Diplome_ID, cascadeDelete: true)
                    .Index(t => t.Candidat_ID)
                    .Index(t => t.Diplome_ID);

                CreateTable(
                    "dbo.DomaineCompetenceCands",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Diplome_ID = c.Int(nullable: false),
                        DomaineCompetence_ID = c.Int(),
                        Statut = c.String(),
                        DateObtention = c.DateTime(),
                        ModeObtention = c.String(),
                        Commentaire = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.DiplomeCands", t => t.Diplome_ID, cascadeDelete: true)
                    .ForeignKey("dbo.DomaineCompetences", t => t.DomaineCompetence_ID)
                    .Index(t => t.Diplome_ID)
                    .Index(t => t.DomaineCompetence_ID);

                CreateTable(
                    "dbo.DomaineCompetences",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Nom = c.String(),
                        Diplome_ID = c.Int(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Diplomes", t => t.Diplome_ID, cascadeDelete: true)
                    .Index(t => t.Numero)
                    .Index(t => t.Diplome_ID);

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
                        TypeDemande = c.String(),
                        VecteurInformation = c.String(),
                        DateDemande = c.DateTime(),
                        DateLimiteEnvoiEHESP = c.DateTime(),
                        DateLimiteReceptEHESP = c.DateTime(),
                        DateLimiteJury = c.DateTime(),
                        DateValidite = c.DateTime(),
                        Date1ereDemandePieceManquantes = c.DateTime(),
                        Date2emeDemandePieceManquantes = c.DateTime(),
                        DateDemandePieceManquantesRetour = c.DateTime(),
                        DateReceptionPiecesManquantes = c.DateTime(),
                        Candidat_ID = c.Int(nullable: false),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        EtatLivret = c.String(),
                        DateEnvoiEHESP = c.DateTime(),
                        DateEnvoiCandidat = c.DateTime(),
                        DateReceptEHESP = c.DateTime(),
                        DateReceptEHESPComplet = c.DateTime(),
                        Diplome_ID = c.Int(nullable: false),
                        isClos = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Candidats", t => t.Candidat_ID, cascadeDelete: true)
                    .ForeignKey("dbo.Diplomes", t => t.Diplome_ID, cascadeDelete: true)
                    .Index(t => t.Candidat_ID)
                    .Index(t => t.Diplome_ID);

                CreateTable(
                    "dbo.EchangeL1",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Livret1_ID = c.Int(nullable: false),
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
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Livret1", t => t.Livret1_ID, cascadeDelete: true)
                    .Index(t => t.Livret1_ID);

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
                        Livret1_ID = c.Int(),
                        Livret2_ID = c.Int(),
                        DateNotificationJury = c.DateTime(),
                        DateNotificationJuryRecours = c.DateTime(),
                        IsRecours = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Livret1", t => t.Livret1_ID)
                    .ForeignKey("dbo.Livret2", t => t.Livret2_ID)
                    .Index(t => t.Livret1_ID)
                    .Index(t => t.Livret2_ID);

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
                        DateLimiteJury = c.DateTime(),
                        DateJury = c.DateTime(),
                        LieuJury = c.String(),
                        Decision = c.String(),
                        MotifGeneral = c.String(),
                        MotifDetail = c.String(),
                        MotifCommentaire = c.String(),
                        Jury_ID = c.Int(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Juries", t => t.Jury_ID, cascadeDelete: true)
                    .Index(t => t.Jury_ID);

                CreateTable(
                    "dbo.Livret2",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        NumPassage = c.Int(nullable: false),
                        IsOuvertureApresRecours = c.Boolean(nullable: false),
                        DateDemande = c.DateTime(),
                        DateLimiteEnvoiEHESP = c.DateTime(),
                        DateLimiteReceptEHESP = c.DateTime(),
                        Date1ereDemandePieceManquantes = c.DateTime(),
                        Date2emeDemandePieceManquantes = c.DateTime(),
                        DateDemandePieceManquantesRetour = c.DateTime(),
                        DateReceptionPiecesManquantes = c.DateTime(),
                        DatePrevJury1 = c.DateTime(),
                        DatePrevJury2 = c.DateTime(),
                        SessionJury = c.String(),
                        DateLimiteJury = c.DateTime(),
                        DateValidite = c.DateTime(),
                        IsAttestationOK = c.Boolean(nullable: false),
                        IsCNIOK = c.Boolean(nullable: false),
                        IsDispenseArt2 = c.Boolean(nullable: false),
                        NumDiplome = c.String(),
                        Candidat_ID = c.Int(nullable: false),
                        DateEcheance = c.DateTime(),
                        isContrat = c.Boolean(nullable: false),
                        EtatLivret = c.String(),
                        DateEnvoiEHESP = c.DateTime(),
                        DateEnvoiCandidat = c.DateTime(),
                        DateReceptEHESP = c.DateTime(),
                        DateReceptEHESPComplet = c.DateTime(),
                        Diplome_ID = c.Int(nullable: false),
                        isClos = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Candidats", t => t.Candidat_ID, cascadeDelete: true)
                    .ForeignKey("dbo.Diplomes", t => t.Diplome_ID, cascadeDelete: true)
                    .Index(t => t.Candidat_ID)
                    .Index(t => t.Diplome_ID);

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
                        Livret2_ID = c.Int(nullable: false),
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
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Livret2", t => t.Livret2_ID, cascadeDelete: true)
                    .Index(t => t.Livret2_ID);

                CreateTable(
                    "dbo.MembreJuries",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        College = c.String(),
                        Origine = c.String(),
                        Region = c.String(),
                        Livret2_ID = c.Int(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Livret2", t => t.Livret2_ID, cascadeDelete: true)
                    .Index(t => t.Livret2_ID);

                CreateTable(
                    "dbo.PieceJointeL2",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Livret2_ID = c.Int(nullable: false),
                        Categorie = c.String(),
                        Libelle = c.String(),
                        IsRecu = c.Boolean(nullable: false),
                        IsOK = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Livret2", t => t.Livret2_ID, cascadeDelete: true)
                    .Index(t => t.Livret2_ID);

                CreateTable(
                    "dbo.PieceJointeL1",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Livret1_ID = c.Int(nullable: false),
                        Categorie = c.String(),
                        Libelle = c.String(),
                        IsRecu = c.Boolean(nullable: false),
                        IsOK = c.Boolean(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.Livret1", t => t.Livret1_ID, cascadeDelete: true)
                    .Index(t => t.Livret1_ID);

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
                        MotifGL1_ID = c.Int(nullable: false),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
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
                        MotifGL2_ID = c.Int(nullable: false),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.MotifGeneralL2", t => t.MotifGL2_ID, cascadeDelete: true)
                    .Index(t => t.MotifGL2_ID);

                CreateTable(
                    "dbo.Params",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumLivret = c.Int(nullable: false),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID);

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
                    "dbo.ParamTypeDemandes",
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
                    "dbo.ParamVecteurInformations",
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
                    "dbo.LockCandidats",
                    c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDLockCandidat = c.Int(nullable: false),
                        IDUser = c.Int(nullable: false),
                        IDCandidat = c.Int(nullable: false),
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
                        Categorie_ID = c.Int(nullable: false),
                        Libelle = c.String(),
                        dateCreation = c.DateTime(nullable: false),
                        dateModif = c.DateTime(nullable: false),
                        bDeleted = c.Boolean(nullable: false),
                        AttSup = c.String(),
                    })
                    .PrimaryKey(t => t.ID)
                    .ForeignKey("dbo.PieceJointeCategories", t => t.Categorie_ID, cascadeDelete: true)
                    .Index(t => t.Categorie_ID);

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

            }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PieceJointeItems", "Categorie_ID", "dbo.PieceJointeCategories");
            //DropForeignKey("dbo.MotifDetailleL2", "MotifGL2_ID", "dbo.MotifGeneralL2");
            //DropForeignKey("dbo.MotifDetailleL1", "MotifGL1_ID", "dbo.MotifGeneralL1");
            //DropForeignKey("dbo.Livret1", "Diplome_ID", "dbo.Diplomes");
            //DropForeignKey("dbo.Livret1", "Candidat_ID", "dbo.Candidats");
            //DropForeignKey("dbo.PieceJointeL1", "Livret1_ID", "dbo.Livret1");
            //DropForeignKey("dbo.Livret2", "Diplome_ID", "dbo.Diplomes");
            //DropForeignKey("dbo.Livret2", "Candidat_ID", "dbo.Candidats");
            //DropForeignKey("dbo.PieceJointeL2", "Livret2_ID", "dbo.Livret2");
            //DropForeignKey("dbo.MembreJuries", "Livret2_ID", "dbo.Livret2");
            //DropForeignKey("dbo.Juries", "Livret2_ID", "dbo.Livret2");
            //DropForeignKey("dbo.EchangeL2", "Livret2_ID", "dbo.Livret2");
            //DropForeignKey("dbo.DCLivrets", "oLivret2_ID", "dbo.Livret2");
            //DropForeignKey("dbo.DCLivrets", "oDomaineCompetence_ID", "dbo.DomaineCompetences");
            //DropForeignKey("dbo.Juries", "Livret1_ID", "dbo.Livret1");
            //DropForeignKey("dbo.Recours", "Jury_ID", "dbo.Juries");
            //DropForeignKey("dbo.EchangeL1", "Livret1_ID", "dbo.Livret1");
            //DropForeignKey("dbo.DiplomeCands", "Diplome_ID", "dbo.Diplomes");
            //DropForeignKey("dbo.DiplomeCands", "Candidat_ID", "dbo.Candidats");
            //DropForeignKey("dbo.DomaineCompetenceCands", "DomaineCompetence_ID", "dbo.DomaineCompetences");
            //DropForeignKey("dbo.DomaineCompetences", "Diplome_ID", "dbo.Diplomes");
            //DropForeignKey("dbo.DomaineCompetenceCands", "Diplome_ID", "dbo.DiplomeCands");
            //DropIndex("dbo.PieceJointeItems", new[] { "Categorie_ID" });
            //DropIndex("dbo.MotifDetailleL2", new[] { "MotifGL2_ID" });
            //DropIndex("dbo.MotifDetailleL1", new[] { "MotifGL1_ID" });
            //DropIndex("dbo.PieceJointeL1", new[] { "Livret1_ID" });
            //DropIndex("dbo.PieceJointeL2", new[] { "Livret2_ID" });
            //DropIndex("dbo.MembreJuries", new[] { "Livret2_ID" });
            //DropIndex("dbo.EchangeL2", new[] { "Livret2_ID" });
            //DropIndex("dbo.DCLivrets", new[] { "oLivret2_ID" });
            //DropIndex("dbo.DCLivrets", new[] { "oDomaineCompetence_ID" });
            //DropIndex("dbo.Livret2", new[] { "Diplome_ID" });
            //DropIndex("dbo.Livret2", new[] { "Candidat_ID" });
            //DropIndex("dbo.Recours", new[] { "Jury_ID" });
            //DropIndex("dbo.Juries", new[] { "Livret2_ID" });
            //DropIndex("dbo.Juries", new[] { "Livret1_ID" });
            //DropIndex("dbo.EchangeL1", new[] { "Livret1_ID" });
            //DropIndex("dbo.Livret1", new[] { "Diplome_ID" });
            //DropIndex("dbo.Livret1", new[] { "Candidat_ID" });
            //DropIndex("dbo.DomaineCompetences", new[] { "Diplome_ID" });
            //DropIndex("dbo.DomaineCompetences", new[] { "Numero" });
            //DropIndex("dbo.DomaineCompetenceCands", new[] { "DomaineCompetence_ID" });
            //DropIndex("dbo.DomaineCompetenceCands", new[] { "Diplome_ID" });
            //DropIndex("dbo.DiplomeCands", new[] { "Diplome_ID" });
            //DropIndex("dbo.DiplomeCands", new[] { "Candidat_ID" });
            //DropTable("dbo.Regions");
            //DropTable("dbo.PieceJointeItems");
            //DropTable("dbo.PieceJointeCategories");
            //DropTable("dbo.LockCandidats");
            //DropTable("dbo.ParamVecteurInformations");
            //DropTable("dbo.ParamTypeDemandes");
            //DropTable("dbo.ParamOrigines");
            //DropTable("dbo.ParamColleges");
            //DropTable("dbo.Params");
            //DropTable("dbo.MotifDetailleL2");
            //DropTable("dbo.MotifGeneralL2");
            //DropTable("dbo.MotifDetailleL1");
            //DropTable("dbo.MotifGeneralL1");
            //DropTable("dbo.PieceJointeL1");
            //DropTable("dbo.PieceJointeL2");
            //DropTable("dbo.MembreJuries");
            //DropTable("dbo.EchangeL2");
            //DropTable("dbo.DCLivrets");
            //DropTable("dbo.Livret2");
            //DropTable("dbo.Recours");
            //DropTable("dbo.Juries");
            //DropTable("dbo.EchangeL1");
            //DropTable("dbo.Livret1");
            //DropTable("dbo.Diplomes");
            //DropTable("dbo.DomaineCompetences");
            //DropTable("dbo.DomaineCompetenceCands");
            //DropTable("dbo.DiplomeCands");
            //DropTable("dbo.Candidats");
        }

        private static bool Exists(string tableName)
        {
            using (var context = new Context())
            {
                var count = context.Database.SqlQuery<int>("SELECT COUNT(OBJECT_ID(@p0, 'U'))", tableName);

                return count.Any() && count.First() > 0;
            }
        }
    }
}
