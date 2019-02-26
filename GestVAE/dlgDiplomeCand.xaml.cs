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
    public partial class dlgDiplomeCand: Window
    {
        public dlgDiplomeCand()
        {
            InitializeComponent();
            cbxNomdiplome.SetBinding(ComboBox.SelectedItemProperty, "oDiplome");
            cbxNomdiplome.SetBinding(ComboBox.ItemsSourceProperty, "LstDiplomes");
            cbxNomdiplome.DisplayMemberPath = "Nom";
            cbxNomdiplome.SelectedValuePath = "Nom";

            cbxStatutdiplome.SetBinding(ComboBox.SelectedValueProperty, "StatutDiplome");
            cbxStatutdiplome.SetBinding(ComboBox.ItemsSourceProperty, "LstStatutDiplome");


            dtDateObtention.SetBinding(DatePicker.SelectedDateProperty, "DateObtentionDiplome");
            tbNumero.SetBinding(TextBox.TextProperty, "NumeroDiplome");
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        public void setContexte(DiplomeCandVM pDiplome)
        {
            this.DataContext = pDiplome;
        }
        bool manualCommit = false;

        private void dgDC_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Statut")
            {
                if (!manualCommit)
                {
                    manualCommit = true;
                    dgDC.CommitEdit(DataGridEditingUnit.Row, true);
                    manualCommit = false;
                }
            }

            DiplomeCandVM oDipCandVM = (DiplomeCandVM)this.DataContext;
            oDipCandVM.CalcStatutDiplome();

        }

        private void btnAddDiplome_Click(object sender, RoutedEventArgs e)
        {
            dlgDiplome odlg = new dlgDiplome();
            DiplomeVM odiplomeVM = new DiplomeVM();
            odlg.setContexte(odiplomeVM);
            odlg.ShowDialog();

            ((DiplomeCandVM)this.DataContext).RefreshlstDiplome();
            //cbxNomdiplome.SetBinding(ComboBox.ItemsSourceProperty, "");
            //cbxNomdiplome.ItemsSource = ((DiplomeCandVM)this.DataContext).LstDiplomes;
        }

        private void cbxNomdiplome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
