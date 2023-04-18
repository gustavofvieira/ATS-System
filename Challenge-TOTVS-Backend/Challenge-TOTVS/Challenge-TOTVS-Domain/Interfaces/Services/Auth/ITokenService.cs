using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;

namespace Challenge.TOTVS.Domain.Interfaces.Services.Auth
{
    public interface ITokenService
    {
        Token GenerateToken(User user);
    }
}
