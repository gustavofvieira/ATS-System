using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;

namespace Challenge.TOTVS.Domain.Interfaces.Repositories.Auth
{
    public interface IRecoverPasswordRepository
    {
        Task Add(RecoverPassword recoverPassword);
        Task<RecoverPassword> GetById(Guid id);
    }
}
