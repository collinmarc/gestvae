namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEtatLivret : DbMigration
    {
        public override void Up()
        {
            // Maj des �tats de Livret1
            Sql("UPDATE LIVRET1 SET EtatLivret = '50-D�favorable' where EtatLivret = '50-Refus�'");
            Sql("UPDATE LIVRET1 SET EtatLivret = '70-Favorable' where EtatLivret = '70-Accept�'");
            // Maj des �tats de Livret2
            Sql("UPDATE LIVRET2 SET EtatLivret = '50-D�favorable' where EtatLivret = '50-Refus�'");
            Sql("UPDATE LIVRET2 SET EtatLivret = '70-Favorable' where EtatLivret = '70-Accept�'");
        }

        public override void Down()
        {
            // Maj des �tats de Livret1
            Sql("UPDATE LIVRET1 SET EtatLivret = '50-Refus�' where EtatLivret = '50-D�favorable'");
            Sql("UPDATE LIVRET1 SET EtatLivret = '70-Accept�' where EtatLivret = '70-Favorable'");
            // Maj des �tats de Livret2
            Sql("UPDATE LIVRET2 SET EtatLivret = '50-Refus�' where EtatLivret = '50-D�favorable'");
            Sql("UPDATE LIVRET2 SET EtatLivret = '70-Accept�' where EtatLivret = '70-Favorable'");
        }
    }
}
