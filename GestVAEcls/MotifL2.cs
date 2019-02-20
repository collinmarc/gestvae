using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class MotifGeneralL2 : GestVAEBase
    {
        public String Libelle { get; set; }

        public MotifGeneralL2() : base()
        {
            Libelle = "";
            lstMotifDetaille = new ObservableCollection<MotifDetailleL2>();
        }

        public virtual ObservableCollection<MotifDetailleL2> lstMotifDetaille { get; set; }

    }
    public class MotifDetailleL2 : GestVAEBase
    {
        [Required]
        public virtual MotifGeneralL2 MotifGL2 { get; set; }
        public String Libelle { get; set; }
        public MotifDetailleL2() : base()
        {
            Libelle = "";
        }
        public MotifDetailleL2(MotifGeneralL2 pMotifG, String pLibelle) : base()
        {
            MotifGL2 = pMotifG;
            Libelle = pLibelle;
        }
    }
}
