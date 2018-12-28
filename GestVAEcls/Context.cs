using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}
