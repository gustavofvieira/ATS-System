using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;

namespace Challenge.TOTVS.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public Task Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
