using System;
using Windows.UI.Xaml.Data;

namespace Carcassonne.Helpers
{
    public class RotationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = (int)value;
            return 90.0 * (4 - val);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}