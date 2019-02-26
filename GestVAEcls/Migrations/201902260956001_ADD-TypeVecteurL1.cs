namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDTypeVecteurL1 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Livret1", "VecteurInformation", c => c.String());
            DropColumn("dbo.Livret1", "OrigineDemande");
            DropColumn("dbo.Livret2", "TypeDemande");
            DropColumn("dbo.Livret2", "OrigineDemande");
            DropTable("dbo.Departments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            AddColumn("dbo.Livret2", "OrigineDemande", c => c.String());
            AddColumn("dbo.Livret2", "TypeDemande", c => c.String());
            AddColumn("dbo.Livret1", "OrigineDemande", c => c.String());
            DropColumn("dbo.Livret1", "VecteurInformation");
            DropTable("dbo.ParamVecteurInformations");
            DropTable("dbo.ParamTypeDemandes");
        }
    }
}
