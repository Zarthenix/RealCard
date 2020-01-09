using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealCard.Models;
using RealCard.Models.Repositories;
using RealCard.ViewModels;
using RealCard.ViewModels.Converters;

namespace RealCard.Controllers
{
    public class AuthController : Controller
    {
        private AuthRepo _authRepo;
        private readonly UserManager<BaseAccount> _userManager;
        private readonly SignInManager<BaseAccount> _signInManager;

        public AuthController(AuthRepo authRepo, 
            UserManager<BaseAccount> userManager, 
            SignInManager<BaseAccount> signInManager)
        {
            _authRepo = authRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            RegisterViewModel rvm = new RegisterViewModel();
            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            IActionResult retval = View();
            RegisterVMConverter rvmc = new RegisterVMConverter();
            BaseAccount user = rvmc.ConvertToModel(rvm);

            if (ModelState.IsValid)
            {
                bool result = await _authRepo.Register(user);

                if (result)
                {
                    try
                    {
                        await _signInManager.PasswordSignInAsync(user.Username, rvm.Password, false, false);
                        retval = RedirectToAction("Index", "Home");
                    }
                    catch (Exception)
                    {
                        retval = RedirectToAction("Error", "Home");
                    }
                }
                else
                {
                    ViewData["Error"] = "An error has occured.";
                }
            }
            return retval;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel lv = new LoginViewModel();

            return View(lv);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            IActionResult retval = null;
            LoginVMConverter lvmc = new LoginVMConverter();
            BaseAccount user = lvmc.ConvertToModel(lvm);

            if (ModelState.IsValid)
            {
                bool result = await _authRepo.Login(user);

                if (result)
                    retval = RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("Username", "Database error.");
                    retval = RedirectToAction("Login");
                }
            }
            else retval = RedirectToAction("Login");
            

            return retval;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}