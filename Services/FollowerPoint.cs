namespace Carcassonne.Services
{
    public class FollowerPoint
    {
        public FollowerPoint(double x, double y, EdgeTypes edgeType)
        {
            X = x;
            Y = y;
            EdgeType = edgeType;
        }

        public double X { get; }

        public double Y { get; }

        public EdgeTypes EdgeType { get; }
    }
}