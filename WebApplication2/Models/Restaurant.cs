using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //each restaurant has multiple item
        public IEnumerable<Item> Items { get; set; }

        //Each restaurant has a picture??
        public string Url { get; set; }

        public string userId { get; set; }

        public Restaurant()
        {
            Items = new List<Item>();
        }


    }
    
}
