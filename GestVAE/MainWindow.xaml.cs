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

        public MyViewModel VM
        {
            get
            {
                return (MyViewModel)DataContext;
            }

        }
        public MainWindow()
        {
            InitializeComponent();
            CSDebug.TraceINFO("MainWindow.Construct");

            tbRechIdentVAE.SetBinding(TextBox.TextProperty, "rechIdentifiantVAE");
            tbRechIdentSISCOLE.SetBinding(TextBox.TextProperty, "rechIdentifiantSISCOLE");
            tbRechNom.SetBinding(TextBox.TextProperty, "rechNom");
            tbRechPrénom.SetBinding(TextBox.TextProperty, "rechPrenom");
            tbRechVille.SetBinding(TextBox.TextProperty, "rechVille");
            dpRechDateNaiss.SetBinding(DatePicker.SelectedDateProperty, "rechDateNaissance");
            dpRechReceptL1Deb.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL1Deb");
            dpRechReceptL1Fin.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL1Fin");
            dpRechReceptL2Deb.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL2Deb");
            dpRechReceptL2Fin.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL2Fin");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CSDebug.TraceINFO("MainWindow.Window_Loaded : Start");
            MyViewModel _VM = new MyViewModel();
            _VM.getData();
            this.DataContext = _VM;
            //lbCandidats.ItemsSource = _VM.lstCandidatVM;
            CSDebug.TraceINFO("MainWindow.Window_Loaded : End");

        }
        bool manualCommit = false;
        private void gridLstDiplome_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!manualCommit)
            {
                manualCommit = true;
                gridLstDiplome.CommitEdit(DataGridEditingUnit.Row, true);
                manualCommit = false;
            }
        }

        private void gridLstDiplome_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dlgDiplomeCand odlg = new dlgDiplomeCand();
            VM.CurrentDiplomeCand = (DiplomeCandVM)gridLstDiplome.SelectedItem;
            odlg.setContexte(VM);

            odlg.ShowDialog();
        }

        private void gridLstLivrets_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void gridLstLivrets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window ofrm = null;
            if (VM.CurrentCandidat.CurrentLivret.Typestr=="LIVRET1")
            {
                ofrm = new frmLivret1();
                ((frmLivret1)ofrm).setContexte(VM);
            }
            else
            {
                ofrm = new frmLivret2();
                ((frmLivret2)ofrm).setContexte(VM);
            }


            ofrm.ShowDialog();
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (VM.HasChanges())
            {
                if (MessageBox.Show("Attention, certaines modifications seront perdues, voulez-vous continuer?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    VM.UnlockCandidats();
                }
            }
            else
            {
                VM.UnlockCandidats();
            }


        }
    }
}

