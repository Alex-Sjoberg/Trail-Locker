using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailLocker.Repository;
using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    public class SuperController : Controller
    {
         DBUnitOfWork unitOfWork = new DBUnitOfWork();

         protected Repository<Trip> TripDB;
         protected Repository<User> UserDB;
         protected Repository<Locker> LockerDB;
         protected Repository<Item> ItemDB;

        public SuperController()
        {
            TripDB  = new Repository<Trip>(unitOfWork);
            UserDB = new Repository<User>(unitOfWork);
            ItemDB  = new Repository<Item>(unitOfWork);
            LockerDB = new Repository<Locker>(unitOfWork);
        }

    }
}
