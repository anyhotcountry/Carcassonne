using Carcassonne.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Carcassonne.Views
{
    public sealed partial class GamePage : UserControl
    {
        public GamePage()
        {
            InitializeComponent();
        }

        public GameViewModel ViewModel => (DataContext as GameViewModel);

        private void UserControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TilesScrollViewer.ChangeView(1000, 500, 1);
        }
    }
}