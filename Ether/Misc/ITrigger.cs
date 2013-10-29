namespace Codestellation.Ether.Misc
{
    public interface ITrigger
    {
        void Attach(ITriggerHander hander);

        void Start();
        void Stop();
    }
}