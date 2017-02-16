using Carcassonne.Services;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Carcassonne.ViewModels
{
    public class DesignerViewModel : Mvvm.ViewModelBase
    {
        private ImageSource imageSource;

        private readonly ITileDesignerService tileDesignerService;
        private readonly Uri uri;

        public DesignerViewModel(Uri uri, TileDesignerService tileDesignerService)
        {
            this.uri = uri;
            this.tileDesignerService = tileDesignerService;
        }

        public ImageSource ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                Set(ref imageSource, value);
            }
        }

        public async Task Load()
        {
            var fileName = await tileDesignerService.DrawTile();
            var file = await StorageFile.GetFileFromPathAsync(fileName);
            var fileStream = await file.OpenAsync(FileAccessMode.Read);
            var img = new BitmapImage();
            img.SetSource(fileStream);
            ImageSource = img;
        }
    }
}