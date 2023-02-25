using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuesFight.Data.QuestionData;
using QuesFight.Repositories.QuestionRepositories;

namespace QuesFight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionRepo _questionRepo;

        public QuestionsController(QuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }





        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Get(string id)
        {
            Question? result = _questionRepo.Find(id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
