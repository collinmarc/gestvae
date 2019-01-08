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
    /// Logique d'interaction pour frmLivret1.xaml
    /// </summary>
    public partial class frmLivret1 : Window
    {
        public frmLivret1()
        {
            InitializeComponent();
        }

        public void setContexte(LivretVM pLivret)
        {
            this.DataContext = pLivret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPJ_Click(object sender, RoutedEventArgs e)
        {
            //Ajout d'une piève jointe
            LivretVM oLiv = (LivretVM)this.DataContext;
            oLiv.addPJL1();
        }
    }
}
