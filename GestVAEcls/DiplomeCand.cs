using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class DiplomeCand : GestVAE
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

        [Required]
        public virtual Candidat oCandidat { get; set; }
        [Required]
        public virtual Diplome oDiplome { get; set; }
        public String Statut { get; set; }
        public DateTime? DateObtention { get; set; }

        public virtual ObservableCollection<DomaineCompetenceCand> lstDCCands { get; set; }

    }
}
