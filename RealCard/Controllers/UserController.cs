using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        //alleen mods/admins
        [Authorize]
        public IActionResult Index(int? id)
        {
            User user = new User();
            if (id == null)
            {
                user = _userRepo.GetById(GetUserId());
            }
            else
            {
                user = _userRepo.GetById((int)id);
            }
            UserVMConverter uvmc = new UserVMConverter();
            
            UserViewModel uvm = uvmc.ConvertToViewModel(user);
            return View(uvm);
        }

        [Authorize]
        [HttpGet]
        public IActionResult UserList()
        {
            List<UserViewModel> uvm = new List<UserViewModel>();
            UserVMConverter uvmc = new UserVMConverter();
            List<User> users = _userRepo.GetAllWithRoles();
            foreach (User us in users)
            {
                uvm.Add(uvmc.ConvertToViewModel(us));
            }

            return View(uvm);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ToggleChatPermission(bool currentPermission, int userid)
        {
            _userRepo.ToggleChatPermission(currentPermission, userid);
            return RedirectToAction("UserList");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit()
        {
            User user = _userRepo.GetById(GetUserId());
            user.Id = GetUserId();
            UserVMConverter uvmc = new UserVMConverter();

            UserViewModel uvm = uvmc.ConvertToViewModel(user);
            return View(uvm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(UserViewModel uvm)
        {
            UserVMConverter uvmc = new UserVMConverter();
            
            if (ModelState.IsValid)
            {
                _userRepo.Edit(uvmc.ConvertToModel(uvm));
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int userid)
        {
            if (userid != GetUserId())
            {
                _userRepo.Delete(userid);
            }

            return RedirectToAction("UserList");
        }
    }
}