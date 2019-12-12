using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public long Id { get; set; }
        public short Status { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; private set; }
        
    }
}
