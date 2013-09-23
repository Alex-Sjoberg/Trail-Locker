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
    public class TripController : Controller
    {
        private TrailLockerEntities db = new TrailLockerEntities();

        //
        // GET: /Trip/

        public ViewResult Index()
        {
            return View(db.Trips.ToList());
        }

        //
        // GET: /Trip/Details/5

        public ViewResult Details(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            return View(trip);
        }

        //
        // GET: /Trip/Create

        public ActionResult Create(Guid userID)
        {
            ViewBag.userID = userID;
            return View();
        } 

        //
        // POST: /Trip/Create

        [HttpPost]
        public ActionResult Create(Trip trip , Guid userID)
        {
            if (ModelState.IsValid)
            {
                User trip_leader = db.Users.Find(userID);
                trip.TripID = Guid.NewGuid();
                trip_leader.trips.Add(trip);
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(trip);
        }
        
        //
        // GET: /Trip/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            return View(trip);
        }

        //
        // POST: /Trip/Edit/5

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
        // GET: /Trip/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            return View(trip);
        }

        //
        // POST: /Trip/Delete/5

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