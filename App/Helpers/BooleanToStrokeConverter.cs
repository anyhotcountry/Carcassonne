using System;
using Windows.UI.Xaml.Data;

using Windows.UI.Xaml.Media;

namespace Carcassonne.Helpers
{
    public class BooleanToStrokeConverter : IValueConverter
    {
        private readonly DoubleCollection strokeValues;

        public BooleanToStrokeConverter()
        {
            strokeValues = new DoubleCollection();
            //strokeValues.Add(1.0);
            //strokeValues.Add(1.0);
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = System.Convert.ToBoolean(value);
            return val ? new DoubleCollection() : strokeValues;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}