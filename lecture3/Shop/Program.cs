using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DataAccess;
using Shop.Models;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ShopContext();

            //for (int i = 0; i < 100; i++)
            //{
            //    var customer = new Customer
            //    {
            //        FirstName = "TestName" + i,
            //        LastName = "TestLastName" + i
            //    };

            //    var product = new Product
            //    {
            //        Count = 10
            //    };

            //    var orderPosition = new OrderPosition
            //    {
            //        Product = product,
            //        Count = i + 1
            //    };

            //    var order = new Order
            //    {
            //        Customer = customer,
            //        OrderPositions = new List<OrderPosition> { orderPosition }
            //    };

            //    db.Customers.Add(customer);
            //    db.Orders.Add(order);
            //    db.OrderPositions.Add(orderPosition);
            //    db.Products.Add(product);
            //}

            //db.SaveChanges();

            var people = db.Customers.Include(o => o.Orders).FirstOrDefault(x => x.FirstName == "TestName6");
            var order = people?.Orders;
            var customers = db.Customers.Include(o => o.Orders)
                .Include(z => z.Orders.Select(u => u.OrderPositions))
                .Where(x => x.Orders.Any(y => y.OrderPositions.Any(o => o.Count > 15)))
                .ToList();

            var cust = (from c in db.Customers
                where c.Orders.Any(y => y.OrderPositions.Any(o => o.Count > 15))
                select c).ToList();


            Console.WriteLine("Name " + people?.FirstName);
            Console.WriteLine("Order count" + order?.Count);
        }
    }
}
