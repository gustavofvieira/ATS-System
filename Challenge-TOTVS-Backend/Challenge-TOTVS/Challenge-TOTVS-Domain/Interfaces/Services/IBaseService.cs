namespace Challenge.TOTVS.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
    }
}
