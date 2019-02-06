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
            MyViewModel _VM = new MyViewModel();
            _VM.getData();
            this.DataContext = _VM;
            //lbCandidats.ItemsSource = _VM.lstCandidatVM;
                
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
            if (VM.CurrentCandidat.CurrentLivret.Typestr=="LIVRET1")
            {
                ofrm = new frmLivret1();
                ((frmLivret1)ofrm).setContexte(VM);
            }
            else
            {
                ofrm = new frmLivret2();
                ((frmLivret2)ofrm).setContexte(VM.CurrentCandidat.CurrentLivret);
            }


            ofrm.ShowDialog();
        }

        private void cbAddCandidat_Click(object sender, RoutedEventArgs e)
        {
            VM.AddCandidat();
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

        private void btnAddLivret2_Click(object sender, RoutedEventArgs e)
        {
            CandidatVM oCandVM = (CandidatVM)this.lbCandidats.SelectedItem;
            Livret2VM oLivVM = oCandVM.AjoutLivret2();
            frmLivret2 odlg = new frmLivret2();

            odlg.setContexte(oLivVM);

            odlg.ShowDialog();
        }

        private void cbAddDiplome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

