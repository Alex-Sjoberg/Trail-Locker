using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TrailLocker.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        

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
    }
}
