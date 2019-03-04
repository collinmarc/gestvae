using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class MembreJuryVM: VMBase
    {
        private MembreJury TheMembreJury;
        public MembreJuryVM(GestVAEcls.MembreJury pMembre):base(pMembre)
        {
            TheMembreJury = pMembre;
            IsNew = false;
        }

        public MembreJuryVM():base()
        {
            TheMembreJury = new MembreJury();
            IsNew = true;
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<MembreJury> entry = _ctx.Entry<MembreJury>(TheMembreJury);
            return entry;
        }

        public String Nom
        {
            get { return TheMembreJury.Nom; }
            set { TheMembreJury.Nom = value; RaisePropertyChanged(); }
        }
        public String Origine
        {
            get { return TheMembreJury.Origine; }
            set { TheMembreJury.Origine = value;RaisePropertyChanged(); }
        }
        public String College
        {
            get { return TheMembreJury.College; }
            set {
                TheMembreJury.College = value;
                RaisePropertyChanged();
            }
        }
        public String Region
        {
            get { return TheMembreJury.Region; }
            set {
                TheMembreJury.Region = value;
                RaisePropertyChanged(); }
        }

        public MembreJury MembreJuryItem
        {
            get { return TheMembreJury; }
        }

    }
}
