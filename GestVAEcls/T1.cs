using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class T1 : GestVAEBase


    {

        public T1()
        {
            lstT2 = new HashSet<T2>();
        }
        public virtual ICollection<T2> lstT2 { get; set; }
    }
    public class T2 : GestVAEBase
    {

        public virtual T1 oT1 { get; set; }
    }

    public enum DepartmentNames
    {
        English,
        Math,
        Economics
    }

    public partial class Department
    {
        public int DepartmentID { get; set; }
        public DepartmentNames Name { get; set; }
        public decimal Budget { get; set; }
    }
 
}
