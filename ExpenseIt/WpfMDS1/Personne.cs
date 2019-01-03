using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMDS1
{
    public class Personne
    {
        public Personne()
        {
            diplomes = new ObservableCollection<Diplome>();
        }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Ville { get; set; }

        public ObservableCollection<Diplome> diplomes { get; set; }
    }

    public class lstPersonne : ObservableCollection<Personne>
    {
    }


    public class Diplome
        {
        public String Nom { get; set; }
        public String Etat{ get; set; }
    }


}
