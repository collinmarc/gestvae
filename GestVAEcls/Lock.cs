using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class LockCandidat: GestVAEBase
    {
        public Int32 IDLockCandidat { get; set; }
        public Int32 IDUser { get; set; }
        public Int32 IDCandidat { get; set; }
        internal LockCandidat()
        {
            IDUser = 0;
            IDCandidat = 0;
        }
        public LockCandidat(Int32 pIDUser)
        {
            IDUser = pIDUser;
            IDCandidat = 0;
        }
        public LockCandidat(Int32 pIDUser, Int32 pId):this(pIDUser)
        {
            IDCandidat = pId;
        }
    }
}
