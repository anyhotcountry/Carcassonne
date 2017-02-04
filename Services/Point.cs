namespace Carcassonne.Services
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Point))
            {
                return false;
            }

            var p = obj as Point;
            return X == p.X && Y == p.Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}