using System.Collections.Generic;

namespace EventPublisher.Services
{
    public class Repository<T> : IRepository<T>
    {
        public IEnumerable<T> GetUpdatedItems(List<string> itemIdentifierList)
        {
            throw new System.NotImplementedException();
        }
    }

}
