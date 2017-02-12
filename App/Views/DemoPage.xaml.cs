using Carcassonne.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Carcassonne.Views
{
    public sealed partial class DemoPage : Page
    {
        public DemoPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        public DemoViewModel ViewModel => (DataContext as DemoViewModel);

        private async void PageOnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.Load();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += WrapperPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            ViewModel.Start();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested -= WrapperPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            ViewModel.Stop();
        }

        private void WrapperPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            Frame.GoBack();
        }

        private async void ButtonOnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Render to an image at the current system scale and retrieve pixel contents
            var renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(BoardGrid);
            var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();

            var savePicker = new FileSavePicker();
            savePicker.DefaultFileExtension = ".png";
            savePicker.FileTypeChoices.Add(".png", new List<string> { ".png" });
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.SuggestedFileName = "snapshot.png";

            // Prompt the user to select a file
            var saveFile = await savePicker.PickSaveFileAsync();

            // Verify the user selected a file
            if (saveFile == null)
                return;

            // Encode the image to the selected file on disk
            using (var fileStream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, fileStream);

                encoder.SetPixelData(
               BitmapPixelFormat.Bgra8,
               BitmapAlphaMode.Ignore,
               (uint)renderTargetBitmap.PixelWidth,
               (uint)renderTargetBitmap.PixelHeight,
               DisplayInformation.GetForCurrentView().LogicalDpi,
               DisplayInformation.GetForCurrentView().LogicalDpi,
               pixelBuffer.ToArray());
                await encoder.FlushAsync();
            }
        }
    }
}