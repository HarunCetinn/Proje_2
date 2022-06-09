using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje_2_Urun_Satis_Sitesi.Data.Models;
using Proje_2_Urun_Satis_Sitesi.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Proje_2_Urun_Satis_Sitesi.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {

            return View(foodRepository.TList("Category").ToPagedList(page,5));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(urunekle p)
        {
            Food f = new Food();
            if (p.ImageUrl != null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                f.ImageUrl = newimagename;
            }
            f.FoodName = p.FoodName;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryId = p.CategoryId;
            f.Description = p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            
            foodRepository.TDelete(new Food { FoodId = id });
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Food f = new Food()
            {
                FoodId = x.FoodId,
                CategoryId = x.CategoryId,
                FoodName = x.FoodName,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            };
            return View(f);
        }

        [HttpPost]
        public IActionResult FoodUpdate (Food p)
        {
            var x = foodRepository.TGet(p.FoodId);
            x.FoodName = p.FoodName;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageUrl = p.ImageUrl;
            x.Description = p.Description;
            x.CategoryId = p.CategoryId;
            foodRepository.TUpadete(x);
            return RedirectToAction("Index");
        }
    }
}
