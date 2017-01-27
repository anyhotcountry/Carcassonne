using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Carcassonne.Services
{
    public class Tile : Space
    {
        private readonly IList<EdgeTypes> edges;
        private BitmapImage imageSource;

        public Tile(int pennants, int cloisters, IList<EdgeTypes> edges, Uri imageUri)
        {
            ImageUri = imageUri;
            Pennants = pennants;
            Cloisters = cloisters;
            this.edges = edges.Concat(edges).ToList();
        }

        public EdgeTypes GetEdge(Direction direction, Rotation rotation)
        {
            return edges[(int)direction + (int)rotation];
        }

        public EdgeTypes GetEdge(Direction direction)
        {
            return GetEdge(direction, Rotation);
        }

        public int Pennants { get; }

        public int Cloisters { get; }

        public Rotation Rotation { get; set; }

        public Uri ImageUri { get; }

        public ImageSource ImageSource
        {
            get { return imageSource = imageSource ?? new BitmapImage(ImageUri); }
        }
    }
}