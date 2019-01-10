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
        public ObservableCollection<LivretVM> lstLivrets { get; set; }
        public CandidatVM(Candidat pCandidat)
        {
            TheCandidat = pCandidat;
            lstDiplomesCandVMs = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVM>();
            foreach (DiplomeCand item in pCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                lstDiplomesCandVMs.Add(oDipCand);
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
            lstDiplomesCandVMs = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVM>();
            foreach (DiplomeCand item in TheCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                lstDiplomesCandVMs.Add(oDipCand);
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

        public DiplomeCandVM AjoutDiplomeCand()
        {
            DiplomeCand oDiplCand = TheCandidat.AddDiplome();
            DiplomeCandVM oDiplomeCand = new DiplomeCandVM(oDiplCand);
            lstDiplomesCandVMs.Add(oDiplomeCand);
            RaisePropertyChanged("lstDiplomesCandVMs");
            return oDiplomeCand;
        }

        //public Diplome getDiplomeParDefaut()
        //{
        //    Diplome oDiplome;
        //    //Context ctx = Context.instance;
        //    oDiplome = (from obj in _ctx.Diplomes
        //                where obj.bDeleted == false &&
        //                       obj.Nom == Properties.Settings.Default.NomDiplomeDefaut
        //                select obj).FirstOrDefault<Diplome>();
        //    //Chargement de la liste des domanes de compétences
        //    oDiplome.lstDomainesCompetences.ToList();
        //    return oDiplome;

        //}
    }
}
