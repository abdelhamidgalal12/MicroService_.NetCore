using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task<IEnumerable<Activity>> BrowseAsync(Guid userId);
        Task AddAsync(Activity activity);
    }
}