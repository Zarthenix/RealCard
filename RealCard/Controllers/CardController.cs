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
        FileVMConverter _fileConverter = new FileVMConverter();

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
            IActionResult retVal = View(cvm);
            if (ModelState.IsValid)
            {
                Card card = _cardConverter.ConvertToModel(cvm);
                File file = _fileConverter.ConvertToModel(cvm.Uploader);
                card.ImageId = _fileRepo.UploadFile(file.ImageByteArray);

                int newCardId = _cardRepo.Create(card);
                if (newCardId == -1)
                {
                    ModelState.AddModelError("", "Invalid card creation.");
                }
                else
                {
                    retVal = RedirectToAction("Detail", new {id = newCardId});
                }

            }

            return retVal;
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
            if (ModelState.IsValid)
            {
                Card card = _cardConverter.ConvertToModel(cvm);
                //if _fileRepo.GetImage(cvm.CardId) != cvm.Uploader.File.
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int cardId)
        {
            return View();
        }
    }
}