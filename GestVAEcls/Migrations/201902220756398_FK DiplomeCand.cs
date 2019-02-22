namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKDiplomeCand : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DiplomeCands", name: "oDiplome_ID", newName: "Diplome_ID");
            RenameIndex(table: "dbo.DiplomeCands", name: "IX_oDiplome_ID", newName: "IX_Diplome_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DiplomeCands", name: "IX_Diplome_ID", newName: "IX_oDiplome_ID");
            RenameColumn(table: "dbo.DiplomeCands", name: "Diplome_ID", newName: "oDiplome_ID");
        }
    }
}
