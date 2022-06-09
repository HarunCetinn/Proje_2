using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje_2_Urun_Satis_Sitesi.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage ="Kategori ismi boş geçilemez. ")]
        [StringLength(20,ErrorMessage ="Maksimum 20, minimum 3 karakter girilebilir.",MinimumLength =3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
