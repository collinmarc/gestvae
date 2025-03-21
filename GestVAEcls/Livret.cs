﻿using System;
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
        public Int32 NumPassage { get; set; }
        public DateTime? DateEcheance { get; set; }
        [NotMapped]
        public String Typestr { get; set; }
        public Boolean IsContrat { get; set; }
        public Boolean IsConvention { get; set; }
        public Boolean IsNonRecu { get; set; }

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
        private int _Diplome_ID;  
        public virtual int Diplome_ID
        {
            get{ return _Diplome_ID;}
            set
            {
                _Diplome_ID = value;
            }
        }

        [ForeignKey("Diplome_ID")]
        public virtual Diplome oDiplome { get; set; }
        public virtual ObservableCollection<Jury> lstJurys { get; set; }

        public Jury get1erJury()
        {
            if (lstJurys.Count>0)
            {
                return lstJurys[0];
            }
            else
            {
                return null;
            }
        }
        public Boolean isClos { get; set; }
        public Boolean IsEnregistre { get; set; }
        public Boolean IsPaye { get; set; }

        public Livret()
        {
            isClos = false;
            IsEnregistre = false;
            IsPaye = false;
            EtatLivret = "";
            Typestr = "";
            lstJurys = new ObservableCollection<Jury>();
            lstDCLivrets = new ObservableCollection<DCLivret>();
            //lstJurys.Add(new Jury());
//            oDiplome = Diplome.getDiplomeParDefaut();
        }
        public void create1erJury()
        {
            if (get1erJury() == null)
            {
                lstJurys.Add(new Jury());
            }
        }
        public virtual ObservableCollection<DCLivret> lstDCLivrets { get; set; }
        /// <summary>
        /// initialisation des stattus des domaines de compétences du Livret
        /// </summary>
        /// <param name="pdiplomeCand"></param>
        public void InitDCLivrets(DiplomeCand pdiplomeCand)
        {
            foreach (DomaineCompetenceCand oDCCand in pdiplomeCand.lstDCCands)
            {
                DCLivret oDCL = lstDCLivrets.Where(i => i.NomDC == oDCCand.NomDomaineCompetence).FirstOrDefault();
                if (oDCL == null)
                {
                    oDCL = new DCLivret(oDCCand.oDomaineCompetence);
                    oDCL.Statut = oDCCand.Statut;
                    oDCL.ModeObtention = oDCCand.ModeObtention;
                    lstDCLivrets.Add(oDCL);
                }
                else
                {
                    oDCL.Statut = oDCCand.Statut;
                    oDCL.ModeObtention = oDCCand.ModeObtention;
                    oDCL.DateObtention = oDCCand.DateObtention;
                    oDCL.Commentaire = oDCCand.Commentaire;
                    if (oDCL.Statut == "")
                    {
                        if (NumPassage > 1)
                        {
                            oDCL.Statut = "Refusé";
                        }
                        else
                        {
                            oDCL.Statut = "En Cours";
                        }
                    }
                }
            }
        }


    }
    public class Livret1 : Livret
    {
        static public String TYPELIVRET { get { return "L1"; } }

        public String Numero { get; set; }
        public String TypeDemande { get; set; }
        public String VecteurInformation { get; set; }

        public DateTime? DateDemande { get; set; }
        public DateTime? DateLimiteEnvoiEHESP { get; set; }
        public DateTime? DateLimiteReceptEHESP { get; set; }
        public DateTime? DateLimiteJury { get; set; }
        public DateTime? DateValidite { get; set; }
        public DateTime? DateEnvoiL2 { get; set; }
        public DateTime? Date1ereDemandePieceManquantes { get; set; }
        public DateTime? Date2emeDemandePieceManquantes { get; set; }
        public DateTime? DateDemande1erRetour { get; set; }
        public DateTime? DateDemande2emeRetour { get; set; }
        public DateTime? DateReceptionPiecesManquantes { get; set; }
        public Boolean IsCNIOK { get; set; }
        public DateTime? DateValiditeCNI { get; set; }

        public virtual ObservableCollection<PieceJointeL1> lstPiecesJointes { get; set; }
        public virtual ObservableCollection<EchangeL1> lstEchanges { get; set; }
        public virtual int Candidat_ID { get; set; }
        [ForeignKey("Candidat_ID")]
        [Required]
        public virtual Candidat oCandidat { get; set; }

        public Livret1():base()
        {
            Typestr = TYPELIVRET;
            lstPiecesJointes = new ObservableCollection<PieceJointeL1>();
            lstEchanges = new ObservableCollection<EchangeL1>();
            IsNonRecu = true; IsContrat = false; IsConvention = false;
            IsCNIOK = false;DateValiditeCNI = null;

        }


    }
    public class Livret2 : Livret
    {
        static public String TYPELIVRET { get { return "L2"; } }

        public String Numero { get; set; }
        public Boolean IsOuvertureApresRecours{ get; set; }
        public DateTime? DateDemande { get; set; }
        public DateTime? DateLimiteEnvoiEHESP { get; set; }
        public DateTime? DateLimiteReceptEHESP { get; set; }
        public DateTime? Date1ereDemandePieceManquantes { get; set; }
        public DateTime? Date2emeDemandePieceManquantes { get; set; }
        public DateTime? DateDemande1erRetour { get; set; }
        public DateTime? DateDemande2emeRetour { get; set; }
        public DateTime? DateReceptionPiecesManquantes { get; set; }
        public DateTime? DateValiditeCNI { get; set; }
        public DateTime? DateEnvoiCourrierJury { get; set; }
        public DateTime? DatePrevJury1 { get; set; }
        public DateTime? DatePrevJury2 { get; set; }
        public String SessionJury { get; set; }
        public DateTime? DateLimiteJury { get; set; }
        public DateTime? DateValidite { get; set; }
        public Boolean IsAttestationOK { get; set; }
        public Boolean IsCNIOK { get; set; }
        public Boolean IsDispenseArt2 { get; set; }
        //public String NumDiplome { get; set; }
        public Boolean IsTrtSpecial { get; set; }
        public virtual ObservableCollection<PieceJointeL2> lstPiecesJointes { get; set; }
        public virtual ObservableCollection<EchangeL2> lstEchanges { get; set; }
        public virtual ObservableCollection<MembreJury> lstMembreJurys { get; set; }
        public virtual int Candidat_ID { get; set; }
        [ForeignKey("Candidat_ID")]
        [Required]
        public virtual Candidat oCandidat { get; set; }

        public Livret2():base()
        {
            Typestr = TYPELIVRET;
            lstPiecesJointes = new ObservableCollection<PieceJointeL2>();
            lstEchanges = new ObservableCollection<EchangeL2>();
            lstDCLivrets = new ObservableCollection<DCLivret>();
            lstMembreJurys = new ObservableCollection<MembreJury>();

            Numero = DateTime.Now.ToString("L2yyyyMMddHHmm");
            NumPassage = 1;
            IsTrtSpecial = false;
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
