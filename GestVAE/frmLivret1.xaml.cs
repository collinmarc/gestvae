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
    public partial class frmLivret1 : Window
    {
        public frmLivret1()
        {
            InitializeComponent();

            tbDiplome.SetBinding(TextBox.TextProperty, "NomDiplome");
            cbxEtatLivret.SetBinding(ComboBox.SelectedItemProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.ItemsSourceProperty, "LstEtatLivret");

            pnlDatesEnvois.SetBinding(VisibilityProperty, "IsEnvoyeVisibility");
            pnlJury.SetBinding(VisibilityProperty, "IsRecuVisibility");

            tbPieceJointes.SetBinding(TextBlock.TextProperty, "ResultatPiecesJointesL1");

            tbNomJury.SetBinding(TextBox.TextProperty, "NomJury");
            tbLieuJury.SetBinding(TextBox.TextProperty, "LieuJury");

            dtpDateJury.SetBinding(DatePicker.SelectedDateProperty, new Binding("DateJury"));

            cbxDecision.SetBinding(ComboBox.SelectedItemProperty, "DecisionJury");
            cbxDecision.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL1");

            cbxMotifDetaille.SetBinding(ComboBox.SelectedItemProperty, "MotifDetailJury");
            cbxMotifDetaille.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifDetaille");
            cbxMotifDetaille.SetBinding(ComboBox.IsEnabledProperty, "IsRefuse");

            cbxMotifGeneral.SetBinding(ComboBox.SelectedItemProperty, "MotifGeneralJury");
            cbxMotifGeneral.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifGeneral");
            cbxMotifGeneral.SetBinding(ComboBox.IsEnabledProperty, "IsRefuse");

            tbCommentaire.SetBinding(TextBox.TextProperty, "CommentaireJury");

        }

        public void setContexte(LivretVM pLivret)
        {
            this.DataContext = pLivret;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddPJ_Click(object sender, RoutedEventArgs e)
        {
            //Ajout d'une piève jointe
            LivretVM oLiv = (LivretVM)this.DataContext;
            oLiv.addPJL1();
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL1");
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL1Color");
        }

        private void btnAddEchange_Click(object sender, RoutedEventArgs e)
        {

            LivretVM oLiv = (LivretVM)this.DataContext;
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

            LivretVM oLiv = (LivretVM)this.DataContext;
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL1");
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL1Color");
}
    }
}
