using Carcassonne.Services;
using Carcassonne.ViewModels;
using Carcassonne.Views;
using System;

namespace Carcassonne
{
    public class ViewModelLocator
    {
        public WrapperPageViewModel WrapperPageViewModel
        {
            get
            {
                return new WrapperPageViewModel(new QuestionsService(), false);
            }
        }
    }
}