namespace GestVAEcls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codeINSEE : DbMigration
    {
        public override void Up()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CODEINSEE" + "Start");
            AddColumn("dbo.Candidats", "INSEECommuneNaissance", c => c.String());
            AddColumn("dbo.Candidats", "INSEEPaysNaissance", c => c.String());
            AddColumn("dbo.Params", "PathToBasePays", c => c.String());
            AddColumn("dbo.Params", "PathToBaseCommunes", c => c.String());


            Sql(@"CREATE VIEW RQ_MONCOMPTEFORMATION
AS
SELECT        '' AS '5.1', '' AS '5.2', '' AS '5.3', 'PAR_ADMISSION' AS '5.4', 'false' AS '5.5', CONVERT(char(10), r.DateJury, 120) AS '5.6', CONVERT(char(10), r.DateJury, 120) AS '5.7', 'EN_PRESENTIEL' AS '5.8', '35000' AS '5.9', 
                         CONVERT(char(10), r.dateNotificationJury, 126) AS '5.10', CONVERT(char(10), r.DateValidite, 126) AS '5.11', '' AS '5.12', '' AS '5.13', '' AS '5.14', 'nil' AS '5.15', 'SANS_MENTION' AS '5.16', '' AS '5.17', '' AS '6.1', '' AS '6.2', 
                         '' AS '6.3', '' AS '6.4', 'VAE' AS '7.1', 'VAE_CLASSIQUE' AS '7.2', 'CERTIFIE' AS '7.3', CONVERT(char(10), r.DateReceptEHESPComplet, 126) AS '7.4', iif(r.NomJeuneFille IS NULL, r.nom, r.NomJeuneFille) AS '8.1', r.nom AS '8.2', 
                         r.Prenom AS '8.3', r.Prenom2 AS '8.4', r.Prenom3 AS '8.5', Year(r.DateNaissance) AS '8.6', month(r.DateNaissance) AS '8.7', DAY(r.DateNaissance) AS '8.8', r.sexe AS '8.9', candidats.INSEECommuneNaissance AS '8.10', 
                         candidats.CPNaissance AS '8.11', r.VilleNaissance AS '8.12', Candidats.INSEEPaysNaissance AS '8.13', r.PaysNaissance AS '8.14', '' AS '9.1', '' AS '9.2', '' AS '9.3'
FROM            RQ_L2_DOC r INNER JOIN
                         Candidats ON r.ID = Candidats.ID
WHERE r.Decision Like '30%'");


            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION UP]" + "CODEINSEE" + "End");
        }

        public override void Down()
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CODEINSEE" + "Start");
            DropColumn("dbo.Params", "PathToBaseCommunes");
            DropColumn("dbo.Params", "PathToBasePays");
            DropColumn("dbo.Candidats", "INSEEPaysNaissance");
            DropColumn("dbo.Candidats", "INSEECommuneNaissance");

            Sql(@"DROP VIEW RQ_MONCOMPTEFORMATION");

            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[DBMIGRATION DOWN]" + "CODEINSEE" + "End");
        }
    }
}
