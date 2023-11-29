using System.Collections.Generic;

namespace OrderEventPublisher
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUpdatedOrders();
    }








}
