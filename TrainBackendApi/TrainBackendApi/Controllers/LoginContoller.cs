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
        private JwtTokenService jwtTokenGenerator;
        private static readonly SemaphoreSlim Mutex = new SemaphoreSlim(1);

        public LoginContoller(UserManager userManager, JwtTokenService jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        [Route("/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(
            [FromBody] LoginUser user)
        {

            if (ModelState.IsValid&&userManager.ValaidateUser(user, out User validuser))
            {
                
                return Ok(new UserData {Username=validuser.UserName,Token= jwtTokenGenerator.Generate(validuser),Role=validuser.Role,Refreshtoken=await jwtTokenGenerator.GenerateRefresToken(validuser.Id)});
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
        [Route("RefreshToken")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (ModelState.IsValid)
            {
                await Mutex.WaitAsync();
                try
                {
                    var response = await jwtTokenGenerator.GenerateNewToken(request.RefreshToken, request.oldToken);
                    return Ok(response);
                }
                finally
                {
                    Mutex.Release();
                }
           
            }
            return BadRequest();
        }

    }
}
