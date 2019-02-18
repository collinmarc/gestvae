using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public  class ParamCollege : GestVAE
    {
        public String Nom { get; set; }

        public ParamCollege()
        {
            Nom = "";
        }
        public ParamCollege(String pNom) : this()
        {
            Nom = pNom;
        }
    }

}// Class ParamCollege
