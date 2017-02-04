using Carcassonne.ViewModels;
using Windows.UI.Xaml;
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

        public void GamePageOnDrag(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
        }
    }
}