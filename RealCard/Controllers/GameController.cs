using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Editing;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;
using RealCard.Models;
using RealCard.Models.Converters;

namespace RealCard.Controllers
{
    public class GameController : BaseController
    {
        private readonly CardRepo _cardRepo;
        private readonly DeckRepo _deckRepo;
        private readonly ImageFileRepo _fileRepo;

        private readonly CardVMConverter _cardConverter = new CardVMConverter();
        private readonly ImageFileVMConverter _ifvmConverter = new ImageFileVMConverter();
        private readonly DeckVMConverter _deckConverter = new DeckVMConverter();

        public GameController(CardRepo c, DeckRepo d, ImageFileRepo i)
        {
            _cardRepo = c;
            _deckRepo = d;
            _fileRepo = i;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDeckCreateView()
        {
            DeckViewModel dvm = new DeckViewModel();
            List<Card> cards = new List<Card>();
            List<CardViewModel> cvm = new List<CardViewModel>();

            cards = _cardRepo.GetAllByPlayerId(GetUserId());
            
            foreach (Card c in cards)
            {
                ImageFile img = _fileRepo.Read(c.ImageId);
                ImageFileViewModel ifvm = _ifvmConverter.ConvertToViewModel(img);
                CardViewModel m = _cardConverter.ConvertToViewModel(c);
                m.Uploader = ifvm;
                cvm.Add(m);
            }

            dvm.Cards = cvm;
            return PartialView("~/Views/Game/_DeckCreate.cshtml", dvm);
        }

        [HttpGet]
        public IActionResult GetDeckDetailView(int id)
        {
            List<CardViewModel> cvm = new List<CardViewModel>();

            List<Card> cards = _cardRepo.GetAllByPlayerId(GetUserId());
            Deck deck = _deckRepo.Read(id);
            DeckViewModel dvm = _deckConverter.ConvertToViewModel(deck);

            foreach (Card c in cards)
            {
                ImageFile img = _fileRepo.Read(c.ImageId);
                ImageFileViewModel ifvm = _ifvmConverter.ConvertToViewModel(img);
                CardViewModel m = _cardConverter.ConvertToViewModel(c);
                m.Uploader = ifvm;
                cvm.Add(m);
            }
            dvm.Cards = cvm;

            return PartialView("~/Views/Game/_DeckDetail.cshtml", dvm);
        }

        [HttpGet]
        public IActionResult GetDeckIndexView()
        {
            int id = GetUserId();
            List<Deck> decks = _deckRepo.GetAllByPlayerId(id);

            return PartialView("~/Views/Game/_DeckIndex.cshtml", decks);
        }
    }
}