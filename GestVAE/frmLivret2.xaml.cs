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
    /// Logique d'interaction pour frmLivret2.xaml
    /// </summary>
    public partial class frmLivret2 : Window
    {
        public frmLivret2()
        {
            InitializeComponent();

            tbDiplome.SetBinding(TextBox.TextProperty, "NomDiplome");
            cbxEtatLivret.SetBinding(ComboBox.SelectedItemProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.ItemsSourceProperty, "LstEtatLivret");

            pnlDatesEnvois.SetBinding(VisibilityProperty, "IsEnvoyeVisibility");
            pnlJury.SetBinding(VisibilityProperty, "IsRecuVisibility");

            tbPieceJointes.SetBinding(TextBlock.TextProperty, "ResultatPiecesJointesL2");

            tbNomJury.SetBinding(TextBox.TextProperty, "NomJury");
            tbLieuJury.SetBinding(TextBox.TextProperty, "LieuJury");

            dtpDateJury.SetBinding(DatePicker.SelectedDateProperty, new Binding("DateJury"));

            cbxDecision.SetBinding(ComboBox.SelectedItemProperty, "DecisionJury");
            cbxDecision.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL2");

            cbxMotifDetaille.SetBinding(ComboBox.SelectedItemProperty, "MotifDetailJury");
            cbxMotifDetaille.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifDetaille");
            cbxMotifDetaille.SetBinding(ComboBox.IsEnabledProperty, "IsRefuse");

            cbxMotifGeneral.SetBinding(ComboBox.SelectedItemProperty, "MotifGeneralJury");
            cbxMotifGeneral.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifGeneral");
            cbxMotifGeneral.SetBinding(ComboBox.IsEnabledProperty, "IsRefuse");

            tbCommentaire.SetBinding(TextBox.TextProperty, "CommentaireJury");

        }

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
            Livret2VM oLiv = (Livret2VM)this.DataContext;
            oLiv.addPJL2();
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2");
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2Color");
        }

        private void btnAddEchange_Click(object sender, RoutedEventArgs e)
        {

            Livret1VM oLiv = (Livret1VM)this.DataContext;
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

            Livret1VM oLiv = (Livret1VM)this.DataContext;
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2");
            oLiv.RaisePropertyChanged("ResultatPiecesJointesL2Color");
}
    }
}
