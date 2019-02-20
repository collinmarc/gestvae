namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Juries", name: "oLivret1_ID", newName: "Livret1_ID");
            RenameColumn(table: "dbo.Juries", name: "oLivret2_ID", newName: "Livret2_ID");
            RenameIndex(table: "dbo.Juries", name: "IX_oLivret1_ID", newName: "IX_Livret1_ID");
            RenameIndex(table: "dbo.Juries", name: "IX_oLivret2_ID", newName: "IX_Livret2_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Juries", name: "IX_Livret2_ID", newName: "IX_oLivret2_ID");
            RenameIndex(table: "dbo.Juries", name: "IX_Livret1_ID", newName: "IX_oLivret1_ID");
            RenameColumn(table: "dbo.Juries", name: "Livret2_ID", newName: "oLivret2_ID");
            RenameColumn(table: "dbo.Juries", name: "Livret1_ID", newName: "oLivret1_ID");
        }
    }
}
