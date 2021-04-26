using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.Model;

namespace Vjezba.Web.Controllers
{
    public class BaseController : Controller
    {
        public String UserId { get; }        
        public BaseController(UserManager<AppUser> userManager)
        {
            try
            {
                UserId = userManager.GetUserId(User);
            }
            catch (Exception e)
            {
                UserId = null;
            }            
        }
    }
}
