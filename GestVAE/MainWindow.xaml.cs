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

        private MyViewModel _VM;
        public MainWindow()
        {
            InitializeComponent();
            tbRechIdentVAE.SetBinding(TextBox.TextProperty, "rechIdentifiantVAE");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _VM = new MyViewModel();
            _VM.getData();
            this.DataContext = _VM;
            lbCandidats.ItemsSource = _VM.lstCandidatVM;
           grid1.DataContext = _VM.lstCandidatVM;
                
        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _VM.saveData();
            
        }
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _VM.populate();
        }
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _VM.populate();

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
            DiplomeCandVM obj = (DiplomeCandVM)gridLstDiplome.SelectedItem;
            odlg.setContexte(obj);

            odlg.ShowDialog();
        }

        private void gridLstLivrets_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void gridLstLivrets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window ofrm = null;
            LivretVMBase obj = (LivretVMBase)gridLstLivrets.SelectedItem;
            if (obj.TheLivret.Typestr=="LIVRET1")
            {
                ofrm = new frmLivret1();
                ((frmLivret1)ofrm).setContexte(obj);
            }
            else
            {
                ofrm = new frmLivret2();
                ((frmLivret2)ofrm).setContexte(obj);
            }


            ofrm.ShowDialog();
        }

        private void cbAddCandidat_Click(object sender, RoutedEventArgs e)
        {
            _VM.AddCandidat();
        }

        /// <summary>
        /// Ajout d'un diplome au Candidat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDiplomeCand_Click(object sender, RoutedEventArgs e)
        {
            CandidatVM oCandVM = (CandidatVM)this.lbCandidats.SelectedItem;
            DiplomeCandVM oDipCandVM= oCandVM.AjoutDiplomeCand();
            dlgDiplomeCand odlg = new dlgDiplomeCand();
            
            odlg.setContexte(oDipCandVM);

            odlg.ShowDialog();

        }

        private void btnAddLivret1_Click(object sender, RoutedEventArgs e)
        {

            CandidatVM oCandVM = (CandidatVM)this.lbCandidats.SelectedItem;
            Livret1VM oLivVM = oCandVM.AjoutLivret1();
            frmLivret1 odlg = new frmLivret1();

            odlg.setContexte(oLivVM);

            odlg.ShowDialog();
        }

        private void btnAddLivret2_Click(object sender, RoutedEventArgs e)
        {
            CandidatVM oCandVM = (CandidatVM)this.lbCandidats.SelectedItem;
            Livret2VM oLivVM = oCandVM.AjoutLivret2();
            frmLivret2 odlg = new frmLivret2();

            odlg.setContexte(oLivVM);

            odlg.ShowDialog();
        }

        private void cbRecherche_Click(object sender, RoutedEventArgs e)
        {
            _VM.Recherche();
        }
    }
}

