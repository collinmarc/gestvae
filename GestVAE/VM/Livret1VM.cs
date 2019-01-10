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
    public class Livret1VM:LivretVMBase
    {
        private Livret1 oL1 { get { return (Livret1)TheLivret; } }
        public Livret1VM(Livret pLivret):base(pLivret)
        {
        }


        public Livret1VM():base()
        {
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


        public Boolean IsContrat {
            get{
                return TheLivret.isContrat;
            }

            set
            {
                if (value != IsContrat)
                {
                    TheLivret.isContrat = value;
                    RaisePropertyChanged("IsContrat");
 //                   RaisePropertyChanged("IsConvention");
                }
            }
        }
        public Boolean IsConvention {
            get { return !TheLivret.isContrat; }
            set {
                if (value != IsConvention)
                {
                    TheLivret.isContrat= !value;
 //                   RaisePropertyChanged("IsContrat");
                    RaisePropertyChanged("IsConvention");
                }
}
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
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsEnvoyeVisibility");
                    RaisePropertyChanged("IsRecuVisibility");
                    RaisePropertyChanged("IsLivret1Valide");
                }
            }
        }
        public Visibility IsEnvoyeVisibility
        {
            get
            {
                if (this.EtatLivret.StartsWith("0"))
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            set { }
        }

        public Visibility IsRecuVisibility
        {
            get
            {
                try
                {
                    int n = Convert.ToInt32(this.EtatLivret.Substring(0,1));
                    if (n<2)
                    {
                        return Visibility.Hidden;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }

                }
                catch (Exception)
                {

                    return Visibility.Hidden;
                }
            }
            set { }
        }
        public Boolean IsRefuse => DecisionJury.ToUpper().Contains("REFUS");

        public Visibility IsRefuseVisibility
        {
            get
            {
                try
                {
                    Visibility oreturn = Visibility.Hidden;
                    if (IsRecuVisibility == Visibility.Visible)
                    {
                        if (IsRefuse)
                        {
                            oreturn = Visibility.Visible;
                        }
                    }

                    return oreturn;
                }
                catch (Exception)
                {

                    return Visibility.Hidden;
                }
            }
        }


        public String ResultatPiecesJointesL1
        {
            get {
                try
                {
                    foreach (PieceJointe item in oL1.lstPiecesJointes)
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
        public Brush ResultatPiecesJointesL1Color
        {
            get
            {
                Brush cReturn = Brushes.Gray;
                switch (ResultatPiecesJointesL1)
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
                oReturn.Add("0-Demandé");
                oReturn.Add("1-Envoyé");
                oReturn.Add("2-Reçu");
                oReturn.Add("3-Accepté");
                oReturn.Add("4-Refusé");
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
                oReturn.Add("Validation totale");
               // oReturn.Add("Validation partielle");
                oReturn.Add("Refus de validation");
                oReturn.Add("");
                return oReturn;
            }
            set { }
        }
        public  List<String> LstMotifGeneral
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Motif General1");
                oReturn.Add("Motif General2");
                oReturn.Add("Motif General3");
                oReturn.Add("");
                return oReturn;
            }
            set { }
        }
        public  List<String> LstMotifDetaille
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Motif DEtaille1");
                oReturn.Add("Motif Detaille2");
                oReturn.Add("Motif Detailee3");
                oReturn.Add("");
                return oReturn;
            }
            set { }
        }
        public List<String> LstMotifRecours
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Motif Recours1");
                oReturn.Add("Motif Recours2");
                oReturn.Add("Motif Recours3");
                oReturn.Add("");
                return oReturn;
            }
            set { }
        }

        public void addPJL1()
        {

            oL1.lstPiecesJointes.Add(new PieceJointeL1("..."));
            RaisePropertyChanged("TheLivret.lstPiecesJointes");
        }

        public void addEchangeL1()
        {
            oL1.lstEchanges.Add(new EchangeL1("..."));
            RaisePropertyChanged("TheLivret.lstEchanges");
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

                    TheLivret.lstJurys[0].NomJury= value;

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

                    TheLivret.lstJurys[0].LieuJury= value;

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

                    RaisePropertyChanged();
                }
            }
        }




        public Visibility IsLivret1Valide  {
            get
            {
                Visibility oReturn = Visibility.Hidden;
                if (IsRecuVisibility== Visibility.Visible && IsRefuseVisibility == Visibility.Hidden)
                {
                    oReturn = Visibility.Visible;
                }
                if (IsRecuVisibility == Visibility.Visible && 
                    IsRefuseVisibility == Visibility.Visible &&
                    !IsRefuseRecours)
                {
                    oReturn = Visibility.Visible;
                }
                return oReturn;
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


                    if (!IsRefuse)
                    {
                        MotifDetailJury = "";
                        MotifGeneralJury = "";
                        IsRecoursDemande = false;
                    }
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsRefuseVisibility");
                    RaisePropertyChanged("IsRecoursDemandeVisibility");
                    RaisePropertyChanged("IsLivret1Valide");
                }
            }
        }

        public Boolean IsRecoursDemande {
            get { return oL1.IsRecours; }
            set
            {
                if (value != IsRecoursDemande)
                {
                    oL1.IsRecours = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsRecoursDemandeVisibility");
                }
            }
        }
        public Visibility IsRecoursDemandeVisibility
        {
            get { return IsRecoursDemande ? Visibility.Visible : Visibility.Hidden; }
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

                    RaisePropertyChanged();
                    RaisePropertyChanged("IsRefuseRecours");
                    RaisePropertyChanged("IsLivret1Valide");
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

        public void CreerLivret2()
        {
            CandidatVM oCandVM = new CandidatVM(oL1.oCandidat);
            oCandVM.AjoutLivret2();
        }

    }
}
