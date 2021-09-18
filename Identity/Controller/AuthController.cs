using System.Threading.Tasks;
using Identity.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controller
{
    public class AuthController:Microsoft.AspNetCore.Mvc.Controller
    {
         private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IIdentityServerInteractionService interactionService) =>
            (_signInManager, _userManager, _interactionService) =
            (signInManager, userManager, interactionService);

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Login(object viewModel)
        {
            return null;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Register(object viewModel)
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}