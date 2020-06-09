using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IHostingEnvironment _appEnvironment;
        public RestaurantController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }
        
        public IActionResult Index()
        {
            
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants = Data.Db.ShowRestaurant();
            
            
          

            return View(restaurants);
        }

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddRestaurant(string restaurantTitle, string userId, string password, IFormFile file)
        {
            if (Data.Db.CheckUser(userId) != null)
            {
                TempData["message"] = "Similar Id exits";
                return View();
            }
            if (file == null || file.Length == 0) return Content("File not selected");

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path_Root = _appEnvironment.WebRootPath;

            string path_to_images = path_Root + "\\images\\" + fileName;
            

            using (var stream = new FileStream(path_to_images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            
            Data.Db.AddUser(userId, password, 2);
            string image_path = "~/images/" + fileName;
            Data.Db.AddRestaurant(restaurantTitle, userId, image_path);

            return RedirectToAction("Index", "Restaurant");
        }

        [HttpPost]

        public IActionResult DeleteRestaurant (int restaurantId)
        {
            Data.Db.DeleteRestaurant(restaurantId);
            return RedirectToAction("Index", "Restaurant");

        }


        [HttpGet]
        public IActionResult EditRestaurant(int id)
        {
            ViewBag.restaurantId = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditRestaurant(string restaurantTitle, int restaurantId, IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("File not selected");

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path_Root = _appEnvironment.WebRootPath;

            string path_to_images = path_Root + "\\images\\" + fileName;


            using (var stream = new FileStream(path_to_images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


           
            string image_path = "~/images/" + fileName;
            Data.Db.UpdateRestaurant( restaurantId,restaurantTitle, image_path);

            return RedirectToAction("Index", "Restaurant");
        }
    }
}