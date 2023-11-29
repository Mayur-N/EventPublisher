using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using OrderEventPublisher;
using System.Collections.Generic;

namespace EventPublisherTests
{
    [TestClass]
    public class OrderPollerTests
    {
        private Mock<IOrderRepository> _mockOrderRepository;
        private Mock<IOrderStatusPublisher> _mockOrderStatusPublisher;
        private OrderPoller _orderPoller;

        public  OrderPollerTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderStatusPublisher = new Mock<IOrderStatusPublisher>();
            _orderPoller = new OrderPoller(_mockOrderRepository.Object, _mockOrderStatusPublisher.Object);
        }

        [TestMethod]
        public void PollDatabaseForChanges_WhenCalled_InvokesGetUpdatedOrders()
        {
            _orderPoller.PollDatabaseForChanges();

            _mockOrderRepository.Verify(repo => repo.GetUpdatedOrders(), Times.Once);
        }

        [TestMethod]
        public void PollDatabaseForChanges_WithUpdatedOrders_PublishesEachOrderStatus()
        {
            var orders = new List<Order>
        {
            new Order(), // Assuming Order is a class you have defined
            new Order()
        };

            _mockOrderRepository.Setup(repo => repo.GetUpdatedOrders()).Returns(orders);

            _orderPoller.PollDatabaseForChanges();

            _mockOrderStatusPublisher.Verify(pub => pub.PublishOrderStatus(It.IsAny<Order>()), Times.Exactly(orders.Count));
        }
    }

}
