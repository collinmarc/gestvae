using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public abstract class Echange : GestVAE
    {
        public DateTime? DateEch { get; set; }
        public String MotifEch { get; set; }
        public DateTime? DateEcheanceEch { get; set; }
        public DateTime? DateReceptionEch { get; set; }
        public Boolean IsOK { get; set; }
        public String CommentaireEch { get; set; }

        public Echange()
        {
            DateEch = DateTime.Now;
            MotifEch = "";
            DateEcheanceEch = null;
            DateReceptionEch = null;

            IsOK = false;
            CommentaireEch = "";
    }
    public Echange(String pMotif) : this()
        {
            MotifEch = pMotif;
        }
    }
    public class EchangeL1 : Echange
    {
        [Required]
        public virtual Livret1 oLivret { get; set; }

        public EchangeL1(String pNom):base(pNom)
        {
        }


        public EchangeL1() : base()
        {
        }
    }
    public class EchangeL2 : Echange
    {
        [Required]
        public virtual Livret2 oLivret { get; set; }

        public EchangeL2() : base()
        {
        }
        public EchangeL2(String pNom) : base(pNom)
        {
        }
    }
}
