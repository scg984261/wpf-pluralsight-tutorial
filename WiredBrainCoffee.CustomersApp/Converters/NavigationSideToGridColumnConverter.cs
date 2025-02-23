using System;
using System.Globalization;
using System.Windows.Data;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.Converters
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (NavigationSide) value;
            
            // Value for grid column.
            if (navigationSide == NavigationSide.Left)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do not need to implment as data binding only goes one way.
            throw new NotImplementedException();
        }
    }
}
