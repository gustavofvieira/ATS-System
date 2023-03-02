namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
    }
}
