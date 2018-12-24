using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Activities.Domain.Models;

namespace Services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
         Task<Category> GetAsync(string name);
         Task<IEnumerable<Category>> BrowseAsync();
         Task AddAsync(Category category);
    }
}