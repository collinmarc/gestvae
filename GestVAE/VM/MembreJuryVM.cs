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
        public String Nom_Prenom
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

        public BDMembreJury _DBMembreJurySelected;
        public BDMembreJury DBMembreJurySelected
        {
            get
            {
                return _DBMembreJurySelected;
            }
            set
            {
                if (value != _DBMembreJurySelected)
                {
                    ContextParam _ctx = new ContextParam();
                    _DBMembreJurySelected = value;
                    if (_DBMembreJurySelected != null)
                    {
                        Nom = DBMembreJurySelected.Nom_Prenom;
                        College = DBMembreJurySelected.College_membre;
                        Region = DBMembreJurySelected.Region;
                        String dpt_PRO;
                        String dpt_PRSO;
                        if (DBMembreJurySelected.Adresse_prioritaire.ToUpper().Contains("PROFESSION"))
                        {
                            dpt_PRO = String.Format("{0:00000}", DBMembreJurySelected.Cp_prio).Substring(0, 2);
                            dpt_PRSO = String.Format("{0:00000}", DBMembreJurySelected.Cp_non_prio).Substring(0, 2);

                        }
                        else
                        {
                            dpt_PRSO = String.Format("{0:00000}", DBMembreJurySelected.Cp_prio).Substring(0, 2);
                            dpt_PRO = String.Format("{0:00000}", DBMembreJurySelected.Cp_non_prio).Substring(0, 2);

                        }
                        ParamDepartement odpt = _ctx.dbParamDepartement.Where(d => d.Nom.StartsWith(dpt_PRO)).FirstOrDefault();
                        if (odpt != null)
                        {
                            DptTravail = odpt.Nom;
                        }
                        odpt = _ctx.dbParamDepartement.Where(d => d.Nom.StartsWith(dpt_PRSO)).FirstOrDefault();
                        if (odpt != null)
                        {
                            DptDomicile = odpt.Nom;
                        }
                    }
                }
            }
        }


    }
}
