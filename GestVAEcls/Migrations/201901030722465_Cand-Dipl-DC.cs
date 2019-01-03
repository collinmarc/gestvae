namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandDiplDC : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands");
            DropForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes");
            DropIndex("dbo.DiplomeCands", new[] { "oCandidat_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oDiplome_ID" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDiplomeCand_ID" });
            DropIndex("dbo.DomaineCompetences", new[] { "oDiplome_ID" });
            AlterColumn("dbo.DiplomeCands", "oCandidat_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.DiplomeCands", "oDiplome_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.DomaineCompetences", "oDiplome_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.DiplomeCands", "oCandidat_ID");
            CreateIndex("dbo.DiplomeCands", "oDiplome_ID");
            CreateIndex("dbo.DomaineCompetenceCands", "oDiplomeCand_ID");
            CreateIndex("dbo.DomaineCompetences", "oDiplome_ID");
            AddForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes");
            DropForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands");
            DropForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats");
            DropIndex("dbo.DomaineCompetences", new[] { "oDiplome_ID" });
            DropIndex("dbo.DomaineCompetenceCands", new[] { "oDiplomeCand_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oDiplome_ID" });
            DropIndex("dbo.DiplomeCands", new[] { "oCandidat_ID" });
            AlterColumn("dbo.DomaineCompetences", "oDiplome_ID", c => c.Int());
            AlterColumn("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", c => c.Int());
            AlterColumn("dbo.DiplomeCands", "oDiplome_ID", c => c.Int());
            AlterColumn("dbo.DiplomeCands", "oCandidat_ID", c => c.Int());
            CreateIndex("dbo.DomaineCompetences", "oDiplome_ID");
            CreateIndex("dbo.DomaineCompetenceCands", "oDiplomeCand_ID");
            CreateIndex("dbo.DiplomeCands", "oDiplome_ID");
            CreateIndex("dbo.DiplomeCands", "oCandidat_ID");
            AddForeignKey("dbo.DomaineCompetences", "oDiplome_ID", "dbo.Diplomes", "ID");
            AddForeignKey("dbo.DiplomeCands", "oDiplome_ID", "dbo.Diplomes", "ID");
            AddForeignKey("dbo.DomaineCompetenceCands", "oDiplomeCand_ID", "dbo.DiplomeCands", "ID");
            AddForeignKey("dbo.DiplomeCands", "oCandidat_ID", "dbo.Candidats", "ID");
        }
    }
}
