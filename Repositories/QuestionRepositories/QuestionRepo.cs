using System.Net;
using Microsoft.EntityFrameworkCore;
using QuesFight.Data;
using QuesFight.Data.QuestionData;
using QuesFight.Models.QuestionDTOs;
using QuesFight.Services;

namespace QuesFight.Repositories.QuestionRepositories
{
    public class QuestionRepo : IRepository
    {
        private readonly Context _context;

        public QuestionRepo(Context context)
        {
            _context = context;
        }

        public void Save() => _context.SaveChanges();






        public async Task<List<Question>?> FetchQuestions(QuestionQueryDTO dto)
        {
            UrlBuilder builder = new("https://the-trivia-api.com/api/questions");
            if (dto.Categories != null)
                builder.AddParam("categories", dto.Categories);
            if (dto.Limit != null)
                builder.AddParam("limit", dto.Limit.ToString());
            if (dto.Difficulty != null)
                builder.AddParam("difficulty", dto.Difficulty);

            HttpResponseMessage response = await new HttpClient().GetAsync(builder.url);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            List<QuesAPIModel>? res = await response.Content.ReadFromJsonAsync<List<QuesAPIModel>>();
            return Create(res);
        }

        public Question? Find(string id) => _context.Questions.Find(id);






        /*
         * Map QuesAPIModels to Questions and save them to database
         */
        private List<Question>? Create(List<QuesAPIModel>? data)
        {
            if (data == null)
                return null;

            //get distinct genres
            HashSet<string> genres = new();
            foreach (QuesAPIModel model in data)
                genres.Add(model.Category);

            //add new distinct genres to database
            foreach (string genre in genres)
                if (!_context.Genres.Any(g => g.Name == genre))
                    _context.Genres.Add(new QuestionGenre { Name = genre });
            _context.SaveChanges();

            //add question list
            List<Question> quesList = new();
            List<Question> newQues = new();
            foreach (QuesAPIModel model in data)
            {
                Question? ques = _context.Questions.FirstOrDefault(q => q.Id == model.Id);

                //if the question doesn't exist, insert to database
                if (ques == null) {
                    //in case of a question having only 2 choices
                    if (model.IncorrectAnswers.Count < 3)
                        model.IncorrectAnswers.AddRange(new List<string> { null, null });
                    ques = new Question
                    {
                        Id = model.Id,
                        Genre = _context.Genres.FirstOrDefault(g => g.Name == model.Category)!,
                        Content = model.Question,
                        Difficulty = model.Difficulty,
                        Choice1 = model.IncorrectAnswers[0],
                        Choice2 = model.IncorrectAnswers[1],
                        Choice3 = model.IncorrectAnswers[2],
                        CorrectChoice = model.CorrectAnswer,
                        CreatedAt = DateTime.Now
                    };
                    newQues.Add(ques);
                }

                quesList.Add(ques);
            }
            _context.Questions.AddRange(newQues);
            _context.SaveChanges();

            return quesList;
        }
    }
}
