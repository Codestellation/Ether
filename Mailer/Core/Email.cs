namespace Codestellation.Mailer.Core
{
    public class Email
    {
        public string From { get; private set; }

        public Email(string fromAddress)
        {
            From = fromAddress;
        }
    }
}