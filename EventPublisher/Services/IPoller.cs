namespace EventPublisher.Services
{
    public interface IPoller<T>
    {
        void PollDatabaseForChanges();
    }

}
