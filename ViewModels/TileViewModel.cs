using Carcassonne.Services;
using Windows.UI.Xaml.Media;

namespace Carcassonne.ViewModels
{
    public class TileViewModel
    {
        public TileViewModel(double x, double y, Rotation rotation, ImageSource imageSource)
        {
            X = x;
            Y = y;
            Rotation = rotation;
            ImageSource = imageSource;
        }

        public ImageSource ImageSource { get; }

        public double Y { get; set; }

        public double X { get; set; }

        public Rotation Rotation { get; }
    }
}