using System.Collections.Generic;

namespace OrderEventPublisher
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetUpdatedOrders()
        {
            return new List<Order>();
        }
    }








}
