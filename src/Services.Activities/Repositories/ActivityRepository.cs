using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Activities.Domain.Models;
using Services.Activities.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Common.DataBase;

namespace Services.Activities.Repositories
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

        public async Task AddAsync(Activity activity)
        {
            await Collection.AddAsync(activity);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = Collection.Find(id);

             Collection.Remove(entity);
            await _database.SaveChangesAsync();

        }

        private DbSet<Activity> Collection 
            => _database.Set<Activity>();
    }
}