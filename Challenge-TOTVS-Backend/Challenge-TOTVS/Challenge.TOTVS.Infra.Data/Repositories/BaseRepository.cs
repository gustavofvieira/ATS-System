using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> //: IBaseService<TEntity> where TEntity : class
    {
        //protected ATSContext _context;
        //private readonly IMongoCollection<TEntity> _collection;
        // Flag: Has Dispose already been called?
        //bool disposed = false;

        //public BaseRepository(ATSContext context)
        //{
        //    _context = context;
        //    //var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        //    //_collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        //}


        //public Task Add(TEntity obj)
        //{
        //    throw new NotImplementedException();
        //}
        ////public async Task Add(TEntity obj)
        ////{
        ////    await _context.Candidate.InsertOne(obj);
        ////}

        //public TEntity GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(TEntity obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Remove(TEntity obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
