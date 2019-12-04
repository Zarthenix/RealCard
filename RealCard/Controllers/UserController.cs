using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealCard.Models;
using RealCard.Models.Repositories;
using RealCard.ViewModels;
using RealCard.ViewModels.Converters;

namespace RealCard.Controllers
{
    public class UserController : BaseController
    {
        private UserRepo _userRepo;

        public UserController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            UserVMConverter uvmc = new UserVMConverter();
            BaseAccount user = _userRepo.GetById(GetUserId());
            UserViewModel uvm = uvmc.ConvertToViewModel(user);
            return View(uvm);
        }
    }
}