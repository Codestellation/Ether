namespace Codestellation.Mailer.Core
{
    public class MailView
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailView(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}