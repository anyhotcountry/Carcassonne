using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carcassonne.Services
{
    public interface IQuestionsService
    {
        Task PickFiles();

        string GetAnswer(string filename);

        Task<string> GetAnswersAsync();

        Task<IList<string>> GetAnswersListAsync();

        Task SaveQuiz(IDictionary<string, Uri> images, IDictionary<string, string> otherQuestions);
    }
}