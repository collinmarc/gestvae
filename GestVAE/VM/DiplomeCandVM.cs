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
    public class DiplomeCandVM:VMBase
    {
        public DiplomeCand TheDiplomeCand { get; set; }
        public DiplomeCandVM(DiplomeCand pDiplomeCand):base(pDiplomeCand)
        {
            TheDiplomeCand = pDiplomeCand;
        }


        public DiplomeCandVM():base()
        {
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<DiplomeCand> entry = _ctx.Entry<DiplomeCand>(TheDiplomeCand);
            return entry;
        }

        public Diplome oDiplome
        {
            get
            {
                return TheDiplomeCand.oDiplome;
            }
            set
            {
                if (value != oDiplome)
                {
                    TheDiplomeCand.oDiplome = value;
                    foreach (var item in lstDCCands)
                    {
                        if (item.ID !=0)
                        {
                            _ctx.DomaineCompetenceCands.Remove(item);
                        }
                    }
                    TheDiplomeCand.SetDCs();
                    RaisePropertyChanged();
                    RaisePropertyChanged("NomDiplome");
                }
            }
        }

        public String NomDiplome
        {
            get
            {
                return TheDiplomeCand.oDiplome.Nom;
            }
        }
        public String StatutDiplome
        {
            get
            {
                return TheDiplomeCand.Statut;
            }
            set
            {
                if (value != StatutDiplome)
                {
                    TheDiplomeCand.Statut = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtention
        {
            get
            {
                return TheDiplomeCand.ModeObtention;
            }
            set
            {
                if (value != ModeObtention)
                {
                    TheDiplomeCand.ModeObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public void CalcStatutDiplome()
        {
            Int32 nbRefusé = 0;
            Int32 nbEncours = 0;
            Int32 nbValidé = 0;

            nbRefusé = lstDCCands.Where(d => d.Statut == "Refusé").Count();
            nbEncours = lstDCCands.Where(d => d.Statut == "En cours").Count();
            nbValidé = lstDCCands.Where(d => d.Statut == "Validé").Count();

            if (nbRefusé == lstDCCands.Count())
                { StatutDiplome = LstStatutDiplome[2]; } // Refusé
            if (nbValidé == lstDCCands.Count())
                { StatutDiplome = LstStatutDiplome[0]; } // Validé

            if (nbValidé != lstDCCands.Count() && nbRefusé != lstDCCands.Count())
            {

                if (nbEncours > 0)
                {
                    if (StatutDiplome == "")
                    {
                        StatutDiplome = LstStatutDiplome[3]; // encours
                    }
                }
                else
                {
                     StatutDiplome = LstStatutDiplome[1];  // Validé partiellement                
                }
            }
        }
        public DateTime? DateObtentionDiplome
        {
            get
            {
                return TheDiplomeCand.DateObtention;
            }
            set
            {
                if (value != DateObtentionDiplome)
                {
                    TheDiplomeCand.DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NumeroDiplome
        {
            get
            {
                return TheDiplomeCand.NumeroDiplome;
            }
            set
            {
                if (value != NumeroDiplome)
                {
                    TheDiplomeCand.NumeroDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NumeroEURODIR
        {
            get
            {
                return TheDiplomeCand.NumeroEURODIR;
            }
            set
            {
                if (value != NumeroEURODIR)
                {
                    TheDiplomeCand.NumeroEURODIR = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Boolean IsDCCands
        {
            get
            {
                return (lstDCCands.Count > 0);
            }
        }
        public ObservableCollection<DomaineCompetenceCand> lstDCCands
        {
            get
            {
                return TheDiplomeCand.lstDCCands;
            }
            set
            {
                if (value != lstDCCands)
                {
                    TheDiplomeCand.lstDCCands = value;
                    RaisePropertyChanged();
                }
            }
        }
         public String StatutDC1
        {
            get
            {
                return TheDiplomeCand.lstDCCands[0].Statut;
            }
            set
            {
                if (value != StatutDC1)
                {
                    TheDiplomeCand.lstDCCands[0].Statut = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC1ACCEPTE");
                }
            }
        }
        public  Boolean isDC1ACCEPTE
        {
            get
            {
                return StatutDC1 == "ACCEPTE";
            }
        }
        public DateTime? DateObtentionDC1
        {
            get
            {
                return TheDiplomeCand.lstDCCands[0].DateObtention;
            }
            set
            {
                if (value != DateObtentionDC1)
                {
                    TheDiplomeCand.lstDCCands[0].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC1
        {
            get
            {
                return TheDiplomeCand.lstDCCands[0].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC1)
                {
                    TheDiplomeCand.lstDCCands[0].ModeObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC2
        {
            get
            {
                return TheDiplomeCand.lstDCCands[1].Statut;
            }
            set
            {
                if (value != StatutDC2)
                {
                    TheDiplomeCand.lstDCCands[1].Statut = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC2ACCEPTE");
                }
            }
        }
        public Boolean isDC2ACCEPTE
        {
            get
            {
                return StatutDC2 == "ACCEPTE";
            }
        }
        public DateTime? DateObtentionDC2
        {
            get
            {
                return TheDiplomeCand.lstDCCands[1].DateObtention;
            }
            set
            {
                if (value != DateObtentionDC2)
                {
                    TheDiplomeCand.lstDCCands[1].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC2
        {
            get
            {
                return TheDiplomeCand.lstDCCands[1].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC2)
                {
                    TheDiplomeCand.lstDCCands[1].ModeObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC3
        {
            get
            {
                return TheDiplomeCand.lstDCCands[2].Statut;
            }
            set
            {
                if (value != StatutDC3)
                {
                    TheDiplomeCand.lstDCCands[2].Statut = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC3ACCEPTE");
                }
            }
        }
        public Boolean isDC3ACCEPTE
        {
            get
            {
                return StatutDC3 == "ACCEPTE";
            }
        }
        public DateTime? DateObtentionDC3
        {
            get
            {
                return TheDiplomeCand.lstDCCands[2].DateObtention;
            }
            set
            {
                if (value != DateObtentionDC3)
                {
                    TheDiplomeCand.lstDCCands[2].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC3
        {
            get
            {
                return TheDiplomeCand.lstDCCands[2].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC3)
                {
                    TheDiplomeCand.lstDCCands[2].ModeObtention = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC3ACCEPTE");
                }
            }
        }
        public String StatutDC4
        {
            get
            {
                return TheDiplomeCand.lstDCCands[3].Statut;
            }
            set
            {
                if (value != StatutDC4)
                {
                    TheDiplomeCand.lstDCCands[3].Statut = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean isDC4ACCEPTE
        {
            get
            {
                return StatutDC4 == "ACCEPTE";
            }
        }
        public DateTime? DateObtentionDC4
        {
            get
            {
                return TheDiplomeCand.lstDCCands[3].DateObtention;
            }
            set
            {
                if (value != DateObtentionDC4)
                {
                    TheDiplomeCand.lstDCCands[3].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC4
        {
            get
            {
                return TheDiplomeCand.lstDCCands[3].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC4)
                {
                    TheDiplomeCand.lstDCCands[3].ModeObtention = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC4ACCEPTE");
                }
            }
        }
        public List<String> LstStatutModule {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Validé");
                oReturn.Add("Refusé");
                oReturn.Add("En cours");
                return oReturn;
            }
            set { }
                 }
        public List<String> LstStatutDiplome
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Validé");
                oReturn.Add("Validé Partiellement");
                oReturn.Add("Refusé");
                oReturn.Add("En cours");
                oReturn.Add("");
                return oReturn;
            }
            set { }
        }
        public List<String> LstModeObtention
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("FI");
                oReturn.Add("VAE");
                oReturn.Add("Dispense");
                return oReturn;
            }
            set { }
        }
        public List<Diplome> LstDiplomes
        {
            get
            {
                List<Diplome> oReturn;
                oReturn = (from obj in _ctx.Diplomes
                           select obj).ToList<Diplome>();

                return oReturn;
            }

        }

        public void RefreshlstDiplome()
        {
            RaisePropertyChanged("LstDiplomes");
        }
        public void Commit()
        {
            foreach (DomaineCompetenceCand item in lstDCCands)
            {
                if (_ctx.Entry<DomaineCompetenceCand>(item).State == System.Data.Entity.EntityState.Detached)
                {
                    _ctx.DomaineCompetenceCands.Add(item);
                }
                if (_ctx.Entry<DomaineCompetenceCand>(item).State == System.Data.Entity.EntityState.Deleted)
                {
                    _ctx.DomaineCompetenceCands.Remove(item);
                }

            }
            if (_ctx.Entry<DiplomeCand>(TheDiplomeCand).State == System.Data.Entity.EntityState.Detached)
            {
                _ctx.DiplomeCands.Add(TheDiplomeCand);
            }
            if (_ctx.Entry<DiplomeCand>(TheDiplomeCand).State == System.Data.Entity.EntityState.Deleted)
            {
                _ctx.DiplomeCands.Remove(TheDiplomeCand);
            }
        }

    }
}
