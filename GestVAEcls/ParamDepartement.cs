using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public  class ParamDepartement : GestVAEBase
    {
        public String Nom { get; set; }

        public ParamDepartement()
        {
            Nom = "";
        }
        public ParamDepartement(String pNom) : this()
        {
            Nom = pNom;
        }
    }// Class ParamDepartement

}
