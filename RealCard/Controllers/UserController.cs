using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Models;
using RealCard.Models;
using RealCard.Models.Converters;

namespace RealCard.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserRepo _userRepo;

        public UserController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            User user;
            if (id == null)
            {
                int uid = GetUserId();
                user = _userRepo.GetById(uid);
                user.Id = uid;
            }
            else
            {
                user = _userRepo.GetById((int)id);
                user.Id = (int) id;
            }
            UserVMConverter uvmc = new UserVMConverter();
            
            UserViewModel uvm = uvmc.ConvertToViewModel(user);
            return View(uvm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult UserList()
        {
            List<UserViewModel> uvm = new List<UserViewModel>();
            UserVMConverter uvmc = new UserVMConverter();
            List<User> users = _userRepo.GetAll();
            foreach (User us in users)
            {
                uvm.Add(uvmc.ConvertToViewModel(us));
            }

            return View(uvm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult ToggleChatPermission(bool currentPermission, int userid)
        {
            _userRepo.ToggleChatPermission(currentPermission, userid);
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            User user = _userRepo.GetById(GetUserId());
            user.Id = GetUserId();
            UserVMConverter uvmc = new UserVMConverter();

            UserViewModel uvm = uvmc.ConvertToViewModel(user);
            return View(uvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                UserVMConverter uvmc = new UserVMConverter();
                _userRepo.Edit(uvmc.ConvertToModel(uvm));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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