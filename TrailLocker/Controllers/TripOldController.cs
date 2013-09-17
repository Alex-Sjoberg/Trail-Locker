using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    public class TripOldController : Controller
    {
        //
        // GET: /Trip/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewTrip(string destination , int times = 5)
        {
            ViewBag.destination = destination;
            ViewBag.times = times;

            return View();
        }

        public ActionResult ViewTrip()
        {
            Trip my_trip = new Trip();

            return View(my_trip);
        }
/*
        //
        // GET: /Trip/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Trip/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Trip/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Trip/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Trip/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Trip/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Trip/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
