
using Microsoft.EntityFrameworkCore;

namespace TestWebAPITraining.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ShopDBContext _dbContext;
        public PieRepository(ShopDBContext context)
        {
            _dbContext = context;
        }
        
        public async Task<IEnumerable<Pie>> AllPiesAsync(int pageNumber,int pageSize)
        {
            return await _dbContext.pies
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Pie>> PiesOfTheWeekAsync()
        {
            return await _dbContext.pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek)
                .ToListAsync();
        }
        public async Task<Pie?> GetPieByIdAsync(int pieId)
        {
            return await _dbContext.pies.FirstOrDefaultAsync(c=>c.PieId == pieId); 
        }

        public async Task<int> AddPieAsync(Pie pie)
        {
            //throw new Exception("Database down");
            _dbContext.pies.Add(pie);//could be done using async too
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdatePieAsync(Pie pie)
        {

            var pieToUpdate = await _dbContext.pies.FirstOrDefaultAsync(c => c.PieId == pie.PieId);
            if (pieToUpdate != null)
            {
                pieToUpdate.CategoryId = pie.CategoryId;
                pieToUpdate.ShortDescription = pie.ShortDescription;
                pieToUpdate.LongDescription = pie.LongDescription;
                pieToUpdate.Price = pie.Price;
                pieToUpdate.AllergyInformation = pie.AllergyInformation;
                pieToUpdate.ImageThumbnailUrl = pie.ImageThumbnailUrl;
                pieToUpdate.ImageUrl = pie.ImageUrl;
                pieToUpdate.InStock = pie.InStock;
                pieToUpdate.IsPieOfTheWeek = pie.IsPieOfTheWeek;
                pieToUpdate.Name = pie.Name;

                _dbContext.pies.Update(pieToUpdate);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The pie to update can't be found.");
            }
        }

        public async Task<int> DeletePieAsync(int id)
        {
            var pieToDelete = await _dbContext.pies.FirstOrDefaultAsync(c => c.PieId == id);

            if (pieToDelete != null)
            {
                _dbContext.pies.Remove(pieToDelete);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The pie to delete can't be found.");
            }
        }

    }
}
