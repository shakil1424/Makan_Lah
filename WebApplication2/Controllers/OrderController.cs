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
    public class OrderController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult CheckOut()
        {
            Order order = new Order();
            var orderList = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            float totalPrice = 0;
            string description = "";

            foreach (var item in orderList)
            {
                totalPrice = totalPrice + (item.Price - item.Discount);
                description = item.Title + " " + description;
            }
            order.RestaurantId = orderList.Last().RestaurantId;
            order.UserId = loggedUser.UserId;
            order.Date = DateTime.Now.ToLocalTime();
            order.TotalPrice = totalPrice;
            order.Description = description;
            int orderId = Data.Db.AddOrder(order);

            foreach (var item in orderList)
            {
                var orderItem = new OrderItem();
                orderItem.OrderId = orderId;
                orderItem.ItemId = item.Id;
                Data.Db.AddOrderItem(orderItem);
            }
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Index", "Restaurant");
        }

        public IActionResult ViewRestaurantOrder(int id)
        {
            List<Order> orderList = new List<Order>();
            orderList = Data.Db.ShowRestaurantOrder(id);
            return View(orderList);
        }

        public IActionResult ChangeOrderStatus(int id)
        {
            
            int restaurantId = Data.Db.ChangeOrderStatus(id);
            return RedirectToAction("ViewRestaurantOrder", "Order", new { id = restaurantId });
        }

        public IActionResult ViewCustomerOrder()
        {
            List<Order> orderList = new List<Order>();
            orderList = Data.Db.ShowCustomerOrder(loggedUser.UserId);
            return View(orderList);
        }
    }
}
