using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public abstract class Livret : GestVAEBase
    {
        public DateTime? DateEcheance { get; set; }
        [NotMapped]
        public String Typestr { get; set; }
        public Boolean isContrat { get; set; }
        public String TypeDemande { get; set; }
        public String OrigineDemande { get; set; }

        private String _EtatLivret;
        public String EtatLivret {
            get { return _EtatLivret; }
            set {
                if (value != _EtatLivret)
                    {
                    _EtatLivret = value;
                    }
                }
        }
        public DateTime? DateEnvoiEHESP { get; set; }
        public DateTime? DateEnvoiCandidat { get; set; }
        public DateTime? DateReceptEHESP { get; set; }
        public DateTime? DateReceptEHESPComplet { get; set; }
        public virtual Diplome oDiplome { get; set; }
        public virtual ObservableCollection<Jury> lstJurys { get; set; }
        public Boolean isClos { get; set; }

        public Livret()
        {
            isClos = false;
            EtatLivret = "";
            Typestr = "";
            lstJurys = new ObservableCollection<Jury>();
            oDiplome = Diplome.getDiplomeParDefaut();
        }


    }
    public class Livret1 : Livret
    {
        public String Numero { get; set; }
        public DateTime? DateDemande { get; set; }
        public DateTime? DateLimiteEnvoiEHESP { get; set; }
        public DateTime? DateLimiteReceptEHESP { get; set; }
        public DateTime? DateLimiteJury { get; set; }
        public DateTime? DateValidite { get; set; }
        public DateTime? Date1ereDemandePieceManquantes { get; set; }
        public DateTime? Date2emeDemandePieceManquantes { get; set; }
        public DateTime? DateDemandePieceManquantesRetour { get; set; }
        public virtual ObservableCollection<PieceJointeL1> lstPiecesJointes { get; set; }
        public virtual ObservableCollection<EchangeL1> lstEchanges { get; set; }
        [Required]
        public virtual Candidat oCandidat { get; set; }
        public Boolean IsRecours { get; set; }
        public virtual ObservableCollection<Recours> lstRecours { get; set; }

        public Livret1():base()
        {
            Typestr = "LIVRET1";
            lstPiecesJointes = new ObservableCollection<PieceJointeL1>();
            lstEchanges = new ObservableCollection<EchangeL1>();

            Numero = DateTime.Now.ToString("yyyyMMddHHmm");
            lstRecours = new ObservableCollection<Recours>();
        }


    }
    public class Livret2 : Livret
    {

        public String Numero { get; set; }
        public DateTime? DateDemande { get; set; }
        public DateTime? DateLimiteEnvoiEHESP { get; set; }
        public DateTime? DateLimiteReceptEHESP { get; set; }
        public DateTime? DatePrevJury1 { get; set; }
        public DateTime? DatePrevJury2 { get; set; }
        public String SessionJury { get; set; }
        public DateTime? DateLimiteJury { get; set; }
        public DateTime? DateValidite { get; set; }
        public Boolean IsAttestationOK { get; set; }
        public Boolean IsCNIOK { get; set; }
        public Boolean IsDispenseArt2 { get; set; }
        public virtual ObservableCollection<PieceJointeL2> lstPiecesJointes { get; set; }
        public virtual ObservableCollection<EchangeL2> lstEchanges { get; set; }
        public virtual ObservableCollection<DCLivret> lstDCLivrets { get; set; }
        public virtual ObservableCollection<MembreJury> lstMembreJurys { get; set; }
        [Required]
        public virtual Candidat oCandidat { get; set; }
 //       public virtual ObservableCollection<Recours> lstRecours { get; set; }

        public Livret2():base()
        {
            Typestr = "LIVRET2";
            lstPiecesJointes = new ObservableCollection<PieceJointeL2>();
            lstEchanges = new ObservableCollection<EchangeL2>();
            lstDCLivrets = new ObservableCollection<DCLivret>();
            lstMembreJurys = new ObservableCollection<MembreJury>();
            //           lstRecours = new ObservableCollection<Recours>();

        }
        public Livret2(Diplome pDipl) : this()
        {
            oDiplome = pDipl;

            foreach (DomaineCompetence item in oDiplome.lstDomainesCompetences)
            {
                DCLivret oDCLivret = new DCLivret(item);
                lstDCLivrets.Add(oDCLivret);
            }


        }
        /// <summary>
        /// initialisation des stattus des domaindes de compétences du Livret
        /// </summary>
        /// <param name="pdiplomeCand"></param>
        public void InitDCLivrets(DiplomeCand pdiplomeCand )
        {
            foreach (DomaineCompetenceCand oDCCand in pdiplomeCand.lstDCCands)
            {
                DCLivret oDC = lstDCLivrets.Where(i => i.NomDC == oDCCand.NomDomaineCompetence).FirstOrDefault();
                if (oDC == null)
                {
                    oDC = new DCLivret(oDCCand.oDomaineCompetence);
                    lstDCLivrets.Add(oDC);
                }
                oDC.Statut = oDCCand.Statut;
                oDC.ModeObtention = oDCCand.ModeObtention;
                oDC.DateObtention = oDCCand.DateObtention;
                oDC.Commentaire = oDCCand.Commentaire;
            }
        }
        /// <summary>
        /// Valider le Livret2 (Créer ou mettre à jour le diplome du candidiat
        /// </summary>
        public void ValiderLivret2()
        {
            // Vérification du diplome 
            DiplomeCand oDipCand = oCandidat.lstDiplomes.Where(obj => obj.oDiplome.ID == oDiplome.ID).FirstOrDefault();
            if (oDipCand == null)
            {
                // Le candidat n'a pas le diplome
                oDipCand =  oCandidat.AddDiplome(oDiplome);
            }

            if (oDipCand != null)
            {
                // Mise à jour des Domaines de compétences Candidat
                foreach (var item in oDipCand.lstDCCands)
                {
                    //Récupération du DCCand
                    DCLivret oDCLiv = lstDCLivrets.FirstOrDefault(dc => (dc.IsAValider && dc.oDomaineCompetence.ID == item.oDomaineCompetence.ID));
                    if (oDCLiv != null)
                    {
                        if (oDCLiv.Decision.ToUpper().StartsWith("10-"))
                        {
                            item.Statut = "Validé";
                        }
                        if (oDCLiv.Decision.ToUpper().StartsWith("20-"))
                        {
                            item.Statut = "Refusé";
                        }
                        item.ModeObtention = "VAE";
                        item.DateObtention = this.lstJurys[0].DateJury;
                    }
                }
                oDipCand.CalculerStatut();

            }
        }//ValiderLivret2
    }
}
