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
    public class DomaineCompetence:GestVAE
    {

        public DomaineCompetence():base()
        {

        }
        public DomaineCompetence(Diplome pDip, String pNom) : base()
        {
            this.oDiplome = pDip;
            this.Nom = pNom;

        }
        [Index]
        public int Numero { get; set; }
        public String Nom { get; set; }

        [Required]

        public virtual Diplome oDiplome { get; set; }
       //public virtual ObservableCollection<DomaineCompetenceCand> lstDCCands { get; set; }
    }
}
