namespace Codestellation.Ether.Misc
{
    public interface IQueue
    {
        void Enqueue(object item);
        bool TryDequeue(out object item);
        bool IsEmpty { get; }
    }
}