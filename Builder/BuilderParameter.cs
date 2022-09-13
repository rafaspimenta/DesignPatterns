using System;

namespace Builder
{
    public class Email
    {
        public string From, To, Subject, Body;
    }

    public class EMailService
    {
        public class EmailBuilder
        {
            private readonly Email email;
            public EmailBuilder(Email email) => this.email = email;

            public EmailBuilder From(string from)
            {
                this.email.From = from;
                return this;
            }

            public EmailBuilder To(string to)
            {
                this.email.To = to;
                return this;
            }

            public EmailBuilder Subject(string subject)
            {
                this.email.Subject = subject;
                return this;
            }

            public EmailBuilder Body(string body)
            {
                this.email.Body = body;
                return this;
            }
        }

        private void SendEmailInternal(Email email) { }

        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            var b = new EmailBuilder(email);
            builder(b);
            b.Subject("outro");
            SendEmailInternal(email);
        }
    }
}
