using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Test()

        {
            //Check add user
            //Data.Db.AddUser("user5", "123456", 1);

            //Check delete user
            //Data.Db.DeleteUser("user2");

            //Check update user
            Data.Db.UpdateUser("rahim1234", "karim1424", "123456", 1);
            //ViewData["Message"] = "Your contact page.";
            return RedirectToAction("ShowUser", "Home");

            //return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Show userlist
        public IActionResult ShowUser()
        {
            List<AppUser> userList = new List<AppUser>();
            userList = Data.Db.ShowUser();
            return View(userList);
        }
    }
}
