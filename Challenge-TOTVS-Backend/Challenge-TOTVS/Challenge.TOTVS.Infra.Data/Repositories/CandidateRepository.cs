﻿using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
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
            await _context
            .Candidate
            .UpdateOneAsync(c => c.CandidateId == candidate.CandidateId, 
                Builders<Candidate>.Update.Set(c => c, candidate));

        public void UploadCVFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}