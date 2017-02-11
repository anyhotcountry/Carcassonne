using System;
using System.Collections.Generic;
using System.Linq;

namespace Carcassonne.Services
{
    public class Tile : Space
    {
        private readonly IList<EdgeTypes> edges;
        private readonly IList<FollowerPoint> followerPositions;

        public Tile(int pennants, int cloisters, IList<EdgeTypes> edges, Uri imageUri, IList<FollowerPoint> followerPositions)
        {
            ImageUri = imageUri;
            Pennants = pennants;
            Cloisters = cloisters;
            this.edges = edges.Concat(edges).ToList();
            this.followerPositions = followerPositions;
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

        public IEnumerable<FollowerPoint> GetFollowers(FitProperties selectedPossibility)
        {
            var angle = 0.5 * Math.PI * (4.0 - (int)selectedPossibility.Rotation);
            return followerPositions.Select(p => new FollowerPoint(Math.Cos(angle) * p.X + Math.Sin(angle) * p.Y, Math.Cos(angle) * p.Y - Math.Sin(angle) * p.X, p.EdgeType));
        }
    }
}