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
        public Context() : base("name=CSGESTVAE")
        {
        }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<DomaineCompetence> DomainesCompetences { get; set; }
        public DbSet<DiplomeCand> DiplomeCands { get; set; }
        public DbSet<DomaineCompetenceCand> DomaineCompetenceCands { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

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
