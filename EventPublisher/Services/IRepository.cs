using System.Collections.Generic;

namespace EventPublisher.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetUpdatedItems(List<string> itemIdentifierList);
    }

}
