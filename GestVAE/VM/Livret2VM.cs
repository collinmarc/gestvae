using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<MembreJury> lstMembreJury{
            get
            {
                return oL2.lstMembreJurys;
            }
        }
        public Livret2VM(Livret2 pLivret) : base(pLivret)
        {
            lstDCLivret = new ObservableCollection<DCLivretVM>();

            foreach (PieceJointeL2 opj in pLivret.lstPiecesJointes)
            {
                lstPieceJointe.Add(new PieceJointeLivretVM(opj, "L2"));
            }

            foreach (DCLivret oDCL in pLivret.lstDCLivrets)
            {
                lstDCLivret.Add(new DCLivretVM(oDCL));
            }
        }


        public Livret2VM() : base()
        {
            lstDCLivret = new ObservableCollection<DCLivretVM>();
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

        public List<String> LstEtatLivret
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Demandé", MyEnums.EtatL1.ETAT_L1_DEMANDE));
                oReturn.Add(String.Format("{0:D}-Envoyé", MyEnums.EtatL1.ETAT_L1_ENVOYE));
                oReturn.Add(String.Format("{0:D}-Reçu incomplet", MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET));
                oReturn.Add(String.Format("{0:D}-Reçu complet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET));
                oReturn.Add(String.Format("{0:D}-Refusé", MyEnums.EtatL1.ETAT_L1_REFUSE));
//                oReturn.Add(String.Format("{0:D}-Recours", MyEnums.EtatL1.ETAT_L1_RECOURS));
                oReturn.Add(String.Format("{0:D}-Accepté", MyEnums.EtatL1.ETAT_L1_ACCEPTE));
                return oReturn;
            }
            set { }
        }
        public List<String> LstTypeDemande
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Courrier");
                oReturn.Add("Téléphone");
                oReturn.Add("Mail");
                oReturn.Add("Retrait au secretariat VAE");
                oReturn.Add("Fax");
                oReturn.Add("Non Renseigné");
                return oReturn;
            }
            set { }
        }

        public List<String> LstOrigineDemande
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Ehesp(autre)");
                oReturn.Add("site Ehesp");
                oReturn.Add("Établissements de formation CAFDES");
                oReturn.Add("Site établissements de formation CAFDES");
                oReturn.Add("Organisme de formation(suite à une prestation)");
                oReturn.Add("Directeur, RH");
                oReturn.Add("Collègues");
                oReturn.Add("DRASS");
                oReturn.Add("PIC / PRC");
                oReturn.Add("ASH");
                oReturn.Add("Gazette des communes");
                oReturn.Add("Direction");
                oReturn.Add("TSA");
                oReturn.Add("Autres");
                oReturn.Add("Presse");
                oReturn.Add("Salon Géront'Expo");
                oReturn.Add("Pôle Emploi(ANPE)");
                oReturn.Add("ASP(CNASEA)");
                oReturn.Add("Internet(autres sites…)");
                oReturn.Add("Non renseigné");
                return oReturn;
            }
            set { }
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
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE));
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
                    return "";
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

                    setEtatLivret();
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsDecisionJuryFavorable");
                    RaisePropertyChanged("IsDecisionJuryDefavorable");
                    RaisePropertyChanged("IsDecisionJuryPartielle");
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

 
    }
}
