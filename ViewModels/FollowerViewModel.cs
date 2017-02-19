namespace Carcassonne.ViewModels
{
    public class FollowerViewModel : Mvvm.ViewModelBase
    {
        private bool isSelected;

        public FollowerViewModel(double x, double y)
        {
            X = x;
            Y = y;
        }

        public DelegateCommand ClickCommand { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set { Set(ref isSelected, value); }
        }

        public double Y { get; set; }

        public double X { get; set; }
    }
}