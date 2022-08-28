using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShops.Models;

namespace WebShops.Controllers
{
    [Authorize]
    public class AdidasController : Controller
    {
        private AcountContext db = new AcountContext();

        public ActionResult Index()
        {
            return View(db.Adidases.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adidas adidas = db.Adidases.Find(id);
            if (adidas == null)
            {
                return HttpNotFound();
            }
            return View(adidas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "AdidasId,Name,Price,Foto")] Adidas adidas)
        {
            if (ModelState.IsValid)
            {
                if (adidas.Foto == null) adidas.Foto = "https://el-sirius.ru/img/nophoto.png";
                db.Adidases.Add(adidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adidas);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adidas adidas = db.Adidases.Find(id);
            if (adidas == null)
            {
                return HttpNotFound();
            }
            return View(adidas);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "AdidasId,Name,Price,Foto")] Adidas adidas)
        {
            if (ModelState.IsValid)
            {
                if (adidas.Foto == null) adidas.Foto = "https://el-sirius.ru/img/nophoto.png";
                db.Entry(adidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adidas);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adidas adidas = db.Adidases.Find(id);
            if (adidas == null)
            {
                return HttpNotFound();
            }
            return View(adidas);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Adidas adidas = db.Adidases.Find(id);
            db.Adidases.Remove(adidas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Adidas adidas = db.Adidases.Find(id);
            if (adidas == null)
            {
                return HttpNotFound();
            }
            return View(adidas);
        }
        [HttpPost, ActionName("Buy")]
        public ActionResult BuyConfirmed(Adidas adidas)
        {
            Basket basket = new Basket();
            basket.Name = adidas.Name;
            basket.Price = adidas.Price;
            basket.Foto = adidas.Foto;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return View("Index", db.Adidases.ToList());

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}