using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;
using MongoDB.Driver;

namespace Challenge.TOTVS.Infra.Data.Context
{
    public class ATSContext
    {
        public ATSContext(IMongoDatabase database) => Database = database;

        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<JobVacancy> JobVacancy => Database.GetCollection<JobVacancy>("JobVacancy");
        public IMongoCollection<Candidate> Candidate => Database.GetCollection<Candidate>("Candidate");
        public IMongoCollection<User> Users => Database.GetCollection<User>("Users");
        public IMongoCollection<RecoverPassword> RecoverPasswords => Database.GetCollection<RecoverPassword>("RecoverPasswords");

    }
}
