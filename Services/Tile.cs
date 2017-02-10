using System;
using System.Collections.Generic;
using System.Linq;

namespace Carcassonne.Services
{
    public class Tile : Space
    {
        private readonly IList<EdgeTypes> edges;

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

        public IEnumerable<Point> GetFollowers(FitProperties selectedPossibility)
        {
            if (GetEdge(Direction.North) == EdgeTypes.City)
            {
                yield return new Point(0, 1);
            }
            if (GetEdge(Direction.East) == EdgeTypes.City)
            {
                yield return new Point(1, 0);
            }
            if (GetEdge(Direction.South) == EdgeTypes.City)
            {
                yield return new Point(0, -1);
            }
            if (GetEdge(Direction.West) == EdgeTypes.City)
            {
                yield return new Point(-1, 0);
            }
            if (GetEdge(Direction.North) == EdgeTypes.Road)
            {
                yield return new Point(0, 1);
            }
            if (GetEdge(Direction.East) == EdgeTypes.Road)
            {
                yield return new Point(1, 0);
            }
            if (GetEdge(Direction.South) == EdgeTypes.Road)
            {
                yield return new Point(0, -1);
            }
            if (GetEdge(Direction.West) == EdgeTypes.Road)
            {
                yield return new Point(-1, 0);
            }
            if (GetEdge(Direction.North) == EdgeTypes.Field)
            {
                yield return new Point(0, 1);
            }
            if (GetEdge(Direction.East) == EdgeTypes.Field)
            {
                yield return new Point(1, 0);
            }
            if (GetEdge(Direction.South) == EdgeTypes.Field)
            {
                yield return new Point(0, -1);
            }
            if (GetEdge(Direction.West) == EdgeTypes.Field)
            {
                yield return new Point(-1, 0);
            }
        }
    }
}