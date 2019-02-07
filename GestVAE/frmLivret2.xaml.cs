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
    /// Logique d'interaction pour frmLivret1.xaml
    /// </summary>
    public partial class frmLivret2 : Window
    {
        public frmLivret2()
        {
            InitializeComponent();
            //Recours oLiv;
            tbDiplome.SetBinding(TextBox.TextProperty, "NomDiplome");
            cbxEtatLivret.SetBinding(ComboBox.SelectedItemProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.ItemsSourceProperty, "LstEtatLivret");

            pnlDatesEnvois.SetBinding(VisibilityProperty, "IsEnvoyeVisibility");
            pnlJury.SetBinding(VisibilityProperty, "IsRecuVisibility");
            tabJury.SetBinding(TabItem.VisibilityProperty, "IsRecuVisibility");

            tbPieceJointes.SetBinding(TextBlock.TextProperty, "ResultatPiecesJointesL2");

            tbNomJury.SetBinding(TextBox.TextProperty, "NomJury");
            tbLieuJury.SetBinding(TextBox.TextProperty, "LieuJury");

            dtpDateJury.SetBinding(DatePicker.SelectedDateProperty, "DateJury");

            cbxDecision.SetBinding(ComboBox.SelectedItemProperty, "DecisionJury");
            cbxDecision.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL2");
            // Refus de Validation
            cbxMotifDetaille.SetBinding(ComboBox.SelectedItemProperty, "MotifDetailJury");
            cbxMotifDetaille.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifDetaille");
            cbxMotifDetaille.SetBinding(ComboBox.IsEnabledProperty, "IsEtatRefuse");
            cbxMotifDetaille.SetBinding(ComboBox.VisibilityProperty, "IsNotValidationPartielleVisibility");

            cbxMotifGeneral.SetBinding(ComboBox.SelectedItemProperty, "MotifGeneralJury");
            cbxMotifGeneral.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifGeneral");
            cbxMotifGeneral.SetBinding(ComboBox.IsEnabledProperty, "IsEtatRefuse");
            cbxMotifGeneral.SetBinding(ComboBox.VisibilityProperty, "IsNotValidationPartielleVisibility");

            tbCommentaire.SetBinding(TextBox.TextProperty, "CommentaireJury");
            //chkRecours.SetBinding(CheckBox.IsCheckedProperty, "IsRecoursDemande");
            // Validation Partielle
            dgDCLivretDecision.SetBinding(DataGrid.ItemsSourceProperty, "lstDcLivretsAValider");
            dgDCLivretDecision.SetBinding(DataGrid.VisibilityProperty, "IsValidationPartielleVisibility");

            // Recours
            TabRecours.Visibility = Visibility.Hidden;
            //pnlRecours.SetBinding(VisibilityProperty, "IsRecoursDemandeVisibility");
            //TabRecours.SetBinding(TabItem.VisibilityProperty, "IsRecoursDemandeVisibility");

            //dtpDateDepotRecours.SetBinding(DatePicker.SelectedDateProperty, "DateDepot");
            //tbLieuJuryRecours.SetBinding(TextBox.TextProperty, "LieuJuryRecours");
            //dtpDateJuryRecours.SetBinding(DatePicker.SelectedDateProperty, "DateJuryRecours");

            //cbxMotifRecours.SetBinding(ComboBox.SelectedItemProperty, "MotifRecours");
            //cbxMotifRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifRecours");

            //tbMotifRecoursCommentaire.SetBinding(TextBox.TextProperty, "MotifRecoursCommentaire");

            //cbxDecisionRecours.SetBinding(ComboBox.SelectedItemProperty, "DecisionJuryRecours");
            //cbxDecisionRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL1");

            //cbxMotifGeneralRecours.SetBinding(ComboBox.SelectedItemProperty, "MotifGeneralJuryRecours");
            //cbxMotifGeneralRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifGeneral");
            //cbxMotifGeneralRecours.SetBinding(ComboBox.IsEnabledProperty, "IsRefuseRecours");

            //cbxMotifDetailleRecours.SetBinding(ComboBox.SelectedItemProperty, "MotifDetailJuryRecours");
            //cbxMotifDetailleRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifDetaille");
            //cbxMotifDetailleRecours.SetBinding(ComboBox.IsEnabledProperty, "IsRefuseRecours");

            //tbCommentaireRecours.SetBinding(TextBox.TextProperty, "CommentaireJuryRecours");

        //    cbcreerL2.SetBinding(Button.VisibilityProperty, "IsLivret1Valide");
        }

        public Livret2VM oLiv { get { return (Livret2VM)this.DataContext; } }
        public void setContexte(LivretVMBase pLivret)
        {
            this.DataContext = pLivret;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPJ_Click(object sender, RoutedEventArgs e)
        {
            //Ajout d'une piève jointe
            
            oLiv.addPJL2();
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2");
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2Color");
        }

        private void btnAddEchange_Click(object sender, RoutedEventArgs e)
        {

            
            oLiv.addEchangeL2();
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

            
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2");
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2Color");
}

        private void dgDCLivret_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!manualCommit)
            {
                manualCommit = true;
                dgPiecesjointes.CommitEdit(DataGridEditingUnit.Row, true);
                manualCommit = false;
            }

            
            oLiv.RaisePropertyChanged("lstDcLivretsAValider");

        }

        private void dbValiderDiplome_Click(object sender, RoutedEventArgs e)
        {
            oLiv.ValiderLivret2();
        }
    }
}
