using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelyRev.Models;

namespace WheelyRev.Controllers
{
    public class AddShopController : BaseController
    {
        // GET: AddShop
        [AllowAnonymous]
        public ActionResult AddShop()
        {
            return View();
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult AddShop(Shops s)
        {
            int userId = (int)Session["UserId"]; //Retrieve the session nga gikan sa Login Action
            s.userId = userId;

            setShopOwner();
            _tableShop.Create(s);

            TempData["msg"] = $"Register successfully!";
            return View();
        }
        private void setShopOwner()
        {
            int userRoleId = (int)Session["UserRole_ID"];
            _db.sp_setShopOwner(userRoleId); //Stored procedure is the key, the best gyud !
        }
    }
}