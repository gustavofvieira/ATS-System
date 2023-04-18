﻿using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.ViewModel;
using Challenge.TOTVS.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.TOTVS.Infra.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {

        private readonly ATSContext _context;
        public UserRepository(
            ATSContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email) => await _context.Users.AsQueryable().FirstOrDefaultAsync(u => u.EmailAddress.ToLower().Equals(email.ToLower()));
        public async Task AddUser(User user) => await _context.Users.InsertOneAsync(user);

        public async Task<User> AuthenticateAsync(LoginVM loginVM)
        {
            var userDb = await _context.Users.AsQueryable().FirstOrDefaultAsync(u => u.EmailAddress.ToLower().Equals(loginVM.EmailAddress.ToLower()) && u.Password.Equals(loginVM.Password));
            return userDb;
        }

        public async Task Add(User user) => await _context.Users.InsertOneAsync(user);

        public async Task<User> GetById(Guid id) => await _context.Users.AsQueryable().Where(u => u.UserId == id).FirstOrDefaultAsync();

        public async Task Remove(Guid id) => await _context.Users.DeleteOneAsync(u => u.UserId.Equals(id));

        public async Task Update(User user) =>
        await _context.Users.FindOneAndUpdateAsync(
                u => u.UserId.Equals(user.UserId),
                Builders<User>.Update.Combine(
                    Builders<User>.Update.Set(c => c.Name, user.Name),
                    Builders<User>.Update.Set(c => c.Password, user.Password),
                    Builders<User>.Update.Set(c => c.UpdatedAt, DateTime.UtcNow)
                ));
        public async Task UpdatePassword(User user) =>
        await _context.Users.FindOneAndUpdateAsync(
                u => u.UserId.Equals(user.UserId),
                Builders<User>.Update.Combine(
                    Builders<User>.Update.Set(c => c.Password, user.Password),
                    Builders<User>.Update.Set(c => c.UpdatedAt, DateTime.UtcNow)
                ));

        public async Task<List<User>> GetAll() => await _context.Users.AsQueryable().ToListAsync();
    }
}
