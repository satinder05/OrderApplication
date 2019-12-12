namespace Domain.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public short Status { get; set; }
        public long CustomerOrderId { get; set; }
        public long ItemId { get; set; }
        public decimal Price { get; set; }
        public Item Item { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
    }
}
