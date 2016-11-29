using Carcassonne.Services;
using Carcassonne.ViewModels;

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