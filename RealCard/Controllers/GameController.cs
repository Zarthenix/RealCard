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
            List<DeckViewModel> deckVms = new List<DeckViewModel>();

            foreach (Deck d in decks)
            {
                deckVms.Add(_deckConverter.ConvertToViewModel(d));
            }

            return PartialView("~/Views/Game/_DeckIndex.cshtml", decks);
        }

        [HttpGet]
        public IActionResult GetGameDeckSelectView()
        {
            int id = GetUserId();
            List<Deck> decks = _deckRepo.GetAllByPlayerId(id);
            List<DeckViewModel> deckVms = new List<DeckViewModel>();
            foreach (Deck d in decks)
            {
                deckVms.Add(_deckConverter.ConvertToViewModel(d));
            }
            return PartialView("~/Views/Game/_GameDeckSelect.cshtml", decks);
        }

        [HttpGet]
        public IActionResult GetGameMainView(int id)
        {
            Deck chosenDeck = _deckRepo.Read(id);
            DeckViewModel dvm = _deckConverter.ConvertToViewModel(chosenDeck);

            foreach (Card c in chosenDeck.Cards)
            {
                Card d = _cardRepo.Read(c.Id);
                CardViewModel cvm = _cardConverter.ConvertToViewModel(d);
                ImageFile f = _fileRepo.Read(d.ImageId);
                cvm.Uploader = _ifvmConverter.ConvertToViewModel(f);
                dvm.Cards.Add(cvm);
            }

            return PartialView("~/Views/Game/_GameMainWindow.cshtml", dvm);
        }
    }
}