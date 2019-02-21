namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MembreJuries", "oLivret2_ID", "dbo.Livret2");
            DropIndex("dbo.MembreJuries", new[] { "oLivret2_ID" });
            RenameColumn(table: "dbo.DiplomeCands", name: "oCandidat_ID", newName: "Candidat_ID");
            RenameColumn(table: "dbo.Livret1", name: "oCandidat_ID", newName: "Candidat_ID");
            RenameColumn(table: "dbo.Livret2", name: "oCandidat_ID", newName: "Candidat_ID");
            RenameColumn(table: "dbo.DomaineCompetenceCands", name: "oDiplomeCand_ID", newName: "Diplome_ID");
            RenameColumn(table: "dbo.DiplomeCands", name: "oDiplome_ID", newName: "Diplome_ID");
            RenameColumn(table: "dbo.DomaineCompetenceCands", name: "oDomaineCompetence_ID", newName: "DomaineCompetence_ID");
            RenameColumn(table: "dbo.DomaineCompetences", name: "oDiplome_ID", newName: "Diplome_ID");
            RenameColumn(table: "dbo.EchangeL1", name: "oLivret_ID", newName: "Livret1_ID");
            RenameColumn(table: "dbo.PieceJointeL1", name: "oLivret_ID", newName: "Livret1_ID");
            RenameColumn(table: "dbo.Recours", name: "oLivret_ID", newName: "Livret1_ID");
            RenameColumn(table: "dbo.EchangeL2", name: "oLivret_ID", newName: "Livret2_ID");
            RenameColumn(table: "dbo.MembreJuries", name: "oLivret2_ID", newName: "Livret2_ID");
            RenameColumn(table: "dbo.PieceJointeL2", name: "oLivret_ID", newName: "Livret2_ID");
            RenameColumn(table: "dbo.PieceJointeItems", name: "CategoriePJ_ID", newName: "Categorie_ID");
            RenameIndex(table: "dbo.DiplomeCands", name: "IX_oCandidat_ID", newName: "IX_Candidat_ID");
            RenameIndex(table: "dbo.DiplomeCands", name: "IX_oDiplome_ID", newName: "IX_Diplome_ID");
            RenameIndex(table: "dbo.DomaineCompetenceCands", name: "IX_oDiplomeCand_ID", newName: "IX_Diplome_ID");
            RenameIndex(table: "dbo.DomaineCompetenceCands", name: "IX_oDomaineCompetence_ID", newName: "IX_DomaineCompetence_ID");
            RenameIndex(table: "dbo.DomaineCompetences", name: "IX_oDiplome_ID", newName: "IX_Diplome_ID");
            RenameIndex(table: "dbo.Livret1", name: "IX_oCandidat_ID", newName: "IX_Candidat_ID");
            RenameIndex(table: "dbo.EchangeL1", name: "IX_oLivret_ID", newName: "IX_Livret1_ID");
            RenameIndex(table: "dbo.Livret2", name: "IX_oCandidat_ID", newName: "IX_Candidat_ID");
            RenameIndex(table: "dbo.EchangeL2", name: "IX_oLivret_ID", newName: "IX_Livret2_ID");
            RenameIndex(table: "dbo.PieceJointeL2", name: "IX_oLivret_ID", newName: "IX_Livret2_ID");
            RenameIndex(table: "dbo.PieceJointeL1", name: "IX_oLivret_ID", newName: "IX_Livret1_ID");
            RenameIndex(table: "dbo.Recours", name: "IX_oLivret_ID", newName: "IX_Livret1_ID");
            RenameIndex(table: "dbo.PieceJointeItems", name: "IX_CategoriePJ_ID", newName: "IX_Categorie_ID");
            AlterColumn("dbo.MembreJuries", "Livret2_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.MembreJuries", "Livret2_ID");
            AddForeignKey("dbo.MembreJuries", "Livret2_ID", "dbo.Livret2", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembreJuries", "Livret2_ID", "dbo.Livret2");
            DropIndex("dbo.MembreJuries", new[] { "Livret2_ID" });
            AlterColumn("dbo.MembreJuries", "Livret2_ID", c => c.Int());
            RenameIndex(table: "dbo.PieceJointeItems", name: "IX_Categorie_ID", newName: "IX_CategoriePJ_ID");
            RenameIndex(table: "dbo.Recours", name: "IX_Livret1_ID", newName: "IX_oLivret_ID");
            RenameIndex(table: "dbo.PieceJointeL1", name: "IX_Livret1_ID", newName: "IX_oLivret_ID");
            RenameIndex(table: "dbo.PieceJointeL2", name: "IX_Livret2_ID", newName: "IX_oLivret_ID");
            RenameIndex(table: "dbo.EchangeL2", name: "IX_Livret2_ID", newName: "IX_oLivret_ID");
            RenameIndex(table: "dbo.Livret2", name: "IX_Candidat_ID", newName: "IX_oCandidat_ID");
            RenameIndex(table: "dbo.EchangeL1", name: "IX_Livret1_ID", newName: "IX_oLivret_ID");
            RenameIndex(table: "dbo.Livret1", name: "IX_Candidat_ID", newName: "IX_oCandidat_ID");
            RenameIndex(table: "dbo.DomaineCompetences", name: "IX_Diplome_ID", newName: "IX_oDiplome_ID");
            RenameIndex(table: "dbo.DomaineCompetenceCands", name: "IX_DomaineCompetence_ID", newName: "IX_oDomaineCompetence_ID");
            RenameIndex(table: "dbo.DomaineCompetenceCands", name: "IX_Diplome_ID", newName: "IX_oDiplomeCand_ID");
            RenameIndex(table: "dbo.DiplomeCands", name: "IX_Diplome_ID", newName: "IX_oDiplome_ID");
            RenameIndex(table: "dbo.DiplomeCands", name: "IX_Candidat_ID", newName: "IX_oCandidat_ID");
            RenameColumn(table: "dbo.PieceJointeItems", name: "Categorie_ID", newName: "CategoriePJ_ID");
            RenameColumn(table: "dbo.PieceJointeL2", name: "Livret2_ID", newName: "oLivret_ID");
            RenameColumn(table: "dbo.MembreJuries", name: "Livret2_ID", newName: "oLivret2_ID");
            RenameColumn(table: "dbo.EchangeL2", name: "Livret2_ID", newName: "oLivret_ID");
            RenameColumn(table: "dbo.Recours", name: "Livret1_ID", newName: "oLivret_ID");
            RenameColumn(table: "dbo.PieceJointeL1", name: "Livret1_ID", newName: "oLivret_ID");
            RenameColumn(table: "dbo.EchangeL1", name: "Livret1_ID", newName: "oLivret_ID");
            RenameColumn(table: "dbo.DomaineCompetences", name: "Diplome_ID", newName: "oDiplome_ID");
            RenameColumn(table: "dbo.DomaineCompetenceCands", name: "DomaineCompetence_ID", newName: "oDomaineCompetence_ID");
            RenameColumn(table: "dbo.DiplomeCands", name: "Diplome_ID", newName: "oDiplome_ID");
            RenameColumn(table: "dbo.DomaineCompetenceCands", name: "Diplome_ID", newName: "oDiplomeCand_ID");
            RenameColumn(table: "dbo.Livret2", name: "Candidat_ID", newName: "oCandidat_ID");
            RenameColumn(table: "dbo.Livret1", name: "Candidat_ID", newName: "oCandidat_ID");
            RenameColumn(table: "dbo.DiplomeCands", name: "Candidat_ID", newName: "oCandidat_ID");
            CreateIndex("dbo.MembreJuries", "oLivret2_ID");
            AddForeignKey("dbo.MembreJuries", "oLivret2_ID", "dbo.Livret2", "ID");
        }
    }
}
