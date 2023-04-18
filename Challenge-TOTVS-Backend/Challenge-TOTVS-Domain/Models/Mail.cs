namespace Challenge.TOTVS.Domain.Models
{
    public class Mail
    {

        public string Subject { get; set; } = string.Empty;
        public string NameSend { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string EmailAddressFrom { get; set; } = string.Empty;
        public string EmailAddressTo { get; set; } = string.Empty;
        public string HtmlBody { get; set; } = string.Empty;
    }
}
