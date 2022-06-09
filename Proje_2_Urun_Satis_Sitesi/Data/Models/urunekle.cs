using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje_2_Urun_Satis_Sitesi.Data.Models
{
    public class urunekle
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

    }
}
