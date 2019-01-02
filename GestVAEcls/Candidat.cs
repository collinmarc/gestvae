using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Candidat(String pNom) : this ()
        {
            Nom = pNom;
        }


        public virtual ObservableCollection<DiplomeCand> lstDiplomes { get; set; }

    }
}
