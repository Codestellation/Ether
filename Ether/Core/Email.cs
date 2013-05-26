namespace Codestellation.Ether.Core
{
    public class Email
    {
        public string From { get; set; }
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email()
        {
        }

        public Email(string fromAddress, string[] recipients, MailView view)
        {
            From = fromAddress;
            Recipients = recipients;
            Subject = view.Subject;
            Body = view.Body;
        }

        public override string ToString()
        {
            return Subject;
        }
    }
}