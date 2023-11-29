namespace OrderEventPublisher
{
    public class OrderPoller : IOrderPoller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusPublisher _orderStatusPublisher;

        public OrderPoller(IOrderRepository orderRepository, IOrderStatusPublisher orderStatusPublisher)
        {
            _orderRepository = orderRepository;
            _orderStatusPublisher = orderStatusPublisher;
        }

        public void PollDatabaseForChanges()
        {
            var updatedOrders = _orderRepository.GetUpdatedOrders();
            foreach (var order in updatedOrders)
            {
                _orderStatusPublisher.PublishOrderStatus(order);
            }
        }
    }








}
