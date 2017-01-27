using Carcassonne.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Carcassonne.ViewModels
{
    public class GameViewModel : Mvvm.ViewModelBase
    {
        private readonly DispatcherTimer gameTimer;
        private readonly Random random;
        private readonly ITilesService tilesService;

        public GameViewModel(ITilesService tilesService)
        {
            random = new Random();
            this.tilesService = tilesService;
            gameTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            gameTimer.Tick += GameTimerOnTick;
        }

        public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();

        private void GameTimerOnTick(object sender, object e)
        {
            gameTimer.Stop();
            var tile = tilesService.NextTile();
            if (tile == null)
            {
                return;
            }

            var possibilities = tilesService.GetPossibilities(tile).ToList();
            var possibility = possibilities.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (possibility != null)
            {
                tilesService.PlaceTile(tile, possibility);
                Tiles.Add(new TileViewModel(50 * tile.X + 500, 500 - 50 * tile.Y, tile.Rotation, tile.ImageSource));
            }

            gameTimer.Start();
        }

        public async Task Start()
        {
            await tilesService.LoadTiles();
            gameTimer.Start();
        }
    }
}