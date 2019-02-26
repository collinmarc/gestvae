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
    public class DiplomeCand : GestVAEBase
    {

        public DiplomeCand() : base()
        {
            lstDCCands = new ObservableCollection<DomaineCompetenceCand>();
            this.DateObtention = DateTime.MinValue;
            Statut = "";
        }

        public DiplomeCand(Diplome pDip ,DateTime pDateObtention) : this()
        {
            oDiplome = pDip;
            this.DateObtention = pDateObtention;
            SetDCs();
            
        }
        /// <summary>
        /// Initialisation des Domaines de compétences à aprtir des DC du diplomes
        /// Ne peut être executé dans le constructreur
        /// </summary>
        public void SetDCs()
        {
            foreach (DomaineCompetence oDC in oDiplome.lstDomainesCompetences)
            {
                DomaineCompetenceCand oDCCand = new DomaineCompetenceCand(oDC);
                lstDCCands.Add(oDCCand);
            }

        }

        public virtual int Candidat_ID { get; set; }
        [ForeignKey("Candidat_ID")]
        [Required]
        public virtual Candidat oCandidat { get; set; }
        public virtual int Diplome_ID { get; set; }
        [ForeignKey("Diplome_ID")]
        [Required]
        public virtual Diplome oDiplome { get; set; }
        public String Statut { get; set; }
        public DateTime? DateObtention { get; set; }
        public String NumeroDiplome { get; set; }

        public virtual ObservableCollection<DomaineCompetenceCand> lstDCCands { get; set; }

        public void CalculerStatut()
        {
            int nbValide = 0;
            int nbRefuse = 0;
            int nbDivers = 0;
            nbValide = lstDCCands.Where(obj => obj.Statut == "Validé").Count();
            nbRefuse = lstDCCands.Where(obj => obj.Statut == "Refusé").Count();
            nbDivers = lstDCCands.Where(obj => obj.Statut == "En cours").Count();

            if (nbDivers >0)
            {
                Statut = "En cours";
            }
            else
            {
                if (nbValide==0 && nbRefuse >0)
                {
                    Statut = "Refusé";
                }
                if (nbValide > 0 && nbRefuse == 0)
                {
                    Statut = "Validé";
                }
                if (nbValide > 0 && nbRefuse > 0)
                {
                    Statut = "Validé partiellement";
                }

            }



        }

    }
}
