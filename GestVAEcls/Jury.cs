using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class Jury: GestVAE
    {
        public int NumeroOrdre { get; set; }
        public String NomJury { get; set; }
        public DateTime? DateJury { get; set; }
        public String LieuJury { get; set; }
        public String Decision { get; set; }
        public String MotifGeneral { get; set; }
        public String MotifDetail { get; set; }
        public String MotifCommentaire { get; set; }

    }
}
