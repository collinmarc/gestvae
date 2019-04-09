namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LockIDUSER : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LockCandidats", "IDLockCandidat", c => c.Int(nullable: false));
            AddColumn("dbo.LockCandidats", "IDUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LockCandidats", "IDUser");
            DropColumn("dbo.LockCandidats", "IDLockCandidat");
        }
    }
}
