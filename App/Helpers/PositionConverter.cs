using System;
using Windows.UI.Xaml.Data;

namespace Carcassonne.Helpers
{
    public class PositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = System.Convert.ToInt32(value);
            return 500 + val * 50;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}