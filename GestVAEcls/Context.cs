using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestVAEcls
{

    public class Context:DbContext
    {
        private static Context _instance = null;
        public static Context instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new Context();
                }
                return _instance;
            }
        }

        public static void Reset()
        {
            _instance = new Context();
        }
        public Context():base()
        {
            String CS1 = Properties.Settings.Default.CSGESTVAE;
            String CS = ConfigurationManager.ConnectionStrings["CSGESTVAE"].ConnectionString;
            if (dbMode != "PROD")
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(CS);
                builder.DataSource = dbSRV;
                builder.InitialCatalog = dbCatalog;
                Database.Connection.ConnectionString = builder.ConnectionString;
            }
            
        }
        public String dbMode
        {
            get
            {
                return ConfigurationManager.AppSettings["dbMODE"];
            }
        }
        public String dbSRV
        {
            get
            {
                String strReturn="";
                if (dbMode == "DEV")
                {
                    strReturn = ConfigurationManager.AppSettings["dbSRVDEV"];
                }
                if (dbMode == "PP")
                {
                    strReturn = ConfigurationManager.AppSettings["dbSRVPP"];
                }
                return strReturn;
            }
        }
        public String dbCatalog
        {
            get
            {
                String strReturn = "";
                if (dbMode == "DEV")
                {
                    strReturn = ConfigurationManager.AppSettings["dbCATALOGDEV"];
                }
                if (dbMode == "PP")
                {
                    strReturn = ConfigurationManager.AppSettings["dbCATALOGPP"];
                }
                return strReturn;
            }
        }
        public DbSet<LockCandidat> Locks { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<DomaineCompetence> DomainesCompetences { get; set; }
        public DbSet<DiplomeCand> DiplomeCands { get; set; }
        public DbSet<DomaineCompetenceCand> DomaineCompetenceCands { get; set; }

        public DbSet<Recours> dbRecours { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ParamCollege> dbParamCollege { get; set; }
        public DbSet<ParamOrigine> dbParamOrigine { get; set; }
        public DbSet<ParamTypeDemande> dbParamTypeDemande { get; set; }
        public DbSet<ParamVecteurInformation> dbParamVecteurInformation { get; set; }
        public DbSet<PieceJointeCategorie> pieceJointeCategories { get; set; }
        public DbSet<MotifGeneralL1> dbMotifGeneralL1 { get; set; }
        public DbSet<MotifGeneralL2> dbMotifGeneralL2 { get; set; }
        public DbSet<Param> dbParam { get; set; }


        public void DeleteOnCascade()

        {
            foreach (Candidat oCand in Candidats)
            {
                if (Entry<Candidat>(oCand).State == System.Data.Entity.EntityState.Deleted)
                {
                    foreach (Livret1 oLiv in oCand.lstLivrets1)
                    {
                        Entry<Livret1>(oLiv).State = System.Data.Entity.EntityState.Deleted;
                    }
                    foreach (Livret2 oLiv in oCand.lstLivrets2)
                    {
                        Entry<Livret2>(oLiv).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (Livret1 oLiv in oCand.lstLivrets1)
                {
                    if (Entry<Livret1>(oLiv).State == System.Data.Entity.EntityState.Deleted)
                    {
                        foreach (Jury oItem in oLiv.lstJurys)
                        {
                            Entry<Jury>(oItem).State = System.Data.Entity.EntityState.Deleted;
                            foreach (Recours oItemR in oItem.lstRecours)
                            {
                                Entry<Recours>(oItemR).State = System.Data.Entity.EntityState.Deleted;
                            }
                        }

                        foreach (Echange oItem in oLiv.lstEchanges)
                        {
                            Entry<Echange>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                        foreach (PieceJointe oItem in oLiv.lstPiecesJointes)
                        {
                            Entry<PieceJointe>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }
                }
                foreach (Livret2 oLiv in oCand.lstLivrets2)
                {
                    if (Entry<Livret2>(oLiv).State == System.Data.Entity.EntityState.Deleted)
                    {
                        foreach (Jury oItem in oLiv.lstJurys)
                        {
                            Entry<Jury>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }

                        foreach (Echange oItem in oLiv.lstEchanges)
                        {
                            Entry<Echange>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                        foreach (PieceJointe oItem in oLiv.lstPiecesJointes)
                        {
                            Entry<PieceJointe>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                        foreach (DCLivret oItem in oLiv.lstDCLivrets)
                        {
                            Entry<DCLivret>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                        foreach (MembreJury oItem in oLiv.lstMembreJurys)
                        {
                            Entry<MembreJury>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }
                }
            }
        }
    }
}
