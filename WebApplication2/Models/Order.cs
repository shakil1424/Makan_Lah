using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public string Description { get; set; }
        public byte OrderStatus { get; set; }

        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public string restaurantTitle { get; set; }

        public Order()
        {

            Items = new List<OrderItem>();
        }
    }
}
