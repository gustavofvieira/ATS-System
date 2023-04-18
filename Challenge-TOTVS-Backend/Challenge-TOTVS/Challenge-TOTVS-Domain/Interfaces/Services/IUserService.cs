using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;
using Challenge.TOTVS.Domain.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<Token> AuthenticateAsync(LoginVM loginVM);
        Task RecoverEmail(string email);
        Task UpdatePassword(Guid id, string password);
    }
}
