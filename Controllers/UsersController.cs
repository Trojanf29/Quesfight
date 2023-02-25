using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuesFight.Repositories;
using QuesFight.Services;
using QuesFight.Models.UserDTOs;

namespace QuesFight.Controllers
{
    /// <summary>
    /// Register & Update the profile
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepo _userRepo;

        public UsersController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id) {
            UserDTO? user = _userRepo.Find(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_userRepo.GetAll());
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO dto)
        {
            bool succeed = _userRepo.Create(dto);

            if (succeed)
            {
                _userRepo.Save();
                return Ok();
            }
            return Conflict();
        }

        [HttpPut("/api/[controller]/password")]
        [Authorize]
        public IActionResult ChangePassword(ChangePasswordDTO dto)
        {
            bool succeed = _userRepo.ChangePassword(dto, ContextParser.GetEmail(HttpContext));
            if (succeed)
            {
                _userRepo.Save();
                return Ok();
            }
            return Unauthorized("Current password doesn't match");
        }

        /*[HttpPut]
        [Authorize]
        public IActionResult UpdateAvatar() {

        }*/

        [HttpPut("/api/[controller]/bio")]
        [Authorize]
        public IActionResult UpdateBio(string bio)
        {
            bool succeed = _userRepo.UpdateBio(bio, ContextParser.GetEmail(HttpContext));
            if (succeed)
            {
                _userRepo.Save();
                return Ok();
            }
            return Unauthorized();
        }
    }
}