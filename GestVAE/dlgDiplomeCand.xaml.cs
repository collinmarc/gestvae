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
        public MyViewModel VM
        {
            get
            {
                return (MyViewModel)DataContext;
            }
        }
        public dlgDiplomeCand()
        {
            InitializeComponent();
            cbxNomdiplome.SetBinding(ComboBox.SelectedItemProperty, "CurrentDiplomeCand.oDiplome");
            cbxNomdiplome.SetBinding(ComboBox.ItemsSourceProperty, "CurrentDiplomeCand.LstDiplomes");
            cbxNomdiplome.DisplayMemberPath = "Nom";
            cbxNomdiplome.SelectedValuePath = "Nom";

            cbxStatutdiplome.SetBinding(ComboBox.SelectedValueProperty, "CurrentDiplomeCand.StatutDiplome");
            cbxStatutdiplome.SetBinding(ComboBox.ItemsSourceProperty, "CurrentDiplomeCand.LstStatutDiplome");


            dtDateObtention.SetBinding(DatePicker.SelectedDateProperty, "CurrentDiplomeCand.DateObtentionDiplome");
            tbNumero.SetBinding(TextBox.TextProperty, "CurrentDiplomeCand.NumeroDiplome");
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        public void setContexte(MyViewModel pVM)
        {
            this.DataContext = pVM;
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

            DiplomeCandVM oDipCandVM = VM.CurrentDiplomeCand;
            oDipCandVM.CalcStatutDiplome();

        }

        private void btnAddDiplome_Click(object sender, RoutedEventArgs e)
        {
            dlgDiplome odlg = new dlgDiplome();
            DiplomeVM odiplomeVM = new DiplomeVM();
            odlg.setContexte(odiplomeVM);
            odlg.ShowDialog();

            VM.CurrentDiplomeCand.RefreshlstDiplome();
            //cbxNomdiplome.SetBinding(ComboBox.ItemsSourceProperty, "");
            //cbxNomdiplome.ItemsSource = ((DiplomeCandVM)this.DataContext).LstDiplomes;
        }

        private void cbxNomdiplome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
