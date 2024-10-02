using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class Order : BaseEntity
    {
        public string DeliveryAddress { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }

        public HashSet<OrderPizza> OrderPizzas { get; set; }
        public OrderStatus Status { get; set; }
    }
}
