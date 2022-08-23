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
    public class FishingsController : Controller
    {
        private AcountContext db = new AcountContext();

        public ActionResult Index()
        {
            return View(db.Fishings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fishing fishing = db.Fishings.Find(id);
            if (fishing == null)
            {
                return HttpNotFound();
            }
            return View(fishing);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FishingId,Name,Price")] Fishing fishing)
        {
            if (ModelState.IsValid)
            {
                db.Fishings.Add(fishing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fishing);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fishing fishing = db.Fishings.Find(id);
            if (fishing == null)
            {
                return HttpNotFound();
            }
            return View(fishing);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "FishingId,Name,Price")] Fishing fishing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fishing);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fishing fishing = db.Fishings.Find(id);
            if (fishing == null)
            {
                return HttpNotFound();
            }
            return View(fishing);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Fishing b = new Fishing { FishingId = id };
            //db.Entry(b).State = EntityState.Deleted;
            //db.SaveChanges();
            Fishing fishing = db.Fishings.Find(id);
            db.Fishings.Remove(fishing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Fishing fishing = db.Fishings.Find(id);
            if (fishing == null)
            {
                return HttpNotFound();
            }
            return View(fishing);
        }
        [HttpPost, ActionName("Buy")]
        public ActionResult BuyConfirmed(Fishing fishing)
        {
            Basket basket = new Basket();
            basket.Name = fishing.Name;
            basket.Price = fishing.Price;
            basket.Foto = fishing.Foto;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return View("Index", db.Fishings.ToList());

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