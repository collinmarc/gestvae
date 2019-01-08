using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public abstract class PieceJointe : GestVAE
    {
        public String Nom { get; set; }
        public Boolean IsRecu { get; set; }
        public Boolean IsOK { get; set; }

        public PieceJointe()
        {
            Nom = "";
            IsRecu = false;
            IsOK = false;
        }
        public PieceJointe(String pNom) : this()
        {
            Nom = pNom;
        }
    }

    public class PieceJointeL1 : PieceJointe
    {
        [Required]

        public virtual Livret1 oLivret { get; set; }

        public PieceJointeL1(String pNom):base(pNom)
        {
        }


        public PieceJointeL1() : base()
        {
        }
    }
    public class PieceJointeL2 : PieceJointe
    {
        [Required]
        public virtual Livret2 oLivret { get; set; }

        public PieceJointeL2() : base()
        {
        }
        public PieceJointeL2(String pNom) : base(pNom)
        {
        }
    }
}
