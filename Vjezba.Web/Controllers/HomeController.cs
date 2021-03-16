﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Jednostavan način proslijeđivanja poruke iz Controller -> View.";


            return View();
        }

        /// <summary>
        /// Ova akcija se poziva kada na formi za kontakt kliknemo "Submit"
        /// URL ove akcije je /Home/SubmitQuery, uz POST zahtjev isključivo - ne može se napraviti GET zahtjev zbog [HttpPost] parametra
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitQuery(IFormCollection formData)
        {
            //Ovdje je potrebno obraditi podatke i pospremiti finalni string u ViewBag
            string ime = formData["inputIme"].ToString();
            string prezime = formData["inputPrezime"].ToString();
            string email = formData["inputEmail"].ToString();
            string poruka = formData["FormTextarea"].ToString();
            string upit = formData["inputState"].ToString();

            bool Newsletter;
            if (formData["NewsletterInput"].ToString() == "on")
            {
                Newsletter = true;
            }
            else
            {
                Newsletter = false;
            }


            //Kao rezultat se pogled /Views/Home/ContactSuccess.cshtml renderira u "pravi" HTML
            //Kao parametar se predaje naziv cshtml datoteke koju treba obraditi (ne koristi se default vrijednost)
            //Trazenu cshtml datoteku je potrebno samostalno dodati u projekt

            ViewBag.FormInformationIme = ime;
            ViewBag.FormInformationPrezime = prezime;
            ViewBag.FormInformationEmail = email;
            ViewBag.FormInformationPoruka = poruka;
            ViewBag.FormInformationupit = upit;
            ViewBag.FormInformationNews = Newsletter;

            return View("ContactSuccess");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // ZADACI



        public IActionResult FAQ(int? brojPitanja)
        {

            var list = new List<PitanjaIOdgovori>();
            list.Add(new PitanjaIOdgovori { Pitanje = "1.Da li je nebo plavo?", Odgovor = "DA" });
            list.Add(new PitanjaIOdgovori { Pitanje = "2.Da li je jež bodljikav?", Odgovor = "DA" });
            list.Add(new PitanjaIOdgovori { Pitanje = "3.Da li je drvo drveno?", Odgovor = "DA" });
            list.Add(new PitanjaIOdgovori { Pitanje = "4.Da li je 2 + 2 = 5?", Odgovor = "NE" });
            list.Add(new PitanjaIOdgovori { Pitanje = "5.Da li je jabuka povrće?", Odgovor = "NE" });


            ViewData["ReturningList"] = list;
            ViewBag.ReturningIndicator = brojPitanja;
            return View();
        }


    }

}
