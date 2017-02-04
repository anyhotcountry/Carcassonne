using Carcassonne.Services;
using System;
using Template10.Mvvm;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Carcassonne.ViewModels
{
    public class TileViewModel : Mvvm.ViewModelBase
    {
        private ImageSource imageSource;
        private Rotation rotation;

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

        public DelegateCommand ClickCommand { get; set; }

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { Set(ref imageSource, value); }
        }

        public double Y { get; set; }

        public double X { get; set; }

        public Rotation Rotation
        {
            get { return rotation; }
            set { Set(ref rotation, value); }
        }
    }
}