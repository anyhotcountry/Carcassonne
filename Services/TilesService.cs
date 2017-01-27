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

        private static readonly IDictionary<char, EdgeTypes> Edges = new Dictionary<char, EdgeTypes>
        {
            ['c'] = EdgeTypes.City,
            ['f'] = EdgeTypes.Field,
            ['r'] = EdgeTypes.Road,
        };

        private readonly Uri baseUri;
        private IList<Space> spaces;
        private List<Tile> remainingTiles;
        private List<Tile> playedTiles;
        private Tile startTile;
        private int counter;

        public TilesService(Uri baseUri)
        {
            this.baseUri = baseUri;
        }

        public async Task LoadTiles()
        {
            var appInstalledFolder = Package.Current.InstalledLocation;
            var assets = await appInstalledFolder.GetFolderAsync(@"Assets\Tiles");
            var files = await assets.GetFilesAsync();
            remainingTiles = files.SelectMany(Parse).OrderBy(x => Guid.NewGuid()).ToList();
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
                return new[] { new FitProperties { X = 0, Y = 0 } };
            }

            return spaces.SelectMany(s => s.CanFit(tile));
        }

        public void PlaceTile(Tile tile, FitProperties properties)
        {
            var spaceToRemove = spaces.FirstOrDefault(s => s.X == properties.X && s.Y == properties.Y);
            var spacesAndTiles = spaces.Concat(playedTiles.Cast<Space>()).ToList();
            var northSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.X && s.Y == properties.Y + 1);
            var eastSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.X + 1 && s.Y == properties.Y);
            var southSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.X && s.Y == properties.Y - 1);
            var westSpace = spacesAndTiles.FirstOrDefault(s => s.X == properties.X - 1 && s.Y == properties.Y);
            if (northSpace == null)
            {
                northSpace = new Space { SouthTile = tile, X = properties.X, Y = properties.Y + 1 };
                spaces.Add(northSpace);
            }

            if (eastSpace == null)
            {
                eastSpace = new Space { WestTile = tile, X = properties.X + 1, Y = properties.Y };
                spaces.Add(eastSpace);
            }

            if (southSpace == null)
            {
                southSpace = new Space { NorthTile = tile, X = properties.X, Y = properties.Y - 1 };
                spaces.Add(southSpace);
            }

            if (westSpace == null)
            {
                westSpace = new Space { EastTile = tile, X = properties.X - 1, Y = properties.Y };
                spaces.Add(westSpace);
            }

            northSpace.SouthTile = tile;
            eastSpace.WestTile = tile;
            southSpace.NorthTile = tile;
            westSpace.EastTile = tile;

            playedTiles.Add(tile);
            tile.X = properties.X;
            tile.Y = properties.Y;
            tile.Rotation = properties.Rotation;

            if (spaceToRemove != null)
            {
                spaces.Remove(spaceToRemove);
            }
        }

        private IEnumerable<Tile> Parse(StorageFile file)
        {
            var count = int.Parse(file.Name.Substring(0, 2));
            var edges = file.Name.Skip(2).Take(4).Select(f => Edges[f]).ToList();
            var pennants = int.Parse(file.Name[6].ToString());
            var cloisters = int.Parse(file.Name[7].ToString());
            for (int i = 0; i < count; i++)
            {
                yield return new Tile(pennants, cloisters, edges, new Uri(baseUri, file.Name));
            }

            if (file.DisplayName == StartTileName)
            {
                startTile = new Tile(pennants, cloisters, edges, new Uri(baseUri, file.Name));
            }
        }
    }
}