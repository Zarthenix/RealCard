using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        private CardVMConverter _cardConverter = new CardVMConverter();
        private ImageFileVMConverter _ifvmConverter = new ImageFileVMConverter();

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
            //Deck deck = _deckRepo.Read(id);
            Card c = new Card()
            {
                Id = 1,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Pieter",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c1 = new Card()
            {
                Id = 2,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Henk",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c2 = new Card()
            {
                Id = 3,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Jna",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c3 = new Card()
            {
                Id = 4,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Aaa",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c4 = new Card()
            {
                Id = 5,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Tey",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c5 = new Card()
            {
                Id = 6,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Air Wizard",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c6 = new Card()
            {
                Id = 7,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Kawaii",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            CardViewModel cvm = _cardConverter.ConvertToViewModel(c);
            CardViewModel cvm1 = _cardConverter.ConvertToViewModel(c1);
            CardViewModel cvm2 = _cardConverter.ConvertToViewModel(c2);
            CardViewModel cvm3 = _cardConverter.ConvertToViewModel(c3);
            CardViewModel cvm4 = _cardConverter.ConvertToViewModel(c4);
            CardViewModel cvm5 = _cardConverter.ConvertToViewModel(c5);
            CardViewModel cvm6 = _cardConverter.ConvertToViewModel(c6);

            ImageFile file = _fileRepo.Read(5);
            ImageFileViewModel ifvm = _ifvmConverter.ConvertToViewModel(file);

            cvm.Uploader = ifvm;
            cvm1.Uploader = ifvm;
            cvm2.Uploader = ifvm;
            cvm3.Uploader = ifvm;
            cvm4.Uploader = ifvm;
            cvm5.Uploader = ifvm;
            cvm6.Uploader = ifvm;

            List<CardViewModel> cvmlist = new List<CardViewModel>();
            cvmlist.Add(cvm);
            cvmlist.Add(cvm1);
            cvmlist.Add(cvm2);
            cvmlist.Add(cvm3);
            cvmlist.Add(cvm4);
            cvmlist.Add(cvm5);
            cvmlist.Add(cvm6);

            DeckViewModel d = new DeckViewModel()
            {
                Cards = cvmlist,
            };

            return PartialView("~/Views/Game/_DeckCreate.cshtml", d);
        }

        public IActionResult GetDeckView(int? id)
        {
            //Deck deck = _deckRepo.Read(id);
            Card c = new Card()
            {
                Id = 1,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Pieter",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c1 = new Card()
            {
                Id = 2,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Henk",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c2 = new Card()
            {
                Id = 3,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Jna",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c3 = new Card()
            {
                Id = 4,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Aaa",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c4 = new Card()
            {
                Id = 5,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Tey",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c5 = new Card()
            {
                Id = 6,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Air Wizard",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            Card c6 = new Card()
            {
                Id = 7,
                Attack = 200,
                Health = 300,
                Description = "Blablablablalaalaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Name = "Kawaii",
                ImageId = 109,
                Type = CardType.Air,
                Value = 999
            };
            CardViewModel cvm = _cardConverter.ConvertToViewModel(c);
            CardViewModel cvm1 = _cardConverter.ConvertToViewModel(c1);
            CardViewModel cvm2 = _cardConverter.ConvertToViewModel(c2);
            CardViewModel cvm3 = _cardConverter.ConvertToViewModel(c3);
            CardViewModel cvm4 = _cardConverter.ConvertToViewModel(c4);
            CardViewModel cvm5 = _cardConverter.ConvertToViewModel(c5);
            CardViewModel cvm6 = _cardConverter.ConvertToViewModel(c6);

            ImageFile file = _fileRepo.Read(5);
            ImageFileViewModel ifvm = _ifvmConverter.ConvertToViewModel(file);

            cvm.Uploader = ifvm;
            cvm1.Uploader = ifvm;
            cvm2.Uploader = ifvm;
            cvm3.Uploader = ifvm;
            cvm4.Uploader = ifvm;
            cvm5.Uploader = ifvm;
            cvm6.Uploader = ifvm;

            List<CardViewModel> cvmlist = new List<CardViewModel>();
            cvmlist.Add(cvm);
            cvmlist.Add(cvm1);
            cvmlist.Add(cvm2);
            cvmlist.Add(cvm3);
            cvmlist.Add(cvm4);
            cvmlist.Add(cvm5);
            cvmlist.Add(cvm6);

            DeckViewModel d = new DeckViewModel()
            {
                Cards = cvmlist,
                CreatedAt = DateTime.Now,
                Id = 1,
                Name = "Coolio",
                Wins = 11
            };

            return PartialView("~/Views/Game/_DeckDetail.cshtml", d);
        }

        public IActionResult GetDeckOverview()
        {
            //int id = GetUserId();
            //List<Deck> decks = _deckRepo.GetAllByPlayerId(id);
            //foreach (Deck d in decks)
            //{
            //    d.Cards = _cardRepo.GetAllByDeckId(d.Id);
            //}

            List<Deck> decks = new List<Deck>();
            Deck a = new Deck();
            a.Name = "test";
            a.Id = 1;
            Deck b = new Deck();
            b.Name = "tast";
            b.Id = 2;
            Deck c = new Deck();
            c.Name = "test";
            c.Id = 3;
            Deck d = new Deck();
            d.Name = "tast";
            d.Id = 4;
            Deck e = new Deck();
            e.Name = "test";
            e.Id = 5;
            Deck f = new Deck();
            f.Name = "tast";
            f.Id = 6;


            decks.Add(a);
            decks.Add(b);
            decks.Add(c);
            decks.Add(d);
            decks.Add(e);
            decks.Add(f);

            return PartialView("~/Views/Game/_DeckIndex.cshtml", decks);
        }
    }
}