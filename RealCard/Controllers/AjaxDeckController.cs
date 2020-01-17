using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        private readonly DeckCreateVMConverter _dcvmc = new DeckCreateVMConverter();

        public AjaxDeckController(CardRepo c, DeckRepo d)
        {
            _cardRepo = c;
            _deckRepo = d;
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

            DeckCreateViewModel t = JsonSerializer.Deserialize<DeckCreateViewModel>(data, _jsonOptions);
            Deck d = _dcvmc.ConvertToModel(t);

            if (d.Name == "")
            {
                d.Name = "Nameless";
            }
            _deckRepo.Save(d);

            return new JsonResult("success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = await sr.ReadToEndAsync();

            DeckCreateViewModel t = JsonSerializer.Deserialize<DeckCreateViewModel>(data, _jsonOptions);
            t.UserId = GetUserId();
            Deck d = _dcvmc.ConvertToModel(t);

            if (d.Name == "")
            {
                d.Name = "Nameless";
            }
            _deckRepo.Create(d);

            return new JsonResult("aa");
        }

  
    }
}