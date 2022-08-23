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
    public class NikesController : Controller
    {
        private AcountContext db = new AcountContext();

        public ActionResult Index()
        {
            return View(db.Nikes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nike nike = db.Nikes.Find(id);
            if (nike == null)
            {
                return HttpNotFound();
            }
            return View(nike);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "NikeId,Name,Price")] Nike nike)
        {
            if (ModelState.IsValid)
            {
                db.Nikes.Add(nike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nike);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nike nike = db.Nikes.Find(id);
            if (nike == null)
            {
                return HttpNotFound();
            }
            return View(nike);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "NikeId,Name,Price")] Nike nike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nike);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nike nike = db.Nikes.Find(id);
            if (nike == null)
            {
                return HttpNotFound();
            }
            return View(nike);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Nike nike = db.Nikes.Find(id);
            db.Nikes.Remove(nike);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Nike nike = db.Nikes.Find(id);
            if (nike == null)
            {
                return HttpNotFound();
            }
            return View(nike);
        }
        [HttpPost, ActionName("Buy")]
        public ActionResult BuyConfirmed(Nike nike)
        {
            Basket basket = new Basket();
            basket.Name = nike.Name;
            basket.Price = nike.Price;
            basket.Foto = nike.Foto;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return View("Index", db.Nikes.ToList());

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