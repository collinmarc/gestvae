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
    public class Livret1VM : LivretVMBase
    {
        private Livret1 oL1 { get { return (Livret1)TheLivret; } }
        public Livret1VM(Livret1 pLivret) : base(pLivret)
        {

            foreach (PieceJointeL1 opj in pLivret.lstPiecesJointes)
            {
                lstPieceJointe.Add(new PieceJointeLivretVM(opj, "L1"));
            }
        }


        public Livret1VM() : base()
        {
            Livret oReturn = null;

            oReturn = new Livret1();
            oReturn.oDiplome = Diplome.getDiplomeParDefaut();
            TheItem = oReturn;

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
                return oL1.Numero;
            }
            set
            {
                if (value != Numero)
                {
                    oL1.Numero = value;
                    RaisePropertyChanged();
                }
            }
        }


        public Boolean IsContrat {
            get {
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
        public Boolean IsConvention {
            get { return !TheLivret.isContrat; }
            set {
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
            set { IsLivretClos = !value;}
        }

        public String EtatLivret {
            get {
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

        public Boolean IsJury
        {
            get
            {
                return (getNumetat() >= 4);
            }
        }
        public Boolean IsValide
        {
            get
            {
                return (getNumetat() == 9);
            }
        }

        public String ResultatPiecesJointes
        {
            get {
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
                oReturn.Add(String.Format("{0:D}-Recours", MyEnums.EtatL1.ETAT_L1_RECOURS));
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

        public static List<String> LstDecisionL1
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE));
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE));
                return oReturn;
            }
            set { }
        }

        /// <summary>
        /// Liste des Catégories de pièces jointes pour le Livret1
        /// </summary>
        public override List<String> lstCategoriePJ
        {
            get
            {
                return (from item in _ctx.pieceJointeCategories
                        where item.Livret == "L1"
                        select item.Categorie).ToList<String>();
            }
        }

        public void addEchangeL1()
        {
            oL1.lstEchanges.Add(new EchangeL1("..."));
            RaisePropertyChanged("TheLivret.lstEchanges");
        }

        public DateTime? DateDemande
        {
            get { return oL1.DateDemande; }
            set
            {
                if (value != DateDemande)
                {
                    oL1.DateDemande = value;
                    RaisePropertyChanged();
                    if (!IsEtatRecu)
                    {
                        DateLimiteEnvoiEHESP = DateDemande.Value.AddDays(Properties.Settings.Default.DelaiEnvoiL1);
                    }
                }
            }
        }
        public DateTime? DateLimiteEnvoiEHESP
        {
            get { return oL1.DateLimiteEnvoiEHESP; }
            set
            {
                if (value != DateLimiteEnvoiEHESP)
                {
                    oL1.DateLimiteEnvoiEHESP = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateEnvoiEHESP
        {
            get { return oL1.DateEnvoiEHESP; }
            set
            {
                if (value != DateEnvoiEHESP)
                {
                    oL1.DateEnvoiEHESP = value;
                    RaisePropertyChanged();
                    DateLimiteReceptEHESP = DateEnvoiEHESP.Value.AddDays(Properties.Settings.Default.DelaiReceptionL1);
                }
            }
        }
        public DateTime? DateLimiteReceptEHESP
        {
            get { return oL1.DateLimiteReceptEHESP; }
            set
            {
                if (value != DateLimiteReceptEHESP)
                {
                    oL1.DateLimiteReceptEHESP = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateReceptEHESP
        {
            get { return oL1.DateReceptEHESP; }
            set
            {
                if (value != DateReceptEHESP)
                {
                    oL1.DateReceptEHESP = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateReceptEHESPComplet
        {
            get { return oL1.DateReceptEHESPComplet; }
            set
            {
                if (value != DateReceptEHESPComplet)
                {
                    oL1.DateReceptEHESPComplet = value;
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
            get { return oL1.DateValidite; }
            set
            {
                if (value != DateValidite)
                {
                    oL1.DateValidite = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? Date1ereDemandePieceManquantes
        {
            get { return oL1.Date1ereDemandePieceManquantes; }
            set
            {
                if (value != Date1ereDemandePieceManquantes)
                {
                    oL1.Date1ereDemandePieceManquantes = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? Date2emeDemandePieceManquantes
        {
            get { return oL1.Date2emeDemandePieceManquantes; }
            set
            {
                if (value != Date2emeDemandePieceManquantes)
                {
                    oL1.Date2emeDemandePieceManquantes = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? DateDemandePieceManquantesRetour
        {
            get { return oL1.DateDemandePieceManquantesRetour; }
            set
            {
                if (value != DateDemandePieceManquantesRetour)
                {
                    oL1.DateDemandePieceManquantesRetour = value;
                    RaisePropertyChanged();

                }
            }
        }


        public DateTime? DateLimiteJury
        {
            get { return oL1.DateLimiteJury; }
            set
            {
                if (value != DateLimiteJury)
                {
                    oL1.DateLimiteJury = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NomJury {
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
                }
            }
        }

        public Boolean IsDecisionJuryFavorable
        {
            get{ 
            return (getNumDecisionJury() < (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
        }
        }
        public Boolean IsDecisionJuryDefavorable { 
                 get{
                    return (getNumDecisionJury() >= (int) MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            }
        }
        public Boolean IsDecisionJuryRecoursFavorable
        {
            get
            {
                return (getNumDecisionJuryRecours() < (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            }
        }
        public Boolean IsDecisionJuryRecoursDefavorable
        {
            get
            {
                return (getNumDecisionJuryRecours() >= (int)MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            }
        }
        private void setEtatLivret()
        {
            String strEtat = EtatLivret;
            String strKey = "";
            if ( IsDecisionJuryFavorable  || (  IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursFavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_ACCEPTE);
            }
            if ((IsDecisionJuryDefavorable && !IsRecoursDemande) || 
                (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursDefavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_REFUSE);
            }
            strEtat = LstEtatLivret.Find(x => x.StartsWith(strKey));
            EtatLivret = strEtat;
        }
        public Boolean IsRecoursDemande {
            get { return oL1.IsRecours; }
            set
            {
                if (value != IsRecoursDemande)
                {
                    oL1.IsRecours = value;
                    RaisePropertyChanged();
                }
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
        public EnumTypeRecours TypeRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].TypeRecours;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].TypeRecours = value;

                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? DateDepot
        {
            get
            {
                if (oL1.lstRecours.Count>= 1)
                {
                    return oL1.lstRecours[0].DateDepot;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != DateDepot)
                {
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].DateDepot= value;

                    RaisePropertyChanged();
                }
            }
        }
        public String LieuJuryRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].LieuJury;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].LieuJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateJuryRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].DateJury;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].DateJury = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String DecisionJuryRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].Decision;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != DecisionJuryRecours)
                {
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].Decision = value;

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
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].MotifRecours;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (value != MotifRecours)
                {
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].MotifRecours = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String MotifRecoursCommentaire
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].MotifRecoursCommentaire;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].MotifRecoursCommentaire = value;

                    RaisePropertyChanged();
                }
            }
        }

        public String MotifGeneralJuryRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].MotifGeneral;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].MotifGeneral = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String MotifDetailJuryRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].MotifDetail;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].MotifDetail = value;

                    RaisePropertyChanged();
                }
            }
        }
        public String CommentaireJuryRecours
        {
            get
            {
                if (oL1.lstRecours.Count >= 1)
                {
                    return oL1.lstRecours[0].MotifCommentaire;
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
                    if (oL1.lstRecours.Count == 0)
                    {
                        oL1.lstRecours.Add(new Recours());
                    }

                    oL1.lstRecours[0].MotifCommentaire = value;

                    RaisePropertyChanged();
                }
            }
        }

        public Boolean IsRefuseRecours => DecisionJuryRecours.ToUpper().Contains("REFUS");

        public void ClotureretCreerLivret2(CandidatVM pCandidat)
        {

            // CloturerLivret1
            IsLivretClos = true;
            Livret2VM oLiv = new Livret2VM(TheLivret.oDiplome);
            pCandidat.AjoutLivret2(oLiv);
        }

        public override void Commit()
        {
            // Validation des PiècesJointes L1
            foreach (PieceJointeLivretVM item in lstPieceJointe)
            {
                PieceJointeL1 oPJ = (PieceJointeL1)item.ThePiecejointe;
                if (_ctx.Entry<PieceJointeL1>(oPJ).State == System.Data.Entity.EntityState.Detached)
                {
                    oL1.lstPiecesJointes.Add(oPJ);
                }
            }

        }



    }
}
