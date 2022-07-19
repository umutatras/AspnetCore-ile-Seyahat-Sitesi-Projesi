using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appuser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username

            };
            if(p.Password==p.ComfirmPassword)
            {
                var result=await _userManager.CreateAsync(appuser,p.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult  SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new {area="Member"});
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");

                }
            }
            return View();
        }
    }
}
