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
using Xceed.Wpf.Toolkit;

namespace GestVAE
{
    /// <summary>
    /// Logique d'interaction pour frmLivret2.xaml
    /// </summary>
    public partial class frmLivret2 : Window
    {
        public MyViewModel VM
        {
            get
            {
                return (MyViewModel)DataContext;
            }

        }
        public Livret2VM oLivret2VM
        {
            get
            {
                if (VM.CurrentCandidat != null)
                {

                    return (Livret2VM)VM.CurrentCandidat.CurrentLivret;
                }
                else
                {
                    return null;
                }
            }

        }
        public frmLivret2()
        {
            InitializeComponent();
            //Recours oLiv;
            tbNumLivret.SetBinding(TextBox.TextProperty, "Numero");

            // cbxEtatLivret.SetBinding(ComboBox.TextProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.SelectedItemProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.ItemsSourceProperty, "LstEtatLivret");

            ckIsClos.SetBinding(CheckBox.IsCheckedProperty, "IsLivretClos");
            ckIsOuvertureApresRecours.SetBinding(CheckBox.IsCheckedProperty, "IsOuvertureApresRecours");


            dtpDateEnvoiCourierJury.SetBinding(DatePicker.SelectedDateProperty, "DateEnvoiCourrierJury");
            dtpDateJury.SetBinding(DatePicker.SelectedDateProperty, "DateJury");
            tpHeureConvoc.SetBinding(TimePicker.ValueProperty, "HeureConvoc");
            tpHeureJury.SetBinding(TimePicker.ValueProperty, "HeureJury");
            tbLieuJury.SetBinding(TextBox.TextProperty, "LieuJury");

            cbxDecision.SetBinding(ComboBox.SelectedItemProperty, "DecisionJury");
            cbxDecision.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL2");

            tabEchanges.Visibility = Visibility.Hidden;
        }

        public void setContexte(MyViewModel pViewModel)
        {
            this.DataContext = pViewModel;
            // Mise a jour de la liste des Etat pour faire fonctionner le Set Etat
            oLivret2VM.LstEtatLivret = pViewModel.LstEtatLivret2;
            pViewModel.CloseAction = new Action(() => this.Close());
            // Bind Manuel car incompréhensible
            rbcontrat.IsChecked = oLivret2VM.IsContrat;
            rbconvention.IsChecked = oLivret2VM.IsConvention;
            rbIsNonRecu.IsChecked = oLivret2VM.IsNonRecu;

        }


        private void btnAddEchange_Click(object sender, RoutedEventArgs e)
        {

            Livret1VM oLiv = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            oLiv.addEchangeL1();
        }
        bool manualCommit = false;

        private void dgPiecesjointes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (!manualCommit)
            {
                manualCommit = true;
                dgPiecesjointes.CommitEdit(DataGridEditingUnit.Row, true);
                manualCommit = false;
            }

            oLivret2VM.RaisePropertyChanged("ResultatPiecesJointes");
            oLivret2VM.RaisePropertyChanged("ResultatPiecesJointesColor");
        }

        private void dgDCLivret_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void cbQuitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgMembreJury_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new VM.MembreJuryVM();
        }

        private void dgMembreJury_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //'CSDebug.TraceINFO(VM.CurrentCandidat.CurrentLivret.SelectedMembreJ.Nom);
        }

        private void DtpEnvoiCandidat_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Boolean bEnabled = false;
            if (oLivret2VM != null)
            {
                bEnabled = oLivret2VM.IsValiderOK();

            }
            cbValider.IsEnabled = bEnabled;
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            cbValider.IsEnabled = oLivret2VM.IsValiderOK();

        }

        private void CbxCategoriePJ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.RaisePropertyChanged("IsAjoutPJPossible");

        }

        private void CbxLibellePJ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.RaisePropertyChanged("IsAjoutPJPossible");

        }

    }
}
