using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class DomaineCompetenceCand:GestVAEBase
    {

        public DomaineCompetenceCand() : base()
        {
            this.Statut = "";
            this.DateObtention = null;
            this.ModeObtention = "";
            this.Commentaire = "";
        }
        public DomaineCompetenceCand(DomaineCompetence pDC ) : this()
        {
           
            oDomaineCompetence = pDC;
            this.Statut = "??";
        }
        public virtual int Diplome_ID { get; set; }
        [ForeignKey("Diplome_ID")]
        [Required]
        public virtual DiplomeCand oDiplomeCand { get; set; }

        public virtual int? DomaineCompetence_ID { get; set; }
        [ForeignKey("DomaineCompetence_ID")]
        public virtual DomaineCompetence oDomaineCompetence { get; set; }
        public String Statut { get; set; }
        public DateTime? DateObtention { get; set; }
        public String ModeObtention { get; set; }
        public String Commentaire { get; set; }
        [NotMapped]
        public String NomDomaineCompetence {
            get
            {
                if (oDomaineCompetence == null)
                {
                    return "";
                }
                else
                { 
                return oDomaineCompetence.Nom;
                }
            }

        }

    }
}
