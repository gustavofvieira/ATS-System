using Challenge.TOTVS.Domain.Interfaces.Repositories;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public Task Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
