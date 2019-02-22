using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class Jury: GestVAEBase
    {
        public int NumeroOrdre { get; set; }
        public String NomJury { get; set; }
        public DateTime? DateJury { get; set; }
        public DateTime? HeureJury { get; set; }
        public DateTime? HeureConvoc { get; set; }
        public DateTime? DateLimiteRecours { get; set; }
        public String LieuJury { get; set; }
        public String Decision { get; set; }
        public String MotifGeneral { get; set; }
        public String MotifDetail { get; set; }
        public String MotifCommentaire { get; set; }

        public virtual int? Livret1_ID { get; set; }
        [ForeignKey("Livret1_ID")]
        public virtual Livret1 oLivret1 { get; set; }
        public virtual int? Livret2_ID { get; set; }
        [ForeignKey("Livret2_ID")]
        public virtual Livret2 oLivret2 { get; set; }

        public DateTime? DateNotificationJury { get; set; }
        public DateTime? DateNotificationJuryRecours { get; set; }

        public Jury() : base()
        {
            NomJury = "";
            DateJury = DateTime.Now;
            LieuJury = "";
            Decision = "";
            MotifCommentaire = "";
            MotifDetail = "";
            MotifGeneral = "";
        }
    }
}
