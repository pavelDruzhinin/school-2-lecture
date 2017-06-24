using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lecture_5.DataAccess;

namespace lecture_5.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var db = new ShopContext();

            return View(db.Orders.Include(x => x.OrderPositions).Include(x => x.OrderPositions.Select(y => y.Product)).FirstOrDefault());
        }
    }
}