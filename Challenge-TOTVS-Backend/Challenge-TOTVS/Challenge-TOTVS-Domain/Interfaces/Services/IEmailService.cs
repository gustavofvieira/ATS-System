using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        void SendRecovery(User user, Guid recoverId);
        void SendConfirmation(User user);
    }
}
