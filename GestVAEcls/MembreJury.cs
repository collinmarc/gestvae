using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class MembreJury: GestVAEBase
    {
        public String Nom { get; set; }
        public String College { get; set; }
        public String Origine { get; set; }
        public String Region { get; set; }
        public virtual int Livret2_ID { get; set; }
        [ForeignKey("Livret2_ID")]

        [Required]
        public virtual Livret2 oLivret2 { get; set;  }

        public MembreJury() : base()
        {
            Nom = "";
            College = "";
            Origine = "";
            Region = "";
        }
    }
}
