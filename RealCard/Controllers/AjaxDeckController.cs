using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
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
        private DeckVMConverter _deckConverter = new DeckVMConverter();

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
            Deck d = _deckRepo.Read(id);
            List<Card> retList = new List<Card>();
            foreach (Card c in d.Cards)
            {
                Card card = _cardRepo.Read(c.Id);
                retList.Add(card);
            }

            return new JsonResult(JsonSerializer.Serialize(retList, _jsonOptions));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = await sr.ReadToEndAsync();
            DeckSerialize t = JsonSerializer.Deserialize<DeckSerialize>(data, _jsonOptions);
            _deckRepo.Save(t.Ids, t.Deckid, t.DeckName);

            return new JsonResult("success");
        }

        private class DeckSerialize
        {
            public int Deckid { get; set; }
            public int[] Ids { get; set; }
            public string DeckName { get; set; }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = await sr.ReadToEndAsync();
            DeckSerialize t = JsonSerializer.Deserialize<DeckSerialize>(data, _jsonOptions);
            _deckRepo.Create(t.Ids, t.DeckName, GetUserId());

            return new JsonResult(t.DeckName);
        }

  
    }
}