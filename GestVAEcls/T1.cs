using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class T1 : GestVAE


    {

        public T1()
        {
            lstT2 = new HashSet<T2>();
        }
        public virtual ICollection<T2> lstT2 { get; set; }
    }
    public class T2 : GestVAE
    {

        public virtual T1 oT1 { get; set; }
    }
}
