using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using WebApplication2.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    public class ItemController : BaseController
    {
        // GET: /<controller>/
        private readonly IHostingEnvironment _appEnvironment;
        public ItemController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddItem(int id)
        {
            ViewBag.restaurantId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(string itemTitle, string itemDescription, float itemPrice, float itemDiscount, int restaurantid, IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("File not selected");

            string path_Root = _appEnvironment.WebRootPath;

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            string path_to_images = path_Root + "\\images\\" + fileName;

            using (var stream = new FileStream(path_to_images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string image_path = "~/images/" + fileName;
            Data.Db.AddItem(itemTitle, itemDescription, itemPrice, itemDiscount, image_path, restaurantid);

            return RedirectToAction("Index", "Restaurant");
        }

        [HttpPost]

        public IActionResult DeleteItem(int itemId)
        {
            Data.Db.DeleteItem(itemId);
            return RedirectToAction("Index", "Restaurant");

        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            ViewBag.itemId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(string itemTitle, string itemDescription, float itemPrice, float itemDiscount, int itemId, IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("File not selected");

            string path_Root = _appEnvironment.WebRootPath;

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            string path_to_images = path_Root + "\\images\\" + fileName;

            using (var stream = new FileStream(path_to_images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string image_path = "~/images/" + fileName;
            Data.Db.UpdateItem(itemId, itemTitle, itemDescription, itemPrice, itemDiscount, image_path);

            return RedirectToAction("Index", "Restaurant");
        }

       
        public IActionResult ToggleAvailability(int id)
        {
            Data.Db.ChangeStatus(id);
            return RedirectToAction("Index", "Restaurant");

        }
        public IActionResult AddToCart(int id)
        {
            var item = Data.Db.GetItem(id);
            var cart = HttpContext.Session.Get("cart");
            var orderList = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            if(orderList.Count()==0 || orderList.Last().RestaurantId == item.RestaurantId)
            {
                orderList.Add(item);
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(orderList));
                return RedirectToAction("Index", "Restaurant");

            }
            else
            {
                TempData["message"] = "Can not order from different restaurant at the same times";
                return RedirectToAction("ViewCart", "Item");
            }
            
            

        }

        public IActionResult ViewCart()
        {
            var orderList = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            ViewBag.orderList = orderList;
        
            return View();
        }

        public IActionResult RemoveFromCart(int id)
        {
            
            var cart = HttpContext.Session.Get("cart");
            var orderList = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            orderList.RemoveAt(id);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(orderList));
            if (orderList.Count() != 0)
            {
                

                return RedirectToAction("ViewCart", "Item");

            }
            else
            {
                return RedirectToAction("Index", "Restaurant");
            }
            
        }

        [HttpPost]

        public IActionResult AddDiscount(int itemId, float itemDiscount)
        {
            Data.Db.AddDiscount(itemDiscount,itemId);
            return RedirectToAction("Index", "Restaurant");

        }
    }

    
}
