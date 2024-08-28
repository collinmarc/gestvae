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
using GestVAE.VM;
using GestVAEcls;

namespace GestVAE
{
    /// <summary>
    /// Logique d'interaction pour dlgMigration.xaml
    /// </summary>
    public partial class dlgMigration : Window
    {
        public dlgMigration()
        {
            InitializeComponent();
        }
        private MyViewModel getViewModel()
        {
            return (MyViewModel)this.DataContext;
        }



        internal void setContexte(MyViewModel pModel)
        {
            this.DataContext = pModel;
        }

        private void CbMigrationCAFDESV2_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Candidat> rq;
            getViewModel().IsInTest = true; // On utilise les commandes de l'interface sans agir sur les fenêtres
            rq = getViewModel()._ctx.Candidats;
            this.pbCandidats.Maximum = rq.Count();
            pbCandidats.Value = 0;
            foreach (Candidat item in rq)
            {

                getViewModel().CurrentCandidat = new CandidatVM(item);
                foreach (LivretVMBase oL in getViewModel().CurrentCandidat.lstLivretsActif)
                {
                    pbCandidats.Value = pbCandidats.Value + 1;
                    if (!oL.IsCAFDESV2)
                    {
                        getViewModel().CurrentCandidat.CurrentLivret = oL;
                        getViewModel().MigrationCAFDESV2();
                    }
                }
            }

        }
    }
}
