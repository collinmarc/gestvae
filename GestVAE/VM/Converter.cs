using GestVAE.VM;
using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace GestVAE
{
    public class BooleanToCursorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool?)value == true)
            {
                return Cursors.Wait;
            }
            else
            {
                return Cursors.Arrow;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class EnumToBoleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(parameter);
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }

    [ValueConversion(typeof(bool), typeof(GridLength))]
    public class BoolToGridRowHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value == true) ? new GridLength(1, GridUnitType.Auto) : new GridLength(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }

    [ValueConversion(typeof(EnumTypeCommentaire), typeof(String))]
    public class TypeCommentaireToBackgroundConverter : IValueConverter
    {
        public bool Inverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                EnumTypeCommentaire o = (EnumTypeCommentaire)value;
                String strReturn = "";
                switch (o)
                {
                    case EnumTypeCommentaire.INFO:
                        strReturn = "yellow";
                        break;
                    case EnumTypeCommentaire.IMPORTANT:
                        strReturn = "red";
                        break;
                    default:
                        strReturn = "red";
                        break;
                }
                return strReturn;

            }
            catch (Exception)
            {
                return "gray";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }

    [ValueConversion(typeof(EnumTypeCommentaire), typeof(Binding))]
    public class ABConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EnumTypeCommentaire o = (EnumTypeCommentaire)value;
            String strReturn = "";
            switch (o)
            {
                case EnumTypeCommentaire.INFO:
                    strReturn = "{StaticResource ResourceKey=SNYellow}";
                    break;
                case EnumTypeCommentaire.IMPORTANT:
                    strReturn = "{StaticResource ResourceKey=SNRed}";
                    break;
                default:
                    strReturn = "{StaticResource ResourceKey=SNGray}";
                    break;
            }
            return strReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }
    [ValueConversion(typeof(bool), typeof(string))]
    public class TolereToBackgroudConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String str = new ContextParam().dbParam.First().CouleurTolerance;
            return ((bool)value == true) ? str : "#FFDDDDDD";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }

    public class InvertVisibilityConverter : IValueConverter
    {

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                Visibility vis = (Visibility)value;
                return vis == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new InvalidOperationException("Converter can only convert to value of type Visibility.");
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new Exception("Invalid call - one way only");
        }
    }
    [ValueConversion(typeof(bool), typeof(bool))]
    public class BooleanConverter : IValueConverter
    {

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                Visibility vis = (Visibility)value;
                return vis == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new InvalidOperationException("Converter can only convert to value of type Visibility.");
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new Exception("Invalid call - one way only");
        }
    }
}
