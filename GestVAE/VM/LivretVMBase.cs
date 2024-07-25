using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GestVAE.VM
{
    public abstract class LivretVMBase:VMBase
    {
        public Livret TheLivret {
            get
            {
                return (Livret)TheItem;
            }
        }


        public Boolean  IsL1
        {
            get { return TheLivret.Typestr == Livret1.TYPELIVRET; }
        }
        public Boolean IsL2
        {
            get { return TheLivret.Typestr == Livret2.TYPELIVRET; }
        }



        public ObservableCollection<DCLivretVM> lstDCLivret { get; set; }
        public DCLivretVM selectedDCLivret { get; set;}
                       public ObservableCollection<JuryVM> lstJuryVM;
        public ObservableCollection<PieceJointeLivretVM> lstPieceJointe { get; set; }
        public List<PieceJointeLivretVM> lstPieceJointeActif { get { return lstPieceJointe.Where(pj => !pj.IsDeleted).ToList(); } }
        public PieceJointeLivretVM selectedPJ { get; set; }
        private MembreJuryVM _selectedMembreJ; 
        public MembreJuryVM SelectedMembreJ
        {
            get
            {
                return _selectedMembreJ;
            }
            set
            {
                _selectedMembreJ = value;
            }
        }

        public LivretVMBase(Livret pLivret):base(pLivret)
        {
            lstDCLivret = new ObservableCollection<DCLivretVM>();
            lstPieceJointe = new ObservableCollection<PieceJointeLivretVM>();
            SetLstJuryVM();
            isAdded = false;
            foreach (DCLivret oDCL in pLivret.lstDCLivrets)
            {
                lstDCLivret.Add(new DCLivretVM(oDCL));
            }

        }
        private void SetLstJuryVM()
        {
            lstJuryVM = new ObservableCollection<JuryVM>();
            foreach (Jury item in TheLivret.lstJurys)
            {
                JuryVM oJuryVM = new JuryVM(item);
                lstJuryVM.Add(oJuryVM);
            }

        }

        public LivretVMBase(Boolean pIsLocked):base()
        {
            IsLocked = pIsLocked;
            lstDCLivret = new ObservableCollection<DCLivretVM>();
            lstPieceJointe = new ObservableCollection<PieceJointeLivretVM>();
            lstJuryVM = new ObservableCollection<JuryVM>();
            create1erJury();
        }


        public JuryVM Jury1er
        {
            get { if (lstJuryVM.Count == 0)
                    {
                        create1erJury();
                    }
                 return lstJuryVM[0]; }
        }

        public abstract String Numero { get; set; }
        public String NomDiplome
        {
            get
            {
                return TheLivret.oDiplome.Nom;
            }
            set
            {
                //if (value != NomDiplome)
                //{
                //    TheLivret.oDiplome.Nom = value;
                //    RaisePropertyChanged();
                //}
            }
        }

        public String Typestr
        {
            get
            {
                return TheLivret.Typestr;
            }
        }

        public DateTime? DateValidite
        {
            get
            {
                if (this is Livret1VM)
                {
                    return ((Livret1)TheLivret).DateValidite;
                }
                else
                {
                    return ((Livret2)TheLivret).DateValidite;

                }
            }
            set
            {
                if (this is Livret1VM)
                {
                    ((Livret1)TheLivret).DateValidite = value;
                }
                else
                {
                    ((Livret2)TheLivret).DateValidite = value;
                }
                RaisePropertyChanged();
                RaisePropertyChanged("DateValiditeBase");
                RaisePropertyChanged("IsTolere");
                RaisePropertyChanged("IsL1Tolere");

            }
        }
        public abstract void CalcDateValidite();
        public DateTime? DateValiditeBase
        {
            get
            {
                if (this is Livret1VM)
                {
                    if (IsEtatAccepte)
                    {
                        return ((Livret1)TheLivret).DateValidite;
                    }
                    else { return null; }
                }
                else
                {
                    return null; 

                }
            }
        }
        public virtual void Commit() {
            foreach (JuryVM item in lstJuryVM)
            {
                Jury obj = (Jury)item.TheItem;
                if (item.IsNew)
                {
                    TheLivret.lstJurys.Add(obj);
                    item.IsNew = false;
                }
                item.Commit();
            }


        }
        public void AjoutePJ(String pstrLivret)
        {
            if (CategoriePJ!= null)
            {
                // Récupération de la catégorie
                String strCat = CategoriePJ.Categorie;
                PieceJointeLivretVM opjVM = new PieceJointeLivretVM(pstrLivret);
                opjVM.Categorie = strCat;
                // Récupération du libellé
                if (LibellePJ != null)
                {
                    opjVM.Libelle = LibellePJ.Libelle;
                }
                else
                {
                    opjVM.Libelle = CategoriePJ.lstPJItems[0].Libelle;
                }
                // Ajout dans la collection
                lstPieceJointe.Add(opjVM);
                CategoriePJ = null;
                LibellePJ = null;
                RaisePropertyChanged("lstPieceJointe");
                RaisePropertyChanged("lstPieceJointeActif");
            }
        }
         
        public List<String> LstEtatLivret { get; set; }

        public abstract void ClearDCs();
        protected JuryVM oJury
        {
            get
            {
                if (lstJuryVM.Count == 0)
                {
                    create1erJury();
                }
                return lstJuryVM[0];
            }
        }

        private void create1erJury()
        {
            lstJuryVM.Add(new JuryVM());
        }
        public String LieuJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.LieuJury;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != LieuJury)
                {
                    oJury.LieuJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public virtual DateTime? DateJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.DateJury;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateJury)
                {
                    oJury.DateJury = value;
                    RaisePropertyChanged();
                    if (DateJury == null)
                    {
                        IsRecoursDemande = false;
                    }
                }
            }
        }
        public virtual DateTime? DateNotificationJury
        { get; set; }
        public DateTime? DateNotificationJuryRecours
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.DateNotificationJuryRecours;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateNotificationJuryRecours)
                {

                    oJury.DateNotificationJuryRecours = value;

                    RaisePropertyChanged();
                    CalcDateValidite();
                }
                //if (value != null)
                //{
                //    DateValidite = value.Value.AddYears(Properties.Settings.Default.DelaiValidite);
                //}

            }
        }
        public DateTime? HeureJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.HeureJury;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != HeureJury)
                {

                    oJury.HeureJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? HeureConvoc
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.HeureConvoc;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != HeureConvoc)
                {

                    oJury.HeureConvoc = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateLimiteRecours
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.DateLimiteRecours;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateLimiteRecours)
                {

                    oJury.DateLimiteRecours = value;

                    RaisePropertyChanged();
                }
            }
        }







        public String DecisionJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.Decision;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != DecisionJury)
                {

                    oJury.Decision = value;


                    if (!IsEtatRefuse)
                    {
                        MotifDetailJury = "";
                        MotifGeneralJury = "";
                        IsRecoursDemande = false;
                    }
                    setEtatLivret();
                    // Passage de tous les items à Favorable
                    foreach (DCLivretVM item in lstDCLivretAValider)
                    {
                        if (IsDecisionJuryFavorable)
                        {
                            item.IsDecisionFavorable = true;
                        }
                        if (IsDecisionJuryDefavorable)
                        {
                            item.IsDecisionDefavorable = true;
                        }
                    }
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsDecisionJuryFavorable");
                    RaisePropertyChanged("IsDecisionJuryDefavorable");
                    RaisePropertyChanged("IsDecisionJuryPartielle");
                }
            }
        }

        public void calcDecisionJury()
        {
            int nDCFavorable = lstDCLivretAValider.Count(x => x.IsDecisionFavorable.HasValue && x.IsDecisionFavorable.Value);
            int nDCdeFavorable = lstDCLivretAValider.Count(x => x.IsDecisionDefavorable.HasValue && x.IsDecisionDefavorable.Value);
            int nDCsansDecision = lstDCLivretAValider.Count(x => !x.IsDecisionDefavorable.HasValue);
            if (nDCsansDecision > 0)
            {
                DecisionJury = "";
            }
            else
            {
                // Les enums de L1 et L2 sont les mêmes (ouf!!!)
                if (nDCFavorable > 0 && nDCdeFavorable == 0)
                {
                    DecisionJury = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);
                }
                if (nDCFavorable == 0 && nDCdeFavorable > 0)
                {
                    DecisionJury = String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
                }
                if (nDCFavorable > 0 && nDCdeFavorable > 0)
                {
                    DecisionJury = String.Format("{0:D}-Partielle", MyEnums.DecisionJuryL1.DECISION_L1_PARTIELLE);
                }
            }

        }

        public Boolean IsDecisionJuryPartielle
        {
            get
            {
                return ((getNumDecisionJury() >= (int)MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE));
            }
        }

        public virtual String EtatLivret
        {
            get
            {
                try
                {
                    return TheLivret.EtatLivret;

                }
                catch (Exception)
                {

                    return "";

                }
            }
            set
            {
                if (value != EtatLivret)
                {
                    TheLivret.EtatLivret = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsEtatEnvoye");
                    RaisePropertyChanged("IsEtatRecu");
                    RaisePropertyChanged("IsEtatRecuComplet");
                    RaisePropertyChanged("IsEtatRecuIncomplet");
                    RaisePropertyChanged("IsEtatRefuse");
                    RaisePropertyChanged("IsEtatRecours");
                    RaisePropertyChanged("IsEtatAccepte");
                    RaisePropertyChanged("IsEtatFerme");
                    RaisePropertyChanged("IsEtatIrrecevable");
                    if (!IsEtatRecuComplet)
                    {
                        DateJury = null;
                        LieuJury = "";
                        HeureConvoc = null;
                        HeureJury = null;
                        DecisionJury = "";
                    }
                    if (IsEtatIrrecevable)
                    {
                        // Motif Irrecevabilité
                        Jury1er.MotifCommentaire = _ctxParam.dbParam.First<Param>().MotifIrrecevabilite;
                        RaisePropertyChanged("MotifIrrecevabilité");
                    }
                }
            }
        }
        public Boolean IsLivretNonModifiable
        {
            get { if (!IsLocked)
                {
                    return true;
                }
                else
                {

                    return TheLivret.isClos;
                }
            }
        }
        public Boolean IsLivretModifiable
        {
            get { return !IsLivretNonModifiable; }
        }
        public Boolean IsLivretClos
        {
            get
            {

                    return TheLivret.isClos;
            }
            set
            {
                if (value != IsLivretClos)
                {
                    TheLivret.isClos = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsLivretNonClos");
                    RaisePropertyChanged("IsLivretModifiable");
                    RaisePropertyChanged("IsLivretNonModifiable");
                }
            }
        }
        public Boolean IsLivretNonClos
        {
            get { return !IsLivretClos; }
            set { IsLivretClos = !value; }
        }
        public Boolean IsContrat
        {
            get
            {
                return TheLivret.IsContrat;
            }

            set
            {
                if (value != IsContrat)
                {
                    TheLivret.IsContrat = value;
//                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsConvention
        {
            get { return TheLivret.IsConvention; }
            set
            {
                if (value != IsConvention)
                {
                    TheLivret.IsConvention = value;
//                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsNonRecu
        {
            get { return TheLivret.IsNonRecu; }
            set
            {
                if (value != IsNonRecu)
                {
                    TheLivret.IsNonRecu = value;
                    //RaisePropertyChanged();
                }
            }
        }
        public Boolean IsEnregistre
        {
            get { return TheLivret.IsEnregistre; }
            set
            {
                if (value != IsEnregistre)
                {
                    TheLivret.IsEnregistre = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsPaye
        {
            get { return TheLivret.IsPaye; }
            set
            {
                if (value != IsPaye)
                {
                    TheLivret.IsPaye = value;
                    RaisePropertyChanged();
                }
            }
        }


        private int getNumetat()
        {
            int nReturn = 0;
            try
            {
                nReturn = Convert.ToInt32(this.EtatLivret.Split('-')[0]);
            }
            catch (Exception)
            {
                nReturn = 0;
            }
            return nReturn;
        }
        private int getNumDecisionJury()
        {
            int nReturn = 0;
            try
            {
                nReturn = Convert.ToInt32(this.DecisionJury.Split('-')[0]);
            }
            catch (Exception)
            {
                nReturn = 0;
            }
            return nReturn;
        }
        private int getNumDecisionJuryRecours()
        {
            int nReturn = 0;
            try
            {
                nReturn = Convert.ToInt32(this.DecisionJuryRecours.Split('-')[0]);
            }
            catch (Exception)
            {
                nReturn = 0;
            }
            return nReturn;
        }


        public Boolean IsDecisionJuryFavorable
        {
            get
            {
                if (IsL1)
                {
                    return (getNumDecisionJury() != (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
                }
                else
                {
                    return (getNumDecisionJury() != (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);

                }

            }
        }
        public Boolean IsDecisionJuryDefavorable
        {
            get
            {
                if (IsL1)
                {
                    return (getNumDecisionJury() == (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
                }
                else
                {
                    return (getNumDecisionJury() == (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
                }
            }
        }
        public Boolean IsDecisionJuryRecoursFavorable
        {
            get
            {
                return (getNumDecisionJuryRecours() != (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            }
        }
        public Boolean IsDecisionJuryRecoursDefavorable
        {
            get
            {
                return (getNumDecisionJuryRecours() == (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            }
        }
        protected abstract  void setEtatLivret();
        public Boolean IsRecoursDemande
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.IsRecours;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (value != IsRecoursDemande)
                {
                    oJury.IsRecours = value;
                    if (IsRecoursDemande)
                    {
                        if (DateJury.HasValue)
                        {
                            //DateLimiteRecours = DateJury.Value.AddDays(Properties.Settings.Default.DelaiDepotRecours);
                            MotifRecours = MotifGeneralJury;
                        }
                    }
                    else
                    {
                        DateDepotRecours = null;
                        DateJuryRecours = null;
                        MotifGeneralJuryRecours = "";
                        MotifRecours = "";
                        MotifRecoursCommentaire = "";
                    }
                    RaisePropertyChanged();
                }
            }
        }
        public String MotifGeneralJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.MotifGeneral;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != MotifGeneralJury)
                {

                    oJury.MotifGeneral = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String MotifDetailJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.MotifDetail;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != MotifDetailJury)
                {

                    oJury.MotifDetail = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String CommentaireJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.MotifCommentaire;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != CommentaireJury)
                {

                    oJury.MotifCommentaire = value;

                    RaisePropertyChanged();
                }
            }
        }
        public EnumTypeRecours TypeRecours
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.oRecours.TypeRecours;
                }
                else
                {
                    return EnumTypeRecours.Gracieux;
                }
            }
            set
            {
                if (value != TypeRecours)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].TypeRecours = value;

                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? DateDepotRecours
        {
            get
            {
                return oJury.oRecours.DateDepot;
            }
            set
            {
                if (value != DateDepotRecours)
                {
                    oJury.oRecours.DateDepot = value;
                    if (DateDepotRecours.HasValue)
                    {
                        DateLimiteJuryRecours = DateDepotRecours.Value.AddMonths(1);
                    }

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateLimiteJuryRecours
        {
            get
            {
                if (oJury.oRecours != null)
                {
                    return oJury.oRecours.DateLimiteJury;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateLimiteJuryRecours)
                {

                    oJury.oRecours.DateLimiteJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String LieuJuryRecours
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.lstRecoursVM[0].LieuJury;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != LieuJury)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].LieuJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateJuryRecours
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.lstRecoursVM[0].DateJury;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateJuryRecours)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].DateJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String DecisionJuryRecours
        {
            get
            {
                return oJury.oRecours.Decision;
            }
            set
            {
                if (value != DecisionJuryRecours)
                {
                    oJury.oRecours.Decision = value;

                    setEtatLivret();
                    if (!IsEtatRefuse)
                    {
                        MotifDetailJuryRecours = "";
                        MotifGeneralJuryRecours = "";
                    }
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsDecisionJuryRecoursFavorable");
                    RaisePropertyChanged("IsDecisionJuryRecoursDefavorable");
                }
            }
        }
        public String MotifRecours
        {
            get
            {
                return oJury.oRecours.MotifRecours;
            }
            set
            {
                if (value != MotifRecours)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].MotifRecours = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String MotifRecoursCommentaire
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.lstRecoursVM[0].MotifRecoursCommentaire;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != MotifRecoursCommentaire)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].MotifRecoursCommentaire = value;

                    RaisePropertyChanged();
                }
            }
        }

        public String MotifGeneralJuryRecours
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.lstRecoursVM[0].MotifGeneral;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != MotifGeneralJuryRecours)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].MotifGeneral = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String MotifDetailJuryRecours
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.lstRecoursVM[0].MotifDetail;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != MotifDetailJuryRecours)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].MotifDetail = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String CommentaireJuryRecours
        {
            get
            {
                if (oJury.oRecours !=null)
                {
                    return oJury.lstRecoursVM[0].MotifCommentaire;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != CommentaireJuryRecours)
                {
                    if (oJury.lstRecoursVM.Count == 0)
                    {
                        oJury.lstRecoursVM.Add(new RecoursVM());
                    }

                    oJury.lstRecoursVM[0].MotifCommentaire = value;

                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsEtatDemande
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatLivret.ETAT_Lv_DEMANDE);
            }
        }
        public Boolean IsEtatIrrecevable
        {
            get
            {
                return (getNumetat() == (int)MyEnums.EtatLivret.ETAT_Lv_SANS_SUITE);
            }
        }
        public Boolean IsEtatEnvoye
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatLivret.ETAT_Lv_ENVOYE);
            }
        }
        public Boolean IsEtatRecuIncomplet
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatLivret.ETAT_Lv_RECU_INCOMPLET &&
                    getNumetat() < (int)MyEnums.EtatLivret.ETAT_Lv_RECU_COMPLET);
            }
        }
        public Boolean IsEtatRecu
        {
            get
            {
                return IsEtatRecuComplet || IsEtatRecuIncomplet;
            }
        }
        public Boolean IsEtatRecuComplet
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatLivret.ETAT_Lv_RECU_COMPLET);
            }
        }
        public Boolean IsEtatRefuse
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatLivret.ETAT_Lv_REFUSE) &&
                        (getNumetat() < (int)MyEnums.EtatLivret.ETAT_Lv_ACCEPTE);
            }
        }
        public Boolean IsEtatAccepte
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatLivret.ETAT_Lv_ACCEPTE);
            }
        }
        /// <summary>
        /// Rend vrai si le livret est en cours d'examen 
        /// </summary>
        public Boolean IsEtatEnCours
        {
            get
            {
                return ! (IsEtatAccepte  || IsEtatRefuse) ;
            }
        }
        public Boolean IsEtatSansSuite
        {
            get
            {
                return (getNumetat() == (int)MyEnums.EtatLivret.ETAT_Lv_SANS_SUITE);
            }
        }

        public override Boolean Reset()
        {
            try
            {
                base.Reset();
                foreach (JuryVM oJury in lstJuryVM)
                {
                    oJury.Reset();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }//Reset

        public override Boolean HasChanges()
        {
            Boolean bReturn = false;
            bReturn = (getEntity().State == System.Data.Entity.EntityState.Modified);
            if (!bReturn)
            {
                if (oJury != null)
                {
                    bReturn = oJury.HasChanges();
                }
            }
            return bReturn;

        }


        private PieceJointeCategorie _CategoriePJ;
        public PieceJointeCategorie CategoriePJ
        {
            get { return _CategoriePJ; }
            set {
                if (value != _CategoriePJ)
                {
                    _CategoriePJ = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("lstLibellePJ");
                }
            }
        }

        private PieceJointeItem _LibellePJ;
        public PieceJointeItem LibellePJ
        {
            get
            {
                return _LibellePJ;
            }
            set
            {
                if (value != LibellePJ)
                {
                    _LibellePJ = value;
                    RaisePropertyChanged();
                }
            }
        }
        public abstract List<PieceJointeCategorie> lstCategoriePJ
        { get; }
        public List<PieceJointeItem> lstLibellePJ
        {
            get
            {
                if (CategoriePJ != null)
                {
                    return (from item in CategoriePJ.lstPJItems
                            select item).ToList();
                }
                else
                {
                    return new List<PieceJointeItem>();
                }
            }
        }

        public void DeletePJ()

        {
            if (selectedPJ != null)
            {
                selectedPJ.IsDeleted = true;
                RaisePropertyChanged("lstPieceJointe");
                RaisePropertyChanged("lstPieceJointeActif");
            }
        }
        public virtual void DeleteMembreJury()

        {
        }

        public void FTO_SetDecisionJuryL1Favorable()
        {
            FTO_SetDecisionJuryL1Favorable(DateTime.Today);
        }
        public void FTO_SetDecisionJuryL1DeFavorable()
        {
            FTO_SetDecisionJuryL1DeFavorable(DateTime.Today);
        }
        public void FTO_SetDecisionJuryL2Favorable( Boolean pCreateAllDC = true)
        {
            FTO_SetDecisionJuryL2Favorable(DateTime.Today,pCreateAllDC);
        }
        public void FTO_SetDecisionJuryL2DeFavorable()
        {
            FTO_SetDecisionJuryL2DeFavorable(DateTime.Today);
        }
        public void FTO_SetDecisionJuryL1Favorable(DateTime pDateJury)
        {
            DateJury = pDateJury;
            DecisionJury = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);

        }
        public void FTO_SetDecisionJuryL1DeFavorable(DateTime pDateJury)
        {
            DateJury = pDateJury;
            DecisionJury = String.Format("{0:D}-DeFavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);

        }
        public void FTO_SetDecisionJuryL2Partielle()
        {
            FTO_SetDecisionJuryL2Partielle(DateTime.Today);
        }
        public void FTO_SetDecisionJuryL2Partielle(DateTime pDateJury)
        {
            DateJury = pDateJury;
            DecisionJury = String.Format("{0:D}-Validation Partielle", MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE);

        }
        public void FTO_SetDecisionJuryL2Favorable(DateTime pDateJury, Boolean pMAJ_DC_AValider = true )
        {
            if (pMAJ_DC_AValider)
            {
                // tous les Dc sont A Valider
                foreach (DCLivretVM oDCLivret in ((Livret2VM)this).lstDCLivret)
                {
                    oDCLivret.IsAValider = true;
                }
            }
            DateJury = pDateJury;
            DecisionJury = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE);

        }
        public void FTO_SetDecisionJuryL2DeFavorable(DateTime pDateJury)
        {
            DateJury = pDateJury;
            DecisionJury = String.Format("{0:D}-DeFavorable", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
            foreach (DCLivretVM oDCLivret in ((Livret2VM)this).lstDCLivretAValider)
            {
                oDCLivret.Decision = ((Livret2VM)this).DecisionL2ModuleDeFavorable;
            }

        }

        public virtual void AjouterMembreJury()
        {

        }
        public abstract Boolean IsValiderOK();
        public bool isAdded{ get; set; }

        public List<DCLivretVM> lstDCLivretAValider
        {
            get
            {
                return lstDCLivret.Where(i => i.IsAValider == true).ToList<DCLivretVM>();
            }
        }

        private Boolean IsBloc(int pNum)
        {
            if (ISCAFDESV2)
            {
                return lstDCLivretAValider.Exists(b => b.NumDC == pNum);
            }
            else
            {
                return false;
            }
        }
        public Boolean IsBlocDecisionFavorable (int pNum)
        {
            Boolean breturn = false;
            if (IsBloc(pNum))
            {
                if (lstDCLivretAValider.First(b => b.NumDC == pNum).IsDecisionFavorable.HasValue)
                {
                    breturn = lstDCLivretAValider.First(b => b.NumDC == pNum).IsDecisionFavorable.Value;
                }
            }
            return breturn;

        }

        public Boolean IsBloc1
        {
            get { return IsBloc(1); }
        }

        public Boolean IsBloc1DecisionFavorable
        {
            get { return IsBlocDecisionFavorable(1);}
        }
        public Boolean IsBloc2
        {
            get { return IsBloc(2); }
        }
        public Boolean IsBloc2DecisionFavorable
        {
            get { return IsBlocDecisionFavorable(2); }
        }
        public Boolean IsBloc3
        {
            get { return IsBloc(3); }
        }
        public Boolean IsBloc3DecisionFavorable
        {
            get { return IsBlocDecisionFavorable(3); }
        }
        public Boolean IsBloc4
        {
            get { return IsBloc(4); }
        }
        public Boolean IsBloc4DecisionFavorable
        {
            get { return IsBlocDecisionFavorable(4); }
        }

        public Boolean ISCAFDESV2
        {
            get { return NomDiplome == Properties.Settings.Default.NomDiplomeDefaut; }
        }

        public Boolean ISNOTCAFDESV2
        {
            get { return !ISCAFDESV2; }
        }

    }

}
