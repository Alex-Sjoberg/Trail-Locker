using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrailLocker.Repository;
using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

         DBUnitOfWork unitOfWork = new DBUnitOfWork();

         private Repository<Trip> TripDB;
         private Repository<User> UserDB;

        public LoginController()
        {
            UserDB = new Repository<User>(unitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    // Query the DB for a user with the right username and password. The '.single()' is necessary to get out a single user object, since 'FindBy()' returns
                    // a collection. If it didn't find anything, it will throw an InvalidOperationException.
                    User user = UserDB.FindBy(x => x.username == model.username && x.password == model.password).Single(); 
                    FormsAuthentication.SetAuthCookie(model.username, true);
                    return RedirectToAction("index", "home");

                } catch (InvalidOperationException e){
                    ModelState.AddModelError("", "Invalid username or password");
                
                }
            }

            return View();
        }
    }
}

/*
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //if (model.Username == "jed" && model.Password == "albao") // Simulate data store call where Username/Password
                if (DataAccess.DAL.UserIsValid(model.username, model.password))
                {
                    FormsAuthentication.SetAuthCookie(model.username, true);
                    return RedirectToAction("index", "home");
                }
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View();
        }
*/