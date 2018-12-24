using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataBase;
using Gateway.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Gateway.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDBContext _database;

        public ActivityRepository(IDBContext database)
        {
            _database = database;
        }

        public async Task<Activity> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userId)
            => await Collection
                .AsQueryable()
                .Where(x => x.UserId == userId)
                .ToListAsync();

        public async Task AddAsync(Activity activity)
        {
          await  Collection.AddAsync(activity);
            await _database.SaveChangesAsync();

        }

        private DbSet<Activity> Collection 
            => _database.Set<Activity>();
    }
}