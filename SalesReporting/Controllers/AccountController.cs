using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesReporting.Data;
using SalesReporting.Security;
using SalesReporting.ViewResource;

namespace SalesReporting.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AccountController(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestViewResource viewResource)
        {
            UserData userData = new UserData();
            var user = userData.Users.Find(x => x.EmailId == viewResource.EmailId && x.Password == viewResource.Password);

            if (user == null)
            {
                return NotFound($"Invalid Email Id Or Password!");
            }

            return Ok(_jwtTokenGenerator.CreateToken(user));
        }
    }
}
