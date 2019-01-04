using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class DiplomeCandVM:VMBase
    {
        private DiplomeCand TheDiplome { get; set; }
        public DiplomeCandVM(DiplomeCand pDiplome)
        {
            TheDiplome = pDiplome;
        }


        public DiplomeCandVM()
        {
        }
        public String NomDiplome {
            get
            {
                return TheDiplome.oDiplome.Nom;
            }
            set
            {
                
                 TheDiplome.oDiplome.Nom = value;
                RaisePropertyChanged();

            }
        }
        public Boolean EtatDiplome
        {
            get
            {

                Boolean bReturn= true;
                foreach (var oDC in TheDiplome.lstDCCands)
                {
                    if (oDC.Statut =="REFUSE")
                    {
                        bReturn = false;
                    }
                }
                return bReturn;
            }
            set
            {
                if (value != EtatDiplome)
                {
                    if (value)
                    {
                        foreach (var oDC in TheDiplome.lstDCCands)
                        {
                            oDC.Statut = "ACCEPTE";
                            oDC.DateObtention = DateTime.Now;
                        }
                        RaisePropertyChanged("StatutDC1");
                        RaisePropertyChanged("StatutDC2");
                        RaisePropertyChanged("StatutDC3");
                        RaisePropertyChanged("StatutDC4");
                    }
                }
                

            }
        }
         public String StatutDC1
        {
            get
            {
                return TheDiplome.lstDCCands[0].Statut;
            }
            set
            {
                if (value != StatutDC1)
                {
                    TheDiplome.lstDCCands[0].Statut = value;
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
        public DateTime DateObtentionDC1
        {
            get
            {
                return TheDiplome.lstDCCands[0].DateObtention.Value;
            }
            set
            {
                if (value != DateObtentionDC1)
                {
                    TheDiplome.lstDCCands[0].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC1
        {
            get
            {
                return TheDiplome.lstDCCands[0].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC1)
                {
                    TheDiplome.lstDCCands[0].ModeObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC2
        {
            get
            {
                return TheDiplome.lstDCCands[1].Statut;
            }
            set
            {
                if (value != StatutDC2)
                {
                    TheDiplome.lstDCCands[1].Statut = value;
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
        public DateTime DateObtentionDC2
        {
            get
            {
                return TheDiplome.lstDCCands[1].DateObtention.Value;
            }
            set
            {
                if (value != DateObtentionDC2)
                {
                    TheDiplome.lstDCCands[1].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC2
        {
            get
            {
                return TheDiplome.lstDCCands[1].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC2)
                {
                    TheDiplome.lstDCCands[1].ModeObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC3
        {
            get
            {
                return TheDiplome.lstDCCands[2].Statut;
            }
            set
            {
                if (value != StatutDC3)
                {
                    TheDiplome.lstDCCands[2].Statut = value;
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
        public DateTime DateObtentionDC3
        {
            get
            {
                return TheDiplome.lstDCCands[2].DateObtention.Value;
            }
            set
            {
                if (value != DateObtentionDC3)
                {
                    TheDiplome.lstDCCands[2].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC3
        {
            get
            {
                return TheDiplome.lstDCCands[2].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC3)
                {
                    TheDiplome.lstDCCands[2].ModeObtention = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC3ACCEPTE");
                }
            }
        }
        public String StatutDC4
        {
            get
            {
                return TheDiplome.lstDCCands[3].Statut;
            }
            set
            {
                if (value != StatutDC4)
                {
                    TheDiplome.lstDCCands[3].Statut = value;
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
        public DateTime DateObtentionDC4
        {
            get
            {
                return TheDiplome.lstDCCands[3].DateObtention.Value;
            }
            set
            {
                if (value != DateObtentionDC4)
                {
                    TheDiplome.lstDCCands[3].DateObtention = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtentionDC4
        {
            get
            {
                return TheDiplome.lstDCCands[3].ModeObtention;
            }
            set
            {
                if (value != ModeObtentionDC4)
                {
                    TheDiplome.lstDCCands[3].ModeObtention = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("isDC4ACCEPTE");
                }
            }
        }
        public List<String> LstStatut {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("ACCEPTE");
                oReturn.Add("REFUSE");
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
                oReturn.Add("Dispence");
                return oReturn;
            }
            set { }
        }
    }
}
