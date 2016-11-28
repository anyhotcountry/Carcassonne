using Carcassonne.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace Carcassonne.ViewModels
{
    public class GameViewModel : Mvvm.ViewModelBase, IQuestionViewModel
    {
        private readonly DispatcherTimer gameTimer;
        private readonly Random random;
        private readonly string filename;
        private readonly IQuestionsService questionsService;
        private readonly bool isPreview;
        private string answer;
        private BitmapImage imageSource;
        private bool isCollapsed = true;
        private int questionIndex = 1;
        private double takeCount;
        private bool stopped;

        public event EventHandler QuestionFinished;

        public GameViewModel(IQuestionsService questionsService)
        {
            random = new Random();
            this.questionsService = questionsService;
            gameTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            gameTimer.Tick += (s, e) => GameTimerOnTick();
            ShowQuestion();
            gameTimer.Start();
        }

        public ObservableCollection<BlockViewModel> Blocks { get; } = new ObservableCollection<BlockViewModel>();

        public void Stop()
        {
            stopped = true;
        }

        public void Start()
        {
            stopped = false;
            gameTimer.Start();
        }

        public void End()
        {
            Blocks.Clear();
        }

        private async Task GameTimerOnTick()
        {
            gameTimer.Stop();
            if (stopped)
            {
                return;
            }

            for (int i = 0; i < (int)takeCount; i++)
            {
                if (Blocks.Count != 0)
                {
                    var index = random.Next(Blocks.Count);
                    Blocks.RemoveAt(Blocks.Count - 1);
                }
            }

            if (Blocks.Count > 0)
            {
                takeCount += 0.02;
                gameTimer.Start();
            }
        }

        private async Task ShowQuestion()
        {
            var blockCount = 12;
            var width = 10;
            for (int i = 0; i < blockCount; i++)
            {
                for (int j = -i - 1; j <= i; j++)
                {
                    Blocks.Add(new BlockViewModel((blockCount + i) * width, (blockCount + j) * width, width, width));
                    Blocks.Add(new BlockViewModel((blockCount - i - 1) * width, (blockCount + j) * width, width, width));
                    Blocks.Add(new BlockViewModel((blockCount + j) * width, (blockCount + i) * width, width, width));
                    Blocks.Add(new BlockViewModel((blockCount + j) * width, (blockCount - i - 1) * width, width, width));
                }
            }

            takeCount = 1;
        }
    }
}