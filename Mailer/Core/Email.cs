namespace Codestellation.Mailer.Core
{
    public class Email
    {
        public string From { get; private set; }
        public string[] Recepients { get; private set; }

        public Email(string fromAddress, string[] recepients)
        {
            From = fromAddress;
            Recepients = recepients;
        }
    }
}