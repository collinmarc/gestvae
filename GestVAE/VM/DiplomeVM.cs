using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class DiplomeVM: VMBase
    {
        public Diplome TheDiplome;

        public DiplomeVM():base()
        {
            TheDiplome = new Diplome();
        }

        public DiplomeVM(Diplome pDiplome):base(pDiplome)
        {
            TheDiplome = pDiplome;
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Diplome> entry = _ctx.Entry<Diplome>(TheDiplome);
            return entry;
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
        public String DescriptionDiplome
        {
            get
            {
                return TheDiplome.Description;
            }
            set
            {
                if (value != DescriptionDiplome)
                {
                    TheDiplome.Description = value;
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
            if (_ctx.Entry<Diplome>(TheDiplome).State == System.Data.Entity.EntityState.Deleted)
            {
                _ctx.Diplomes.Remove(TheDiplome);
            }
        }
    }

}
