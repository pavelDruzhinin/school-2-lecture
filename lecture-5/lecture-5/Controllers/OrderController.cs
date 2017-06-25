using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using lecture_5.DataAccess;

namespace lecture_5.Controllers
{
    public class OrderController : Controller
    {
        private ShopContext _db;

        public OrderController()
        {
            _db = new ShopContext();
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_db.Orders.Include(x => x.OrderPositions).Include(x => x.OrderPositions.Select(y => y.Product)).FirstOrDefault());
        }

        [HttpGet]
        public void DeleteOrderPosition(int orderPositionId)
        {
            var orderPosition = _db.OrderPositions.Find(orderPositionId);

            if (orderPosition != null)
            {
                _db.OrderPositions.Remove(orderPosition);
                _db.SaveChanges();
            }
        }
    }
}