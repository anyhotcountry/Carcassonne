using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Carcassonne.ViewModels
{
    public class FollowerViewModel : Mvvm.ViewModelBase
    {
        private bool isSelected;

        public FollowerViewModel(double x, double y, Color colour)
        {
            Colour = new SolidColorBrush(colour);
            X = x;
            Y = y;
        }

        public DelegateCommand ClickCommand { get; set; }

        public Brush Colour { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set { Set(ref isSelected, value); }
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}