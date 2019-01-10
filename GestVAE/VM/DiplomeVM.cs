using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class DiplomeVM: VMBase
    {
        public Diplome TheDiplome;

        public DiplomeVM()
        {
            TheDiplome = new Diplome();
        }

        public DiplomeVM(Diplome pDiplome)
        {
            TheDiplome = pDiplome;
        }

        public String NomDiplome
        {
            get
            {
                return TheDiplome.Nom;
            }
            set
            {
                if (value != NomDiplome)
                {
                    TheDiplome.Nom = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<DomaineCompetence> lstDomainesCompetences
        {
            get
            {
                return TheDiplome.lstDomainesCompetences;
            }
        }

        public void Commit()
        {
            if ( _ctx.Entry<Diplome>(TheDiplome).State== System.Data.Entity.EntityState.Detached )
            {
                _ctx.Diplomes.Add(TheDiplome);
            }
        }
    }

}
