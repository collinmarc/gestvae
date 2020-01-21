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


        public Livret2VM(Boolean pIsCandidatLocked) : base(pIsCandidatLocked)
        {
            Livret oReturn = null;

            oReturn = new Livret2();
            oReturn.oDiplome = Diplome.getDiplomeParDefaut();
            TheItem = oReturn;

            lstDCLivret = new ObservableCollection<DCLivretVM>();
            _lstMembreJuryVM = new ObservableCollection<MembreJuryVM>();
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Livret2> entry = _ctx.Entry<Livret2>(oL2);
            return entry;
        }

        public String NomDiplome
        {
            get
            {
                if (TheLivret.oDiplome == null)
                {
                    return "";
                }
                else
                {
                    return TheLivret.oDiplome.Nom;
                }
            }
        }
        public String StatutDiplomeCandidat
        {
            get
            {
                DiplomeCandVM oDip = getCurrentCandidat().lstDiplomesCandVMs.Where(d => d.oDiplome.ID == TheLivret.oDiplome.ID).FirstOrDefault();
                if (oDip != null)
                {
                    return oDip.StatutDiplome;
                }
                else
                {
                    return "";
                }
            }
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

        public String NumeroDiplome
        {
            get
            {
                return oL2.NumDiplome;
            }
            set
            {
                if (value != NumeroDiplome)
                {
                    oL2.NumDiplome = value;
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
        public Boolean IsDecisionJuryPartielle
        {
            get
            {
                return ((getNumDecisionJury() >= (int)MyEnums.DecisionJuryL2.DECISION_L2_PARTIELLE));
            }
        }



        public override void Commit()
        {
            base.Commit();

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
            foreach (MembreJuryVM oItem in _lstMembreJuryVM)
            {
                if (oItem.IsNew)
                {
                    _ctx.Entry<MembreJury>((MembreJury)oItem.TheItem).State = System.Data.Entity.EntityState.Detached;
                }
                else
                {
                    _ctx.Entry<MembreJury>((MembreJury)oItem.TheItem).State = System.Data.Entity.EntityState.Deleted;
                }

            }

        }

        public override CandidatVM getCurrentCandidat()
        {
                return new CandidatVM(oL2.oCandidat);
        }
        protected override void setEtatLivret()
        {
            String strEtat = EtatLivret;
            String strKey = "";
            if (IsDecisionJuryFavorable || (IsDecisionJuryDefavorable && IsRecoursDemande && IsDecisionJuryRecoursFavorable))
            {
                strKey = String.Format("{0:D}", MyEnums.EtatL1.ETAT_L1_ACCEPTE);
            }
            if (IsDecisionJuryDefavorable )
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
        /// <summary>
        /// Un Livret En cours est un Livert non Clos que n'est Ni Accepté, ni refusé
        /// </summary>
        /// <returns></returns>
        public Boolean IsLivretEnCours
        {
            get
            {
                Boolean bReturn = false;
                if (!IsLivretClos)
                {
                    bReturn = (!IsEtatAccepte && !IsEtatRefuse);
                }
                return bReturn;
            }
        }
        public Boolean IsLivretNotEnCours
        {
            get {
                return !IsLivretEnCours;
            }
        }
        /// <summary>
        /// Rend le numéro de l'onglet a Afficher par défaut
        /// </summary>
        public Int32 getNumTab
        {
            get
            {
                if (IsEtatRecu)
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
                if (!oMembreJ.IsNew)
                {
                    _ctx.Entry<MembreJury>(oMembreJ.MembreJuryItem).State = System.Data.Entity.EntityState.Deleted;

                }
                lstMembreJury.Remove(oMembreJ);
                RaisePropertyChanged("lstMembreJury");
            }
        }


    }
}
