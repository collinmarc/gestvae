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
    public class MyDataGridDateTimeColumn : DataGridBoundColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var textBox = new TextBlock();
            BindingOperations.SetBinding(textBox, TextBlock.TextProperty, Binding);
            return textBox;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var control = new DatePicker { };
            control.Margin = new Thickness(0d);
            BindingOperations.SetBinding(control, DatePicker.SelectedDateProperty, Binding);
            return control;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            DatePicker control = editingElement as DatePicker;
            if (control == null) return null;

            control.IsDropDownOpen= true;
            control.Focus();
            // This solves the double-tabbing problem that Nick mentioned.
            return control.Text;
        }
    }
}
