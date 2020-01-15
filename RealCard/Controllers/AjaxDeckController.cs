using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;
using RealCard.Models;
using RealCard.Models.Converters;

namespace RealCard.Controllers
{
    public class AjaxDeckController : BaseController
    {
   
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly CardRepo _cardRepo;
        private readonly DeckRepo _deckRepo;
        private readonly ImageFileRepo _fileRepo;
        private CardVMConverter _cardConverter = new CardVMConverter();
        private ImageFileVMConverter _ifvmConverter = new ImageFileVMConverter();

        public AjaxDeckController(CardRepo c, DeckRepo d, ImageFileRepo i)
        {
            _cardRepo = c;
            _deckRepo = d;
            _fileRepo = i;
            _jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        [HttpGet]
        public JsonResult Detail(int id)
        {
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


            List<CardViewModel> cvmlist = new List<CardViewModel>();
            cvmlist.Add(cvm);
            cvmlist.Add(cvm1);
            cvmlist.Add(cvm2);
            cvmlist.Add(cvm3);
            cvmlist.Add(cvm4);
            cvmlist.Add(cvm5);
            cvmlist.Add(cvm6);

            

            return new JsonResult(JsonSerializer.Serialize(cvmlist, _jsonOptions));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = await sr.ReadToEndAsync();
            Test t = JsonSerializer.Deserialize<Test>(data, _jsonOptions);


            return new JsonResult("bla");
        }

        private class Test
        {
            public int Deckid { get; set; }
            public List<int> Ids { get; set; }
        }

        
    }
}