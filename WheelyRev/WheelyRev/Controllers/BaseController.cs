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
        private WheelyRevEntities _db;  //Connection
        private BaseRepository<Users> _table;   //Users table
        public BaseController()
        {
            _db = new WheelyRevEntities();
            _table = new BaseRepository<Users>();
        }
    }
}