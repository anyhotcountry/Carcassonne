namespace Carcassonne.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GameButtonOnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WrapperPage));
        }

        private void DemoButtonOnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DemoPage));
        }
    }
}