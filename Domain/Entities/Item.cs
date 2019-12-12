using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Item
    {
        public long Id { get; set; }
        public short Status { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
