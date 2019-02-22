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
    /// Logique d'interaction pour frmLivret1.xaml
    /// </summary>
    public partial class frmLivret1 : Window
    {
        public MyViewModel VM {
            get
            {
                return (MyViewModel)DataContext;
            }

        }
        private Livret1VM m_oLivret;
        public frmLivret1()
        {
            InitializeComponent();
            //Recours oLiv;
            tbDiplome.SetBinding(TextBox.TextProperty, "NomDiplome");
            tbNumLivret.SetBinding(TextBox.TextProperty, "Numero");

           // cbxEtatLivret.SetBinding(ComboBox.TextProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.SelectedItemProperty, "EtatLivret");
            cbxEtatLivret.SetBinding(ComboBox.ItemsSourceProperty, "LstEtatLivret");

            ckIsClos.SetBinding(CheckBox.IsCheckedProperty, "IsLivretClos");


            tbPieceJointes.SetBinding(TextBlock.TextProperty, "ResultatPiecesJointes");


            dtpDateJury.SetBinding(DatePicker.SelectedDateProperty, "DateJury");
            tpHeureConvoc.SetBinding(TimePicker.ValueProperty, "HeureConvoc");
            tpHeureJury.SetBinding(TimePicker.ValueProperty, "HeureJury");
            tbLieuJury.SetBinding(TextBox.TextProperty, "LieuJury");

            cbxDecision.SetBinding(ComboBox.SelectedItemProperty, "DecisionJury");
            cbxDecision.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL1");

         //   cbxMotifDetaille.SetBinding(ComboBox.SelectedItemProperty, "MotifDetailJury");
  //          cbxMotifDetaille.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifDetaille");
        //    cbxMotifDetaille.SetBinding(ComboBox.IsEnabledProperty, "IsEtatRefuse");

          //  cbxMotifGeneral.SetBinding(ComboBox.SelectedItemProperty, "MotifGeneralJury");
//            cbxMotifGeneral.SetBinding(ComboBox.ItemsSourceProperty, "lstMotifGL1");
           // cbxMotifGeneral.SetBinding(ComboBox.IsEnabledProperty, "IsEtatRefuse");

            tbCommentaire.SetBinding(TextBox.TextProperty, "CommentaireJury");
            chkRecours.SetBinding(CheckBox.IsCheckedProperty, "IsRecoursDemande");
            dtpDateLimiteRecours.SetBinding(DatePicker.SelectedDateProperty, "DateLimiteRecours");

            // Recours

            dtpDateDepotRecours.SetBinding(DatePicker.SelectedDateProperty, "DateDepot");
            tbLieuJuryRecours.SetBinding(TextBox.TextProperty, "LieuJuryRecours");
            dtpDateJuryRecours.SetBinding(DatePicker.SelectedDateProperty, "DateJuryRecours");

            tbMotifRecours.SetBinding(TextBox.TextProperty, "MotifRecours");

            tbMotifRecoursCommentaire.SetBinding(TextBox.TextProperty, "MotifRecoursCommentaire");

            cbxDecisionRecours.SetBinding(ComboBox.SelectedItemProperty, "DecisionJuryRecours");
            cbxDecisionRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstDecisionL1");

            //cbxMotifGeneralRecours.SetBinding(ComboBox.SelectedItemProperty, "MotifGeneralJuryRecours");
            //cbxMotifGeneralRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifGeneral");
            //cbxMotifGeneralRecours.SetBinding(ComboBox.IsEnabledProperty, "IsEtatRefuse");

            //cbxMotifDetailleRecours.SetBinding(ComboBox.SelectedItemProperty, "MotifDetailJuryRecours");
            //cbxMotifDetailleRecours.SetBinding(ComboBox.ItemsSourceProperty, "LstMotifDetaille");
            //cbxMotifDetailleRecours.SetBinding(ComboBox.IsEnabledProperty, "IsEtatRefuse");

            tbCommentaireRecours.SetBinding(TextBox.TextProperty, "CommentaireJuryRecours");

            tabEchanges.Visibility = Visibility.Hidden;
        }

        public void setContexte(MyViewModel pViewModel)
        {
            this.DataContext = pViewModel;
            m_oLivret = (Livret1VM) pViewModel.CurrentCandidat.CurrentLivret;
            // Mise a jour de la liste des Etat pour faire fonctionner le Set Etat
            m_oLivret.LstEtatLivret = pViewModel.LstEtatLivret1;

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

    }
}
