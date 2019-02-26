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
        private Livret2VM m_oLivret;
        public frmLivret2()
        {
            InitializeComponent();
            //Recours oLiv;
            tbDiplome.SetBinding(TextBox.TextProperty, "NomDiplome");
            tbNumLivret.SetBinding(TextBox.TextProperty, "Numero");

            // cbxEtatLivret.SetBinding(ComboBox.TextProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.SelectedItemProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.ItemsSourceProperty, "LstEtatLivret");

            ckIsClos.SetBinding(CheckBox.IsCheckedProperty, "IsLivretClos");
            ckIsOuvertureApresRecours.SetBinding(CheckBox.IsCheckedProperty, "IsOuvertureApresRecours");

            tbPieceJointes.SetBinding(TextBlock.TextProperty, "ResultatPiecesJointes");


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
            m_oLivret = (Livret2VM)pViewModel.CurrentCandidat.CurrentLivret;
            // Mise a jour de la liste des Etat pour faire fonctionner le Set Etat
            m_oLivret.LstEtatLivret = pViewModel.LstEtatLivret2;
            pViewModel.CloseAction = new Action(() => this.Close());
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

            m_oLivret.RaisePropertyChanged("ResultatPiecesJointes");
            m_oLivret.RaisePropertyChanged("ResultatPiecesJointesColor");
        }

        private void dgDCLivret_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
