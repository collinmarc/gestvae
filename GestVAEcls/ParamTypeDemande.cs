using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public  class ParamTypeDemande : GestVAEBase
    {
        public String Nom { get; set; }

        public ParamTypeDemande()
        {
            Nom = "";
        }
        public ParamTypeDemande(String pNom) : this()
        {
            Nom = pNom;
        }
    }

}// Class Origine
