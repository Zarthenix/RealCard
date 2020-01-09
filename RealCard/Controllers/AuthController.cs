using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealCard.Core.DAL.Models;
using RealCard.Models;


namespace RealCard.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly UserManager<BaseAccount> _userManager;
        private readonly SignInManager<BaseAccount> _signInManager;

        public AuthController(UserManager<BaseAccount> userManager, 
            SignInManager<BaseAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            IActionResult retVal = View(rvm);

            if (ModelState.IsValid)
            {
                BaseAccount user = new BaseAccount(-1, rvm.Username, rvm.Email);
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                  await _signInManager.SignInAsync(user, isPersistent: false);
                  retVal = RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            return retVal;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            IActionResult retVal = View(lvm);

            if (ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(lvm.Username, lvm.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                    retVal = RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    retVal = View(lvm);
                }
            }

            return retVal;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}