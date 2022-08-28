using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShops.Models
{
    public class Nike
    {
        public int NikeId { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string Name { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public int Price { get; set; }
        [Display(Name = "Фотография")]
        public string Foto { get; set; }
    }
}