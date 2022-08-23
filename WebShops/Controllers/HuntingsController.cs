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
    public class HuntingsController : Controller
    {
        private AcountContext db = new AcountContext();

        public ActionResult Index()
        {
            return View(db.Huntings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "HuntingId,Name,Price")] Hunting hunting)
        {
            if (ModelState.IsValid)
            {
                db.Huntings.Add(hunting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hunting);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "HuntingId,Name,Price")] Hunting hunting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hunting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hunting);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Hunting hunting = db.Huntings.Find(id);
            db.Huntings.Remove(hunting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Hunting hunting = db.Huntings.Find(id);
            if (hunting == null)
            {
                return HttpNotFound();
            }
            return View(hunting);
        }
        [HttpPost, ActionName("Buy")]
        public ActionResult BuyConfirmed(Hunting hunting)
        {
            Basket basket = new Basket();
            basket.Name = hunting.Name;
            basket.Price = hunting.Price;
            basket.Foto = hunting.Foto;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return View("Index", db.Huntings.ToList());

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