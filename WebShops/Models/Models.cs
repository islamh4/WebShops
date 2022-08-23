using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShops.Models
{
    public class LoginModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
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
        public string RegistrLogin { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string RegistrPassword { get; set; }
    }
}