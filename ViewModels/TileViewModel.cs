using Carcassonne.Services;
using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Carcassonne.ViewModels
{
    public class TileViewModel
    {
        public TileViewModel(double x, double y, Rotation rotation, Uri imageUri)
        {
            X = x;
            Y = y;
            Rotation = rotation;
            ImageSource = new BitmapImage(imageUri);
        }

        public TileViewModel(double x, double y)
        {
            X = x;
            Y = y;
        }

        public ImageSource ImageSource { get; }

        public double Y { get; set; }

        public double X { get; set; }

        public Rotation Rotation { get; }
    }
}