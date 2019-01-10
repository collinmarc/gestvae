
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

        public void AddCandidat()
        {
            Candidat oCand = new Candidat("...");
            //_ctx.Candidats.Add(oCand);
            CandidatVM oCandVM = new CandidatVM(oCand);
            lstCandidatVM.Add(oCandVM);

        }
        public void saveData()
        {
            Context.instance.SaveChanges();
        }

 
    }
}
