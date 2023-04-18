namespace Challenge.TOTVS.Domain.Models.Auth
{
    public class AuthSmtp
    {
        public string SmtpHost { get; set; } = string.Empty;
        public int SmtpPort { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
