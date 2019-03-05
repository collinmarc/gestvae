using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class LockCandidat: GestVAEBase
    {
        public Int32 IDCandidat { get; set; }
        public LockCandidat()
        {
            IDCandidat = 0;
        }
        public LockCandidat(Int32 pId)
        {
            IDCandidat = pId;
        }
    }
}
