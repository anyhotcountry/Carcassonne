using Carcassonne.Services;
using Carcassonne.ViewModels;
using System;

namespace Carcassonne
{
    public class ViewModelLocator
    {
        public WrapperPageViewModel WrapperPageViewModel
        {
            get
            {
                return new WrapperPageViewModel(new TilesService(new Uri("ms-appx:///Assets/Tiles/")));
            }
        }
    }
}