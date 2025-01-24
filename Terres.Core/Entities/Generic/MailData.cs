namespace Terres.Core.Entities.Generic
{
    public class MailData
    {
        // Receiver
        public string To { get; set; }
        public string Bcc { get; set; }

        public string Cc { get; set; }

        // Sender
        public string? From { get; set; }

        public string? DisplayName { get; set; }

        public string? ReplyTo { get; set; }

        public string? ReplyToName { get; set; }

        // Content
        public string Subject { get; set; }

        public string? Body { get; set; }

    }
}
