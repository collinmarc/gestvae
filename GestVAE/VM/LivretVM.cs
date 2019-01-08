using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class LivretVM:VMBase
    {
        public Livret TheLivret { get; set; }
        //public ObservableCollection<PieceJointeL1> lstPiecesJointes;

        public LivretVM(Livret pLivret)
        {
            TheLivret = pLivret;
            //lstPiecesJointes = new ObservableCollection<PieceJointeL1>();
        }


        public LivretVM()
        {
        }


        public Boolean IsContrat {
            get{
                return TheLivret.isContrat;
            }

            set
            {
                if (value != IsContrat)
                {
                    TheLivret.isContrat = value;
                    RaisePropertyChanged("IsContrat");
 //                   RaisePropertyChanged("IsConvention");
                }
            }
        }
        public Boolean IsConvention {
            get { return !TheLivret.isContrat; }
            set {
                if (value != IsConvention)
                {
                    TheLivret.isContrat= !value;
 //                   RaisePropertyChanged("IsContrat");
                    RaisePropertyChanged("IsConvention");
                }
}
        }

        public List<String> LstEtatLivret
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Demandé");
                oReturn.Add("Envoyé");
                oReturn.Add("Reçu");
                oReturn.Add("Accepté");
                oReturn.Add("Refusé");
                return oReturn;
            }
            set { }
        }
        public List<String> LstTypeDemande
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Courrier");
                oReturn.Add("Téléphone");
                oReturn.Add("Mail");
                oReturn.Add("Retrait au secretariat VAE");
                oReturn.Add("Fax");
                oReturn.Add("Non Renseigné");
                return oReturn;
            }
            set { }
        }

        public List<String> LstOrigineDemande
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Ehesp(autre)");
                oReturn.Add("site Ehesp");
                oReturn.Add("Établissements de formation CAFDES");
                oReturn.Add("Site établissements de formation CAFDES");
                oReturn.Add("Organisme de formation(suite à une prestation)");
                oReturn.Add("Directeur, RH");
                oReturn.Add("Collègues");
                oReturn.Add("DRASS");
                oReturn.Add("PIC / PRC");
                oReturn.Add("ASH");
                oReturn.Add("Gazette des communes");
                oReturn.Add("Direction");
                oReturn.Add("TSA");
                oReturn.Add("Autres");
                oReturn.Add("Presse");
                oReturn.Add("Salon Géront'Expo");
                oReturn.Add("Pôle Emploi(ANPE)");
                oReturn.Add("ASP(CNASEA)");
                oReturn.Add("Internet(autres sites…)");
                oReturn.Add("Non renseigné");
                return oReturn;
            }
            set { }
        }

        public void addPJL1()
        {
            Livret1 obj = (Livret1)TheLivret;

            obj.lstPiecesJointes.Add(new PieceJointeL1("..."));
            RaisePropertyChanged("TheLivret.lstPiecesJointes");
        }

    }
}
