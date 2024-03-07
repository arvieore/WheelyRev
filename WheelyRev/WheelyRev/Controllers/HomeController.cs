using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WheelyRev.Models;

namespace WheelyRev.Controllers
{
    [Authorize(Roles = "Admin,Customer,Store owner")]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(_table.GetAll());
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Users u)
        {
            var user = _db.Users.Where(m => m.username == u.username && m.password == u.password).FirstOrDefault();
            if(user != null)//Check if the user is nag exist or same og value
            {
                //if true
                FormsAuthentication.SetAuthCookie(u.username, false); //Set Cookie
                return RedirectToAction("Index");
            }
            //else if ang user wala nag exist or dli same og value
            ModelState.AddModelError("", "User is not exist or incorrect Password.");
            return View(u);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); //Para mawagtang ang authentication nga gikan ni login.
            return RedirectToAction("Login");
        }
    }
}