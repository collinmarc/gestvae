using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class DCLivret:GestVAE
    {
        public DCLivret() : base()
        {
            IsAValider = false;
            Decision = "";
            MotifGeneral = "";
            MotifDetail = "";
            MotifCommentaire = "";
        }
        public DCLivret(DomaineCompetence pDC) : base()
        {
            oDomaineCompetence = pDC;
            IsAValider = true;
            Decision = "";
            MotifGeneral = "";
            MotifDetail = "";
            MotifCommentaire = "";
        }
        public String Decision { get; set; }
        public String MotifGeneral { get; set; }
        public String MotifDetail { get; set; }
        public String MotifCommentaire { get; set; }
        public virtual DomaineCompetence oDomaineCompetence{ get; set; }
        [Required]
        public virtual Livret2 oLivret2 { get; set; }
        public Boolean IsAValider { get; set; }

        public String NomDC { get { return oDomaineCompetence.Nom; } }
        public String Statut { get; set; }
        public DateTime? DateObtention { get; set; }
        public String ModeObtention { get; set; }
        public String Commentaire { get; set; }

    }
}
