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
                var canFit = (NorthTile == null || tile.GetEdge(Directions.North, rotation).FeatureType == NorthTile.GetEdge(Directions.South).FeatureType) &&
                                (EastTile == null || tile.GetEdge(Directions.East, rotation).FeatureType == EastTile.GetEdge(Directions.West).FeatureType) &&
                                (SouthTile == null || tile.GetEdge(Directions.South, rotation).FeatureType == SouthTile.GetEdge(Directions.North).FeatureType) &&
                                (WestTile == null || tile.GetEdge(Directions.West, rotation).FeatureType == WestTile.GetEdge(Directions.East).FeatureType);
                if (canFit)
                {
                    var score = 0;
                    score += NorthTile != null ? 1 : 0;
                    score += EastTile != null ? 1 : 0;
                    score += SouthTile != null ? 1 : 0;
                    score += WestTile != null ? 1 : 0;

                    score += NorthTile != null && tile.GetEdge(Directions.North, rotation).FeatureType == FeatureTypes.Road ? 1 : 0;
                    score += EastTile != null && tile.GetEdge(Directions.East, rotation).FeatureType == FeatureTypes.Road ? 1 : 0;
                    score += SouthTile != null && tile.GetEdge(Directions.South, rotation).FeatureType == FeatureTypes.Road ? 1 : 0;
                    score += WestTile != null && tile.GetEdge(Directions.West, rotation).FeatureType == FeatureTypes.Road ? 1 : 0;

                    score += NorthTile != null && tile.GetEdge(Directions.North, rotation).FeatureType == FeatureTypes.City ? 2 : 0;
                    score += EastTile != null && tile.GetEdge(Directions.East, rotation).FeatureType == FeatureTypes.City ? 2 : 0;
                    score += SouthTile != null && tile.GetEdge(Directions.South, rotation).FeatureType == FeatureTypes.City ? 2 : 0;
                    score += WestTile != null && tile.GetEdge(Directions.West, rotation).FeatureType == FeatureTypes.City ? 2 : 0;
                    yield return new FitProperties { Rotation = rotation, Score = score, Point = new Point(X, Y) };
                }
            }
        }
    }
}