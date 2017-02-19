using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace Carcassonne.Helpers
{
    public class BooleanToOpacityConverter : IValueConverter
    {
        public Color TrueColour { get; set; }

        public Color FalseColour { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = System.Convert.ToBoolean(value);
            return val ? 1.0 : 0.35;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}