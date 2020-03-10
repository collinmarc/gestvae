using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GestVAE
{
    public class MyDataGridComboboxColumn : DataGridBoundColumn
    {
        public Binding ItemsSourceBinding { get; set; }
        public String ItemSourceDisplayMemberPath { get; set; }
        public Binding SelectedItemBinding { get; set; }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var textBox = new TextBlock();
            BindingOperations.SetBinding(textBox, TextBlock.TextProperty, Binding);
            return textBox;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var comboBox = new ComboBox { IsEditable = true };
            BindingOperations.SetBinding(comboBox, ComboBox.TextProperty, Binding);
            BindingOperations.SetBinding(comboBox, ComboBox.ItemsSourceProperty, ItemsSourceBinding);
            if (SelectedItemBinding != null)
            {
                BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, SelectedItemBinding);
            }
            comboBox.DisplayMemberPath = ItemSourceDisplayMemberPath;
            return comboBox;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            var comboBox = editingElement as ComboBox;
            if (comboBox == null) return null;

            comboBox.Focus(); // This solves the double-tabbing problem that Nick mentioned.
            return comboBox.Text;
        }
    }
}
