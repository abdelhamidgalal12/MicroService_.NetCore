using System;
using System.Linq;
using System.Threading.Tasks;
using Services.Identity.Domain;
using Services.Identity.Domain.Models;
using Services.Identity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Common.DataBase;

namespace Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBContext _database;
        public UserRepository(IDBContext database)
        {
            _database = database;
        }

        public async Task<User> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        public async Task AddAsync(User user)
        {
            await Collection.AddAsync(user);
            await _database.SaveChangesAsync();
        }

        private DbSet<User> Collection
            => _database.Set<User>();
    }
}