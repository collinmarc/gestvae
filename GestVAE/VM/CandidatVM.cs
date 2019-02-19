using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestVAE.VM
{
    public class CandidatVM:VMBase
    {

        const String cstDEIS = "DEIS";
        const String cstCAFERUIS = "CAFERUIS";
        const String cstCAFDES = "CAFDES";
        public Candidat TheCandidat { get; set; }
        public ObservableCollection<DiplomeCandVM> lstDiplomesCandVMs { get; set; }
        public ObservableCollection<LivretVMBase> lstLivrets { get; set; }

        private LivretVMBase _LivretVM;
        public LivretVMBase CurrentLivret
        {
            get { return _LivretVM; }
            set { _LivretVM = value; RaisePropertyChanged(); }
        }

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

            DeleteLivretCommand = new RelayCommand<MyViewModel>(o => { DeleteLivret(); });



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


        public String Civivilte
        {
            get { return TheCandidat.Civilite; }
            set { TheCandidat.Civilite = value; RaisePropertyChanged(); }
        }

        private DiplomeCandVM diplomeCAFDESCandidat
        {
            get
            {
                return (from oDiplomeCand in lstDiplomesCandVMs
                        where oDiplomeCand.oDiplome.Nom == cstCAFDES
                        select oDiplomeCand).FirstOrDefault<DiplomeCandVM>();
            }
        }
        private DiplomeCandVM diplomeDEISCandidat
        {
            get
            {
                return (from oDiplomeCand in lstDiplomesCandVMs
                        where oDiplomeCand.oDiplome.Nom == cstDEIS
                        select oDiplomeCand).FirstOrDefault<DiplomeCandVM>();
            }
        }
        private DiplomeCandVM diplomeCAFERUISCandidat
        {
            get
            {
                return (from oDiplomeCand in lstDiplomesCandVMs
                        where oDiplomeCand.oDiplome.Nom == cstCAFERUIS
                        select oDiplomeCand).FirstOrDefault<DiplomeCandVM>();
            }
        }
        public Boolean IsDEIS
        {
            get
            {
                return (diplomeDEISCandidat != null);
            }
            set
            {
                if (value != IsDEIS)
                {
                    if (value)
                    {
                        Diplome oDiplome = (from o in _ctx.Diplomes where o.Nom == cstDEIS select o).FirstOrDefault<Diplome>();
                        DiplomeCandVM oDip = AjoutDiplomeCand(oDiplome);
                    }
                    else
                    {
                        DiplomeCandVM oDip = diplomeDEISCandidat;
                        _ctx.DiplomeCands.Remove(oDip.TheDiplomeCand);
//                        diplomeDEISCandidat.TheDiplomeCand.bDeleted = true;
                        lstDiplomesCandVMs.Remove(oDip);
                        
                    }
                }
            }
        }
        public DateTime? DateObtentionDEIS
        {
            get
            {
                if (diplomeDEISCandidat != null)
                { return diplomeDEISCandidat.DateObtentionDiplome; }
                else

                { return null; }
            }
            set
            {
                if (value != DateObtentionDEIS)
                {
                    diplomeDEISCandidat.DateObtentionDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NumeroDEIS
        {
            get
            {
                if (diplomeDEISCandidat != null)
                { return diplomeDEISCandidat.NumeroDiplome; }
                else

                { return ""; }
            }
            set
            {
                if (value != NumeroDEIS)
                {
                    diplomeDEISCandidat.NumeroDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsCAFERUIS
        {
            get
            {
                return (diplomeCAFERUISCandidat != null);
            }
            set
            {
                if (value != IsCAFERUIS)
                {
                    if (value)
                    {

                        Diplome oDiplome = (from o in _ctx.Diplomes where o.Nom == cstCAFERUIS select o).FirstOrDefault<Diplome>();
                        DiplomeCandVM oDip = AjoutDiplomeCand(oDiplome);
                    }
                    else
                    {
                        DiplomeCandVM oDip = diplomeCAFERUISCandidat;
                        _ctx.DiplomeCands.Remove(oDip.TheDiplomeCand);
                        //                        diplomeDEISCandidat.TheDiplomeCand.bDeleted = true;
                        lstDiplomesCandVMs.Remove(oDip);
                    }
                }
            }
        }
        public DateTime? DateObtentionCAFERUIS
        {
            get
            {
                if (diplomeCAFERUISCandidat != null)
                { return diplomeCAFERUISCandidat.DateObtentionDiplome; }
                else

                { return null; }
            }
            set
            {
                if (value != DateObtentionCAFERUIS)
                {
                    diplomeCAFERUISCandidat.DateObtentionDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NumeroCAFERUIS
        {
            get
            {
                if (diplomeCAFERUISCandidat != null)
                { return diplomeCAFERUISCandidat.NumeroDiplome; }
                else

                { return ""; }
            }
            set
            {
                if (value != NumeroCAFERUIS)
                {
                    diplomeCAFERUISCandidat.NumeroDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsCAFDES
        {
            get
            {
                return (diplomeCAFDESCandidat != null);
            }
            set
            {
                if (value != IsCAFDES)
                {
                    if (value)
                    {
                         Diplome oDiplome = (from o in _ctx.Diplomes where o.Nom == cstCAFDES select o).FirstOrDefault<Diplome>();
                        DiplomeCandVM oDip = AjoutDiplomeCand(oDiplome);
                    }
                    else
                    {
                        DiplomeCandVM oDip = diplomeCAFDESCandidat;
                        _ctx.DiplomeCands.Remove(oDip.TheDiplomeCand);
                        //                        diplomeDEISCandidat.TheDiplomeCand.bDeleted = true;
                        lstDiplomesCandVMs.Remove(oDip);
                    }
                }
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

        public DiplomeCandVM AjoutDiplomeCand(Diplome pDiplome)
        {
            DiplomeCand oDiplCand = TheCandidat.AddDiplome(pDiplome);
            DiplomeCandVM oDiplomeCand = new DiplomeCandVM(oDiplCand);
            lstDiplomesCandVMs.Add(oDiplomeCand);
            RaisePropertyChanged("lstDiplomesCandVMs");
            return oDiplomeCand;
        }

  
        public void refreshlstLivrets()
        {
            RaisePropertyChanged("lstLivrets");
        }
        public void AjoutCurrentLivret1(Livret1VM pLivret)
        {
            
            TheCandidat.lstLivrets1.Add((Livret1)pLivret.TheLivret);
            lstLivrets.Add(pLivret);
            refreshlstLivrets();
        }
 
        public Livret2VM AjoutLivret2()
        {
            Diplome oDiplome = Diplome.getDiplomeParDefaut();
            Livret2 oLiv = new Livret2(oDiplome);
            TheCandidat.lstLivrets2.Add(oLiv);
            Livret2VM oLiv2VM = new Livret2VM(oLiv);
            oLiv2VM.DateDemande = DateTime.Now;
            oLiv2VM.Numero = Convert.ToString(TheCandidat.lstLivrets2.Count() + 1);
            // Récupération du diplome du candidat (si présent)
            DiplomeCand oDiplomeCandidat =  TheCandidat.lstDiplomes.Where(d => d.oDiplome.ID == oDiplome.ID).FirstOrDefault();
            if (oDiplomeCandidat != null)
            {
                oLiv.InitDCLivrets(oDiplomeCandidat);
            }

            lstLivrets.Add(oLiv2VM);
            refreshlstLivrets();
            return oLiv2VM;
        }
        public Livret2VM AjoutLivret2(Diplome pDiplome)
        {
            Livret2 oLiv = new Livret2(pDiplome);
            oLiv.EtatLivret = "0-Demandé";
            oLiv.DateDemande = DateTime.Now;
            oLiv.Numero = Convert.ToString(TheCandidat.lstLivrets2.Count() + 1);
            TheCandidat.lstLivrets2.Add(oLiv);
            Livret2VM oLiv2VM = new Livret2VM(oLiv);
            lstLivrets.Add(oLiv2VM);
            refreshlstLivrets();
            return oLiv2VM;
        }

        public void Commit()
        {
            foreach (DiplomeCandVM item in lstDiplomesCandVMs)
            {
                item.Commit();
            }
            if (_ctx.Entry<Candidat>(TheCandidat).State == System.Data.Entity.EntityState.Detached)
            {
                _ctx.Candidats.Add(TheCandidat);
            }
            if (_ctx.Entry<Candidat>(TheCandidat).State == System.Data.Entity.EntityState.Deleted)
            {
                _ctx.Candidats.Remove(TheCandidat);
            }
            foreach (LivretVMBase item in lstLivrets)
            {
                if (item.Typestr == "LIVRET1")
                {
                    if (_ctx.Entry<Livret1>((Livret1)item.TheLivret).State == System.Data.Entity.EntityState.Detached)
                    {
                        TheCandidat.lstLivrets1.Add((Livret1)item.TheLivret);
                    }
                    if (_ctx.Entry<Livret1>((Livret1)item.TheLivret).State == System.Data.Entity.EntityState.Deleted)
                    {
                        TheCandidat.lstLivrets1.Remove((Livret1)item.TheLivret);
                    }
                }
                if (item.Typestr == "LIVRET2")
                {
                    if (_ctx.Entry<Livret2>((Livret2)item.TheLivret).State == System.Data.Entity.EntityState.Detached)
                    {
                        TheCandidat.lstLivrets2.Add((Livret2)item.TheLivret);
                    }
                    if (_ctx.Entry<Livret2>((Livret2)item.TheLivret).State == System.Data.Entity.EntityState.Deleted)
                    {
                        TheCandidat.lstLivrets2.Remove((Livret2)item.TheLivret);
                    }
                }

                item.Commit();
            }
        }

         public ICommand DeleteLivretCommand { get; set; }
                                        

        /// <summary>
        /// Suppression du Livert Courant
        /// </summary>
        public void DeleteLivret()
        {

            LivretVMBase pLiv = CurrentLivret;
            if (pLiv.Typestr == "LIVRET1")
            {
                // Set to be Deleted
                _ctx.Entry<Livret1>((Livret1)pLiv.TheLivret).State = System.Data.Entity.EntityState.Deleted;
            }
            if (pLiv.Typestr == "LIVRET2")
            {
                // Set to be Deleted
                _ctx.Entry<Livret2>((Livret2)pLiv.TheLivret).State = System.Data.Entity.EntityState.Deleted;
            }
            lstLivrets.Remove(pLiv);
            RaisePropertyChanged("lstLivrets");

        }//        public void DeleteLivret()


    }
}
