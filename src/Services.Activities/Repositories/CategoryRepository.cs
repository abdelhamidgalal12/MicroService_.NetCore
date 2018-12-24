using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Activities.Domain.Models;
using Services.Activities.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _database;

        public CategoryRepository(DbContext database)
        {
            _database = database;
        }

        public async Task<Category> GetAsync(string name)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task AddAsync(Category category)
        {
            await Collection.AddAsync(category);
            await _database.SaveChangesAsync();
        }

        private DbSet<Category> Collection 
            => _database.Set<Category>();        
    }
}