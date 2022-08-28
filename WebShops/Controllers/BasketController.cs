using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShops.Models;
using WebShops.Controllers;

namespace WebShops.Controllers
{
    
    public class BasketController : Controller
    {
        private AcountContext db = new AcountContext();
        public ActionResult Index()
        {
            return View(db.Baskets.ToList());
        }
        [Authorize]
        public ActionResult Arrange()
        {
            return View();
        }
        [HttpPost, ActionName("Arrange")]
        public ActionResult ArrangeGood(Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                recipient.DateTime = DateTime.Now;
                db.Recipients.Add(recipient);
                db.SaveChanges();
                while (db.Baskets.FirstOrDefault() != null)
                {
                    Basket basket = db.Baskets.FirstOrDefault();
                    db.Entry(basket).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return View("ArrangeGood", recipient);
            }
            return View("Arrange", recipient);
        }
        public ActionResult Delete(int id)
        {
            Basket basket = db.Baskets.Find(id);
            db.Entry(basket).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}