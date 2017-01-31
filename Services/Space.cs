using System;
using System.Collections.Generic;
using System.Linq;

namespace Carcassonne.Services
{
    public class Space
    {
        public Tile NorthTile { get; set; }

        public Tile EastTile { get; set; }

        public Tile SouthTile { get; set; }

        public Tile WestTile { get; set; }

        public int Y { get; set; } = 0;

        public int X { get; set; } = 0;

        public IEnumerable<FitProperties> CanFit(Tile tile)
        {
            foreach (var rotation in Enum.GetValues(typeof(Rotation)).OfType<Rotation>())
            {
                var canFit = (NorthTile == null || tile.GetEdge(Direction.North, rotation) == NorthTile.GetEdge(Direction.South)) &&
                                (EastTile == null || tile.GetEdge(Direction.East, rotation) == EastTile.GetEdge(Direction.West)) &&
                                (SouthTile == null || tile.GetEdge(Direction.South, rotation) == SouthTile.GetEdge(Direction.North)) &&
                                (WestTile == null || tile.GetEdge(Direction.West, rotation) == WestTile.GetEdge(Direction.East));
                if (canFit)
                {
                    var score = 0;
                    score += NorthTile != null ? 1 : 0;
                    score += EastTile != null ? 1 : 0;
                    score += SouthTile != null ? 1 : 0;
                    score += WestTile != null ? 1 : 0;

                    score += NorthTile != null && tile.GetEdge(Direction.North, rotation) == EdgeTypes.Road ? 1 : 0;
                    score += EastTile != null && tile.GetEdge(Direction.East, rotation) == EdgeTypes.Road ? 1 : 0;
                    score += SouthTile != null && tile.GetEdge(Direction.South, rotation) == EdgeTypes.Road ? 1 : 0;
                    score += WestTile != null && tile.GetEdge(Direction.West, rotation) == EdgeTypes.Road ? 1 : 0;

                    score += NorthTile != null && tile.GetEdge(Direction.North, rotation) == EdgeTypes.City ? 2 : 0;
                    score += EastTile != null && tile.GetEdge(Direction.East, rotation) == EdgeTypes.City ? 2 : 0;
                    score += SouthTile != null && tile.GetEdge(Direction.South, rotation) == EdgeTypes.City ? 2 : 0;
                    score += WestTile != null && tile.GetEdge(Direction.West, rotation) == EdgeTypes.City ? 2 : 0;
                    yield return new FitProperties { Rotation = rotation, Score = score, X = X, Y = Y };
                }
            }
        }
    }
}