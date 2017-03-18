namespace Carcassonne.Services.Models
{
    public class Follower
    {
        public Follower(double x, double y, FeatureTypes featureType, int featureNumber)
        {
            X = x;
            Y = y;
            FeatureType = featureType;
            FeatureNumber = featureNumber;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public FeatureTypes FeatureType { get; }

        public int FeatureNumber { get; }
    }
}