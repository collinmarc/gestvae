using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class CandidatVM:VMBase
    {

        public Candidat TheCandidat { get; set; }
        public ObservableCollection<DiplomeCandVM> lstDiplomesCandVMs { get; set; }
        public ObservableCollection<LivretVMBase> lstLivrets { get; set; }
        public CandidatVM(Candidat pCandidat)
        {
            TheCandidat = pCandidat;
            lstDiplomesCandVMs = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVMBase>();
            foreach (DiplomeCand item in pCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                lstDiplomesCandVMs.Add(oDipCand);
            }
            foreach (Livret1 item in pCandidat.lstLivrets1)
            {
                Livret1VM oLivret = new Livret1VM(item);
                lstLivrets.Add(oLivret);
            }
            foreach (Livret2 item in pCandidat.lstLivrets2)
            {
                Livret2VM oLivret = new Livret2VM(item);
                lstLivrets.Add(oLivret);
            }

        }
        public CandidatVM()
        {
            TheCandidat = new Candidat();
            lstDiplomesCandVMs = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVMBase>();
            foreach (DiplomeCand item in TheCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                lstDiplomesCandVMs.Add(oDipCand);
            }
            foreach (Livret1 item in TheCandidat.lstLivrets1)
            {
                Livret1VM oLivret = new Livret1VM(item);
                lstLivrets.Add(oLivret);
            }
            foreach (Livret2 item in TheCandidat.lstLivrets2)
            {
                Livret2VM oLivret = new Livret2VM(item);
                lstLivrets.Add(oLivret);
            }

        }

        public DiplomeCandVM AjoutDiplomeCand()
        {
            DiplomeCand oDiplCand = TheCandidat.AddDiplome();
            DiplomeCandVM oDiplomeCand = new DiplomeCandVM(oDiplCand);
            lstDiplomesCandVMs.Add(oDiplomeCand);
            RaisePropertyChanged("lstDiplomesCandVMs");
            return oDiplomeCand;
        }


        public Livret1VM AjoutLivret1()
        {
            Livret1 oLiv = new Livret1();
            oLiv.Numero = DateTime.Now.ToString("yyyyMMddHHmm");
            Livret1VM oLivVM = new Livret1VM(oLiv);
            TheCandidat.lstLivrets1.Add(oLiv);
            lstLivrets.Add(oLivVM);
            RaisePropertyChanged("lstLivrets");
            return oLivVM;
        }

        public Livret2VM AjoutLivret2()
        {
            Diplome oDiplome = Diplome.getDiplomeParDefaut();
            Livret2 oLiv = new Livret2(oDiplome);
            oLiv.EtatLivret = "0-Demandé";
            oLiv.DateDemande = DateTime.Now;
            oLiv.Numero = TheCandidat.lstLivrets2.Count() + 1;
            TheCandidat.lstLivrets2.Add(oLiv);
            Livret2VM oLiv2VM = new Livret2VM(oLiv);
            lstLivrets.Add(oLiv2VM);
            RaisePropertyChanged("lstLivrets");
            return oLiv2VM;
        }
        public Livret2VM AjoutLivret2(Diplome pDiplome)
        {
            Livret2 oLiv = new Livret2(pDiplome);
            oLiv.EtatLivret = "0-Demandé";
            oLiv.DateDemande = DateTime.Now;
            oLiv.Numero = TheCandidat.lstLivrets2.Count() + 1;
            TheCandidat.lstLivrets2.Add(oLiv);
            Livret2VM oLiv2VM = new Livret2VM(oLiv);
            lstLivrets.Add(oLiv2VM);
            RaisePropertyChanged("lstLivrets");
            return oLiv2VM;
        }
    }
}
