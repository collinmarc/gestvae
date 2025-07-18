﻿using GestVAEcls;
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

        /// <summary>
        /// Clonage de l'objet
        /// NB: on ne peut utiliser le MemberwiseClone car il faut recréer une nouvelle entity
        /// </summary>
        /// <returns></returns>
        public Livret1VM(Livret1VM pLivAncien) : base(pLivAncien.IsLocked)
        {
            this.TheItem = (Livret)new Livret1(); // Recréation de l'entité
            this.TheLivret.oDiplome = Diplome.getDiplomeParDefaut(); // Diplome CAFDESV2
            // Création des Blocs à partir du Diplome par defaut
            foreach (DomaineCompetence oDC in Diplome.getDiplomeParDefaut().lstDomainesCompetences)
            {
                DCLivretVM oDCLivretVM = new DCLivretVM(new DCLivret(oDC));
                oDCLivretVM.IsAValider = true;
                this.lstDCLivret.Add(oDCLivretVM);
                this.TheLivret.lstDCLivrets.Add(oDCLivretVM.TheDCLivret);

            }
            // Transfert des blocs de CAFDES vers CAFDESV2  (Normalement il n'y en a pas)
            foreach (DCLivretVM item in pLivAncien.lstDCLivret)
            {
                DCLivretVM oItemNew = this.lstDCLivret.First(d => d.NumDC == item.NumDC);
                if (!pLivAncien.IsCAFDESV2)
                {
                    oItemNew = this.lstDCLivret.First(d => d.NumDC == item.getNumBlocV2());
                }
                oItemNew.IsAValider = item.IsAValider;
                oItemNew.Commentaire = item.Commentaire;
                oItemNew.Decision = item.Decision;
                oItemNew.DateObtention = item.DateObtention;
                oItemNew.ModeObtention = item.ModeObtention;
                oItemNew.PropositionDecision = item.PropositionDecision;
                oItemNew.Statut = item.Statut;
            }

            // Recopie des attributs
            this.Numero = pLivAncien.Numero;
            this.DateDemande = pLivAncien.DateDemande;
            this.DateLimiteReceptEHESP = pLivAncien.DateLimiteReceptEHESP;
            this.Date1ereDemandePieceManquantes = pLivAncien.Date1ereDemandePieceManquantes;
            this.Date2emeDemandePieceManquantes = pLivAncien.Date2emeDemandePieceManquantes;
            this.TypeDemande = pLivAncien.TypeDemande;
            //            this.DatePrevJury1 = pLivAncien.DatePrevJury1;
            //            this.DatePrevJury2 = pLivAncien.DatePrevJury2;
            //            this.SessionJury = pLivAncien.SessionJury;
            this.DateLimiteJury = pLivAncien.DateLimiteJury;
//            this.IsAttestationOK = pLivAncien.IsAttestationOK;
            this.IsCNIOK = pLivAncien.IsCNIOK;
           //this.IsDispenseArt2 = pLivAncien.IsDispenseArt2;
            this.IsContrat = pLivAncien.IsContrat;
            this.EtatLivret = pLivAncien.EtatLivret;
            this.DateEnvoiEHESP = pLivAncien.DateEnvoiEHESP;
            //this.DateEnvoiCandidat = pLivAncien.DateEnvoiCandidat;
            this.DateReceptEHESP = pLivAncien.DateReceptEHESP;
            this.DateReceptEHESPComplet = pLivAncien.DateReceptEHESPComplet;
            this.IsLivretClos = pLivAncien.IsLivretClos;
            //this.DateEnvoiCourrierJury = pLivAncien.DateEnvoiCourrierJury;
            this.DateDemande1erRetour = pLivAncien.DateDemande1erRetour;
            this.DateDemande2emeRetour = pLivAncien.DateDemande2emeRetour;
            this.IsConvention = pLivAncien.IsConvention;
            this.IsNonRecu = pLivAncien.IsNonRecu;
            this.DateValiditeCNI = pLivAncien.DateValiditeCNI;
            this.IsEnregistre = pLivAncien.IsEnregistre;
            this.IsPaye = pLivAncien.IsPaye;
            //this.IsTrtSpecial = pLivAncien.IsTrtSpecial;
            this.DateValidite = pLivAncien.DateValidite;
            this.DateReceptionPiecesManquantes = pLivAncien.DateReceptionPiecesManquantes;
            this.DateEnvoiL2 = pLivAncien.DateEnvoiL2;
            this.VecteurInformation = pLivAncien.VecteurInformation;

            this.lstJuryVM.Clear();
            foreach (JuryVM item in pLivAncien.lstJuryVM)
            {
                JuryVM oItemNew = new JuryVM();
                oItemNew.NumeroOrdre = item.NumeroOrdre;
                oItemNew.Nom = item.Nom;
                oItemNew.DateJury = item.DateJury;
                oItemNew.HeureJury = item.HeureJury;
                oItemNew.HeureConvoc = item.HeureConvoc;
                oItemNew.DateLimiteRecours = item.DateLimiteRecours;
                oItemNew.LieuJury = item.LieuJury;
                oItemNew.Decision = item.Decision;
                oItemNew.MotifGeneral = item.MotifGeneral;
                oItemNew.MotifDetail = item.MotifDetail;
                oItemNew.MotifCommentaire = item.MotifCommentaire;
                oItemNew.DateNotificationJury = item.DateNotificationJury;
                oItemNew.DateNotificationJury = item.DateNotificationJuryRecours;

                this.lstJuryVM.Add(oItemNew);
            }

            //_lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();
            //this.lstMembreJury.Clear();
            //foreach (MembreJuryVM item in pLivAncien.lstMembreJury)
            //{
            //    MembreJuryVM oItemNew = new MembreJuryVM();
            //    oItemNew.Nom = item.Nom;
            //    oItemNew.College = item.College;
            //    oItemNew.Region = item.Region;
            //    oItemNew.DptDomicile = item.DptDomicile;
            //    oItemNew.DptTravail = item.DptTravail;

            //    this.lstMembreJury.Add(oItemNew);
            //}


            this.lstPieceJointe.Clear();
            foreach (PieceJointeLivretVM item in pLivAncien.lstPieceJointe)
            {
                PieceJointeLivretVM itemNew = new PieceJointeLivretVM(pLivAncien.Typestr);
                itemNew.Categorie = item.Categorie;
                itemNew.Libelle = item.Libelle;
                itemNew.IsRecu = item.IsRecu;
                itemNew.IsOK = item.IsOK;

                this.lstPieceJointe.Add(itemNew);
            }
        } // Livret1VM()

        public void Cloturer()
        {
            IsLivretClos = true;
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
                    RaisePropertyChanged("IsEtatRecuCompletCAFDESV2");
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
            Boolean bIsL1Valide = false;
            bIsL1Valide = IsEtatAccepte && (!IsLivretClos); // Valide = Accepté et Non clos

            ////            bReturn = (IsEtatAccepte && DateValidite > DateTime.Now);
            //DateTime dDateValid = DateTime.Now;
            //Int32 nDelai = new ContextParam() .dbParam.First().DelaiValiditeL1;
            //if (DateValidite.HasValue)
            //{
            //    dDateValid = DateValidite.Value.AddDays(nDelai);
            //}
            //bIsL1Valide = (IsEtatAccepte && (dDateValid > DateTime.Now));

            //if (bIsL1Valide)
            //{
            //    if (IsEtatAccepte)
            //    {
            //        // Si le L1 est accepté
            //        // Récupération du diplome du candidat
            //        CandidatVM oCand = pCand;
            //        DiplomeCandVM oDiplomeCand = oCand.lstDiplomesCandVMsActifs.FirstOrDefault(oD => oD.oDiplome.Nom == NomDiplome);
            //        Boolean bTousLesBlocsDemandesSontValide = false;
            //        if (oDiplomeCand != null)
            //        {
            //            bTousLesBlocsDemandesSontValide = lstDCLivretAValider.All(item =>
            //                                {
            //                                    var oDCCand = oDiplomeCand.lstDCCands.FirstOrDefault(d => d.NomDomaineCompetence == item.NomDC);
            //                                    return oDCCand != null && oDCCand.Statut == "Validé";
            //                                }
            //                                );
            //        }
            //        // Il n'est plus valide si tous des Blocs sont validés 
            //        bIsL1Valide = !bTousLesBlocsDemandesSontValide;
            //    }
            //}



            return bIsL1Valide;
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
                oReturn.Add("");
                oReturn.Add(String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE));
                oReturn.Add(String.Format("{0:D}-Partielle", MyEnums.DecisionJuryL1.DECISION_L1_PARTIELLE));
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE));
                return oReturn;
            }
            set { }
        }
        /// <summary>
        /// défintion des Liste des motifs 
        /// </summary>
        private ObservableCollection<MotifGeneralL2> _lstMotifGL2;
        public ObservableCollection<MotifGeneralL2> lstMotifGL2
        {
            get { return _lstMotifGL2; }
            set { _lstMotifGL2 = value; }
        }
        private ObservableCollection<MotifGeneralL1> _lstMotifGL1;
        public ObservableCollection<MotifGeneralL1> lstMotifGL1
        {
            get { return _lstMotifGL1; }
            set { _lstMotifGL1 = value; }
        }

        public List<String> listeStatutsBloc
        {
            get
            {
                return DiplomeCandVM.LstStatutModule;
            }
            set {}
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
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
            if (IsDecisionJuryFavorable || 
                (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursFavorable) || 
                IsDecisionJuryPartielle)
                {
                    strKey = String.Format("{0:D}", MyEnums.EtatLivret.ETAT_Lv_ACCEPTE);
                }
            if ((IsDecisionJuryDefavorable && !IsRecoursDemande) ||
                (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursDefavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatLivret.ETAT_Lv_REFUSE);
            }
            if (!String.IsNullOrEmpty(strKey))
            {
                if (LstEtatLivret != null)
                {
                    strEtat = LstEtatLivret.Find(x => x.StartsWith(strKey));
                    EtatLivret = strEtat;
                }
            }
            if (IsEtatIrrecevable)
            {
                IsLivretClos = true;
            }
        }
        public override void  CalcDecisionJury()
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

        public override bool IsValiderOK()
        {
            return IsLocked;
        }
        public override CandidatVM GetCandidatVM()
        {
            if (oL1.oCandidat != null)
            {
                return new CandidatVM(oL1.oCandidat);
            }
            else
            {
                return null;
            }

        }

    }
}
