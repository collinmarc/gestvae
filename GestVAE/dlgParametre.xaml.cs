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
    public partial class dlgParametre: Window
    {
        public dlgParametre()
        {
            InitializeComponent();

            //ItemsSource="{Binding Regions}"
//            Binding = "{Binding Nom}
            //cbxNomdiplome.SetBinding(ComboBox.SelectedItemProperty, "oDiplome");
            //cbxNomdiplome.SetBinding(ComboBox.ItemsSourceProperty, "LstDiplomes");
            //cbxNomdiplome.DisplayMemberPath = "Nom";
            //cbxNomdiplome.SelectedValuePath = "Nom";

            //cbxStatutdiplome.SetBinding(ComboBox.SelectedValueProperty, "StatutDiplome");
            //cbxStatutdiplome.SetBinding(ComboBox.ItemsSourceProperty, "LstStatutDiplome");
        }


        private MyViewModel getViewModel()
        {
            return (MyViewModel)this.DataContext;
        }


        public void setContexte(MyViewModel pModel)
        {
            this.DataContext = pModel;

        }

        private void dgRegion_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            getViewModel().SetModelHasChanges();
        }
    }
}
