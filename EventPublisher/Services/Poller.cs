using System.Collections.Generic;

namespace EventPublisher.Services
{
    public class Poller<T> : IPoller<T>
    {
        private readonly IRepository<T> _repository;
        private readonly IPublisher<T> _publisher;

        public Poller(IRepository<T> repository, IPublisher<T> publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public void PollDatabaseForChanges()
        {
            var updatedItems = _repository.GetUpdatedItems(new List<string>());
            foreach (var item in updatedItems)
            {
                _publisher.Publish(item);
            }
        }
    }

}
