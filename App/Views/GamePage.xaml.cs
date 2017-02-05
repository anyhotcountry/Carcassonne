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
    }
}