using Challenge.TOTVS.Domain.Models;

namespace Challenge.TOTVS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        TEntity GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
    }
}
