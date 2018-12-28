using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class Candidat : GestVAE
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public Candidat() :base()
        {
            Nom = "";
            Prenom = "";

        }
    }
}
