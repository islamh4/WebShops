using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShops.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Foto { get; set; }
    }
}