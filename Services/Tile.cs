using Carcassonne.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carcassonne.Services
{
    public class Tile : Space
    {
        private readonly IList<Edge> edges;
        private readonly IList<Follower> followerPositions;

        public Tile(int pennants, int cloisters, IList<Edge> edges, Uri imageUri, IList<Follower> followerPositions)
        {
            ImageUri = imageUri;
            Pennants = pennants;
            Cloisters = cloisters;
            this.edges = edges.Concat(edges).ToList();
            this.followerPositions = followerPositions;
        }

        public Edge GetEdge(Directions direction, Rotation rotation)
        {
            return edges[(int)direction + (int)rotation];
        }

        public Edge GetEdge(Directions direction)
        {
            return GetEdge(direction, Rotation);
        }

        public int Pennants { get; }

        public int Cloisters { get; }

        public Rotation Rotation { get; set; }

        public Uri ImageUri { get; }

        public IEnumerable<Follower> GetFollowers(FitProperties selectedPossibility)
        {
            var angle = 0.5 * Math.PI * (4.0 - (int)selectedPossibility.Rotation);
            return followerPositions.Select(p => new Follower(Math.Cos(angle) * p.X + Math.Sin(angle) * p.Y, Math.Cos(angle) * p.Y - Math.Sin(angle) * p.X, p.FeatureType, p.FeatureNumber));
        }
    }
}