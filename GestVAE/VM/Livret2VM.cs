using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GestVAE.VM
{
    public class Livret2VM : LivretVMBase
    {
        private Livret2 oL2 { get { return (Livret2)TheLivret; } }
        public ObservableCollection<DCLivretVM> lstDCLivret { get; set; }
        public DCLivretVM selectedDCLivret { get; set; }
        private ObservableCollection<MembreJuryVM> _lstMembreJuryVM;
        public ObservableCollection<MembreJuryVM> lstMembreJury{
            get
            {
                return _lstMembreJuryVM;
            }
        }
        public Livret2VM(Livret2 pLivret) :  base(pLivret)
        {
            lstDCLivret = new ObservableCollection<DCLivretVM>();
            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();

            foreach (PieceJointeL2 opj in pLivret.lstPiecesJointes)
            {
                lstPieceJointe.Add(new PieceJointeLivretVM(opj, "L2"));
            }

            foreach (DCLivret oDCL in pLivret.lstDCLivrets)
            {
                lstDCLivret.Add(new DCLivretVM(oDCL));
            }

            foreach (MembreJury oItem in pLivret.lstMembreJurys)
            {
                lstMembreJury.Add(new MembreJuryVM(oItem));
            }

        }


        public Livret2VM() : base()
        {
            Livret oReturn = null;

            oReturn = new Livret2();
            oReturn.oDiplome = Diplome.getDiplomeParDefaut();
            TheItem = oReturn;

            lstDCLivret = new ObservableCollection<DCLivretVM>();
            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();
        }
        public Livret2VM(Diplome pDip) : this()
        {
            TheLivret.oDiplome = pDip;
        }

        public String NomDiplome
        {
            get
            {
                return TheLivret.oDiplome.Nom;
            }
            set
            {
                if (value != NomDiplome)
                {
                    TheLivret.oDiplome.Nom = value;
                    RaisePropertyChanged();
                }
            }
        }

        public String Numero
        {
            get
            {
                return oL2.Numero;
            }
            set
            {
                if (value != Numero)
                {
                    oL2.Numero = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Int32 NumPassage
        {
            get
            {
                return oL2.NumPassage;
            }
            set
            {
                if (value != NumPassage)
                {
                    oL2.NumPassage = value;
                    RaisePropertyChanged();
                }
            }
        }


        public Boolean IsContrat
        {
            get
            {
                return TheLivret.isContrat;
            }

            set
            {
                if (value != IsContrat)
                {
                    TheLivret.isContrat = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsConvention
        {
            get { return !TheLivret.isContrat; }
            set
            {
                if (value != IsConvention)
                {
                    TheLivret.isContrat = !value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsAttestationOK
        {
            get { return oL2.IsAttestationOK; }
            set
            {
                if (value != IsAttestationOK)
                {
                    oL2.IsAttestationOK = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsCNIOK
        {
            get { return oL2.IsCNIOK; }
            set
            {
                if (value != IsCNIOK)
                {
                    oL2.IsCNIOK = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsDispenseArt2
        {
            get { return oL2.IsDispenseArt2; }
            set
            {
                if (value != IsDispenseArt2)
                {
                    oL2.IsDispenseArt2 = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsOuvertureApresRecours
        {
            get { return oL2.IsOuvertureApresRecours; }
            set
            {
                if (value != IsOuvertureApresRecours)
                {
                    oL2.IsOuvertureApresRecours = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Boolean IsLivretClos
        {
            get { return TheLivret.isClos; }
            set
            {
                if (value != IsLivretClos)
                {
                    TheLivret.isClos = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsLivretNonClos");
                }
            }
        }
        public Boolean IsLivretNonClos
        {
            get { return !IsLivretClos; }
            set { IsLivretClos = !value; }
        }

        public String EtatLivret
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
                    if (IsLivretClos)
                    {

                    }
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
                return (getNumetat() >= (int)MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET);
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


        public String ResultatPiecesJointes
        {
            get
            {
                try
                {
                    foreach (PieceJointeLivretVM item in lstPieceJointe)
                    {
                        if (!item.IsRecu || !item.IsOK)
                        {
                            return "ERREUR";
                        }
                    }
                    return "OK";
                }
                catch (Exception)
                {

                    return "ERREUR";
                }
            }

        }
        public Brush ResultatPiecesJointesColor
        {
            get
            {
                Brush cReturn = Brushes.Gray;
                switch (ResultatPiecesJointes)
                {
                    case "OK":
                        cReturn = Brushes.Green;
                        break;
                    case "ERREUR":
                        cReturn = Brushes.Red;
                        break;

                    default:
                        break;
                }
                return cReturn;
            }

        }

        public static List<String> LstDecisionL2
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE));
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE));
                oReturn.Add(String.Format("{0:D}-Partielle", MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE));
                return oReturn;
            }
            set { }
        }

        public  List<String> LstDecisionL2Module
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE));
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE));
                return oReturn;
            }
            set { }
        }

        public DateTime? DateDemande
        {
            get { return oL2.DateDemande; }
            set
            {
                if (value != DateDemande)
                {
                    oL2.DateDemande = value;
                    RaisePropertyChanged();
                    if (!IsEtatRecu)
                    {
                    }
                }
            }
        }
        public DateTime? DateEnvoiEHESP
        {
            get { return oL2.DateEnvoiEHESP; }
            set
            {
                if (value != DateEnvoiEHESP)
                {
                    oL2.DateEnvoiEHESP = value;
                    RaisePropertyChanged();
                    DateLimiteReceptEHESP = DateEnvoiEHESP.Value.AddDays(Properties.Settings.Default.DelaiReceptionL1);
                }
            }
        }
        public DateTime? DateEnvoiCandidat
        {
            get { return oL2.DateEnvoiCandidat; }
            set
            {
                if (value != DateEnvoiCandidat)
                {
                    oL2.DateEnvoiCandidat = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateLimiteReceptEHESP
        {
            get { return oL2.DateLimiteReceptEHESP; }
            set
            {
                if (value != DateLimiteReceptEHESP)
                {
                    oL2.DateLimiteReceptEHESP = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateReceptEHESP
        {
            get { return oL2.DateReceptEHESP; }
            set
            {
                if (value != DateReceptEHESP)
                {
                    oL2.DateReceptEHESP = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateReceptEHESPComplet
        {
            get { return oL2.DateReceptEHESPComplet; }
            set
            {
                if (value != DateReceptEHESPComplet)
                {
                    oL2.DateReceptEHESPComplet = value;
                    RaisePropertyChanged();
                    if (IsEtatRecu)
                    {
                        DateLimiteJury = DateReceptEHESPComplet.Value.AddDays(Properties.Settings.Default.DelaiJuryL1);
                    }
                }
            }
        }
        public DateTime? DateValidite
        {
            get { return oL2.DateValidite; }
            set
            {
                if (value != DateValidite)
                {
                    oL2.DateValidite = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? DatePrevJury1
        {
            get { return oL2.DatePrevJury1; }
            set
            {
                if (value != DatePrevJury1)
                {
                    oL2.DatePrevJury1 = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DatePrevJury2
        {
            get { return oL2.DatePrevJury2; }
            set
            {
                if (value != DatePrevJury2)
                {
                    oL2.DatePrevJury2 = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? Date1ereDemandePieceManquantes
        {
            get { return oL2.Date1ereDemandePieceManquantes; }
            set
            {
                if (value != Date1ereDemandePieceManquantes)
                {
                    oL2.Date1ereDemandePieceManquantes = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? Date2emeDemandePieceManquantes
        {
            get { return oL2.Date2emeDemandePieceManquantes; }
            set
            {
                if (value != Date2emeDemandePieceManquantes)
                {
                    oL2.Date2emeDemandePieceManquantes = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? DateDemandePieceManquantesRetour
        {
            get { return oL2.DateDemandePieceManquantesRetour; }
            set
            {
                if (value != DateDemandePieceManquantesRetour)
                {
                    oL2.DateDemandePieceManquantesRetour = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? DateReceptionPiecesManquantes
        {
            get { return oL2.DateReceptionPiecesManquantes; }
            set
            {
                if (value != DateReceptionPiecesManquantes)
                {
                    oL2.DateReceptionPiecesManquantes = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? DateNotificationJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].DateNotificationJury;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].DateNotificationJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String SessionJury
        {
            get { return oL2.SessionJury; }
            set
            {
                if (value != SessionJury)
                {
                    oL2.SessionJury = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateLimiteJury
        {
            get { return oL2.DateLimiteJury; }
            set
            {
                if (value != DateLimiteJury)
                {
                    oL2.DateLimiteJury = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NomJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].NomJury;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != NomJury)
                {
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].NomJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String LieuJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].LieuJury;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].LieuJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].DateJury;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].DateJury = value;
                    DateLimiteRecours = value.Value.AddDays(Properties.Settings.Default.DelaiDepotRecours);

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? HeureJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].HeureJury;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].HeureJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? HeureConvoc
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].HeureConvoc;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].HeureConvoc = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateLimiteRecours
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].DateLimiteRecours;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].DateLimiteRecours = value;

                    RaisePropertyChanged();
                }
            }
        }







        public String DecisionJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].Decision;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DecisionJury)
                {
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].Decision = value;
                    if (LstEtatLivret != null)
                    {
                        setEtatLivret();
                        if (IsDecisionJuryFavorable)
                        {
                            String strKey = String.Format("{0:D}", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE);
                            String decisionModule = LstDecisionL2Module.Find(x => x.StartsWith(strKey));
                            foreach (DCLivretVM oDC in lstDCLivret.Where(dc => dc.IsAValider))
                            {
                                oDC.Decision = decisionModule;
                            }
                        }
                    }
                    if (IsDecisionJuryDefavorable)
                        {
                            String strKey = String.Format("{0:D}", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
                            String decisionModule = LstDecisionL2Module.Find(x => x.StartsWith(strKey));
                            foreach (DCLivretVM oDC in lstDCLivret.Where(dc => dc.IsAValider))
                            {
                                oDC.Decision = decisionModule;
                            }
                    }
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsDecisionJuryFavorable");
                    RaisePropertyChanged("IsDecisionJuryDefavorable");
                    RaisePropertyChanged("IsDecisionJuryPartielle");
                    RaisePropertyChanged("lstDCLivretAValider");
                }
            }
        }

        public Boolean IsDecisionJuryFavorable
        {
            get
            {
                return (getNumDecisionJury() < (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
            }
        }
        public Boolean IsDecisionJuryDefavorable
        {
            get
            {
                return ((getNumDecisionJury() >= (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE) &&
                        (getNumDecisionJury() < (int)MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE));
            }
        }
        public Boolean IsDecisionJuryPartielle
        {
            get
            {
                return ((getNumDecisionJury() >= (int)MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE));
            }
        }
        private void setEtatLivret()
        {
            String strEtat = EtatLivret;
            String strKey = "";
            if (IsDecisionJuryFavorable || IsDecisionJuryPartielle)
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_ACCEPTE);
                strEtat = LstEtatLivret.Find(x => x.StartsWith(strKey));
                EtatLivret = strEtat;
            }
            if (IsDecisionJuryDefavorable)
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_REFUSE);
                strEtat = LstEtatLivret.Find(x => x.StartsWith(strKey));
                EtatLivret = strEtat;
            }
        }
        public String MotifGeneralJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].MotifGeneral;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].MotifGeneral = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String MotifDetailJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].MotifDetail;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].MotifDetail = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String CommentaireJury
        {
            get
            {
                if (TheLivret.lstJurys.Count >= 1)
                {
                    return TheLivret.lstJurys[0].MotifCommentaire;
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
                    if (TheLivret.lstJurys.Count == 0)
                    {
                        TheLivret.lstJurys.Add(new Jury());
                    }

                    TheLivret.lstJurys[0].MotifCommentaire = value;

                    RaisePropertyChanged();
                }
            }
        }



        public override void Commit()
        {
            // Validation des PiècesJointes L2
            foreach (PieceJointeLivretVM item in lstPieceJointe)
            {
                if (item.strLivret == "L2")
                {
                    PieceJointeL2 oPJ = (PieceJointeL2)item.ThePiecejointe;
                    if (_ctx.Entry<PieceJointeL2>(oPJ).State == System.Data.Entity.EntityState.Detached)
                    {
                        oL2.lstPiecesJointes.Add(oPJ);
                    }
                }
            }
            foreach (MembreJuryVM item in lstMembreJury)
            {
                {
                    MembreJury oPJ = item.MembreJuryItem;
                    if (_ctx.Entry<MembreJury>(oPJ).State == System.Data.Entity.EntityState.Detached)
                    {
                        oL2.lstMembreJurys.Add(oPJ);
                    }
                    if (_ctx.Entry<MembreJury>(oPJ).State == System.Data.Entity.EntityState.Deleted)
                    {
                        oL2.lstMembreJurys.Remove(oPJ);
                    }
                }
            }

        }


        public List<DCLivretVM> lstDCLivretAValider
        {
            get
            {
                return lstDCLivret.Where(i => i.IsAValider == true).ToList<DCLivretVM>();
            }
        }
        public override  List<String> lstCategoriePJ
        {
            get
                {
                return (from item in _ctx.pieceJointeCategories
                        where item.Livret == "L2"
                        select item.Categorie).ToList<String>();
            }
        }

        public List<String> LstMotifGL2
        {
            get
            {
                return (from item in _ctx.dbMotifGeneralL2
                        select item.Libelle).ToList<String>();
            }
        }

        public void Cloturer()
        {
            IsLivretClos = true;
            oL2.ValiderLivret2();
        }

        public override void ClearDCs()
        {
            foreach (DCLivretVM oItem in lstDCLivret)
            {
                if (oItem.IsNew)
                {
                    _ctx.Entry<DCLivret>((DCLivret)oItem.TheDCLivret).State = System.Data.Entity.EntityState.Detached;
                }
                else
                {
                    _ctx.Entry<DCLivret>((DCLivret)oItem.TheDCLivret).State = System.Data.Entity.EntityState.Deleted;
                }

            }
 
        }

        public override bool HasChanges()
        {
            DbEntityEntry<Livret2> dbL2 = _ctx.Entry<Livret2>(oL2);
            return (dbL2.State == System.Data.Entity.EntityState.Modified);
        }
    }
}
