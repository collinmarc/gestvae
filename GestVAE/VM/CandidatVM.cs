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
        public ObservableCollection<CAFDESVM> Diplome { get; set; }
        public CandidatVM(Candidat pCandidat)
        {
            TheCandidat = pCandidat;
            Diplome = new ObservableCollection<CAFDESVM>();
            Diplome.Add(new CAFDESVM(pCandidat));
        }
    }
}
