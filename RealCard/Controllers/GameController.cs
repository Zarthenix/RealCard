using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RealCard.Controllers
{
    public class GameController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}