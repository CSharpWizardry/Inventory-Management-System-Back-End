using IMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<Category> GetByIdAsync(int id);
    }
}
