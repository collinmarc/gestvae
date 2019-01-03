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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMDS1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public lstPersonne maListe = new lstPersonne(); 
        public MainWindow()
        {
            InitializeComponent();
            Personne P1 = new Personne();
            P1.Nom = "MArc";
            P1.Ville = "Chasné";
            maListe.Add(P1);
            Diplome d;
            d = new Diplome();
            d.Nom = "BACC";
            d.Etat = "OK";
            P1.diplomes.Add(d);
            d = new Diplome();
            d.Nom = "MAster";
            d.Etat = "NOK";
            P1.diplomes.Add(d);

            P1 = new Personne();
            P1.Nom = "Test";
            P1.Ville = "Rennes";
            maListe.Add(P1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "On a Clicker";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbPersonne.ItemsSource = maListe;
          //  dg1.ItemsSource = maListe;
        }
    }
}
