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
        private FitProperties selectedPossibility;

        public GameViewModel(ITilesService tilesService)
        {
            this.tilesService = tilesService;
        }

        public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();

        public ObservableCollection<TileViewModel> Possibilities { get; } = new ObservableCollection<TileViewModel>();

        public ObservableCollection<FollowerViewModel> FollowerPossibilities { get; } = new ObservableCollection<FollowerViewModel>();

        public ObservableCollection<FollowerViewModel> Followers { get; } = new ObservableCollection<FollowerViewModel>();

        public TileViewModel NextTile
        {
            get { return nextTileViewModel; }
            set { Set(ref nextTileViewModel, value); }
        }

        public void PlaceTile()
        {
            if (selectedPossibility == null || tile == null)
            {
                return;
            }

            tilesService.PlaceTile(tile, selectedPossibility);
            Tiles.Add(new TileViewModel(100 * tile.X + 1000, 1000 - 100 * tile.Y, selectedPossibility.Rotation, tile.ImageUri));
            NextTile.ImageSource = null;
            Possibilities.Clear();
        }

        public async Task Start()
        {
            await tilesService.LoadTiles();
            ResetGame();
        }

        public async void ResetGame()
        {
            await tilesService.Reset();
            Tiles.Clear();
            Possibilities.Clear();
            FollowerPossibilities.Clear();
            selectedPossibility = null;
            tile = null;
            if (NextTile != null)
            {
                NextTile.ImageSource = null;
            }
        }

        public void GetNextTile()
        {
            var follower = FollowerPossibilities.FirstOrDefault(f => f.IsSelected);
            if (follower != null)
            {
                Followers.Add(follower);
            }

            FollowerPossibilities.Clear();
            if (tile != null && Possibilities.Any())
            {
                return;
            }

            tile = tilesService.NextTile();
            NextTile = tile == null ? null : new TileViewModel(100 * tile.X + 1000, 1000 - 100 * tile.Y, tile.Rotation, tile.ImageUri);
            if (tile == null)
            {
                return;
            }

            selectedPossibility = null;
            var possibilities = tilesService.GetPossibilities(tile).ToList();
            foreach (var group in possibilities.GroupBy(x => x.Point))
            {
                var vm = new TileViewModel(100 * group.Key.X + 1000, 1000 - 100 * group.Key.Y);
                vm.ClickCommand = new DelegateCommand(() => TryTile(group.ToList(), vm));
                Possibilities.Add(vm);
            }
        }

        public void FollowerPlacement()
        {
            if (tile == null || selectedPossibility == null)
            {
                return;
            }

            if (Possibilities.Any())
            {
                PlaceTile();
            }

            FollowerPossibilities.Clear();

            var followerLocations = tile.GetFollowers(selectedPossibility);
            foreach (var location in followerLocations)
            {
                var followerViewModel = new FollowerViewModel(100 * tile.X + 1042 + location.X * 50, 1042 - 100 * tile.Y - location.Y * 50);
                var clickCommand = new DelegateCommand(() => OnFollowerClick(followerViewModel));
                followerViewModel.ClickCommand = clickCommand;
                FollowerPossibilities.Add(followerViewModel);
            }

            tile = null;
        }

        private void OnFollowerClick(FollowerViewModel followerViewModel)
        {
            foreach (var vm in FollowerPossibilities)
            {
                vm.IsSelected = vm == followerViewModel ? !vm.IsSelected : false;
            }
        }

        private void TryTile(IList<FitProperties> possibilities, TileViewModel tileViewModel)
        {
            foreach (var possibility in Possibilities)
            {
                possibility.ImageSource = null;
            }

            tileViewModel.ImageSource = NextTile.ImageSource;
            var previousPossibility = possibilities.FirstOrDefault(p => p.Rotation == tileViewModel.Rotation);
            var index = previousPossibility == null ? 0 : possibilities.IndexOf(previousPossibility) + 1;
            index = index >= possibilities.Count ? 0 : index;
            selectedPossibility = possibilities[index];
            tileViewModel.Rotation = selectedPossibility.Rotation;
        }
    }
}