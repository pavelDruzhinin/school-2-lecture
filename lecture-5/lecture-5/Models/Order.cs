using System.Collections.Generic;

namespace lecture_5.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public List<OrderPosition> OrderPositions { get; set; }
    }
}