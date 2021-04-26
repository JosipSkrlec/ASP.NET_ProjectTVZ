using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.DAL;
using Vjezba.Model;
using Vjezba.Web.Models;

// https://threejsfundamentals.org/threejs/lessons/threejs-load-obj.html

namespace Vjezba.Web.Controllers
{
    public class ThreeDController : BaseController
    {
        private string objFilePath;
        private ThreeDModelDbContext _dbContext;
        public ThreeDController(ThreeDModelDbContext dbContext, UserManager<AppUser> userManager) : base(userManager)
        {
            this._dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index(ThreeDFilterModel filter)
        {
            //var threeDQuery = this._dbContext.threeD.Include(p => p.Id).AsQueryable();

            //filter = filter ?? new ThreeDFilterModel();

            //if (!string.IsNullOrWhiteSpace(filter.Name))
            //    threeDQuery = threeDQuery.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));

            ////if (!string.IsNullOrWhiteSpace(filter.Category))
            ////    threeDQuery = threeDQuery.Where(p => p.Category.ToLower().Contains(filter.Category.ToLower()));

            //var model = threeDQuery.ToList();
            //return View("Index", model);
            return View("Index");
        }

        //[Authorize(Roles = "Manager,Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }

        //[Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public IActionResult Create(ThreeD model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = UserId;
                this._dbContext.threeD.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValues();
                return View();
            }
        }

        public async Task<IActionResult> Upload(IFormFile file)
        {
            var FileDic = @"wwwroot\3DModels";

            //if (!Directory.Exists(FileDic))
            //{
            //    Directory.CreateDirectory(FileDic);            
            //}

            var fileName = file.FileName;
            var filePath = Path.Combine(FileDic, fileName);

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }
            return RedirectToAction("Index");
        }

        public void Upload1(IFormFile file)
        {
            var FileDic = @"wwwroot\3DModels";

            //if (!Directory.Exists(FileDic))
            //{
            //    Directory.CreateDirectory(FileDic);            
            //}

            var fileName = file.FileName;
            var filePath = Path.Combine(FileDic, fileName);

            objFilePath = filePath;

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }
        }




        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- 3D/Category -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.threeDCategoryes)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleCategoryes = selectItems;
        }

    }

}
