using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class Diplome:GestVAE
    {
        public Diplome()
        {
            lstDomainesCompetences = new ObservableCollection<DomaineCompetence>();
        }
        public Diplome(String pNom):this()
        {
            Nom = pNom;
        }
        public String Nom { get; set; }
        public String Description { get; set; }

        public virtual ObservableCollection<DomaineCompetence> lstDomainesCompetences { get; set; }

        public List<DomaineCompetence> lstDomainesCompetencesSorted()
        {
            return  lstDomainesCompetences.OrderBy(dc => dc.Numero).ToList<DomaineCompetence>();
        }

        public void addDomainecompetence(String pNom)
        {
            DomaineCompetence oDC = new DomaineCompetence(this,pNom);
            oDC.Numero = lstDomainesCompetences.Count + 1;
            lstDomainesCompetences.Add(oDC);

        }
    }
}
