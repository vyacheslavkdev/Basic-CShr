namespace Ex3.Service
{
    public interface IEventHandler
    {
        void Handle(string eventName);
    }

    delegate void HandleFunction();
}