using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public  class Region : GestVAE
    {
        public String Nom { get; set; }

        public Region()
        {
            Nom = "";
        }
        public Region(String pNom) : this()
        {
            Nom = pNom;
        }
    }

}// Class Region
