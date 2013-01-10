namespace Codestellation.Mailer.Core
{
    public class Email
    {
        public string From { get; private set; }
        public string[] Recepients { get; private set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email(string fromAddress, string[] recepients, MailView view)
        {
            From = fromAddress;
            Recepients = recepients;
            Subject = view.Subject;
            Body = view.Body;
        }
    }
}