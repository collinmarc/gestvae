using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class Param: GestVAEBase
    {
        public Int32 NumLivret { get; set; }
        public Int32 NumCandidat { get; set; }
        public Int32 DelaiValiditeL1 { get; set; }
        public String CouleurTolerance { get; set; }
    }
}
