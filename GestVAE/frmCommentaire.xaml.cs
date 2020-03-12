using GestVAE.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestVAE
{
    /// <summary>
    /// Logique d'interaction pour frmCommentaire.xaml
    /// </summary>
    public partial class frmCommentaire : Window
    {
        public frmCommentaire()
        {
            InitializeComponent();
        }
        
        public void SetconTexte( MyViewModel pModel)
        {
            this.DataContext = pModel;
        }
    }
}
