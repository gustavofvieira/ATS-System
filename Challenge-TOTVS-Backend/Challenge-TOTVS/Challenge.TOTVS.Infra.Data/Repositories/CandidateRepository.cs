using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class CandidateRepository : ICandidateRepository
    {

        private readonly ATSContext _context;
        public CandidateRepository(
            ATSContext context) =>
            _context = context;
        
        public async Task Add(Candidate candidate) => await _context.Candidate.InsertOneAsync(candidate);

        public async Task<List<Candidate>> GetAll() => await _context.Candidate.AsQueryable().ToListAsync();

        public async Task<Candidate> GetById(Guid id) => await _context.Candidate.AsQueryable().Where(c => c.CandidateId == id).FirstOrDefaultAsync();

        public async Task Remove(Guid id) => await _context.Candidate.DeleteOneAsync(c => c.CandidateId.Equals(id));

        public async Task Update(Candidate candidate) =>
        await _context.Candidate.FindOneAndUpdateAsync(
                c => c.CandidateId.Equals(candidate.CandidateId),
                Builders<Candidate>.Update.Combine(
                    Builders<Candidate>.Update.Set(c => c.Login, candidate.Login),
                    Builders<Candidate>.Update.Set(c => c.Password, candidate.Password),
                    Builders<Candidate>.Update.Set(c => c.Name, candidate.Name),
                    Builders<Candidate>.Update.Set(c => c.FilePath, candidate.FilePath),
                    Builders<Candidate>.Update.Set(c => c.Birthday, candidate.Birthday),
                    Builders<Candidate>.Update.Set(c => c.UpdatedAt, DateTime.UtcNow)
                )
            );

        public async Task UploadCVFile(Candidate candidate) =>
        await _context.Candidate.FindOneAndUpdateAsync(
                c => c.CandidateId.Equals(candidate.CandidateId),
                Builders<Candidate>.Update.Combine(
                    Builders<Candidate>.Update.Set(c => c.FilePath, candidate.FilePath)
                )
            );
    }
}
