using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailLocker.Repository;
using TrailLocker.Models;
using System.Web.Security;

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

        //seems weird to put this stuff in a controller, but not sure where else to put it
        private string get_current_username()
        {
            return FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
        }

        protected User get_current_user()
        {

            string username = get_current_username();
            User user = UserDB.FindBy(x => x.username == username).Single();
            return user;
        }

        protected Guid get_current_user_id()
        {
            string username = get_current_username();
            User user =  UserDB.FindBy(x => x.username == username).Single();
            return user.UserID;
        }
        

    }
}
