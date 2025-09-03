
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

        public async Task<int> AddCategoryAsync(Category category)
        {
            bool categoryWithSameNameExist = await _dbContext.Categories.AnyAsync(c => c.CategoryName == category.CategoryName);

            if (categoryWithSameNameExist)
            {
                throw new Exception("A category with the same name already exists");
            }

            _dbContext.Categories.Add(category);//could be done using async too

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            bool categoryWithSameNameExist = await _dbContext.Categories.AnyAsync(c => c.CategoryName == category.CategoryName && c.CategoryId != category.CategoryId);

            if (categoryWithSameNameExist)
            {
                throw new Exception("A category with the same name already exists");
            }

            var categoryToUpdate = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);

            if (categoryToUpdate != null)
            {

                categoryToUpdate.CategoryName = category.CategoryName;
                categoryToUpdate.Description = category.Description;

                _dbContext.Categories.Update(categoryToUpdate);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The category to update can't be found.");
            }
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            //throw new Exception("Database down");

            var piesInCategory = _dbContext.pies.Any(p => p.CategoryId == id);

            if (piesInCategory)
            {
                throw new Exception("Pies exist in this category. Delete all pies in this category before deleting the category.");
            }

            var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

            if (categoryToDelete != null)
            {
                _dbContext.Categories.Remove(categoryToDelete);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The category to delete can't be found.");
            }
        }
    }
}
