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
    public class DomaineCompetence:GestVAEBase
    {

        public DomaineCompetence():base()
        {

        }
        public DomaineCompetence(String pNom) : base()
        {
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
