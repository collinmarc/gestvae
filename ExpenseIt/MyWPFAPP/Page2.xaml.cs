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

namespace MyWPFAPP
{
    /// <summary>
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        public lstPersonne maList { get; set; }
        public Page2()
        {
            InitializeComponent();
            maList = new lstPersonne();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Personne oPers = new Personne();
            oPers.Nom = "Collin";
            oPers.Prenom = "MArc";
            oPers.Ville = "Chasné";
            maList.Add(oPers);
            oPers = new Personne();
            oPers.Nom = "Thomas";
            oPers.Prenom = "JF";
            oPers.Ville = "NAntes";
            maList.Add(oPers);

            lbPersonne.ItemsSource = maList;
            
            //Binding oBin = new Binding();
            //oBin.Source = maList;
            //lbPersonne.SetBinding(ListBox.ItemsSourceProperty,oBin);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Personne item in maList)
            {
                Console.WriteLine(item.Nom + "/" + item.Prenom + "/" + item.Ville);
            }
        }
    }
}
