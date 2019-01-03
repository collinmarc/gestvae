using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFAPP
{
    public class Personne
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Ville { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }

    public class lstPersonne : ObservableCollection<Personne>
    {
    }

}
