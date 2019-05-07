using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
        public DiplomeCandVM CurrentDiplomeCand { get; set; }

        public DiplomeCandVM getDiplomeCand(Livret2VM pL2)
        {
            return lstDiplomesCandVMs.Where(d => d.oDiplome.ID == pL2.TheLivret.oDiplome.ID).FirstOrDefault();
        }


        private LivretVMBase _LivretVM;
        public LivretVMBase CurrentLivret
        {
            get { return _LivretVM; }
            set
            {
                if (value != CurrentLivret)
                {
                    _LivretVM = value;
                    if (CurrentLivret != null)
                    {
                        CurrentLivret.IsCandidatLocked = IsLocked;
                    }
                }
            }
        }

        public CandidatVM(Candidat pCandidat):base(pCandidat)
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

            DeleteLivretCommand = new RelayCommand<CandidatVM>(c => { DeleteCurrentLivret(); },
                                                                c=> { return IsDeletePossible; });


        }
        public CandidatVM():base()
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

        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Candidat> entry = _ctx.Entry<Candidat>(TheCandidat);
            return entry;
        }

        public String Civilite
        {
            get { return TheCandidat.Civilite; }
            set { TheCandidat.Civilite = value; RaisePropertyChanged(); }
        }
        public String Nom
        {
            get { return TheCandidat.Nom; }
            set { TheCandidat.Nom = value; RaisePropertyChanged(); }
        }

        public String Prenom
        {
            get { return TheCandidat.Prenom; }
            set { TheCandidat.Prenom = value; RaisePropertyChanged(); }
        }

        public String Ville
        {
            get { return TheCandidat.Ville; }
            set { TheCandidat.Ville = value; RaisePropertyChanged(); }
        }
        public String IdSiscole
        {
            get { return TheCandidat.IdSiscole; }
            set { TheCandidat.IdSiscole = value; RaisePropertyChanged(); }
        }
        public String IdVAE
        {
            get { return TheCandidat.IdVAE; }
            set { TheCandidat.IdVAE = value; RaisePropertyChanged(); }
        }
        public DateTime? DateNaissance
        {
            get { return TheCandidat.DateNaissance; }
            set { TheCandidat.DateNaissance = value; RaisePropertyChanged(); }
        }
        public Boolean bHandicap
        {
            get { return TheCandidat.bHandicap; }
            set { TheCandidat.bHandicap = value; RaisePropertyChanged(); }
        }
        public String Nationnalite
        {
            get { return TheCandidat.Nationalite; }
            set { TheCandidat.Nationalite = value; RaisePropertyChanged(); }
        }

        public String NationnaliteNaissance
        {
            get { return TheCandidat.NationaliteNaissance; }
            set { TheCandidat.NationaliteNaissance = value; RaisePropertyChanged(); }
        }
        public String DptNaissance
        {
            get { return TheCandidat.DptNaissance; }
            set { TheCandidat.DptNaissance = value; RaisePropertyChanged(); }
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
            RaisePropertyChanged("IsL1Valide");
        }
        public void AjouLivret1(Livret1VM pLivret)
        {
            DbEntityEntry oEntity = _ctx.Entry(pLivret.TheLivret);
            if (oEntity.State == System.Data.Entity.EntityState.Detached)
            {

                TheCandidat.lstLivrets1.Add((Livret1)pLivret.TheLivret);
                lstLivrets.Add(pLivret);
                refreshlstLivrets();
            }
        }
 
        public void AjoutLivret2(Livret2VM pLivret)
        {
           DbEntityEntry oEntity = _ctx.Entry(pLivret.TheLivret);
            if (oEntity.State == System.Data.Entity.EntityState.Detached)
            {
                TheCandidat.lstLivrets2.Add((Livret2)pLivret.TheLivret);
                lstLivrets.Add(pLivret);
                refreshlstLivrets();
            }

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
                if (item.Typestr == Livret1.TYPELIVRET)
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
                if (item.Typestr == Livret2.TYPELIVRET)
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

        public Boolean IsDeletePossible
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentLivret != null)
                {
                    if (IsLocked)
                    {
                        if (CurrentLivret is Livret1VM)
                        {
                            bReturn = true;
                            // C'est impossible si on n'a 1 Livret2
                            foreach (LivretVMBase oLiv in lstLivrets)
                            {
                                if (oLiv is Livret2VM)
                                {
                                    bReturn = false;
                                }
                            }
                        }
                        if (CurrentLivret is Livret2VM)
                        {
                            // C'est impossible si Le Livret n'est pas Clos
                            bReturn = CurrentLivret.IsLivretClos;
                        }
                    }
                }

                return bReturn;
            }
        }

        /// <summary>
        /// Suppression du Livert Courant
        /// </summary>
        public void DeleteCurrentLivret()
        {
            Debug.Assert(CurrentLivret != null);

            LivretVMBase oLiv = CurrentLivret;
            oLiv.IsDeleted = true;
            lstLivrets.Remove(oLiv);
            RaisePropertyChanged("lstLivrets");
            oLiv.ClearDCs();
            if (!oLiv.IsNew)
            {
                foreach (JuryVM oJ in oLiv.lstJuryVM)
                {
                    oLiv.TheLivret.lstJurys.Remove(((Jury)oJ.TheItem));

                }

                if (oLiv is Livret1VM)
                {
                    TheCandidat.lstLivrets1.Remove((Livret1)oLiv.TheLivret);

                }
                else
                {
                    TheCandidat.lstLivrets2.Remove((Livret2)oLiv.TheLivret);

                }
                _ctx.Entry<Livret>((Livret)oLiv.TheLivret).State = System.Data.Entity.EntityState.Deleted;

            }
            else
            {
                // Detache l'entity
                _ctx.Entry<Livret>((Livret)oLiv.TheLivret).State = System.Data.Entity.EntityState.Detached;
            }

        }//        public void DeleteLivret()

        internal Boolean Lock(Int32 pIDUser)
        {
            ContextLock ctxLock = new ContextLock();
            ctxLock.Locks.Add(new LockCandidat(pIDUser,ID));
            ctxLock.SaveChanges();
            RaisePropertyChanged("IsLocked");
            RaisePropertyChanged("IsUnlocked");
            return true;
        }
        public Boolean IsLocked
        {
            get
            {
                ContextLock ctxLock = new ContextLock();
                int nLock = ctxLock.Locks.Where(L => L.IDCandidat == ID).Count();
                return (nLock > 0);
            }
        }
        public Boolean IsUnlocked
        {
            get
            {
                return !IsLocked;
            }
        }
        internal Boolean UnLock(Int32 pIDUser)
        {
            ContextLock ctxLock = new ContextLock();
            ctxLock.Locks.RemoveRange(ctxLock.Locks.Where(L => L.IDCandidat == ID && L.IDUser == pIDUser));
            ctxLock.SaveChanges();
            RaisePropertyChanged("IsLocked");
            RaisePropertyChanged("IsUnlocked");
            return true;
        }
        /// <summary>
        /// Rend Vrai s'il y a un Livret1 En cours (DateValidite>Now)
        /// </summary>
        public Boolean IsL1Encours
        {
            get
            {
                Boolean bReturn = false;
                foreach (LivretVMBase oLiv in lstLivrets)
                {
                    if (oLiv is Livret1VM)
                    {
                        if (((Livret1VM)oLiv).IsEncours())
                        {
                            bReturn = true;
                        }
                    }
                }

                return bReturn;

            }
        }
        /// <summary>
        /// Rend Vrai s'il y a un Livret1 de valide
        /// </summary>
        public Boolean IsL1Valide
        {
            get
            {
                Boolean bReturn = false;
                foreach (LivretVMBase oLiv in lstLivrets)
                {
                    if (oLiv is Livret1VM)
                    {
                        if (((Livret1VM)oLiv).IsValide())
                        {
                                bReturn = true;
                        }
                    }
                }

                return bReturn;

            }
        }
        public Livret1VM getL1Valide()
        {
            Livret1VM oReturn = null;
            foreach (LivretVMBase oLiv in lstLivrets)
            {
                if (oLiv is Livret1VM)
                {
                    if (((Livret1VM)oLiv).IsValide())
                    {
                        oReturn = (Livret1VM)oLiv;
                    }
                }
            }


            return oReturn;
        }
        /// <summary>
        /// Rend Vrai si on a un L2 EnCours de traitement dans la date de validité n'est pas échue
        /// </summary>
        public Boolean ISL2EnCours
        {
            get
            {
                Boolean bReturn = false;
                foreach (LivretVMBase oLiv in lstLivrets)
                {
                    if (oLiv is Livret2VM)
                    {
                        Livret2VM oL2 = (Livret2VM)oLiv;
                        // Si le L2 est clos => non Valide
                        if (oL2.IsLivretEnCours)
                        {
                            bReturn = true;
                        }
                    }
                }

                return bReturn;

            }
        }
        /// <summary>
        /// Rend Vrai si le candidat a au moins 1 Livret2 en Décision partielle
        /// </summary>
        public Boolean ISL2EnValidationPartielle
        {
            get
            {
                Boolean bReturn = false;
                foreach (LivretVMBase oLiv in lstLivrets)
                {
                    if (oLiv is Livret2VM)
                    {
                        Livret2VM oL2 = (Livret2VM)oLiv;
                        if (oL2.IsDecisionJuryPartielle )
                        {
                            bReturn = true;
                        }
                    }
                }

                return bReturn;

            }
        }

        public Boolean IsAddL2Available
        {
            get
                {
                Boolean bReturn = false;
                // L'ajout d'un L2 est possible s'il y  a un L1 de Valide ET qu'il n'y a  pas un autre L2 Valide
                if (IsL1Valide && !ISL2EnCours)
                {
                    bReturn = true;
                }
                // OU SI s'il a un L2 En validation partielle
                if (ISL2EnValidationPartielle)
                {
                    bReturn = true;
                }
                return bReturn;
            }
        }

    }
}
