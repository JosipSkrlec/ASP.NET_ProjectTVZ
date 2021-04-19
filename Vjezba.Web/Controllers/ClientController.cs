using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ClientController : BaseController
    {
        private ClientManagerDbContext _dbContext;

        public ClientController(ClientManagerDbContext dbContext, UserManager<AppUser> userManager) : base(userManager)
        {
            this._dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index(ClientFilterModel filter)
        {
            var clientQuery = this._dbContext.Clients.Include(p => p.City).AsQueryable();

            filter = filter ?? new ClientFilterModel();

            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.CityID != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));

            var model = clientQuery.ToList();
            return View("Index", model);
        }

        [Authorize]
        public IActionResult Details(int? id = null)
        {
            var client = this._dbContext.Clients
                .Include(p => p.City)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(client);
        }

        [Authorize(Roles = "Manager,Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public IActionResult Create(Client model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = UserId;
                this._dbContext.Clients.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValues();
                return View();
            }
        }

        [Authorize(Roles = "Manager,Admin")]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Clients.FirstOrDefault(c => c.ID == id);
            this.FillDropdownValues();
            return View(model);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var client = this._dbContext.Clients.FirstOrDefault(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(client);

            if (ok && this.ModelState.IsValid)
            {
                client.UpdatedBy = UserId;
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownValues();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult IndexAjax(ClientFilterModel filter)
        {
            var clientQuery = this._dbContext.Clients.Include(p => p.City).AsQueryable();

            filter = filter ?? new ClientFilterModel();

            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.CityID != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));

            var model = clientQuery.ToList();
            return PartialView("_IndexTable", model: model);
        }

        

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.Cities)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCities = selectItems;
        }
    }
}
