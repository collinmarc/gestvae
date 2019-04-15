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
        public ObservableCollection<JuryVM> lstJuryVM;
        public ObservableCollection<PieceJointeLivretVM> lstPieceJointe { get; set; }
        public PieceJointeLivretVM selectedPJ { get; set; }

        public LivretVMBase(Livret pLivret):base(pLivret)
        {
            lstPieceJointe = new ObservableCollection<PieceJointeLivretVM>();
            SetLstJuryVM();
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
        public Boolean IsCandidatLocked { get; set; }

        public LivretVMBase(Boolean pIsCandidatLocked):base()
        {
            IsCandidatLocked = pIsCandidatLocked;
            lstPieceJointe = new ObservableCollection<PieceJointeLivretVM>();
            lstJuryVM = new ObservableCollection<JuryVM>();
            create1erJury();
        }
        public abstract String Numero { get; set; }

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

            }
        }
        public virtual void Commit() {
            foreach (JuryVM item in lstJuryVM)
            {
                Jury obj = (Jury)item.TheItem;
                if (_ctx.Entry<Jury>(obj).State == System.Data.Entity.EntityState.Detached)
                {
                    TheLivret.lstJurys.Add(obj);
                }
                item.Commit();
            }


        }
        public void AjoutePJ(String pstrLivret)
        {
            if (lstCategoriePJ.Count > 0)
            {
                // Récupération de la première catégorie
                String strCat = lstCategoriePJ[0];
                PieceJointeLivretVM opjVM = new PieceJointeLivretVM(pstrLivret);
                opjVM.Categorie = strCat;
                // Récupération du libellé
                if (opjVM.lstLibellePJ.Count > 0)
                {
                    opjVM.Libelle = opjVM.lstLibellePJ[0];
                }
                // Ajout dans la collection
                lstPieceJointe.Add(opjVM);
                RaisePropertyChanged("lstPieceJointe");
            }
        }
         
        public abstract List<String> lstCategoriePJ
        { get; }

        public void DeletePJ()

        {
            PieceJointeLivretVM oPJ = selectedPJ;
            if (!oPJ.IsNew)
            {
                _ctx.Entry<PieceJointe>(oPJ.ThePiecejointe).State = System.Data.Entity.EntityState.Deleted;

            }
            lstPieceJointe.Remove(selectedPJ);
            RaisePropertyChanged("lstPieceJointe");
        }
        public List<String> LstEtatLivret { get; set; }

        public abstract void ClearDCs();
        protected JuryVM oJury
        {
            get
            {
                if (lstJuryVM.Count == 0)
                {
                    lstJuryVM.Add(new JuryVM());
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
        public DateTime? DateJury
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
                    DateLimiteRecours = value.Value.AddDays(Properties.Settings.Default.DelaiDepotRecours);
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateNotificationJury
        {
            get
            {
                if (oJury != null)
                {
                    return oJury.DateNotificationJury;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateNotificationJury)
                {

                    oJury.DateNotificationJury = value;

                    RaisePropertyChanged();
                }
            }
        }
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
                }
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
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsDecisionJuryFavorable");
                    RaisePropertyChanged("IsDecisionJuryDefavorable");
                    RaisePropertyChanged("IsDecisionJuryPartielle");
                }
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
                }
            }
        }
        public Boolean IsLivretNonModifiable
        {
            get { if (!IsCandidatLocked)
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
                return (getNumDecisionJury() != (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            }
        }
        public Boolean IsDecisionJuryDefavorable
        {
            get
            {
                return (getNumDecisionJury() == (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
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
                            DateLimiteRecours = DateJury.Value.AddDays(Properties.Settings.Default.DelaiDepotRecours);
                        }
                        MotifRecours = MotifGeneralJury;
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
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_DEMANDE);
            }
        }
        public Boolean IsEtatEnvoye
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_ENVOYE);
            }
        }
        public Boolean IsEtatRecuIncomplet
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET &&
                    getNumetat() < (int)MyEnums.EtatL1.ETAT_L1_RECU_COMPLET);
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
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_RECU_COMPLET);
            }
        }
        public Boolean IsEtatRefuse
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_REFUSE) &&
                        (getNumetat() < (int)MyEnums.EtatL1.ETAT_L1_ACCEPTE);
            }
        }
        public Boolean IsEtatAccepte
        {
            get
            {
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_ACCEPTE);
            }
        }
        public Boolean IsEtatSansSuite
        {
            get
            {
                return (getNumetat() == (int)MyEnums.EtatL1.ETAT_L1_SANS_SUITE);
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

        public abstract CandidatVM getCurrentCandidat();

    }
}
