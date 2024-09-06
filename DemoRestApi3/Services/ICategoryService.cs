using DemoRestApi3.Models;
using Microsoft.Extensions.Options;

namespace DemoRestApi3.Services
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task<Category> GetById(string id);
        Task DeleteAsync(string id);
        Task Update(string id, Category category);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
