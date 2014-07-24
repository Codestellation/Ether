namespace Codestellation.Ether.Bootstrap
{
    public static class Create
    {
        public static MailNotifierBuilder MailNotifier()
        {
            return new MailNotifierBuilder();
        }
    }
}