﻿using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class PieceJointeLivretVM : VMBase
    {
        public PieceJointe ThePiecejointe;

        public PieceJointeLivretVM()
        {
            ThePiecejointe = new PieceJointeL1("...", "...");
        }

        public PieceJointeLivretVM(PieceJointe pPieceJointe)
        {
            ThePiecejointe = pPieceJointe;
        }

        public String Categorie
        {
            get
            {
                return ThePiecejointe.Categorie ;
            }
            set
            {
                if (value != Categorie)
                {
                    ThePiecejointe.Categorie= value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("lstLibellePJ");
                }
            }
        }
        public String Libelle
        {
            get
            {
                return ThePiecejointe.Libelle;
            }
            set
            {
                if (value != Libelle)
                {
                    ThePiecejointe.Libelle = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsRecu
        {
            get
            {
                return ThePiecejointe.IsRecu;
            }
            set
            {
                if (value != IsRecu)
                {
                    ThePiecejointe.IsRecu = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsOK
        {
            get
            {
                return ThePiecejointe.IsOK;
            }
            set
            {
                if (value != IsOK)
                {
                    ThePiecejointe.IsOK = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Liste des Libellés de Pièces jointes pour la Catégorie sélectionnée
        /// </summary>
        public List<String> lstLibellePJ
        {
            get
            {
                List<String> oReturn = new List<String>();
                PieceJointeCategorie oPJCat= (from item in _ctx.pieceJointeCategories
                        where item.Categorie == Categorie 
                        select item).FirstOrDefault<PieceJointeCategorie>();
                if (oPJCat != null)
                {
                    oReturn = (from item in oPJCat.lstPJItems
                               select item.Libelle).ToList<String>();
                }

                return oReturn;
            }
        }



    }

}