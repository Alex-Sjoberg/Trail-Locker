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
    public class LoginController : SuperController
    {
        //
        // GET: /Login/


        public LoginController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }


        //
        // POST: /Login/
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

                    // extract username from cookie
                    string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

                    return RedirectToAction("index", "home");

                } catch (InvalidOperationException e){
                    ModelState.AddModelError("", "Invalid username or password");
                
                }
            }

            return View();
        }

        //
        // GET: Login/CreateAccount/
        public ActionResult CreateAccount()
        {
            return View();
        }

        //
        // POST: Login/CreateAccount/
        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserID = Guid.NewGuid();
                UserDB.Add(user);
                UserDB.Commit();

                FormsAuthentication.SetAuthCookie(user.username, true);
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}