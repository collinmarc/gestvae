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
        public List<LivretVMBase> lstLivretsActif { get { return lstLivrets.Where(c => !c.IsDeleted).ToList(); } }
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
                        CurrentLivret.IsLocked = IsLocked;
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

        }
        public void LoadDetails()
        {
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

            DeleteLivretCommand = new RelayCommand<CandidatVM>(c => { DeleteCurrentLivret(); },
                                                                c => { return IsDeletePossible; });
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
        public Sexe? Sexe
        {
            get { return TheCandidat.Sexe; }
            set { TheCandidat.Sexe = value;
                if (Sexe.HasValue  && Sexe== GestVAEcls.Sexe.H)
                {
                    Civilite = "Monsieur";
                }
                if (Sexe.HasValue && Sexe == GestVAEcls.Sexe.F)
                {
                    Civilite = "Madame";
                }
                RaisePropertyChanged();
            }
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
        public String PaysNaissance
        {
            get { return TheCandidat.PaysNaissance; }
            set { TheCandidat.PaysNaissance = value; RaisePropertyChanged(); }
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

        public String TypeDemande {
            get {
                return TheCandidat.TypeDemande;
            } set
            {
                if (value != TypeDemande)
                {
                    TheCandidat.TypeDemande = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DiplomeCandVM AjoutDiplomeCand()
        {
            DiplomeCand oDiplCand = TheCandidat.AddDiplome(pStatut:"");
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
            RaisePropertyChanged("lstLivretsActif");
            RaisePropertyChanged("IsL1Valide");
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
                if (item.IsDeleted)
                {
                    if (!item.IsNew)
                    {
                        //Suppression Manuelle des Jurys
                        while (item.TheLivret.lstJurys.Count > 0)
                        {
                            Jury oJ = item.TheLivret.lstJurys[0];
                            _ctx.Juries.Remove(oJ);
                        }
                        // Suppression des enregistrements de Livrets
                        if (item.Typestr == Livret1.TYPELIVRET)
                        {
                            _ctx.Livret1.Remove((Livret1)item.TheLivret);
                        }
                        if (item.Typestr == Livret2.TYPELIVRET)
                        {
                            _ctx.Livret2.Remove((Livret2)item.TheLivret);
                        }
                    }
                    item.IsDeleted = false;
                    item.IsNew = false;
                }
                else
                {

                    if (item is Livret1VM)
                    {
                            if (item.IsNew)
                            {
                                TheCandidat.lstLivrets1.Add((Livret1)item.TheLivret);
                                item.IsNew = false;
                            }
                    }
                    if (item is Livret2VM)
                    {
                        if (item.IsNew)
                        {
                            TheCandidat.lstLivrets2.Add((Livret2)item.TheLivret);
                            item.IsNew = false;
                        }
                    }

                    item.Commit();
                }

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
            RaisePropertyChanged("lstLivretsActif");
            SetModelHasChanges();
            //            oLiv.ClearDCs();
            //            if (!oLiv.IsNew)
            //            {
            //                foreach (JuryVM oJ in oLiv.lstJuryVM)
            //                {
            //                    _ctx.Juries.Remove((Jury)oJ.TheItem);
            //                    //oLiv.TheLivret.lstJurys.Remove(((Jury)oJ.TheItem));

            //                }
            //                if (oLiv is Livret1VM)
            //                {
            //                    TheCandidat.lstLivrets1.Remove((Livret1)oLiv.TheLivret);

            //                }
            //                else
            //                {
            //                    while (((Livret2VM)oLiv).lstDCLivret.Count>0)
            //                    {
            //                        ((Livret2VM)oLiv).lstDCLivret.RemoveAt(0);
            //                    }
            //                    TheCandidat.lstLivrets2.Remove((Livret2)oLiv.TheLivret);

            //                }
            ////                _ctx.Entry<Livret>((Livret)oLiv.TheLivret).State = System.Data.Entity.EntityState.Deleted;

            //            }
            //            else
            //            {
            //                if (oLiv is Livret1VM)
            //                {
            //                    TheCandidat.lstLivrets1.Remove((Livret1)oLiv.TheLivret);
            //                    oLiv.getEntity().State = System.Data.Entity.EntityState.Deleted;

            //                }
            //                else
            //                {
            //                    //TheCandidat.lstLivrets2.Remove((Livret2)oLiv.TheLivret);
            //                    _ctx.Livret2.Remove((Livret2)oLiv.TheLivret);
            //                    oLiv.getEntity().State = System.Data.Entity.EntityState.Deleted;
            //                }
            //                // Detache l'entity
            //                //_ctx.Entry<Livret>((Livret)oLiv.TheLivret).State = System.Data.Entity.EntityState.Detached;
            //            }

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
        public  override Boolean IsLocked
        {
            get
            {
                ContextLock ctxLock = new ContextLock();
                int nLock = ctxLock.Locks.Where(L => L.IDCandidat == ID).Count();
                return (nLock > 0);
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
                foreach (Livret1VM oLiv in getListLivret1())
                {
                        if (oLiv.IsEncours())
                        {
                            bReturn = true;
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
                return (getL1Valide() != null);
            }
        }
        /// <summary>
        /// Rend le Premier L1 Valide Valide (ou Null S'il n'y en a pas)
        /// </summary>
        /// <returns></returns>
        public Livret1VM getL1Valide()
        {
            Livret1VM oReturn = null;
            oReturn = (from oLiv in getListLivret1()
                       where oLiv.IsValide(this)
                       select oLiv).FirstOrDefault<Livret1VM>();
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
                foreach (Livret2VM oL2 in getListLivret2())
                {
                        // Si le L2 est clos => non Valide
                        if (oL2.IsLivretEnCours)
                        {
                            bReturn = true;
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
        /// <summary>
        /// Ajout de L2 possible ?
        /// L1 Valide et pas de L2 en cours
        /// </summary>
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
                return bReturn;
            }
        }

        /// <summary>
        /// retourne la Liste des Livret2VM
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<Livret2VM> getListLivret2()
        {
            ReadOnlyCollection<Livret2VM> oReturn;

            oReturn  = (from oLiv in lstLivretsActif
                    where oLiv is Livret2VM 
                    select (Livret2VM)oLiv).ToList<Livret2VM>().AsReadOnly();

            return oReturn;
        }
        /// <summary>
        /// Retourne la Liste des Livret1VM
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<Livret1VM> getListLivret1()
        {
            ReadOnlyCollection<Livret1VM> oReturn;

            oReturn = (from oLiv in lstLivretsActif
                       where oLiv is Livret1VM 
                       select (Livret1VM)oLiv).ToList<Livret1VM>().AsReadOnly();

            return oReturn;
        }
        private bool _modelhasChanges = false;
        public void SetModelHasChanges(bool pvalue = true)
        {
            _modelhasChanges = pvalue;
        }

        public override bool HasChanges()
        {
            Boolean bReturn = false;
            bReturn = base.HasChanges();
            bReturn = bReturn || _modelhasChanges;
            return bReturn;
        }
    }
}
