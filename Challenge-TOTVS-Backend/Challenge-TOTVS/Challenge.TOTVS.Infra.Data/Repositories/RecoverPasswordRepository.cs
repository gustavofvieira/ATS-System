using Challenge.TOTVS.Domain.Interfaces.Repositories.Auth;
using Challenge.TOTVS.Domain.Models.Auth;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    public class RecoverPasswordRepository : IRecoverPasswordRepository
    {

        private readonly ATSContext _context;
        public RecoverPasswordRepository(
            ATSContext context)
        {
            _context = context;
        }

        public async Task Add(RecoverPassword recoverPassword) => await _context.RecoverPasswords.InsertOneAsync(recoverPassword);

        public async Task<RecoverPassword> GetById(Guid id) => await _context.RecoverPasswords.AsQueryable().Where(r => r.RecoverPasswordId.Equals(id)).FirstOrDefaultAsync();
    }
}
