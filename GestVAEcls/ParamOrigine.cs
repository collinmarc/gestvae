using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public  class ParamOrigine : GestVAE
    {
        public String Nom { get; set; }

        public ParamOrigine()
        {
            Nom = "";
        }
        public ParamOrigine(String pNom) : this()
        {
            Nom = pNom;
        }
    }

}// Class Origine
