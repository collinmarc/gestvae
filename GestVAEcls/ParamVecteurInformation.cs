using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public  class ParamVecteurInformation : GestVAEBase
    {
        public String Nom { get; set; }

        public ParamVecteurInformation()
        {
            Nom = "";
        }
        public ParamVecteurInformation(String pNom) : this()
        {
            Nom = pNom;
        }
    }

}// Class Origine
