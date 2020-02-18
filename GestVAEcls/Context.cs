using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Diagnostics;
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
#if DEBUG
        public Context() : base("name=CSGESTVAEDEV")
#else
        public Context() : base("name=CSGESTVAE")
#endif
        {
            Trace.WriteLine("Context : SQLServer = " + this.Database.Connection.DataSource);
#if DEBUG
#else
            Trace.WriteLine("Context : SetInitializer TO MigrateDatabaseToLatestVersion" );
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, GestVAEcls.Migrations.Configuration>());
#endif

        }
#if DEBUG
        public Context(IDatabaseInitializer<Context> pInit) : base("name=CSGESTVAEDEV")
#else
        public Context(IDatabaseInitializer<Context> pInit) : base("name=CSGESTVAE")
#endif
        {
            Database.SetInitializer(pInit);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<DiplomeCand> DiplomeCands { get; set; }
        public DbSet<DomaineCompetenceCand> DomaineCompetenceCands { get; set; }

        public DbSet<Recours> dbRecours { get; set; }
        public DbSet<Jury> Juries { get; set; }
        public DbSet<Livret1> Livret1 { get; set; }
        public DbSet<Livret2> Livret2 { get; set; }

        public DbSet<LockCandidat> Locks { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<DomaineCompetence> DomainesCompetences { get; set; }

        //================================
        // NE PAS UTILISER CES DBSETS
        // ILS ONT ETE TRANSFERE DANS CTXPARAM
        // PBLM DE MIGRATION , ILS DOIVENT RESTER LA
        //=====================================
        public DbSet<Param> dbParam_UTILISER_CTXPARAM { get; set; }
        public DbSet<ParamCollege> dbParamCollege_UTILISER_CTXPARAM { get; set; }
        public DbSet<ParamDepartement> dbParamDepartement_UTILISER_CTXPARAM { get; set; }
        public DbSet<ParamTypeDemande> dbParamTypeDemande_UTILISER_CTXPARAM { get; set; }
        public DbSet<ParamVecteurInformation> dbParamVecteurInformation_UTILISER_CTXPARAM { get; set; }
        public DbSet<Region> Regions_UTILISER_CTXPARAM { get; set; }
        public DbSet<PieceJointeCategorie> pieceJointeCategories_UTILISER_CTXPARAM { get; set; }
        public DbSet<MotifGeneralL1> dbMotifGeneralL1_UTILISER_CTXPARAM { get; set; }
        public DbSet<MotifGeneralL2> dbMotifGeneralL2_UTILISER_CTXPARAM { get; set; }


        public void DeleteOnCascade(Candidat oCand)

        {

            foreach (Livret1 oLiv in oCand.lstLivrets1)
            {
                while (oLiv.lstJurys.Count > 0)
                {
                    Jury oJ = oLiv.lstJurys[0];
                    Juries.Remove(oJ);
                }

            }
            foreach (Livret2 oLiv in oCand.lstLivrets2)
            {
                while (oLiv.lstJurys.Count > 0)
                {
                    Jury oJ = oLiv.lstJurys[0];
                    Juries.Remove(oJ);
                }

            }
            Candidats.Remove(oCand);
        }//DeleteOnCascade

    }//Context

    public class ContextLock : DbContext
    {
        private static Context _instance = null;
        public static Context instance
        {
            get
            {
                if (_instance == null)
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
#if DEBUG
        public ContextLock() : base("name=CSGESTVAEDEV")
#else
        public ContextLock() : base("name=CSGESTVAE")
#endif
        {

        }

        public DbSet<LockCandidat> Locks { get; set; }


    }
    public class ContextParam : DbContext
    {
#if DEBUG
        public ContextParam() : base("name=CSGESTVAEDEV")
#else
        public ContextParam() : base("name=CSGESTVAE")
#endif
        {
            Database.SetInitializer<ContextParam>(null);
        }

        public DbSet<Param> dbParam { get; set; }
        public DbSet<ParamCollege> dbParamCollege { get; set; }
        public DbSet<ParamDepartement> dbParamDepartement { get; set; }
        public DbSet<ParamTypeDemande> dbParamTypeDemande { get; set; }
        public DbSet<ParamVecteurInformation> dbParamVecteurInformation { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PieceJointeCategorie> pieceJointeCategories { get; set; }
        public DbSet<MotifGeneralL1> dbMotifGeneralL1 { get; set; }
        public DbSet<MotifGeneralL2> dbMotifGeneralL2 { get; set; }
 
    }
}
