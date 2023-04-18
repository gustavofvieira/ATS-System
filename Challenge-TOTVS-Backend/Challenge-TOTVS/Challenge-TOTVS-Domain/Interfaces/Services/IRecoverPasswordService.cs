using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IRecoverPasswordService
    {
        Task<RecoverPassword> ValidExpirateDate(Guid id);
        Task<Guid> CreateRecoverPassword(User user);
    }
}
