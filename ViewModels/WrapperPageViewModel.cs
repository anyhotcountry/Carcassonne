using Carcassonne.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;

namespace Carcassonne.ViewModels
{
    public class WrapperPageViewModel : Mvvm.ViewModelBase
    {
        private readonly IQuestionsService questionsService;
        private readonly List<string> questions;
        private readonly CoreDispatcher dispatcher;
        private readonly bool isPreview;
        private int questionIndex;
        private IQuestionViewModel currentViewModel;
        private bool stopped = true;

        public WrapperPageViewModel(IQuestionsService questionsService, bool isPreview)
        {
            this.questionsService = questionsService;
            this.isPreview = isPreview;
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            CurrentViewModel = new GameViewModel(questionsService);
        }

        public IQuestionViewModel CurrentViewModel
        {
            get { return currentViewModel; }

            private set { Set(ref currentViewModel, value); }
        }

        public void OnUnLoaded()
        {
        }

        public async Task Start()
        {
            CurrentViewModel?.Start();
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            OnUnLoaded();
            return base.OnNavigatedFromAsync(state, suspending);
        }
    }
}