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


        public Livret1VM(Boolean pIsCandidatLocked) : base( pIsCandidatLocked)
        {
            Livret oReturn = null;

            oReturn = new Livret1();


            oReturn.oDiplome = Diplome.getDiplomeParDefaut();
            TheItem = oReturn;
        }


        public override String Numero
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


        public override String EtatLivret
        {
            get
            {
                return base.EtatLivret;
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
                    if (IsEtatRecu && String.IsNullOrEmpty(Numero))
                    {
                        Numero = DateTime.Now.ToString("yyMM") + ParamVM.incrementLivret().ToString("00000");
                    }
                    CalcDateValidite();

                }
            }
        }

        public override void CalcDateValidite()
        {
            if (IsEtatAccepte)
            {
                DateTime DateRef=DateTime.Now;
                //if (IsRecoursDemande)
                //{
                //    if (DateJuryRecours != null)
                //    {
                //        DateRef = DateJuryRecours.Value;
                //    }
                //    else
                //    {
                //        DateRef = DateJury.Value;

                //    }
                //}
                //else
                //{
                    if (DateJury == null)
                    {
                        DateRef = DateTime.Now;
                    }
                    else
                    {
                        DateRef = DateJury.Value;
                    }
//                }
                DateValidite = DateRef.AddYears(Properties.Settings.Default.DelaiValidite);

            }
            if (IsEtatRefuse)
            {
                DateValidite = DateJury;
            }
        }

        /// <summary>
        /// Le L1 est valide s'il est accepté et que sa date de validité n'est pas dépassé (3 ans)
        /// OU
        /// S'il est accepté et qu'au moins 1 DC a été validé dans un L2
        /// </summary>
        /// <returns></returns>
        public Boolean IsValide(CandidatVM pCand )
        {
            Boolean bReturn = false;
            //            bReturn = (IsEtatAccepte && DateValidite > DateTime.Now);
            DateTime dDateValid = DateTime.Now;
            Int32 nDelai = new ContextParam() .dbParam.First().DelaiValiditeL1;
            if (DateValidite.HasValue)
            {
                dDateValid = DateValidite.Value.AddDays(nDelai);
            }
            bReturn = (IsEtatAccepte && (dDateValid > DateTime.Now));

            if (!bReturn)
            {
                if (IsEtatAccepte)
                {
                    CandidatVM oCand = pCand;
                    // Parcours de la Liste des L2
                    foreach (Livret2VM oLiv in oCand.getListLivret2())
                    {
                        if (oLiv.IsDecisionJuryPartielle)
                        {
                            foreach (DCLivretVM oDC in oLiv.lstDCLivretAValider)
                            {
                                // Si un DC a une décision Favorable
                                if (oDC.IsDecisionFavorable.HasValue && oDC.IsDecisionFavorable.Value)
                                {
                                    bReturn = true;
                                    break;
                                }
                            } // Foreach lstDCaValider
                            if (bReturn)
                            {
                                // Un Dc a une décision favorable => pas la pein d'aller plus loin
                                break;
                            }
                        }
                    }// foreach lstLivret2
                }
            }



            return bReturn;
        }//IsValide

        /// <summary>
        ///  Rend Vrai si le livret est TOLERE
        ///  Date Validité dépassé mais encore dans le delai de validation
        /// </summary>
        /// <returns></returns>
        public Boolean IsTolere
        {
            get
            {
                Boolean bReturn = false;

                DateTime dDateValid;
                if (DateValidite < DateTime.Now)
                {
                    Int32 nDelai = new ContextParam().dbParam.First().DelaiValiditeL1;
                    dDateValid = DateValidite.Value.AddDays(nDelai);
                    bReturn = (IsEtatAccepte && dDateValid > DateTime.Now);

                }
                return bReturn;
            }
        }//IsTolere

        /// <summary>
        /// Un livret1 est Encours s'il est non clos avec une date de validité > now
        /// </summary>
        /// <returns></returns>
        public Boolean IsEncours()
        {
            return (IsLivretNonClos  && DateValidite > DateTime.Now);
        }

        public String TypeDemande
        {
            get
            {
                return oL1.TypeDemande;
            }
            set
            {
                if (value != TypeDemande)
                {
                    oL1.TypeDemande = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String VecteurInformation
        {
            get
            {
                return oL1.VecteurInformation;
            }
            set
            {
                if (value != VecteurInformation)
                {
                    oL1.VecteurInformation   = value;
                    RaisePropertyChanged();
                }
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
        public override List<PieceJointeCategorie> lstCategoriePJ
        {
            get
            {
                return (from item in _ctxParam.pieceJointeCategories
                        where item.Livret == "L1"
                        select item).ToList();
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
                    if (IsEtatRecu && value != null)
                    {
                        DateLimiteJury = DateReceptEHESPComplet.Value.AddDays(Properties.Settings.Default.DelaiJuryL1);
                    }

                }
            }
        }
        
        public DateTime? DateReceptionPiecesManquantes
        {
            get { return oL1.DateReceptionPiecesManquantes; }
            set
            {
                if (value != DateReceptionPiecesManquantes)
                {
                    oL1.DateReceptionPiecesManquantes = value;
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
                    RaisePropertyChanged("IsDate1ereDemandePieceManquantesNull");

                }
            }
        }
        public Boolean IsDate1ereDemandePieceManquantesNull
        {
            get
            {
                return Date1ereDemandePieceManquantes.HasValue;
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
                    RaisePropertyChanged("IsDate2emeDemandePieceManquantesNull");
                }
            }
        }

        public Boolean IsDate2emeDemandePieceManquantesNull
        {
            get
            {
                return Date2emeDemandePieceManquantes.HasValue;
            }
        }
        public DateTime? DateDemande1erRetour
        {
            get { return oL1.DateDemande1erRetour; }
            set
            {
                if (value != DateDemande1erRetour)
                {
                    oL1.DateDemande1erRetour = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? DateDemande2emeRetour
        {
            get { return oL1.DateDemande2emeRetour; }
            set
            {
                if (value != DateDemande2emeRetour)
                {
                    oL1.DateDemande2emeRetour = value;
                    RaisePropertyChanged();

                }
            }
        }
        public Boolean IsCNIOK
        {
            get { return oL1.IsCNIOK; }
            set
            {
                if (value != IsCNIOK)
                {
                    oL1.IsCNIOK = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DateValiditeCNI
        {
            get { return oL1.DateValiditeCNI; }
            set
            {
                if (value != DateValiditeCNI)
                {
                    oL1.DateValiditeCNI = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? DateEnvoiL2
        {
            get { return oL1.DateEnvoiL2; }
            set
            {
                if (value != DateEnvoiL2)
                {
                    oL1.DateEnvoiL2 = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override DateTime? DateJury
        {
            get
            {
                return base.DateJury;
            }
            set
            {
                if (value != DateJury)
                {
                    base.DateJury = value;
                    if (value != null)
                    {
                        CalcDateValidite();
                        DateLimiteRecours = value.Value.AddMonths(Properties.Settings.Default.DelaiDepotRecours);
                    }
                    RaisePropertyChanged();

                }
            }
        }
        public override DateTime? DateNotificationJury
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
                if (value != null)
                {
                    CalcDateValidite();
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
                if (oJury != null)
                {
                   return oJury.Nom;
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
                    if (oJury ==null)
                    {
                        lstJuryVM.Add(new JuryVM());
                    }

                    lstJuryVM[0].Nom = value;

                    RaisePropertyChanged();
                }
            }
        }


        public override void Commit()
        {
            base.Commit();
            // Validation des PiècesJointes L2
            foreach (PieceJointeLivretVM item in lstPieceJointe)
            {
                PieceJointeL1 oPJ = (PieceJointeL1)item.ThePiecejointe;
                if (item.IsDeleted)
                {
                    if (!item.IsNew)
                    {
                        // Il faut faire les suppression sur les DBSets !!!!
                        _ctx.PieceJointeL1.Remove(oPJ);
                    }
                    item.IsDeleted = false;
                    item.IsNew = false;
                }
                else
                {
                    if (item.IsNew)
                    {
                        oL1.lstPiecesJointes.Add(oPJ);
                    item.IsNew = false;
                    }
                }
            }

        }

        public override void ClearDCs()
        {
            foreach (PieceJointeLivretVM oItem in lstPieceJointe)
            {
                DbEntityEntry<PieceJointeL1> odb = _ctx.Entry<PieceJointeL1>((PieceJointeL1)oItem.ThePiecejointe);
                if (oItem.IsNew)
                { 
                    odb.State = System.Data.Entity.EntityState.Detached;
                }
                    else
                    {
                        odb.State = System.Data.Entity.EntityState.Deleted;
                    }

            }

            while (oL1.lstJurys.Count>0)
            {
                oL1.lstJurys.RemoveAt(0);
            }
        }

        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Livret1> entry = _ctx.Entry<Livret1>(oL1);
            return entry;
        }
        protected override void setEtatLivret()
        {
            String strEtat = EtatLivret;
            String strKey = "";
            if (IsDecisionJuryFavorable || (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursFavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_ACCEPTE);
            }
            if ((IsDecisionJuryDefavorable && !IsRecoursDemande) ||
                (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursDefavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_REFUSE);
            }
            if (!String.IsNullOrEmpty(strKey))
            {
                if (LstEtatLivret != null)
                {
                    strEtat = LstEtatLivret.Find(x => x.StartsWith(strKey));
                    EtatLivret = strEtat;
                }
            }
            if (IsEtatSansSuite)
            {
                IsLivretClos = true;
            }
        }

        public override bool IsValiderOK()
        {
            return IsLocked;
        }
    }
}
