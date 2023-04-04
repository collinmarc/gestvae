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
            tbRechIdentVAE.SetBinding(TextBox.TextProperty, "rechIdentifiantVAE");
            tbRechIdentSISCOLE.SetBinding(TextBox.TextProperty, "rechIdentifiantSISCOLE");
            //tbRechNom.SetBinding(TextBox.TextProperty, "rechNom");
            tbRechPrénom.SetBinding(TextBox.TextProperty, "rechPrenom");
            tbRechVille.SetBinding(TextBox.TextProperty, "rechVille");
            dpRechDateNaiss.SetBinding(DatePicker.SelectedDateProperty, "rechDateNaissance");
            dpRechReceptL1Deb.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL1Deb");
            dpRechReceptL1Fin.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL1Fin");
            dpRechReceptL2Deb.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL2Deb");
            dpRechReceptL2Fin.SetBinding(DatePicker.SelectedDateProperty, "rechDateReceptL2Fin");
            dpRechValidL1Deb.SetBinding(DatePicker.SelectedDateProperty, "rechDateValidL1Deb");
            dpRechValidL1Fin.SetBinding(DatePicker.SelectedDateProperty, "rechDateValidL1Fin");
            dpRechValidL2Deb.SetBinding(DatePicker.SelectedDateProperty, "rechDateValidL2Deb");
            dpRechValidL2Fin.SetBinding(DatePicker.SelectedDateProperty, "rechDateValidL2Fin");
            ckRechHandicap.SetBinding(CheckBox.IsCheckedProperty, "rechbHandicap");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyViewModel _VM = new MyViewModel();
            this.DataContext = _VM;
            _VM.getParams();
            
            //cbxPaysNaissance.ItemsSource = VM.lstParamBDPays;
#if DEBUG
            VM.rechNom = "COLLIN";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];

#endif

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
            odlg.setContexte(VM);

            odlg.ShowDialog();
        }

        private void gridLstLivrets_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void gridLstLivrets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window ofrm = null;
            VM.CurrentCandidat.CurrentLivret = (LivretVMBase)gridLstLivrets.SelectedItem;
            VM.CurrentCandidat.CurrentLivret.IsLocked = VM.IsCurrentCandidatLocked;
            if (VM.CurrentCandidat.CurrentLivret is Livret1VM)
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
                if (MessageBox.Show("Attention, certaines modifications seront perdues.\nVoulez-vous quitter sans sauvegarder?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning)
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

        private void CbxDepartementNaissance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbxPaysNaissance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                BDPays oPays = (BDPays)e.AddedItems[0];
                tbCodeInseePaysNaissance.Text = oPays.CODENUM3;
                if (!oPays.IsPaysFrance)
                {
                    tbCodeINSEECommuneNaissance.Text = oPays.CODENUM3;

                }

            }
        }

        private void CbxVilleNaissance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                BDCommune oCommune = (BDCommune)e.AddedItems[0];
                VM.CurrentCandidat.INSEECommuneNaissance = oCommune.code_commune_insee;
                VM.CurrentCandidat.CPNaissance = oCommune.code_postal;
            }

        }


        private void TbCPNaissance_LostFocus(object sender, RoutedEventArgs e)
        {
            //VM.RaisePropertyChanged("lstParamBDCommunes");
            //VM.RaisePropertyChanged("lstParamBDCommunesFiltreesparCPNaissance");
        }
    }
}

