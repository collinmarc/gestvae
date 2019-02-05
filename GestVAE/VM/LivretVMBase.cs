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

        public LivretVMBase(Livret pLivret)
        {
            TheLivret = pLivret;
            //lstPiecesJointes = new ObservableCollection<PieceJointeL1>();
        }


        public LivretVMBase()
        {
        }
 
    }
}
