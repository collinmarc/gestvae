using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class PieceJointeCategorie : GestVAE
    {
        public String Livret { get; set; }
        public String Categorie { get; set; }

        public PieceJointeCategorie() : base()
        {
            Livret = "";
            Categorie = "";
            lstPJItems = new ObservableCollection<PieceJointeItem>();
        }

        public virtual ObservableCollection<PieceJointeItem> lstPJItems { get; set; }

    }
    public class PieceJointeItem : GestVAE
    {
        [Required]
        public virtual PieceJointeCategorie CategoriePJ { get; set; }
        public String Libelle { get; set; }
        public PieceJointeItem() : base()
        {
            Libelle = "";
        }
        public PieceJointeItem(PieceJointeCategorie pCat, String pLibelle) : base()
        {
            CategoriePJ = pCat;
            Libelle = pLibelle;
        }
    }
}
