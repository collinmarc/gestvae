using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class MotifGeneralL1 : GestVAEBase
    {
        public String Libelle { get; set; }

        public MotifGeneralL1() : base()
        {
            Libelle = "";
            lstMotifDetaille = new ObservableCollection<MotifDetailleL1>();
        }

        public virtual ObservableCollection<MotifDetailleL1> lstMotifDetaille { get; set; }

    }
    public class MotifDetailleL1 : GestVAEBase
    {
        public virtual int MotifGL1_ID { get; set; }
        [ForeignKey("MotifGL1_ID")]
        [Required]
        public virtual MotifGeneralL1 MotifGL1 { get; set; }
        public String Libelle { get; set; }
        public MotifDetailleL1() : base()
        {
            Libelle = "";
        }
        public MotifDetailleL1(MotifGeneralL1 pMotifG, String pLibelle) : base()
        {
            MotifGL1 = pMotifG;
            Libelle = pLibelle;
        }
    }
}
