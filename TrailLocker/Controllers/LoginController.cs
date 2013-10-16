using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrailLocker.Repository;
using TrailLocker.Models;
using Facebook;

namespace TrailLocker.Controllers
{
    public class LoginController : SuperController
    {

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        //
        // GET: /Login/


        public LoginController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

    public ActionResult Facebook()
    {
        var fb = new FacebookClient();
        var loginUrl = fb.GetLoginUrl(new {
            client_id = "1424766361075600",
            client_secret = "d23d50adbcd2ffc1077714cd63b7976d",
            redirect_uri = RedirectUri.AbsoluteUri,
            response_type = "code",
            scope = "email" // Add other permissions as needed
        });

        return Redirect(loginUrl.AbsoluteUri);
    }

    public ActionResult FacebookCallback(string code)
    {
        var fb = new FacebookClient();
        dynamic result = fb.Post("oauth/access_token", new
        {
            client_id = "1424766361075600",
            client_secret = "d23d50adbcd2ffc1077714cd63b7976d",
            redirect_uri = RedirectUri.AbsoluteUri,
            code = code
        });

        var accessToken = result.access_token;

        // TODO: Authenticate User

        // Store the access token in the session
        Session["AccessToken"] = accessToken;

        // update the facebook client with the access token so 
        // we can make requests on behalf of the user
        fb.AccessToken = accessToken;

        // Get the user's information
        dynamic me = fb.Get("me?fields=first_name,last_name,id,email");
        string email = me.email;

        // Set the auth cookie
        FormsAuthentication.SetAuthCookie("admin", false);

        return RedirectToAction("Index", "Home");
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