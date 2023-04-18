using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.ViewModel;

namespace Challenge.TOTVS.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> AuthenticateAsync(LoginVM loginVM);
        Task<User> GetUserByEmail(string email);
        Task UpdatePassword(User user);
    }
}
