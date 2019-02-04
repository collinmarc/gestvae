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


    }
}
