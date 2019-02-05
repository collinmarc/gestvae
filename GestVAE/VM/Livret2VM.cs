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
    public class Livret2VM:LivretVMBase
    {
        protected Livret2 TheLivret2
        {
            get { return (Livret2)TheLivret; }
        }
        public Livret2VM(Livret2 pLivret):base((Livret)pLivret)
        {
        }


        public Livret2VM():base()
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

        public String Numero
        {
            get
            {
                return TheLivret2.Numero.ToString();
            }
            set
            {
                if (value != Numero)
                {
                    TheLivret2.Numero = Convert.ToInt32(value);
                    RaisePropertyChanged();
                }
            }
        }


        public ObservableCollection<DCLivret> lstDcLivrets { get { return TheLivret2.lstDCLivrets; } }
        public ObservableCollection<DCLivret> lstDcLivretsAValider {
            get {
                ObservableCollection<DCLivret> oReturn = new ObservableCollection<DCLivret>();
                foreach (var item in TheLivret2.lstDCLivrets.Where(obj => obj.IsAValider ))
                {
                    oReturn.Add(item);
                } 

                return oReturn;
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
                    RaisePropertyChanged("IsLivretNonValidé");
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

        public Visibility IsValidationPartielleVisibility
        {
            get
            {
                try
                {
                    if (DecisionJury.ToUpper().Contains("PARTIELLE"))
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Hidden;
                    }

                }
                catch (Exception)
                {

                    return Visibility.Hidden;
                }
            }
        }
        public Visibility IsNotValidationPartielleVisibility
        {
            get
            {
                try
                {
                    if (!DecisionJury.ToUpper().Contains("PARTIELLE"))
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Hidden;
                    }

                }
                catch (Exception)
                {

                    return Visibility.Hidden;
                }
            }
        }


        public String ResultatPiecesJointesL2
        {
            get {
                try
                {
                    foreach (PieceJointe item in TheLivret2.lstPiecesJointes)
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
        public Brush ResultatPiecesJointesL2Color
        {
            get
            {
                Brush cReturn = Brushes.Gray;
                switch (ResultatPiecesJointesL2)
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
                oReturn.Add("9-Validé");
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

        public List<String> LstDecisionL2
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Validation totale");
                oReturn.Add("Validation partielle");
                oReturn.Add("Refus de validation");
                oReturn.Add("");
                return oReturn;
            }
            set { }
        }
        public List<String> LstDecisionL2Module
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add("Validation totale");
//                oReturn.Add("Validation partielle");
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

        public void addPJL2()
        {
            Livret2 obj = (Livret2)TheLivret;

            obj.lstPiecesJointes.Add(new PieceJointeL2("..."));
            RaisePropertyChanged("TheLivret.lstPiecesJointes");
        }

        public void addEchangeL2()
        {
            Livret2 obj = (Livret2)TheLivret;

            obj.lstEchanges.Add(new EchangeL2("..."));
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












        public Boolean IsRefuse => DecisionJury.ToUpper().Contains("REFUS");
        public Boolean IsLivretNonValidé => EtatLivret!="9-Validé";

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
                    }
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsRefuse");
                    RaisePropertyChanged("IsValidationPartielleVisibility");
                    RaisePropertyChanged("IsNotValidationPartielleVisibility");
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

        public void ValiderLivret2()
        {
            TheLivret2.ValiderLivret2();
            EtatLivret = "9-Validé";
            RaisePropertyChanged("IsLivretValidé");

        }



    }
}
