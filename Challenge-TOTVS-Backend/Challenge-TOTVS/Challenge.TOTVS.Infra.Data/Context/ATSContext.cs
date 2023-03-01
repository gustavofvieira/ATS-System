using Challenge.TOTVS.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.TOTVS.Infra.Data.Context
{
    public class ATSContext
    {
        public ATSContext(IMongoDatabase database) => Database = database;

        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<JobVacancy> JobVacancy => Database.GetCollection<JobVacancy>("JobVacancy");
        public IMongoCollection<Candidate> Candidate => Database.GetCollection<Candidate>("Candidate");
        public IMongoCollection<JobApplication> JobApplication => Database.GetCollection<JobApplication>("JobApplication");
    }
}
