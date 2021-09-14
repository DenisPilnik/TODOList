using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TODO_List.Converters
{
    public class SelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var IsSelected = value == null ? true: false;
            return IsSelected ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
