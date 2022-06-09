using Microsoft.AspNetCore.Mvc;
using Proje_2_Urun_Satis_Sitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje_2_Urun_Satis_Sitesi.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodList = foodRepository.List(x=>x.CategoryId==id);
            return View(foodList);
        }

    }
}
