using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public enum EnumTypeRecours
    {
        Gracieux,
        Contentieux

    }
    public class Recours: GestVAEBase
    {
        
        public DateTime? DateDepot{ get; set; }
        public EnumTypeRecours TypeRecours { get; set; }
        public String MotifRecours { get; set; }
        public String MotifRecoursCommentaire { get; set; }
        public String NomJury { get; set; }
        public DateTime? DateLimiteJury { get; set; }
        public DateTime? DateJury { get; set; }
        public String LieuJury { get; set; }
        public String Decision { get; set; }
        public String MotifGeneral { get; set; }
        public String MotifDetail { get; set; }
        public String MotifCommentaire { get; set; }
        //public virtual Jury oJury { get; set; }
        public virtual int Livret1_ID { get; set; }
        [ForeignKey("Livret1_ID")]
        [Required]
        public virtual Livret1 oLivret { get; set; }


        public Recours() : base()
        {
            DateDepot = DateTime.Now;
            TypeRecours = EnumTypeRecours.Gracieux;
            MotifRecours = "";
        }
    }
}
