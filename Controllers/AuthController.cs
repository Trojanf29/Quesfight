using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuesFight.Data;
using QuesFight.Models.UserDTOs;
using QuesFight.Providers;
using QuesFight.Repositories;
using QuesFight.Services;
using System.Security.Claims;

namespace QuesFight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        // should not inject repo in controller layer,
        // CONTROLLER => SERVICE =< REPOSITORY
        // CONTROLLER: ONLY HANDLE REST API (GET, POST, PUT, PATCH, DELETE)
        // SERVICE: HANDLING BUSINESS
        // REPOSITORY: HANDLING DATA FROM DATABASE (INSERT, UPDATE, DELETE, QUERY,...)
        private readonly UserRepo _userRepo;

        public AuthController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        /*
         * Login & Authenticate using cookie
         */
        [HttpPost("/api/[controller]/login")]
        public IActionResult Login(LoginDTO dto, [FromServices] JwtProvider jwtProvider)
        {
            User? user = _userRepo.CheckLogin(dto);

            if (user == null)
                return Unauthorized();

            UpdateToken(jwtProvider, user);
            _userRepo.Save();
            return Ok();
        }

        /*
         * Expires the cookie
         */
        [HttpPost("/api/[controller]/logout")]
        public IActionResult Logout()
        {
            CookieOptions options = new()
            {
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now
            };
            HttpContext.Response.Cookies.Append("Bearer", "", options);
            HttpContext.Response.Cookies.Append("Refresh", "", options);
            return Ok();
        }

        [HttpPost("/api/[controller]/refresh")]
        public IActionResult RefreshAuth([FromServices] JwtProvider jwtProvider)
        {
            string? accessToken = HttpContext.Request.Cookies["Bearer"];
            string? refreshToken = HttpContext.Request.Cookies["Refresh"];

            if (accessToken == null)
                return Unauthorized();
            var principle = jwtProvider.GetPrincipleFromExpiredToken(accessToken);
            if (principle == null)
                return Unauthorized("Invalid access token");
            string? mail = null;
            foreach (Claim claim in principle.Claims)
                if (claim.Type == ClaimTypes.NameIdentifier)
                    mail = claim.Value;
            User? user = _userRepo.GetByEmail(mail!);
            if (user == null)
                return Unauthorized();
            //always-on refresh token
            if (refreshToken == null || !_userRepo.CheckRefreshToken(user, refreshToken))
                return Unauthorized("Invalid refresh token");

            UpdateToken(jwtProvider, user);
            _userRepo.Save();
            return Ok();
        }




        /*
         * Test Method - Check if the user has logged in
         */
        [HttpGet("/api/[controller]/checkAuth")]
        [Authorize]
        public IActionResult CheckAuth()
        {
            return Ok();
        }

        private void UpdateToken(JwtProvider jwtProvider, User user)
        {
            string authToken = jwtProvider.GenerateAccessToken(user.Email, user.Role);
            string refreshToken = jwtProvider.GenerateRefreshToken();

            _userRepo.UpdateRefreshToken(user, refreshToken);

            CookieOptions options = new()
            {
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(1)
            };
            HttpContext.Response.Cookies.Append("Bearer", authToken, options);
            HttpContext.Response.Cookies.Append("Refresh", refreshToken, options);
        }
    }
}
