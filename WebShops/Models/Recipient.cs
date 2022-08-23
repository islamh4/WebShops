using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShops.Models
{
    public class Recipient
    {
        public int RecipientId { get; set; }
        public DateTime DateTime { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Firstname { get; set; }
        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле должно быть заполненным!")]
        public string Address { get; set; }
    }
}