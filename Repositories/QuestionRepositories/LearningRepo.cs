using Microsoft.EntityFrameworkCore;
using QuesFight.Data;
using QuesFight.Data.QuestionData;
using QuesFight.Models.QuestionDTOs;
using QuesFight.Models.QuestionDTOs.Learning;

namespace QuesFight.Repositories.QuestionRepositories
{
    public class LearningRepo : IRepository
    {
        private readonly Context _context;

        public LearningRepo(Context context)
        {
            _context = context;
        }

        public void Save() => _context.SaveChanges();






        public LearnRecordDTO? Get(int id)
        {
            LearnRecord? result = _context.LearnRecords
                .Include(r => r.User)
                .Include(r => r.QuesCollection).ThenInclude(qc => qc.Collection_Questions).ThenInclude(cq => cq.Question)
                .FirstOrDefault(r => r.Id == id);
            return Map(result);
        }

        public List<LearnRecordDTO> Get(string mail)
        {
            return _context.LearnRecords.Include(r => r.User).Include(r => r.QuesCollection)
                .Where(r => r.User.Email == mail)
                .Select(r => new LearnRecordDTO
                {
                    Id = r.Id,
                    User = new()
                    {
                        Id = r.User.Id,
                        UserName = r.User.UserName,
                        Email = r.User.Email,
                        Avatar = r.User.Avatar
                    },
                    QuesCollection = new()
                    {
                        Id = r.QuesCollection.Id,
                        CollectionName = r.QuesCollection.CollectionName,
                        RestrictTime = r.QuesCollection.RestrictTime,
                        NumberOfQuestion = r.QuesCollection.NumberOfQuestion
                    },
                    FinishTime = r.FinishTime,
                    CompletedQuestion = r.CompletedQuestion,
                    Point = r.Point,
                    CreatedAt = r.CreatedAt
                }).ToList();
        }

        public NewLearnRecordDTO? Create(List<Question> questions, string mail)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == mail)!;

            //CollectionName, RestrictTime ?
            QuesCollection collection = new()
            {
                RestrictTime = -1,
                NumberOfQuestion = questions.Count,
                CreatedAt = DateTime.Now,
                Collection_Questions = new List<Collection_Question>()
            };
            _context.QuesCollections.Add(collection);

            List<Collection_Question> col_ques = new();
            foreach (Question question in questions)
                collection.Collection_Questions.Add(
                    new Collection_Question { CollectionId = collection.Id, QuestionId = question.Id });

            LearnRecord learnRecord = new()
            {
                User = user,
                QuesCollection = collection,
                FinishTime = -1,
                CompletedQuestion = -1,
                Point = -1,
                CreatedAt = DateTime.Now
            };
            _context.LearnRecords.Add(learnRecord);
            _context.SaveChanges();

            return new NewLearnRecordDTO
            {
                Id = learnRecord.Id,
                QuesCollection = Map(collection, questions)
            };
        }

        public bool Update(UpdateLearnRecordDTO dto, string mail)
        {
            LearnRecord? record = _context.LearnRecords.Include(l => l.User).FirstOrDefault(l => l.Id == dto.Id);
            if (record == null || record.User.Email != mail)
                return false;
            record.FinishTime = dto.FinishTime;
            record.CompletedQuestion = dto.CompletedQuestion;
            record.Point = dto.Point;
            return true;
        }






        private static LearnRecordDTO? Map(LearnRecord? record)
        {
            if (record == null)
                return null;

            List<Question> questions = new();
            foreach (Collection_Question cq in record.QuesCollection.Collection_Questions)
                questions.Add(cq.Question);

            return new()
            {
                Id = record.Id,
                User = new ()
                {
                    Id = record.User.Id,
                    UserName = record.User.UserName,
                    Email = record.User.Email,
                    Avatar = record.User.Avatar
                },
                QuesCollection = Map(record.QuesCollection, questions),
                FinishTime = record.FinishTime,
                CompletedQuestion = record.CompletedQuestion,
                Point = record.Point,
                CreatedAt = record.CreatedAt
            };
        }

        private static QuesCollectionDTO Map(QuesCollection collection, List<Question> questions)
        {
            return new()
            {
                Id = collection.Id,
                RestrictTime = collection.RestrictTime,
                NumberOfQuestion = collection.NumberOfQuestion,
                Questions = questions
            };
        }
    }
}
