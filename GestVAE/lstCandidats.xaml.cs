using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using GestVAEcls;

namespace GestVAE
{
    /// <summary>
    /// Logique d'interaction pour lstCandidats.xaml
    /// </summary>
    /// 
   
    public partial class lstCandidats : Window
    {
        private VM.MyViewModel _VM;
        public lstCandidats()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _VM = new VM.MyViewModel();
            _VM.getData();
            Candidat oCand;
 
            oCand = new Candidat("THOMAS");
            oCand.Prenom = "JF";
            oCand.Ville = "Ste Luce";
            _VM.candidats.Add(oCand);
            this.DataContext = _VM.candidats;
        }
    }
}
