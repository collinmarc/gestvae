namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PJCategorie : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PieceJointeItems", "CategoriePJ_ID", "dbo.PieceJointeCategories");
            DropIndex("dbo.PieceJointeItems", new[] { "CategoriePJ_ID" });
            DropTable("dbo.PieceJointeItems");
            DropTable("dbo.PieceJointeCategories");
        }
    }
}
