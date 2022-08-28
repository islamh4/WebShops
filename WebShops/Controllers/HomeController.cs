using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebShops.Models;

namespace WebShops.Controllers
{
    public class HomeController : Controller
    {
        private AcountContext db = new AcountContext();
        public ActionResult Index(string strUrl)
        {
            switch (strUrl)
            {
                case "Магазин рыбалки":
                    TempData["Magas"] = "Рыбалки";
                    return Redirect("~/Fishings/Index");
                case "Магазин Nike":
                    TempData["Magas"] = "Nike";
                    return Redirect("~/Nikes/Index");
                case "Магазин Adidas":
                    TempData["Magas"] = "Adidas";
                    return Redirect("~/Adidas/Index");
                case "Магазин пятёрочка":
                    TempData["Magas"] = "Пятёрочка";
                    return Redirect("~/Pyaterochkas/Index");
                case "Магазин охоты":
                    TempData["Magas"] = "Охоты";
                    return Redirect("~/Huntings/Index");
            }
            return View();
        }
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(LoginModel logins)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (AcountContext db = new AcountContext())
                {
                    user = db.Users.FirstOrDefault(a => a.UserLogin == logins.Login && a.UserPassword == logins.Password);
                }
                if (user != null)
                {
                    if (db.Baskets.Count() == 0) return Redirect("~/Home/Index");
                    FormsAuthentication.SetAuthCookie(logins.Login, true);
                    return Redirect("~/Basket/Index");
                }
            }
            return View(logins);
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (AcountContext db = new AcountContext())
                {
                    user = db.Users.FirstOrDefault(a => a.UserLogin == register.RegistrLogin);
                }
                if (user == null)
                {
                    using (AcountContext db = new AcountContext())
                    {
                        db.Users.Add(new User { Name = register.Name, Firstname = register.Firstname, Age = register.Age, UserLogin = register.RegistrLogin, UserPassword = register.RegistrPassword });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.UserLogin == register.RegistrLogin && u.UserPassword == register.RegistrPassword).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        if (db.Baskets.Count() == 0) return Redirect("~/Home/Index");
                        FormsAuthentication.SetAuthCookie(register.RegistrLogin, true);
                        return Redirect("~/Basket/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует!");
                }
            }
            return View(register);
        }
    }
}