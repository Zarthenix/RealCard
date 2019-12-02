using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        AuthRepo authRepo;
        private readonly UserManager<BaseAccount> _userManager;
        private readonly SignInManager<BaseAccount> _signInManager;

        public AuthController(AuthRepo authRepo, 
            UserManager<BaseAccount> userManager, 
            SignInManager<BaseAccount> signInManager)
        {
            this.authRepo = authRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            return View(rvm);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel rvm)
        {
            RegisterVMConverter rvmc = new RegisterVMConverter();

            if(ModelState.IsValid)
            {
                BaseAccount user = rvmc.ConvertToModel(rvm);
                authRepo.Register(user);
            }


            return View();
        }
    }
}