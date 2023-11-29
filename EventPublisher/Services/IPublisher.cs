namespace EventPublisher.Services
{
    public interface IPublisher<T>
    {
        void Publish(T item);
    }

}
