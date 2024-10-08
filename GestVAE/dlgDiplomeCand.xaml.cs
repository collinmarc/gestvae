﻿using GestVAE.VM;
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
    /// Logique d'interaction pour dlgDetail.xaml
    /// </summary>
    public partial class dlgDiplomeCand: Window
    {
        public MyViewModel VM
        {
            get
            {
                return (MyViewModel)DataContext;
            }
        }
        public dlgDiplomeCand()
        {
            InitializeComponent();

            cbxStatutdiplome.SetBinding(ComboBox.SelectedValueProperty, "CurrentCandidat.CurrentDiplomeCand.StatutDiplome");
            cbxStatutdiplome.SetBinding(ComboBox.ItemsSourceProperty, "CurrentCandidat.CurrentDiplomeCand.LstStatutDiplome");

            dtDateObtention.SetBinding(DatePicker.SelectedDateProperty, "CurrentCandidat.CurrentDiplomeCand.DateObtentionDiplome");
            cbxModeObtention.SetBinding(ComboBox.SelectedValueProperty, "CurrentCandidat.CurrentDiplomeCand.ModeObtention");

            tbNumero.SetBinding(TextBox.TextProperty, "CurrentCandidat.CurrentDiplomeCand.NumeroDiplome");
            tbNumeroEURODIR.SetBinding(TextBox.TextProperty, "CurrentCandidat.CurrentDiplomeCand.NumeroEURODIR");
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        public void setContexte(MyViewModel pVM)
        {
            this.DataContext = pVM;
        }
        bool manualCommit = false;

        private void dgDC_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Statut")
            {
                if (!manualCommit)
                {
                    manualCommit = true;
                    dgDC.CommitEdit(DataGridEditingUnit.Row, true);
                    manualCommit = false;
                }
            }

            DiplomeCandVM oDipCandVM = VM.CurrentCandidat.CurrentDiplomeCand;
            oDipCandVM.CalcStatutDiplome();

        }

        private void cbxNomdiplome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
