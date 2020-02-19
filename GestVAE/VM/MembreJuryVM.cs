using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class MembreJuryVM : VMBase
    {
        public MembreJury TheMembreJury { get { return (MembreJury)TheItem; } }
        public MembreJuryVM(GestVAEcls.MembreJury pMembre):base(pMembre)
        {
            IsNew = false;
        }

        public MembreJuryVM():base()
        {
            TheItem = new MembreJury();
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
        public String DptDomicile
        {
            get { return TheMembreJury.DptDomicile; }
            set { TheMembreJury.DptDomicile = value;RaisePropertyChanged(); }
        }
        public String DptTravail
        {
            get { return TheMembreJury.DptTravail; }
            set { TheMembreJury.DptTravail = value; RaisePropertyChanged(); }
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


    }
}
