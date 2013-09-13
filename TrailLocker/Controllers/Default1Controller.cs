using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailLocker.Models;

namespace TrailLocker.Controllers
{ 
    public class Default1Controller : Controller
    {
        private TripDBContext db = new TripDBContext();

        //
        // GET: /Default1/

        public ViewResult Index()
        {
            return View(db.Trips.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ViewResult Details(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            return View(trip);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                trip.ID = Guid.NewGuid();
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(trip);
        }
        
        //
        // GET: /Default1/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            return View(trip);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Default1/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            return View(trip);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            Trip trip = db.Trips.Find(id);
            db.Trips.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}