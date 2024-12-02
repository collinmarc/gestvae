namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;

    public partial class AjoutCAFDESV2 : DbMigration
    {
        public override void Up()
        {
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutCAFDESV2 " + "start");

            Sql(@"INSERT INTO Diplomes(Nom,Description,dateCreation, dateModif,bDeleted) VALUES ('CAFDESV2','CAFDESV2', getDate(), getDate(),0)");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutCAFDESV2 " + "start");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (1,'BLOC1', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutCAFDESV2 " + "start");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (2,'BLOC2', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutCAFDESV2 " + "start");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (3,'BLOC3', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutCAFDESV2 " + "start");
            Sql(@"insert into DomaineCompetences (Numero,nom,Diplome_Id,datecreation,dateModif,bDeleted) VALUES (4,'BLOC4', (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2'),getdate(), getdate(),0 )");
            Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "AjoutCAFDESV2 " + "End");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM Juries WHERE Livret1_ID in  (SELECT Livret1.ID FROM Livret1, diplomes WHERE Livret1.diplome_id = diplomes.id and diplomes.NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM Juries WHERE Livret2_ID in  (SELECT Livret2.ID FROM Livret2, diplomes WHERE Livret2.diplome_id = diplomes.id and diplomes.NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM Livret1 WHERE  Diplome_Id =  (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM Livret2 WHERE  Diplome_Id =  (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM DCLivrets WHERE oDomaineCompetence_ID in (SELECT DomaineCompetences.ID FROM DomaineCompetences, diplomes WHERE DomaineCompetences.diplome_id = diplomes.id and diplomes.NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM DomaineCompetenceCands WHERE DomaineCompetence_ID in (SELECT DomaineCompetences.ID FROM DomaineCompetences, diplomes WHERE DomaineCompetences.diplome_id = diplomes.id and diplomes.NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM DomaineCompetences WHERE Diplome_Id =  (SELECT ID FROM DIPLOMEs WHERE NOM = 'CAFDESV2')");
            Sql(@"DELETE FROM Diplomes where nom = 'CAFDESV2'");
        }
    }
}
