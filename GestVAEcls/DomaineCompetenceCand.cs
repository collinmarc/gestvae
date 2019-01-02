using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class DomaineCompetenceCand:GestVAE
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
           
          //  oDomaineCompetence = pDC;
        }
        [Required]
        public virtual DiplomeCand oDiplomeCand { get; set; }
       // public  DomaineCompetence oDomaineCompetence { get; set; }
        public String Statut { get; set; }
        public DateTime? DateObtention { get; set; }
        public String ModeObtention { get; set; }
        public String Commentaire { get; set; }
    }
}
