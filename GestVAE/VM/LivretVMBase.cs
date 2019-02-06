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
    public class LivretVMBase:VMBase
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

    }
}
