using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public abstract class PieceJointe : GestVAEBase
    {
        public String Categorie{ get; set; }
        public String Libelle { get; set; }
        public Boolean IsRecu { get; set; }
        public Boolean IsOK { get; set; }

        public PieceJointe()
        {
            Categorie = "";
            Libelle = "";
            IsRecu = false;
            IsOK = false;
        }
        public PieceJointe(String pCategorie, String pLibelle) : this()
        {
            Categorie = pCategorie;
            Libelle = pLibelle;
        }
    }

    public class PieceJointeL1 : PieceJointe
    {
        [Required]
        public virtual Livret1 oLivret { get; set; }

        public PieceJointeL1(String pCategorie, String pLibelle):base(pCategorie, pLibelle)
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
        public PieceJointeL2(String pCategorie, String pLibelle) : base(pCategorie, pLibelle)
        {
        }

    }
}
