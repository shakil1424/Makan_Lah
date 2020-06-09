using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BaseController : Controller
    {
        protected AppUser loggedUser;
        protected int cartCount = 0;
        

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (HttpContext.Session.GetString("user") != null)
                loggedUser = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("user"));

            if (HttpContext.Session.GetString("cart") != null)
            {
                cartCount = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart")).Count;
                


            }
            
            ViewBag.User = loggedUser;
            ViewBag.CartCount = cartCount;
            
        }
    }
}
