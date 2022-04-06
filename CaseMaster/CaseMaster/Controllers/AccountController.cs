using CaseMaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserViewModel> userManager;
        private readonly SignInManager<UserViewModel> signInManager;

        public AccountController(UserManager<UserViewModel> userManager, SignInManager<UserViewModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(Register register)
        {
            var user = new UserViewModel()
            {
                UserName=register.Email,
                Email = register.Email

            };
            var result = await userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
               await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login (LoginViewModel login,string returnUrl= null)
        {
            if (ModelState.IsValid)
            {
              var identityResult =  await signInManager.PasswordSignInAsync( login.Email, login.Password, login.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                      return  RedirectToAction("Index","Home");
                    }
                    else
                    {
                     return   RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return RedirectToAction( "Login", "Account");
        }
      
        public ActionResult Logout()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout(int?id)
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
        [HttpPost]
        public IActionResult DontLogout()
        {
            
            return RedirectToAction("Index","Home");
        }
    }
}
