﻿using System.Collections.Generic;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public List<OrderPosition> OrderPositions { get; set; }
    }
}