using Carcassonne.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Carcassonne.ViewModels
{
    public class GameViewModel : Mvvm.ViewModelBase
    {
        private readonly IList<IPlayer> players;
        private readonly ITilesService tilesService;
        private Brush currentColour;
        private IPlayer currentPlayer;
        private TileViewModel nextTileViewModel;
        private int playerIndex;
        private FitProperties selectedPossibility;
        private Tile tile;

        public GameViewModel(ITilesService tilesService, IList<IPlayer> players)
        {
            this.players = players;
            this.tilesService = tilesService;
        }

        public Brush CurrentColour
        {
            get { return currentColour; }
            set { Set(ref currentColour, value); }
        }

        public ObservableCollection<FollowerViewModel> FollowerPossibilities { get; } = new ObservableCollection<FollowerViewModel>();

        public ObservableCollection<FollowerViewModel> Followers { get; } = new ObservableCollection<FollowerViewModel>();

        public TileViewModel NextTile
        {
            get { return nextTileViewModel; }
            set { Set(ref nextTileViewModel, value); }
        }

        public ObservableCollection<TileViewModel> Possibilities { get; } = new ObservableCollection<TileViewModel>();

        public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();

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
                var followerViewModel = new FollowerViewModel(100 * tile.X + 1042 + location.X * 50, 1042 - 100 * tile.Y - location.Y * 50, currentPlayer.Colour);
                var clickCommand = new DelegateCommand(() => OnFollowerClick(followerViewModel));
                followerViewModel.ClickCommand = clickCommand;
                FollowerPossibilities.Add(followerViewModel);
            }

            tile = null;
        }

        public async Task GetNextTile()
        {
            if (tile != null && Possibilities.Any())
            {
                return;
            }

            var follower = FollowerPossibilities.FirstOrDefault(f => f.IsSelected);
            if (follower != null)
            {
                Followers.Add(follower);
            }

            FollowerPossibilities.Clear();

            currentPlayer = players[playerIndex];
            CurrentColour = new SolidColorBrush(currentPlayer.Colour);
            playerIndex = playerIndex >= players.Count - 1 ? 0 : playerIndex + 1;

            tile = tilesService.NextTile();
            NextTile = tile == null ? null : new TileViewModel(100 * tile.X + 1000, 1000 - 100 * tile.Y, tile.Rotation, tile.ImageUri);
            if (tile == null)
            {
                return;
            }

            selectedPossibility = null;
            var possibilities = tilesService.GetPossibilities(tile).ToList();

            if (!currentPlayer.IsInteractive)
            {
                var possibility = possibilities.OrderByDescending(x => x.Score).FirstOrDefault();
                if (possibility != null)
                {
                    tilesService.PlaceTile(tile, possibility);
                    await Task.Delay(1000);
                    Tiles.Add(new TileViewModel(100 * tile.X + 1000, 1000 - 100 * tile.Y, tile.Rotation, tile.ImageUri));
                    var followerLocation = tile.GetFollowers(possibility).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    if (followerLocation != null)
                    {
                        var followerViewModel = new FollowerViewModel(100 * tile.X + 1042 + followerLocation.X * 50, 1042 - 100 * tile.Y - followerLocation.Y * 50, currentPlayer.Colour);
                        Followers.Add(followerViewModel);
                    }
                }

                await Task.Delay(1000);
                tile = null;
                await GetNextTile();
                return;
            }

            foreach (var group in possibilities.GroupBy(x => x.Point))
            {
                var vm = new TileViewModel(100 * group.Key.X + 1000, 1000 - 100 * group.Key.Y);
                vm.ClickCommand = new DelegateCommand(() => TryTile(group.ToList(), vm));
                Possibilities.Add(vm);
            }
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

        public async Task ResetGame()
        {
            await tilesService.Reset();
            Tiles.Clear();
            Possibilities.Clear();
            FollowerPossibilities.Clear();
            Followers.Clear();
            selectedPossibility = null;
            tile = null;
            playerIndex = 0;
            CurrentColour = null;
            if (NextTile != null)
            {
                NextTile.ImageSource = null;
            }
        }

        public async Task Start()
        {
            await tilesService.LoadTiles();
            await ResetGame();
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