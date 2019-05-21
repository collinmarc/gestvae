namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEtatLivret : DbMigration
    {
        public override void Up()
        {
            // Maj des états de Livret1
            Sql("UPDATE LIVRET1 SET EtatLivret = '50-Défavorable' where EtatLivret = '50-Refusé'");
            Sql("UPDATE LIVRET1 SET EtatLivret = '70-Favorable' where EtatLivret = '70-Accepté'");
            // Maj des états de Livret2
            Sql("UPDATE LIVRET2 SET EtatLivret = '50-Défavorable' where EtatLivret = '50-Refusé'");
            Sql("UPDATE LIVRET2 SET EtatLivret = '70-Favorable' where EtatLivret = '70-Accepté'");
        }

        public override void Down()
        {
            // Maj des états de Livret1
            Sql("UPDATE LIVRET1 SET EtatLivret = '50-Refusé' where EtatLivret = '50-Défavorable'");
            Sql("UPDATE LIVRET1 SET EtatLivret = '70-Accepté' where EtatLivret = '70-Favorable'");
            // Maj des états de Livret2
            Sql("UPDATE LIVRET2 SET EtatLivret = '50-Refusé' where EtatLivret = '50-Défavorable'");
            Sql("UPDATE LIVRET2 SET EtatLivret = '70-Accepté' where EtatLivret = '70-Favorable'");
        }
    }
}
