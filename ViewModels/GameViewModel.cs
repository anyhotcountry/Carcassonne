using Carcassonne.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Carcassonne.ViewModels
{
    public class GameViewModel : Mvvm.ViewModelBase
    {
        private readonly ITilesService tilesService;
        private TileViewModel nextTileViewModel;
        private Tile tile;
        private List<FitProperties> possibilities;

        public GameViewModel(ITilesService tilesService)
        {
            this.tilesService = tilesService;
        }

        public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();

        public ObservableCollection<TileViewModel> Possibilities { get; } = new ObservableCollection<TileViewModel>();

        public TileViewModel NextTile
        {
            get { return nextTileViewModel; }
            set { Set(ref nextTileViewModel, value); }
        }

        public void PlaceTile()
        {
            if (tile == null)
            {
                return;
            }

            possibilities = tilesService.GetPossibilities(tile).ToList();
            var possibility = possibilities.OrderByDescending(x => x.Score).FirstOrDefault();
            if (possibility != null)
            {
                tilesService.PlaceTile(tile, possibility);
                Tiles.Add(new TileViewModel(50 * tile.X + 500, 500 - 50 * tile.Y, tile.Rotation, tile.ImageUri));
            }

            tile = tilesService.NextTile();
            NextTile = tile == null ? null : new TileViewModel(50 * tile.X + 500, 500 - 50 * tile.Y, tile.Rotation, tile.ImageUri);
        }

        public async Task Start()
        {
            await tilesService.LoadTiles();
            tile = tilesService.NextTile();
            possibilities = tilesService.GetPossibilities(tile).ToList();
            foreach (var possibility in possibilities)
            {
                Possibilities.Add(new TileViewModel(50 * possibility.X + 500, 500 - 50 * possibility.Y));
            }

            NextTile = new TileViewModel(50 * tile.X + 500, 500 - 50 * tile.Y, tile.Rotation, tile.ImageUri);
        }
    }
}