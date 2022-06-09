using Microsoft.AspNetCore.Mvc;
using Proje_2_Urun_Satis_Sitesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje_2_Urun_Satis_Sitesi.Data.Models;

namespace Proje_2_Urun_Satis_Sitesi.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proName = "Computer",
                stock=150
            });
            cs.Add(new Class1()
            {
                proName = "Lcd",
                stock = 100
            });
            cs.Add(new Class1()
            {
                proName = "Ssd",
                stock = 50
            });
            return cs;
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodName = x.FoodName,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }

        public IActionResult Statistics()
        {
            Context c = new Context();
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var foid = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.d = foid;
            var deger3 = c.Foods.Where(x => x.CategoryId == foid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x => x.CategoryId == c.Categories.Where(z => z.CategoryName == "Vegatables").Select(y => y.CategoryId).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x=>x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.Where(x => x.CategoryId == c.Categories.Where(z => z.CategoryName == "Legumes").Select(y => y.CategoryId).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d8 = deger8;
            return View();
        }

    }
}
