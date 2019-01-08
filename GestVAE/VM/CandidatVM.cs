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
        public ObservableCollection<DiplomeCandVM> Diplome { get; set; }
        public ObservableCollection<LivretVM> lstLivrets { get; set; }
        public CandidatVM(Candidat pCandidat)
        {
            TheCandidat = pCandidat;
            Diplome = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVM>();
            foreach (DiplomeCand item in pCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                Diplome.Add(oDipCand);
            }
            foreach (Livret item in pCandidat.lstLivrets1)
            {
                LivretVM oLivret = new LivretVM(item);
                lstLivrets.Add(oLivret);
            }
            foreach (Livret item in pCandidat.lstLivrets2)
            {
                LivretVM oLivret = new LivretVM(item);
                lstLivrets.Add(oLivret);
            }

        }
        public CandidatVM()
        {
            TheCandidat = new Candidat();
            Diplome = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVM>();
            foreach (DiplomeCand item in TheCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                Diplome.Add(oDipCand);
            }
            foreach (Livret item in TheCandidat.lstLivrets1)
            {
                LivretVM oLivret = new LivretVM(item);
                lstLivrets.Add(oLivret);
            }
            foreach (Livret item in TheCandidat.lstLivrets2)
            {
                LivretVM oLivret = new LivretVM(item);
                lstLivrets.Add(oLivret);
            }

        }
    }
}
