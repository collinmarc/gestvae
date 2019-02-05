using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
   public  class ListVM : VMBase
    {

        public ObservableCollection<String> lstL1L2 { get; set; }


        public ListVM()
        {
            lstL1L2 = new ObservableCollection<String>();
            lstL1L2.Add("L1");
            lstL1L2.Add("L2");

        }
    }
}
