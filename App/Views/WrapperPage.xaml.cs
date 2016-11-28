using Carcassonne.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Carcassonne.Views
{
    public sealed partial class WrapperPage : Page
    {
        public WrapperPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        public WrapperPageViewModel ViewModel => (DataContext as WrapperPageViewModel);

        private async void PageOnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.Start();
        }

        private void PageOnUnloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.OnUnLoaded();
        }
    }
}