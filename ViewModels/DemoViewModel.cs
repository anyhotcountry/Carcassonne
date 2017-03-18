using Carcassonne.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Carcassonne.ViewModels
{
    public class DemoViewModel : Mvvm.ViewModelBase
    {
        private readonly DispatcherTimer gameTimer;
        private readonly Random random;
        private readonly ITilesService tilesService;

        public DemoViewModel(ITilesService tilesService)
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
            var possibility = possibilities.OrderByDescending(x => x.Score).FirstOrDefault();
            if (possibility != null)
            {
                tilesService.PlaceTile(tile, possibility);
                Tiles.Add(new TileViewModel(100 * tile.X + 1000, 1000 - 100 * tile.Y, tile.Rotation, tile.ImageUri));
            }

            gameTimer.Start();
        }

        public async Task Load()
        {
            await tilesService.LoadTiles();
            Reset();
            gameTimer.Start();
        }

        public void Start()
        {
        }

        public void Stop()
        {
            gameTimer.Stop();
        }

        private void Reset()
        {
            Tiles.Clear();
            tilesService.Reset();
        }
    }
}