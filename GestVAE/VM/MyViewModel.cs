
using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestVAE.VM
{
    //public enum Statuts { ACCEPTE, REFUSE};
    public class MyViewModel : NotifyUIBase
    {
        private Context _ctx;
        private ObservableCollection<CandidatVM> _lstCandidatVM;
        
        public MyViewModel()
        {
            _lstCandidatVM = new ObservableCollection<CandidatVM>();
        }
        public ObservableCollection<CandidatVM> lstCandidatVM
        {
            get => _lstCandidatVM;
            set
            {
                if (value != _lstCandidatVM)
                {
                    _lstCandidatVM = value;
                    RaisePropertyChanged();
                };
            }
        }

 

        public void getData()
        {
            _ctx = Context.instance;

            // Créatino du CAFDES si Necessaire
             Diplome oDipCAFDES = Diplome.getDiplomeParDefaut();

            if (oDipCAFDES == null)
            {
                oDipCAFDES = new Diplome("CAFDES");
                oDipCAFDES.addDomainecompetence("DC1");
                oDipCAFDES.addDomainecompetence("DC2");
                oDipCAFDES.addDomainecompetence("DC3");
                oDipCAFDES.addDomainecompetence("DC4");

                _ctx.Diplomes.Add(oDipCAFDES);
            }
 
            _lstCandidatVM.Clear();
            foreach (Candidat item in _ctx.Candidats)
            {
                if (item.Sexe == null)
                {
                    item.Sexe = Sexe.H;
                }
                //List<DiplomeCand> olst =  item.lstDiplomes.ToList();
                //if (item.lstDiplomes.Count() ==0)
                //{
                //    DiplomeCand oDipCand = new DiplomeCand(oDipCAFDES, DateTime.Now);
                //    oDipCand.lstDCCands[0].Statut = "REFUSE";
                //    oDipCand.lstDCCands[1].Statut = "REFUSE";
                //    oDipCand.lstDCCands[2].Statut = "REFUSE";
                //    oDipCand.lstDCCands[3].Statut = "REFUSE";
                //    item.lstDiplomes.Add(oDipCand);
                //    //_ctx.DiplomeCands.Add(oDipCand);
                //}
                CandidatVM oCand = new CandidatVM(item);
                _lstCandidatVM.Add(oCand);
            }
        }
         public void populate()
        {
            for (int i = 0; i < 50; i++)
            {
                Candidat oCan = new Candidat("Candidat" + i);
                oCan.Ville = "Ville" + i;
                Livret1 oL1 = new Livret1();
                Random oRand = new Random(new Random().Next());
                int Ddays = oRand.Next(0, 360);
                oL1.DateDemande = DateTime.Now.AddDays(Ddays);
                oCan.lstLivrets1.Add(oL1);

                Livret2 oL2 = new Livret2();
                Ddays = oRand.Next(10, 20);
                oL2.DateDemande = oL1.DateDemande.Value.AddDays(Ddays);
                oL2.EtatLivret = "4-Refusé";
                oCan.lstLivrets2.Add(oL2);

                oL2 = new Livret2();
                Ddays = oRand.Next(10, 20);
                oL2.DateDemande = oL1.DateDemande.Value.AddDays(Ddays);
                oL2.EtatLivret = "2-Reçu";
                oCan.lstLivrets2.Add(oL2);

                _ctx.Candidats.Add(oCan);
                CandidatVM oCandVM = new CandidatVM(oCan);
                lstCandidatVM.Add(oCandVM);
            }
            
            RaisePropertyChanged("lstCandidatsVM");
        }
        public void AddCandidat()
        {
            Candidat oCand = new Candidat("...");
            //_ctx.Candidats.Add(oCand);
            CandidatVM oCandVM = new CandidatVM(oCand);
            lstCandidatVM.Add(oCandVM);
            _ctx.Candidats.Add(oCand);
          

        }
        public void saveData()
        {
            Context.instance.SaveChanges();
        }

        public String rechIdentifiantVAE { get; set; }
        public String rechNom { get; set; }
        public String rechPrenom { get; set; }
        public String rechVille { get; set; }
        public DateTime? rechDateReceptL1Deb { get; set; }
        public DateTime? rechDateReceptL1Fin { get; set; }
        public DateTime? rechDateReceptL2Deb { get; set; }
        public DateTime? rechDateReceptL2Fin { get; set; }

        public void Recherche()
        {
            IQueryable<Candidat> rq = _ctx.Candidats;
            if (rechIdentifiantVAE != "")
            {
                rq = rq.Where(c => c.IdVAE.Equals(rechIdentifiantVAE));
            }
            _lstCandidatVM.Clear();
            foreach (Candidat item in rq)
            {
                if (item.Sexe == null)
                {
                    item.Sexe = Sexe.H;
                }
               CandidatVM oCand = new CandidatVM(item);
                _lstCandidatVM.Add(oCand);
            }
            RaisePropertyChanged("lstCandidatVM");
        }
        
    }
}
