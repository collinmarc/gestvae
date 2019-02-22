using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Context() : base("name=CSGESTVAE")
        {
        }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<DomaineCompetence> DomainesCompetences { get; set; }
        public DbSet<DiplomeCand> DiplomeCands { get; set; }
        public DbSet<DomaineCompetenceCand> DomaineCompetenceCands { get; set; }

        public DbSet<Recours> dbRecours { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ParamCollege> dbParamCollege { get; set; }
        public DbSet<ParamOrigine> dbParamOrigine { get; set; }
        public DbSet<PieceJointeCategorie> pieceJointeCategories { get; set; }
        public DbSet<MotifGeneralL1> dbMotifGeneralL1 { get; set; }
        public DbSet<MotifGeneralL2> dbMotifGeneralL2 { get; set; }

        //TST
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Livret>()
            //.Property(p => p.ID)
            //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
            //;
            //modelBuilder.Entity<Livret1>()
            //.Property(p => p.ID)
            //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
            //;
            //modelBuilder.Entity<Livret2>()
            //.Property(p => p.ID)
            //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
            //;

            //modelBuilder.Entity<Livret1>().HasKey(t => t.IDLivret);
            //modelBuilder.Entity<Livret2>().HasKey(t => t.IDLivret);

            //modelBuilder.Entity<Livret1>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Livret1");
            //});

            //modelBuilder.Entity<Livret2>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Livret2");
            //});
            ////modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Candidat>()
            //    .HasKey(t => t.ID);
            //modelBuilder.Entity<Diplome>()
            //    .HasKey(t => t.ID);
            //modelBuilder.Entity<DiplomeCand>()
            //    .HasKey(t => t.ID);
            //modelBuilder.Entity<DomaineCompetence>()
            //    .HasKey(t => t.ID);
            //modelBuilder.Entity<DomaineCompetenceCand>()
            //    .HasKey(t => t.ID);

            //modelBuilder.Entity<DomaineCompetenceCand>()
            //    .HasRequired(t => t.oDiplomeCand)
            //    .WithOptional()
            //    .WillCascadeOnDelete(true);


            //modelBuilder.Entity<T2>()
            //    .HasKey(t => t.ID)
            //    .HasRequired(t => t.oT1)
            //    .WithRequiredPrincipal()
            //    .WillCascadeOnDelete();

        }

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
                        }

                        foreach (Echange oItem in oLiv.lstEchanges)
                        {
                            Entry<Echange>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                        foreach (PieceJointe oItem in oLiv.lstPiecesJointes)
                        {
                            Entry<PieceJointe>(oItem).State = System.Data.Entity.EntityState.Deleted;
                        }
                        foreach (Recours oItem in oLiv.lstRecours)
                        {
                            Entry<Recours>(oItem).State = System.Data.Entity.EntityState.Deleted;
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
