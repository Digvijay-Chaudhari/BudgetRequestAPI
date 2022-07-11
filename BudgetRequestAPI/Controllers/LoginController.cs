using BudgetRequestAPI.DataModel.Entities;
using BudgetRequestAPI.ServiceModel.DTO.Request;
using BudgetRequestAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BudgetRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserInfoService _iuserinfoService;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public LoginController(IConfiguration config, IUserInfoService userService, ITokenService tokenService)
        {
            _config = config;
            _iuserinfoService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LogInDTO userInfo )
        {
            IActionResult response = Unauthorized();
            UserInfo user = _iuserinfoService.AuthenticateUser(userInfo);

            if (user != null)
            {
                var tokenString = _tokenService.CreateToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }

            return response;
        }

    }
}
