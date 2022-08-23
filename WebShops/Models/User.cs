using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShops.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Firstname { get; set; }
        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Age { get; set; }
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string UserLogin { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string UserPassword { get; set; }
    }
}