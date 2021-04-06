﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.DAL;
using Vjezba.Model;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class ClientController : Controller
    {
        private ClientManagerDbContext _dbContext;

        public ClientController(ClientManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index(ClientFilterModel filter)
        {
            var clientQuery = this._dbContext.Clients.AsQueryable();

            filter = filter ?? new ClientFilterModel();

            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.CityID != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));


            var model = clientQuery.OrderBy(p => p.ID).ToList();


            return View("Index", model);
        }

        public IActionResult Details(int? id = null)
        {
            var client = this._dbContext.Clients
                //.Include(p => p.City)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(client);
        }

        public IActionResult Create()
        {
            //List<string> genders = new List<string>();
            //genders.Add("");
            //genders.Add("M");
            //genders.Add("Z");

            //ViewBag.PossibleCategories = genders;
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;

            ViewBag.PossibleCategories = GetCityListItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client model)
        {
            //List<string> genders = new List<string>();
            //genders.Add("");
            //genders.Add("M");
            //genders.Add("Z");

            //ViewBag.PossibleCategories = genders;

            if (ModelState.IsValid)
            {
                model.CityID = 1;
                this._dbContext.Clients.Add(model);
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {

                model.CityID = 1;
                this._dbContext.Clients.Add(model);
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [ActionName("Edit")]
        public IActionResult EditGet(int? id = null)
        {
            var client = this._dbContext.Clients
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(client);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {

            var client = this._dbContext.Clients.First(p => p.ID == id);
            var update = await TryUpdateModelAsync(client);

            if (update)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }



        private List<SelectListItem> GetCityListItems()
        {
            var selectedItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectedItems.Add(listItem);

            foreach (City city in this._dbContext.Cities.ToList())
            {
                var item = new SelectListItem();
                item.Text = city.Name;
                item.Value = city.ID.ToString();
                selectedItems.Add(item);
            }
            
            return selectedItems;
        }


    }
}
