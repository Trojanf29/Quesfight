using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuesFight.Data.QuestionData;
using QuesFight.Models.QuestionDTOs;
using QuesFight.Models.QuestionDTOs.Learning;
using QuesFight.Repositories.QuestionRepositories;
using QuesFight.Services;

namespace QuesFight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LearnController : ControllerBase
    {
        private readonly LearningRepo _learnRepo;

        public LearnController(LearningRepo learnRepo)
        {
            _learnRepo = learnRepo;
        }



        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            List<LearnRecordDTO> result = _learnRepo.Get(ContextParser.GetEmail(HttpContext)!);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            LearnRecordDTO? result = _learnRepo.Get(id);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Start a new learning session
        /// </summary>
        /// 
        /// Receive params & Generate URL based on the-trivia-api.com docs
        /// <param name="dto">
        ///     arts_and_literature / film_and_tv / food_and_drink / general_knowledge / geography
        ///     history / music / science / society_and_culture / sport_and_leisure
        /// </param>
        /// <param name="_questionRepo"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromQuery] QuestionQueryDTO dto, [FromServices] QuestionRepo _questionRepo)
        {
            string? mail = ContextParser.GetEmail(HttpContext);

            //Fetches from the-trivia-api.com, update the database and return questions
            List<Question>? questions = await _questionRepo.FetchQuestions(dto);
            if (questions == null)
                return BadRequest();

            //Create a new LearnRecord
            NewLearnRecordDTO? newLearnRecordDTO = _learnRepo.Create(questions, mail!);
            //saved changes
            return Ok(newLearnRecordDTO);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(UpdateLearnRecordDTO dto)
        {
            bool succeed = _learnRepo.Update(dto, ContextParser.GetEmail(HttpContext)!);
            _learnRepo.Save();
            return succeed ? Ok() : BadRequest();
        }
    }
}
