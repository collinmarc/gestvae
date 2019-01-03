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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestVAE.VM;
using GestVAEcls;

namespace GestVAE
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MyViewModel _VM ;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _VM = new MyViewModel();
            _VM.getData();
            this.DataContext = _VM.candidats;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _VM.saveData();
        }
    }
}
