using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelyRev.Models;
using WheelyRev.Repository;

namespace WheelyRev.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public WheelyRevEntities _db;  //Connection
        public BaseRepository<Users> _table;   //Users table
        public BaseRepository<UserRoles> _tableUR; //User Role table
        public BaseRepository<Shops> _tableShop; //Shop table
        public BaseRepository<Products> _tableProduct;
        public BaseController()
        {
            _db = new WheelyRevEntities();
            _table = new BaseRepository<Users>();
            _tableUR = new BaseRepository<UserRoles>();
            _tableShop = new BaseRepository<Shops>();
            _tableProduct = new BaseRepository<Products>();
        }
    }
}