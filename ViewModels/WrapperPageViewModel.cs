using Carcassonne.Services;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Carcassonne.ViewModels
{
    public class WrapperPageViewModel : Mvvm.ViewModelBase
    {
        private readonly CoreDispatcher dispatcher;
        private GameViewModel currentViewModel;
        private bool stopped = true;
        private ITilesService tilesService;

        public WrapperPageViewModel(ITilesService tilesService)
        {
            this.tilesService = tilesService;
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            CurrentViewModel = new GameViewModel(tilesService);
        }

        public async Task Start()
        {
            await currentViewModel.Start();
        }

        public GameViewModel CurrentViewModel
        {
            get { return currentViewModel; }

            private set { Set(ref currentViewModel, value); }
        }

        public void OnUnLoaded()
        {
        }
    }
}