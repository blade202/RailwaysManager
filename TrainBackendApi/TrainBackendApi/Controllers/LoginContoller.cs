using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainBackendApi.Models;
using TrainBackendApi.Services;

namespace TrainBackendApi.Controllers
{
    public class LoginContoller : ControllerBase
    {
        private UserManager userManager;
        private JwtTokenGenerator jwtTokenGenerator;

        public LoginContoller(UserManager userManager, JwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        [Route("/Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUser user)
        {

            if (userManager.ValaidateUser(user, out User validuser))
            {
                return Ok(new UserData {Username=validuser.UserName,Token= jwtTokenGenerator.Generate(validuser),Role=validuser.Role});
            }
            return BadRequest();

        }

        [Route("/SiginUp")]
        [HttpPost]
        public IActionResult SiginUp([FromBody] RegistryUser user)
        {
            if (user.Password == user.PasswordConfrim)
            {
                if (userManager.IsUsernameExist(user))
                {
                    return Ok("A felhasználónév mar létezik!");
                }
                userManager.CreateUser(user);
                return Ok("Sikeres regisztráció!");
            }
            return BadRequest();
        }
        [Route("Test")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("asd");
        }

    }
}
