﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login([FromBody] User user)
        {

            if (userManager.ValaidateUser(user, out User validuser))
            {
                return Ok(jwtTokenGenerator.Generate(validuser));
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
                    return Ok("A felhasznalonev mar létezik");
                }
                userManager.CreateUser(user);
                return Ok("sikeres regisztracios");
            }
            return BadRequest();
        }
    }
}
