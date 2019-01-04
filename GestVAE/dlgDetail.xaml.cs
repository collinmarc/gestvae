using GestVAE.VM;
using GestVAEcls;
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
    /// Logique d'interaction pour dlgDetail.xaml
    /// </summary>
    public partial class dlgDetail : Window
    {
        public dlgDetail()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        public void setContexte(DiplomeCandVM pDiplome)
        {
            this.DataContext = pDiplome;
        }
    }
}
