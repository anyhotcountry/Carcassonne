using System;

namespace Carcassonne.ViewModels
{
    public interface IQuestionViewModel
    {
        event EventHandler QuestionFinished;

        void Stop();

        void Start();

        void End();
    }
}