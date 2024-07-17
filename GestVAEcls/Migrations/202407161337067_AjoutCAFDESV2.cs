namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutCAFDESV2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Diplomes(Nom,Description,dateCreation, dateModif,bDeleted) VALUES ('CAFDESV2','CAFDESV2', getDate(), getDate(),0)");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (1,'BLOC1', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (2,'BLOC2', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (3,'BLOC3', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (4,'BLOC4', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM DomaineCompetences WHERE Diplome_Id =  (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM Diplomes where nom = 'CAFDESV2'");
        }
    }
}
