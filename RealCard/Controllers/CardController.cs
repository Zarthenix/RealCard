using System;
using System.Collections;
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
        private readonly ImageFileRepo _fileRepo;
        private readonly CardRepo _cardRepo;
        private readonly CardVMConverter _cardConverter = new CardVMConverter();
        private readonly ImageFileVMConverter _imageConverter = new ImageFileVMConverter();

        public CardController(ImageFileRepo fileRepo, CardRepo cardRepo)
        {
            _fileRepo = fileRepo;
            _cardRepo = cardRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CardViewModel> cardViewModels = new List<CardViewModel>();
            List<Card> cards = _cardRepo.GetAll();
            foreach (Card c in cards)
            {
                CardViewModel cvm = _cardConverter.ConvertToViewModel(c);
                cvm.Uploader = _imageConverter.ConvertToViewModel(_fileRepo.Read(c.ImageId));
                cardViewModels.Add(cvm);
            }
            return View(cardViewModels);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            CardViewModel card = _cardConverter.ConvertToViewModel(_cardRepo.Read(id));
            ImageFileViewModel img = _imageConverter.ConvertToViewModel(_fileRepo.Read(card.ImageId));
            card.Uploader = img;

            return View(card);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CardViewModel cvm)
        {
            IActionResult retVal = View(cvm);
            if (ModelState.IsValid)
            {
                Card card = _cardConverter.ConvertToModel(cvm);
                ImageFile file = _imageConverter.ConvertToModel(cvm.Uploader);

                int imgId = _fileRepo.UploadFile(file.ImageByteArray);
                if (imgId != -1)
                {
                    card.ImageId = imgId;
                    int cardId = _cardRepo.Create(card);
                    if (cardId == -1)
                    {
                        _fileRepo.Delete(card.ImageId);
                        ModelState.AddModelError("", "Card creation failed.");
                    }
                    else
                    {
                        retVal = RedirectToAction("Detail", new {id = cardId});
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Image upload failed.");
                }
            }
            return retVal;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            CardViewModel cvm = new CardViewModel();
            Card card = _cardRepo.Read(id);

            ImageFile imageFile = _fileRepo.Read(card.ImageId);
            cvm = _cardConverter.ConvertToViewModel(card);
            cvm.ImageId = card.ImageId;
            cvm.Uploader = _imageConverter.ConvertToViewModel(imageFile);
            
            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(CardViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                Card card = _cardConverter.ConvertToModel(cvm);
                if (cvm.Uploader.FileRaw != null)
                {
                    ImageFile img = _imageConverter.ConvertToModel(cvm.Uploader);
                    ImageFile img2 = _fileRepo.Read(card.ImageId);
                    
                    if (!ByteArrayCompare(img.ImageByteArray, img2.ImageByteArray))
                    {
                        _fileRepo.Delete(card.ImageId);
                        card.ImageId = _fileRepo.UploadFile(img.ImageByteArray);
                    }
                }
                _cardRepo.Update(card);
            }
            return RedirectToAction("Detail", new {id = cvm.Id});
        }

        private bool ByteArrayCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
        {
            return a1.SequenceEqual(a2);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Card c = _cardRepo.Read(id);
            _cardRepo.Delete(id);
            _fileRepo.Delete(c.ImageId);
            
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public PartialViewResult GetCardPartial()
        {
            int id = 3;
            Card c = _cardRepo.Read(id);
            CardViewModel cvm = _cardConverter.ConvertToViewModel(c);
            cvm.Uploader = _imageConverter.ConvertToViewModel(_fileRepo.Read(c.ImageId));
            return PartialView("_Card", cvm);
        }
    }
}