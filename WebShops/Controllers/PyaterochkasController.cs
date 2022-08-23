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
    public class PyaterochkasController : Controller
    {
        private AcountContext db = new AcountContext();

        public ActionResult Index()
        {
            return View(db.Pyaterochkas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pyaterochka pyaterochka = db.Pyaterochkas.Find(id);
            if (pyaterochka == null)
            {
                return HttpNotFound();
            }
            return View(pyaterochka);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "PyaterochkaId,Name,Price")] Pyaterochka pyaterochka)
        {
            if (ModelState.IsValid)
            {
                db.Pyaterochkas.Add(pyaterochka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pyaterochka);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pyaterochka pyaterochka = db.Pyaterochkas.Find(id);
            if (pyaterochka == null)
            {
                return HttpNotFound();
            }
            return View(pyaterochka);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "PyaterochkaId,Name,Price")] Pyaterochka pyaterochka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pyaterochka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pyaterochka);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pyaterochka pyaterochka = db.Pyaterochkas.Find(id);
            if (pyaterochka == null)
            {
                return HttpNotFound();
            }
            return View(pyaterochka);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pyaterochka pyaterochka = db.Pyaterochkas.Find(id);
            db.Pyaterochkas.Remove(pyaterochka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Pyaterochka pyaterochka = db.Pyaterochkas.Find(id);
            if (pyaterochka == null)
            {
                return HttpNotFound();
            }
            return View(pyaterochka);
        }
        [HttpPost, ActionName("Buy")]
        public ActionResult BuyConfirmed(Pyaterochka pyaterochka)
        {
            Basket basket = new Basket();
            basket.Name = pyaterochka.Name;
            basket.Price = pyaterochka.Price;
            basket.Foto = pyaterochka.Foto;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return View("Index", db.Pyaterochkas.ToList());

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