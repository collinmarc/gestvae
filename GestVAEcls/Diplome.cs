using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class Diplome:GestVAEBase
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
            List<DomaineCompetence> oReturn; 
            using (Context _ctx = new Context())
            {
                oReturn = (from obj in _ctx.DomainesCompetences
                           where bDeleted == false && obj.oDiplome.ID == ID
                           orderby obj.Numero ascending
                           select obj).ToList<DomaineCompetence>();
            }
                return oReturn;
        }

        public void addDomainecompetence(String pNom)
        {
            DomaineCompetence oDC = new DomaineCompetence(pNom);
            oDC.Numero = lstDomainesCompetences.Count + 1;
            lstDomainesCompetences.Add(oDC);

        }
        public static Diplome getDiplomeParDefaut()
        {
            Diplome oDiplome;
            Context ctx = Context.instance;
            oDiplome = (from obj in ctx.Diplomes
                        where obj.bDeleted == false &&
                               obj.Nom == Properties.Settings.Default.NomDiplomeDefaut
                        select obj).FirstOrDefault<Diplome>();
            //Chargement de la liste des domanes de compétences
            if (oDiplome != null)
            {
                oDiplome.lstDomainesCompetences.ToList();
            }
            return oDiplome;

        }

    }
}
