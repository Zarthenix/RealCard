﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealCard.Models;
using RealCard.Models.Repositories;

namespace RealCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<BaseAccount> _userManager;
        private readonly SignInManager<BaseAccount> _signInManager;
        private AuthRepo _authRepo;

        public HomeController(ILogger<HomeController> logger, UserManager<BaseAccount> usermanager, SignInManager<BaseAccount> signinmanager, AuthRepo authRepo)
        {
            _logger = logger;
            _userManager = usermanager;
            _signInManager = signinmanager;
            _authRepo = authRepo;
        }

        public IActionResult Index()
        {
            if (HttpContext.User?.Identity.IsAuthenticated == true)
            {
                ViewData["Log"] = "You are logged in";
            }
            else
            {
                ViewData["Log"] = "Not logged in";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
