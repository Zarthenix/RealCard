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
    public class CardController : Controller
    {
        private FileRepo _fileRepo;
        private CardRepo _cardRepo;
        CardVMConverter _cardConverter = new CardVMConverter();

        public CardController(FileRepo fileRepo, CardRepo cardRepo)
        {
            _fileRepo = fileRepo;
            _cardRepo = cardRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CardViewModel cvm)
        {
            Card card = _cardConverter.ConvertToModel(cvm);
            card.ImageId = _fileRepo.UploadFile(cvm.Uploader.FileData);

            int newCardId = _cardRepo.Create(card);

            return RedirectToAction("Detail", new {id = newCardId});
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CardViewModel cvm)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int cardId)
        {
            return View();
        }
    }
}