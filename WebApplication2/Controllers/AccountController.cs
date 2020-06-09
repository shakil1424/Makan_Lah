using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userId, string password)
        {
            var user = Data.Db.CheckUser(userId);
            if (user != null && user.Password == password)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(new List<Item>()));
                

                return RedirectToAction("Index", "Restaurant");
            }
            else
            {
                TempData["message"] = "Invalid Id or password";
                return View();
            }
                
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");

            return RedirectToAction("Index", "Home");
        }

    }
}
