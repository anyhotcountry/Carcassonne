using Carcassonne.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace Carcassonne.Services
{
    public class TilesService : ITilesService
    {
        private const string StartTileName = "04crfr00";

        private static readonly IDictionary<char, FeatureTypes> Edges = new Dictionary<char, FeatureTypes>
        {
            ['c'] = FeatureTypes.City,
            ['f'] = FeatureTypes.Field,
            ['r'] = FeatureTypes.Road,
            ['w'] = FeatureTypes.Water,
        };

        private readonly Uri baseUri;
        private IList<Space> spaces;
        private List<Tile> remainingTiles;
        private List<Tile> playedTiles;
        private Tile startTile;
        private int counter;
        private IEnumerable<TileDefinition> tileDefinitions;

        public TilesService(Uri baseUri)
        {
            this.baseUri = baseUri;
        }

        public async Task LoadTiles()
        {
            var assetsFolder = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
            var tilesFile = await assetsFolder.GetFileAsync("tiles.json");
            var json = await FileIO.ReadTextAsync(tilesFile);
            tileDefinitions = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<TileDefinition>>(json));
            remainingTiles = tileDefinitions.SelectMany(d => Enumerable.Repeat(0, d.Count).Select(x => new Tile(d.Pennants, d.Cloisters, d.Edges, new Uri(baseUri, d.Filename), d.Followers))).ToList();
            startTile = tileDefinitions.Where(d => d.IsStarting).Select(d => new Tile(d.Pennants, d.Cloisters, d.Edges, new Uri(baseUri, d.Filename), d.Followers)).First();
            counter = -1;
            playedTiles = new List<Tile>();
            spaces = new List<Space>();
        }

        public Tile NextTile()
        {
            if (counter == -1)
            {
                counter++;
                return startTile;
            }

            return counter < remainingTiles.Count ? remainingTiles[counter++] : null;
        }

        public IEnumerable<FitProperties> GetPossibilities(Tile tile)
        {
            if (tile == startTile)
            {
                return Enum.GetValues(typeof(Rotation)).OfType<Rotation>().Select(r => new FitProperties { Point = new Point(0, 0), Rotation = r });
            }

            return spaces.SelectMany(s => s.CanFit(tile));
        }

        public async Task Reset()
        {
            if (remainingTiles != null)
            {
                remainingTiles = remainingTiles.Concat(playedTiles).OrderBy(x => Guid.NewGuid()).ToList();
                await Task.Yield();
                playedTiles.Clear();
                spaces.Clear();
                counter = -1;
            }
        }

        public void PlaceTile(Tile tile, FitProperties properties)
        {
            var spaceToRemove = spaces.FirstOrDefault(s => s.X == properties.Point.X && s.Y == properties.Point.Y);
            var spacesAndTiles = spaces.Concat(playedTiles.Cast<Space>()).ToList();
            var northSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.Point.X && s.Y == properties.Point.Y + 1);
            var eastSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.Point.X + 1 && s.Y == properties.Point.Y);
            var southSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.Point.X && s.Y == properties.Point.Y - 1);
            var westSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.Point.X - 1 && s.Y == properties.Point.Y);
            if (northSpace == null)
            {
                northSpace = new Space { SouthTile = tile, X = properties.Point.X, Y = properties.Point.Y + 1 };
                spaces.Add(northSpace);
            }

            if (eastSpace == null)
            {
                eastSpace = new Space { WestTile = tile, X = properties.Point.X + 1, Y = properties.Point.Y };
                spaces.Add(eastSpace);
            }

            if (southSpace == null)
            {
                southSpace = new Space { NorthTile = tile, X = properties.Point.X, Y = properties.Point.Y - 1 };
                spaces.Add(southSpace);
            }

            if (westSpace == null)
            {
                westSpace = new Space { EastTile = tile, X = properties.Point.X - 1, Y = properties.Point.Y };
                spaces.Add(westSpace);
            }

            northSpace.SouthTile = tile;
            eastSpace.WestTile = tile;
            southSpace.NorthTile = tile;
            westSpace.EastTile = tile;

            playedTiles.Add(tile);
            tile.X = properties.Point.X;
            tile.Y = properties.Point.Y;
            tile.Rotation = properties.Rotation;

            if (spaceToRemove != null)
            {
                spaces.Remove(spaceToRemove);
            }
        }
    }
}