using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public short Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<CustomerOrder> Orders { get; private set; }
    }
}
