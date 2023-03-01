namespace Challenge.TOTVS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
    }
}
