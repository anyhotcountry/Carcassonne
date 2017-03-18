namespace Carcassonne.Services
{
    public class FollowerPoint
    {
        public FollowerPoint(double x, double y, FeatureTypes edgeType, int targetNumber)
        {
            X = x;
            Y = y;
            EdgeType = edgeType;
        }

        public double X { get; }

        public double Y { get; }

        public FeatureTypes EdgeType { get; }
    }
}