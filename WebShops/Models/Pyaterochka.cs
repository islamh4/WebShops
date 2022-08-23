using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShops.Models
{
    public class Pyaterochka
    {
        public int PyaterochkaId { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string Name { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public int Price { get; set; }
        [Display(Name = "Фотография")]
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        public string Foto { get; set; }// = "https://el-sirius.ru/img/nophoto.png";
    }
}