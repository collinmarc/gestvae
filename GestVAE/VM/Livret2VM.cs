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

        private ObservableCollection<MembreJuryVM> _lstMembreJuryVM;
        public ObservableCollection<MembreJuryVM> lstMembreJury{
            get
            {
                return _lstMembreJuryVM;
            }
        }
        public List<MembreJuryVM> lstMembreJuryActif
        {
            get
            {
                return lstMembreJury.Where(m=>!m.IsDeleted).ToList();
            }
        }
        public Livret2VM(Livret2 pLivret) :  base(pLivret)
        {
            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();

            foreach (PieceJointeL2 opj in pLivret.lstPiecesJointes)
            {
                lstPieceJointe.Add(new PieceJointeLivretVM(opj, "L2"));
            }


            foreach (MembreJury oItem in pLivret.lstMembreJurys)
            {
                lstMembreJury.Add(new MembreJuryVM(oItem));
            }

        }


        public Livret2VM(Boolean pIsCandidatLocked) : base(pIsCandidatLocked)
        {
            Livret oReturn = null;

            oReturn = new Livret2();
            oReturn.oDiplome = Diplome.getDiplomeParDefaut();
            TheItem = oReturn;

            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();

            //foreach (DomaineCompetence item in TheLivret.oDiplome.lstDomainesCompetences)
            //{
            //    DCLivretVM oDCLivret = new DCLivretVM();
            //    oDCLivret.TheDCLivret.oDomaineCompetence = item;
            //    lstDCLivret.Add(oDCLivret);
            //}


        }


        /// <summary>
        /// création d'un livret2 à partir d'un livret1
        /// </summary>
        /// <param name="pL1"></param>
        public Livret2VM(Livret1VM pL1) : base(pL1.IsLocked)
        {
            Livret oReturn = null;

            oReturn = new Livret2();
            oReturn.oDiplome = pL1.TheLivret.oDiplome;
            TheItem = oReturn;

            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();

            this.Numero = pL1.Numero;
            this.DateValidite = pL1.DateValidite;
            this.DateLimiteReceptEHESP = pL1.DateValidite;
            if (pL1.IsRecoursDemande)
            {
                this.IsOuvertureApresRecours = true;
            }
            if (pL1.DateEnvoiL2.HasValue)
            {
                this.DateEnvoiEHESP = pL1.DateEnvoiL2;
            }
            else
            {
                pL1.DateEnvoiL2 = DateTime.Today;
                this.DateEnvoiEHESP = DateTime.Today;
            }
            this.IsContrat = pL1.IsContrat;
            this.IsConvention = pL1.IsConvention;
            this.IsNonRecu = pL1.IsNonRecu;
            this.IsCNIOK = pL1.IsCNIOK;
            this.DateValiditeCNI = pL1.DateValiditeCNI;
            this.IsEnregistre = false;
            this.IsPaye = false;

            // Transfert des blocs Validé depuis le Livret1 vers le Livret2
            foreach (DCLivretVM item in pL1.lstDCLivretAValider)
            {
                if (item.IsDecisionFavorable.HasValue && item.IsDecisionFavorable.Value)
                {
                    DCLivretVM oDCLivret = new DCLivretVM();
                    oDCLivret.TheDCLivret.oDomaineCompetence = item.TheDCLivret.oDomaineCompetence;
                    oDCLivret.IsAValider = true;
                    oDCLivret.MotifCommentaire = item.MotifCommentaire;
                    if (pL1.GetCandidatVM().IsCAFERUIS && oDCLivret.NomDC == "BLOC4")
                    {
                        oDCLivret.Decision = DecisionL2ModuleFavorable;
                        oDCLivret.PropositionDecision = oDCLivret.Decision;
                    }
                    if (pL1.GetCandidatVM().IsDEIS && (oDCLivret.NomDC == "BLOC1" || oDCLivret.NomDC == "BLOC4"))
                    {
                        oDCLivret.Decision = DecisionL2ModuleFavorable;
                        oDCLivret.PropositionDecision = oDCLivret.Decision;
                    }


                    this.lstDCLivret.Add(oDCLivret);
                    // Ajout de l'entité DB
                    TheLivret.lstDCLivrets.Add(oDCLivret.TheDCLivret);
                }

            }
        }
        /// <summary>
        /// Clonage de l'objet
        /// NB: on ne peut utiliser le MemberwiseClone car il faut recréer une nouvelle entity
        /// </summary>
        /// <returns></returns>
        public Livret2VM (Livret2VM pLivAncien) : base(pLivAncien.IsLocked)
        {
            this.TheItem = (Livret)new Livret2(); // Recréation de l'entité
            this.TheLivret.oDiplome = Diplome.getDiplomeParDefaut(); // Diplome CAFDESV2
            // Création des Blocs à partir du Diplome par defaut
            foreach (DomaineCompetence oDC in Diplome.getDiplomeParDefaut().lstDomainesCompetences)
            {
                DCLivretVM oDCLivretVM = new DCLivretVM(new DCLivret(oDC));
                this.lstDCLivret.Add(oDCLivretVM);
                this.TheLivret.lstDCLivrets.Add(oDCLivretVM.TheDCLivret);
            }
            // Transfert des blocs de CAFDES V2 vers CAFDESV2
            foreach (DCLivretVM item in pLivAncien.lstDCLivret)
            {
                DCLivretVM oItemNew;
                if (!pLivAncien.IsCAFDESV2)
                {
                    oItemNew = this.lstDCLivret.First(d => d.NumDC == item.getNumBlocV2());
                }
                else
                {
                    oItemNew = this.lstDCLivret.First(d => d.NumDC == item.NumDC);
                }
                oItemNew.IsAValider = item.IsAValider;
                oItemNew.Commentaire = item.Commentaire;
                oItemNew.Decision = item.Decision;
                oItemNew.DateObtention = item.DateObtention;
                oItemNew.ModeObtention = item.ModeObtention;
                oItemNew.PropositionDecision = item.PropositionDecision;
                oItemNew.MotifCommentaire = item.MotifCommentaire;
                oItemNew.Statut = item.Statut;
                lstDCLivret.Add(oItemNew);
            }

            // Recopie des attributs
            this.Numero = pLivAncien.Numero;
            this.NumPassage = pLivAncien.NumPassage;
            this.IsOuvertureApresRecours = pLivAncien.IsOuvertureApresRecours;
            this.DateDemande = pLivAncien.DateDemande;
            this.DateLimiteReceptEHESP = pLivAncien.DateLimiteReceptEHESP;
            this.Date1ereDemandePieceManquantes = pLivAncien.Date1ereDemandePieceManquantes;
            this.Date2emeDemandePieceManquantes = pLivAncien.Date2emeDemandePieceManquantes;
            this.DateReceptionPiecesManquantes = pLivAncien.DateReceptionPiecesManquantes;
            this.DatePrevJury1 = pLivAncien.DatePrevJury1;
            this.DatePrevJury2 = pLivAncien.DatePrevJury2;
            this.SessionJury = pLivAncien.SessionJury;
            this.DateLimiteJury = pLivAncien.DateLimiteJury;
            this.IsAttestationOK = pLivAncien.IsAttestationOK;
            this.IsCNIOK = pLivAncien.IsCNIOK;
            this.IsDispenseArt2 = pLivAncien.IsDispenseArt2;
            this.IsContrat = pLivAncien.IsContrat;
            this.EtatLivret = pLivAncien.EtatLivret;
            this.DateEnvoiEHESP = pLivAncien.DateEnvoiEHESP;
            this.DateEnvoiCandidat = pLivAncien.DateEnvoiCandidat;
            this.DateReceptEHESP = pLivAncien.DateReceptEHESP;
            this.DateReceptEHESPComplet = pLivAncien.DateReceptEHESPComplet;
            this.IsLivretClos = pLivAncien.IsLivretClos;
            this.DateEnvoiCourrierJury = pLivAncien.DateEnvoiCourrierJury;
            this.DateDemande1erRetour = pLivAncien.DateDemande1erRetour;
            this.DateDemande2emeRetour = pLivAncien.DateDemande2emeRetour;
            this.IsConvention = pLivAncien.IsConvention;
            this.IsNonRecu = pLivAncien.IsNonRecu;
            this.DateValiditeCNI = pLivAncien.DateValiditeCNI;
            this.IsEnregistre = pLivAncien.IsEnregistre;
            this.IsPaye = pLivAncien.IsPaye;
            this.IsTrtSpecial = pLivAncien.IsTrtSpecial;
            this.DateValidite = pLivAncien.DateValidite;
            this.DateNotificationJury = pLivAncien.DateNotificationJury;


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
                oItemNew.DateNotificationJuryRecours = item.DateNotificationJuryRecours;

                this.lstJuryVM.Add(oItemNew);
            }

            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();
            this.lstMembreJury.Clear();
            foreach (MembreJuryVM item in pLivAncien.lstMembreJury)
            {
                MembreJuryVM oItemNew = new MembreJuryVM();
                oItemNew.Nom = item.Nom;
                oItemNew.College = item.College;
                oItemNew.Region = item.Region;
                oItemNew.DptDomicile = item.DptDomicile;
                oItemNew.DptTravail = item.DptTravail;

                this.lstMembreJury.Add(oItemNew);
            }


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
        } // Livret2CM()


        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Livret2> entry = _ctx.Entry<Livret2>(oL2);
            return entry;
        }


        public override String Numero
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
        public Boolean IsTrtSpecial
        {
            get { return oL2.IsTrtSpecial; }
            set
            {
                if (value != IsTrtSpecial)
                {
                    oL2.IsTrtSpecial = value;
                    RaisePropertyChanged();
                }
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
                oReturn.Add(String.Format("{0:D}-Validation totale", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE));
                oReturn.Add(String.Format("{0:D}-Refus de validation", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE));
                oReturn.Add(String.Format("{0:D}-Validation partielle", MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE));
                return oReturn;
            }
            set { }
        }
        public String DecisionL2ModuleFavorable { get { return LstDecisionL2Module[0]; } }
        public String DecisionL2ModuleDeFavorable { get { return LstDecisionL2Module[1]; } }
        public List<String> LstDecisionL2Module
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Validation", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE));
                oReturn.Add(String.Format("{0:D}-Refus de validation", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE));
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
                    RaisePropertyChanged("DateEnvoiColor");
                    
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

        public DateTime? DateEnvoiCourrierJury
        {
            get { return oL2.DateEnvoiCourrierJury; }
            set
            {
                if (value != DateEnvoiCourrierJury)
                {
                    oL2.DateEnvoiCourrierJury = value;
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
                    if (DatePrevJury1.HasValue)
                    {
                            DatePrevJury2 = DatePrevJury1.Value.AddDays(1);

                    }
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
        public DateTime? DateDemande1erRetour
        {
            get { return oL2.DateDemande1erRetour; }
            set
            {
                if (value != DateDemande1erRetour)
                {
                    oL2.DateDemande1erRetour = value;
                    RaisePropertyChanged();

                }
            }
        }
        public DateTime? DateDemande2emeRetour
        {
            get { return oL2.DateDemande2emeRetour; }
            set
            {
                if (value != DateDemande2emeRetour)
                {
                    oL2.DateDemande2emeRetour = value;
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
        public DateTime? DateValiditeCNI
        {
            get { return oL2.DateValiditeCNI; }
            set
            {
                if (value != DateValiditeCNI)
                {
                    oL2.DateValiditeCNI = value;
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
                //uniquement dans le cas du livret1
                //if (value != null)
                //{
                //    DateValidite = value.Value.AddYears(Properties.Settings.Default.DelaiValidite);
                //}

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



        public override void Commit()
        {
            base.Commit();

            // Validation des PiècesJointes L2
            foreach (PieceJointeLivretVM item in lstPieceJointe)
            {
                    PieceJointeL2 oPJ = (PieceJointeL2)item.ThePiecejointe;
                    if (item.IsDeleted)
                    {
                    // il faut faire les suppressions sur les dbSet
                        if (!item.IsNew)
                        {
                        _ctx.PieceJointeL2.Remove(oPJ);
                        }
                        item.IsDeleted = false;
                        item.IsNew = false;
                    }
                    else
                    {
                        if (item.IsNew)
                        {
                            oL2.lstPiecesJointes.Add(oPJ);
                        }
                        item.IsNew = false;
                    }
            }
            foreach (MembreJuryVM item in lstMembreJury)
            {
                MembreJury oMJ = (MembreJury)item.TheMembreJury;
                if (item.IsDeleted)
                {
                    if (!item.IsNew)
                    {
                        _ctx.MembreJuries.Remove(oMJ);
                    }
                    item.IsDeleted = false;
                    item.IsNew = false;
                }
                else
                {
                    if (item.IsNew)
                    {
                        oL2.lstMembreJurys.Add(oMJ);
                    }
                    item.IsNew = false;
                }
            }

        }



        public override  List<PieceJointeCategorie> lstCategoriePJ
        {
            get
                {

                return (from item in _ctxParam.pieceJointeCategories
                        where item.Livret == "L2"
                        select item).ToList();
            }
        }

        public List<String> LstMotifGL2
        {
            get
            {
                return (from item in _ctxParam.dbMotifGeneralL2
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
            //foreach (DCLivretVM oItem in lstDCLivret)
            //{
            //    if (oItem.IsNew)
            //    {
            //        _ctx.Entry<DCLivret>((DCLivret)oItem.TheDCLivret).State = System.Data.Entity.EntityState.Detached;
            //    }
            //    else
            //    {
            //        _ctx.Entry<DCLivret>((DCLivret)oItem.TheDCLivret).State = System.Data.Entity.EntityState.Deleted;
            //    }

            //}
            //foreach (MembreJuryVM oItem in _lstMembreJuryVM)
            //{
            //    if (oItem.IsNew)
            //    {
            //        _ctx.Entry<MembreJury>((MembreJury)oItem.TheItem).State = System.Data.Entity.EntityState.Detached;
            //    }
            //    else
            //    {
            //        _ctx.Entry<MembreJury>((MembreJury)oItem.TheItem).State = System.Data.Entity.EntityState.Deleted;
            //    }

            //}

        }
        protected override void setEtatLivret()
        {
            String strEtat = EtatLivret;
            String strKey = "";
            if (IsDecisionJuryFavorable || (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursFavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatLivret.ETAT_Lv_ACCEPTE);
            }
            if (IsDecisionJuryDefavorable )
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
            if (IsEtatSansSuite)
            {
                IsLivretClos = true;
            }

        }
        /// <summary>
        /// Rend le numéro de l'onglet a Afficher par défaut
        /// </summary>
        public Int32 getNumTab
        {
            get
            {
                if (IsEtatRecuComplet)
                    return 1;
                else
                    return 0;
            }
        }

        public override void DeleteMembreJury()

        {
            if (SelectedMembreJ != null)
            {
                MembreJuryVM oMembreJ = SelectedMembreJ;
                SelectedMembreJ.IsDeleted = true;
                RaisePropertyChanged("lstMembreJury");
                RaisePropertyChanged("lstMembreJuryActif");
            }
        }
        public override void AjouterMembreJury()
        {
            lstMembreJury.Add(new MembreJuryVM() { Nom = "[nouveau]" });
            RaisePropertyChanged("lstMembreJury");
            RaisePropertyChanged("lstMembreJuryActif");
        }

        public override bool IsValiderOK()
        {
            Boolean bReturn = false;
            if (IsLocked)
            {
                if (IsEtatRecu)
                {
                    if (DateEnvoiCandidat != null)
                    {
                        //if (DateEnvoiCandidat < DateValidite)
                        //{
                            bReturn = true;
                        //}
                    }
                }
                else
                {
                    bReturn = true;
                }
            }
            return bReturn;
        }

        public String DateEnvoiColor
        {
            get
            {
                if (!DateEnvoiCandidat.HasValue)
                {
                    return "red";

                }
                else
                {
                    return "green";
                }
            }
        }
        public override void CalcDateValidite()
        {
        }


        public String MotifIrrecevabilité
        {
            get { return Jury1er.MotifCommentaire; }
            set { Jury1er.MotifCommentaire = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Clonage de l'objet
        /// NB: on ne peut utiliser le MemberwiseClone car il faut recréer une nouvelle entity
        /// </summary>
        /// <returns></returns>
        object Clone()
        {
            Livret2VM oL2new = new Livret2VM(this.IsLocked);
            oL2new.TheItem = (Livret)new Livret2(); // Recréation de l'entité
            oL2new.TheLivret.oDiplome = Diplome.getDiplomeParDefaut(); // Diplome CAFDESV2
            // Création des Blocs à partir du Diplome
            foreach (DomaineCompetence oDC in Diplome.getDiplomeParDefaut().lstDomainesCompetences)
            {
                DCLivretVM oDCLivretVM = new DCLivretVM(new DCLivret(oDC));
                oL2new.lstDCLivret.Add(oDCLivretVM);
            }
            // Transfert des blocs de CAFDES V2 vers CAFDESV2
            foreach (DCLivretVM item in this.lstDCLivret)
            {
                DCLivretVM oItemNew = oL2new.lstDCLivret.First(d => d.NumDC == item.NumDC);
                if (!this.IsCAFDESV2)
                {
                    oItemNew = oL2new.lstDCLivret.First(d => d.NumDC == item.getNumBlocV2());
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
            oL2new.Numero = this.Numero;
            oL2new.NumPassage = this.NumPassage;
            oL2new.IsOuvertureApresRecours = this.IsOuvertureApresRecours;
            oL2new.DateDemande = this.DateDemande;
            oL2new.DateLimiteReceptEHESP = this.DateLimiteReceptEHESP;
            oL2new.Date1ereDemandePieceManquantes = this.Date1ereDemandePieceManquantes;
            oL2new.Date2emeDemandePieceManquantes = this.Date2emeDemandePieceManquantes;
            oL2new.DateReceptionPiecesManquantes = this.DateReceptionPiecesManquantes;
            oL2new.DatePrevJury1 = this.DatePrevJury1;
            oL2new.DatePrevJury2 = this.DatePrevJury2;
            oL2new.SessionJury = this.SessionJury;
            oL2new.DateLimiteJury = this.DateLimiteJury;
            oL2new.DateValidite = this.DateValidite;
            oL2new.IsAttestationOK = this.IsAttestationOK;
            oL2new.IsCNIOK = this.IsCNIOK;
            oL2new.IsDispenseArt2 = this.IsDispenseArt2;
            oL2new.IsContrat = this.IsContrat;
            oL2new.EtatLivret = this.EtatLivret;
            oL2new.DateEnvoiEHESP = this.DateEnvoiEHESP;
            oL2new.DateEnvoiCandidat = this.DateEnvoiCandidat;
            oL2new.DateReceptEHESP = this.DateReceptEHESP;
            oL2new.DateReceptEHESPComplet = this.DateReceptEHESPComplet;
            oL2new.IsLivretClos = this.IsLivretClos;
            oL2new.DateEnvoiCourrierJury = this.DateEnvoiCourrierJury;
            oL2new.DateDemande1erRetour = this.DateDemande1erRetour;
            oL2new.DateDemande2emeRetour = this.DateDemande2emeRetour;
            oL2new.IsConvention = this.IsConvention;
            oL2new.IsNonRecu = this.IsNonRecu;
            oL2new.DateValiditeCNI = this.DateValiditeCNI;
            oL2new.IsEnregistre = this.IsEnregistre;
            oL2new.IsPaye = this.IsPaye;
            oL2new.IsTrtSpecial = this.IsTrtSpecial;


            oL2new.lstJuryVM.Clear();
            foreach (JuryVM item in this.lstJuryVM)
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
                oItemNew.DateNotificationJury = item.DateNotificationJuryRecours ;

                oL2new.lstJuryVM.Add(oItemNew);
            }

            oL2new.lstMembreJury.Clear();
            foreach (MembreJuryVM item in this.lstMembreJury)
            {
                MembreJuryVM oItemNew = new MembreJuryVM();
                oItemNew.Nom = item.Nom;
                oItemNew.College = item.College;
                oItemNew.Region = item.Region;
                oItemNew.DptDomicile = item.DptDomicile;
                oItemNew.DptTravail = item.DptTravail;

                oL2new.lstMembreJury.Add(oItemNew);
            }


            oL2new.lstPieceJointe.Clear();
            foreach (PieceJointeLivretVM item in this.lstPieceJointe)
            {
                PieceJointeLivretVM itemNew = new PieceJointeLivretVM(this.Typestr);
                itemNew.Categorie = item.Categorie;
                itemNew.Libelle = item.Libelle;
                itemNew.IsRecu = item.IsRecu;
                itemNew.IsOK = item.IsOK;
            }


            return oL2new;

        }

        public override CandidatVM GetCandidatVM()
        {
            return new CandidatVM(oL2.oCandidat);

        }
        public override void CalcDecisionJury()
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
                    DecisionJury = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE);
                }
                if (nDCFavorable == 0 && nDCdeFavorable > 0)
                {
                    DecisionJury = String.Format("{0:D}-Défavorable", MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
                }
                if (nDCFavorable > 0 && nDCdeFavorable > 0)
                {
                    DecisionJury = String.Format("{0:D}-Partielle", MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE);
                }
            }

        }
    }
}
