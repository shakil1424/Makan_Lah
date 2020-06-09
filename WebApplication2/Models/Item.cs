using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public byte IsAvailable { get; set; }

        //Each Item has a picture??
        public string Url { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public IEnumerable<OrderItem> Orders { get; set; }

        public Item()
        {
            Orders = new List<OrderItem>();
        }

    }
}
