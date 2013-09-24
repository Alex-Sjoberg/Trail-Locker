﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailLocker.Models;
using TrailLocker.Repository;

namespace TrailLocker.Controllers
{ 
    public class TripController : Controller
    {
        private Repository<Trip> TripDB = new Repository<Trip>(new DBUnitOfWork());
        private Repository<User> UserDB = new Repository<User>(new DBUnitOfWork());


        //
        // GET: /Trip/

        public ViewResult Index()
        {
            return View(TripDB.FindAll().ToList());
        }

        //
        // GET: /Trip/Details/5

        public ViewResult Details(Guid id)
        {
            Trip trip = TripDB.FindBy(x => x.TripID == id).Single();

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
                User trip_leader = UserDB.FindBy(x => x.UserID ==userID).Single();
                //huh??? How is the trip getting the user id right now??? probably from form

                trip.TripID = Guid.NewGuid();
                TripDB.Add(trip);

                //trip.trip_leader = trip_leader;
                //trip.UserID = trip_leader.UserID;
                //trip_leader.trips.Add(trip);
                //UserDB.Attach(trip_leader);
                //TripDB.Attach(trip);
                
                TripDB.Commit();
                return RedirectToAction("Index");
            }

            return View(trip);
        }
        
        //
        // GET: /Trip/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            Trip trip = TripDB.FindBy(x => x.TripID == id).Single();
            return View(trip);
        }

        //
        // POST: /Trip/Edit/5

        [HttpPost]
        public ActionResult Edit(Trip trip)
        {
            if (ModelState.IsValid)
            {

                TripDB.Attach(trip);
                TripDB.Commit();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Trip/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            Trip trip = TripDB.FindBy(x => x.TripID == id).Single();
            return View(trip);
        }

        //
        // POST: /Trip/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            

            Trip trip = TripDB.FindBy(x => x.TripID == id).Single();
            TripDB.Remove(trip);
            TripDB.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            TripDB.Dispose();
            base.Dispose(disposing);
        }
    }
}