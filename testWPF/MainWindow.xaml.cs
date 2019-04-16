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

namespace testWPF
{
    public class Item
    {
        public String Libelle { get; set; }
    }
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Item> lst = new List<Item>();
            Item i = new Item();
            i.Libelle = "Ceci est un texte trop long pour être affiché en une ligne";

            lst.Add(i);
            i = new Item();
            i.Libelle = "TextCourt";
            lst.Add(i);
            i = new Item();
            i.Libelle = "TextCourtMoyennaaaaaaaaa";
            lst.Add(i);
            comboBoxTest.ItemsSource = lst;
        }
    }
}
