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

        [HttpGet]
        [Route("Customer/{customerId:int}/Order/{orderId:int}")]
        public ActionResult Index(int customerId, int orderId)
        {
            var order = _db.Orders
                .Include(x => x.OrderPositions)
                .Include(x => x.OrderPositions.Select(y => y.Product))
                .FirstOrDefault(x => x.CustomerId == customerId && x.Id == orderId);

            return View(order);
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

        [HttpPost]
        public void ChangeOrderPositionCount(ChangeOrderPositionCountParams @params)
        {
            var orderPosition = _db.OrderPositions.Find(@params.OrderPositionId);

            if (orderPosition == null) return;

            orderPosition.Count += @params.Step;
            _db.SaveChanges();
        }
    }

    public class ChangeOrderPositionCountParams
    {
        public int OrderPositionId { get; set; }
        public int Step { get; set; }
    }
}