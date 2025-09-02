
using Microsoft.EntityFrameworkCore;

namespace TestWebAPITraining.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDBContext _dbContext;
        public CategoryRepository(ShopDBContext context)
        {
            _dbContext=context;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            
            return await _dbContext.Categories
                
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }
    }
}
