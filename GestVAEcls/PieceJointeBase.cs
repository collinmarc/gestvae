﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class PieceJointeCategorie : GestVAEBase
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
    public class PieceJointeItem : GestVAEBase
    {
        public virtual int Categorie_ID { get; set; }
        [ForeignKey("Categorie_ID")]

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
