using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GestVAE.VM
{
    public abstract class LivretVMBase:VMBase
    {
        public Livret TheLivret { get; set; }
        //public ObservableCollection<PieceJointeL1> lstPiecesJointes;
        public ObservableCollection<PieceJointeLivretVM> lstPieceJointe { get; set; }
        public PieceJointeLivretVM selectedPJ { get; set; }

        public LivretVMBase(Livret pLivret)
        {
            TheLivret = pLivret;
            lstPieceJointe = new ObservableCollection<PieceJointeLivretVM>();
        }

        public LivretVMBase()
        {
        }

        public String Typestr
        {
            get
            {
                return TheLivret.Typestr;
            }
        }

        public virtual void Commit() { }
        public void AjoutePJ(String pLivret)
        {
            // Récupération de la première catégorie
            String strCat = lstCategoriePJ[0];
            PieceJointeLivretVM opjVM = new PieceJointeLivretVM(pLivret);
            opjVM.Categorie = strCat;
            // Récupération du libellé
            if (opjVM.lstLibellePJ.Count > 0)
            {
                opjVM.Libelle = opjVM.lstLibellePJ[0];
            }
            // Ajout dans la collection
            lstPieceJointe.Add(opjVM);
            RaisePropertyChanged("lstPieceJointe");
        }

        public abstract List<String> lstCategoriePJ
        { get; }

        public void DeletePJ()
        {
            // Set to be Deleted
            _ctx.Entry<PieceJointeL1>((PieceJointeL1)selectedPJ.ThePiecejointe).State = System.Data.Entity.EntityState.Deleted;
            //oL1.lstPiecesJointes.Remove((PieceJointeL1)selectedPJ.ThePiecejointe);
            lstPieceJointe.Remove(selectedPJ);
            RaisePropertyChanged("lstPieceJointe");
        }

    }
}
