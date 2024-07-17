using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class DCLivret:GestVAEBase
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
            IsAValider = false;
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
        public virtual int? oLivret2_ID { get; set; }
        [ForeignKey("oLivret2_ID")]
        public virtual Livret2 oLivret2 { get; set; }
        public virtual int? oLivret1_ID { get; set; }
        [ForeignKey("oLivret1_ID")]
        public virtual Livret1 oLivret1 { get; set; }
        public Boolean IsAValider { get; set; }

        public String NomDC { get { return oDomaineCompetence.Nom; } }
        public String Statut { get; set; }
        public DateTime? DateObtention { get; set; }
        public String ModeObtention { get; set; }
        public String Commentaire { get; set; }
        public String PropositionDecision { get; set; }

    }
}
