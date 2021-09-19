using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Identity.Exception;
using Identity.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Controller
{
 
    [Route("api/account/")]
    public class AuthController:Microsoft.AspNetCore.Mvc.Controller
    {
         private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<RegisterModel> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;
        //private readonly AppSettings _appSettings;


        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<RegisterModel> userManager,
            IIdentityServerInteractionService interactionService) =>
            (_signInManager, _userManager, _interactionService) =
            (signInManager, userManager, interactionService);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Phone);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "not user" });
            }

            var result = await _signInManager.PasswordSignInAsync(loginModel.Phone,
                loginModel.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
           // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                //    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
               // SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            return  Ok(new
            {
                token =  tokenString
            });
            
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel _registerModel)
        {
            var user = await _userManager.FindByNameAsync(_registerModel.Phone);
            if (user != null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            }

            RegisterModel registerModel = new RegisterModel()
            {
                Phone = _registerModel.Phone,
                Email = _registerModel.Email,
                FIO = _registerModel.FIO,
                Password = _registerModel.Password
            };
            //var user = await  
            var result = await _userManager.CreateAsync(registerModel, _registerModel.Password);
            return  Ok(new
            {
                a = "gh"
              //  token = new JwtSecurityTokenHandler().WriteToken(token),
               /// expiration = token.ValidTo
            });
        }
        
        [HttpPost("logout")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new{ token = "2213"});
        }
    }
}