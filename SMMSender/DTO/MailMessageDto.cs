namespace SMMSender.DTO
{
    public class MailMessageDto
    {

        public MailMessageDto(
            string fromAddress,
            string password,
            string subject,
            string body,
            IEnumerable<string> addresses)
        {
            FromAddress = fromAddress ?? throw new ArgumentNullException(nameof(fromAddress));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            if (!addresses.Any())
            {
                throw new ArgumentException("At least one address should be defined.");
            }
            Addresses = new List<string>(addresses) ?? throw new ArgumentNullException(nameof(fromAddress));
        }

        public string FromAddress { get; }
        public string Password { get; }
        public string Subject { get; }
        public string Body { get; }
        public IEnumerable<string> Addresses { get; }

    }
}
