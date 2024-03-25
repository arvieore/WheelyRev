using System;
using System.Collections.Generic;
using System.IO;
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
            return View(_tableProduct.GetAll());
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
                Session["UserId"] = user.userId; //Store the userId to Session para magamit nato sa lain lain nga Action
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
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(Users u)
        {
            _table.Create(u);
            setDefaultRole(u.userId);
            TempData["msg"] = $"Register successfully!";
            return View();
        }
        private void setDefaultRole(int id)
        {
            UserRoles Default_Role = new UserRoles
            {
                roleId = 3, //Default role 3 = Customer
                userId = id
            };
            _tableUR.Create(Default_Role);
            Session["UserRole_ID"] = Default_Role.UserRoles_ID;
        }
        public ActionResult ViewProducts()
        {
            return View(_db.Products.ToList());
        }
    }
}