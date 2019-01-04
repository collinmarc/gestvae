using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class CAFDESVM:VMBase
    {
        private Candidat _candidat { get; set; }
        public CAFDESVM(Candidat pCandidat)
        {
            _candidat = pCandidat;
        }


        public CAFDESVM()
        {
        }
        public String NomDiplome {
            get
            {
                return _candidat.lstDiplomes[0].oDiplome.Nom;
            }
            set
            {
                
                 _candidat.lstDiplomes[0].oDiplome.Nom = value;
                RaisePropertyChanged();

            }
        }
        public Boolean EtatDiplome
        {
            get
            {

                Boolean bReturn= true;
                foreach (var oDC in _candidat.lstDiplomes[0].lstDCCands)
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
                        foreach (var oDC in _candidat.lstDiplomes[0].lstDCCands)
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
                return _candidat.lstDiplomes[0].lstDCCands[0].Statut;
            }
            set
            {
                if (value != StatutDC1)
                {
                    _candidat.lstDiplomes[0].lstDCCands[0].Statut = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC2
        {
            get
            {
                return _candidat.lstDiplomes[0].lstDCCands[1].Statut;
            }
            set
            {
                if (value != StatutDC2)
                {
                    _candidat.lstDiplomes[0].lstDCCands[1].Statut = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC3
        {
            get
            {
                return _candidat.lstDiplomes[0].lstDCCands[2].Statut;
            }
            set
            {
                if (value != StatutDC3)
                {
                    _candidat.lstDiplomes[0].lstDCCands[2].Statut = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String StatutDC4
        {
            get
            {
                return _candidat.lstDiplomes[0].lstDCCands[3].Statut;
            }
            set
            {
                if (value != StatutDC4)
                {
                    _candidat.lstDiplomes[0].lstDCCands[3].Statut = value;
                    RaisePropertyChanged();
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
    }
}
